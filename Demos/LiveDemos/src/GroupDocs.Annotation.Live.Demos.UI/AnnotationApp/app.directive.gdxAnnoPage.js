(function () {
    'use strict';

    function main($rootScope, $mdPanel, cfpLoadingBar, UpdateAnnotationPosition, AddAnnotation) {
        return {
            restrict: 'E',
            link: {
                pre: function (scope, element, attrs) {
                },
                post: function (scope, element, attrs) {
                    $rootScope.$watch("zoomFactor", function () {
                        setupCanvas($rootScope, scope, element, attrs);
                        setupPageImage($rootScope, scope, element, attrs);
                        setupDrawingTools($rootScope, $mdPanel, UpdateAnnotationPosition, AddAnnotation, scope, element, attrs);
                        setupAnnotationDeletion($rootScope, scope, element, attrs);
                    });
                }
            }
        }
    }

    function setupCanvas($rootScope, scope, element, attrs) {
        element[0].innerHTML = "";
        var canvas = document.createElement("canvas");
        canvas.setAttribute('width', $rootScope.zoomFactor * parseFloat(attrs.width));
        canvas.setAttribute('height', $rootScope.zoomFactor * parseFloat(attrs.height));
        canvas.setAttribute("id", "page-canvas-" + attrs.number);
        element.append(canvas);

        var ps = new paper.PaperScope();
        ps.setup(canvas);
        scope.paperScopeId = ps._id;
    }

    function setupPageImage($rootScope, scope, element, attrs) {
        var ps = paper.PaperScope.get(scope.paperScopeId);
        ps.settings.handleSize = 10;

        var pageImageUrl = GROUPDOCS_ANNOTATION_API_BASE + "/GetPageImage"
            + "?jid=" + $rootScope.jid
            + "&file=" + attrs.file
            + "&page=" + attrs.number
            + "&width=" + attrs.width
            + "&height=" + attrs.height;

        var loadingIndicator = new ps.Raster({
            source: '/AnnotationApp/loading_indicator.gif',
            position: ps.view.center
        });

        var pageImage = new ps.Raster({
            source: pageImageUrl,
            position: ps.view.center
        });

        pageImage.on("load", function () {
            pageImage.scale($rootScope.zoomFactor * parseFloat(attrs.width) / parseFloat(pageImage.width));
            setupAnnotations($rootScope, scope, element, attrs);
            loadingIndicator.remove();
        });
    }

    function setupDrawingTools($rootScope, $mdPanel, UpdateAnnotationPosition, AddAnnotation, scope, element, attrs) {
        var ps = paper.PaperScope.get(scope.paperScopeId);

        var currentObject = null;
        var textRowMouseDown;
        ps.tool = new ps.Tool();
        ps.tool.minDistance = 3;

        ps.tool.onMouseDown = function (event) {
            var hitResult = ps.project.activeLayer.hitTest(event.point, {
                segments: true,
                stroke: true,
                fill: true,
                tolerance: 11
            });

            ps.project.deselectAll();
            if (scope.toolboxPanelRef) {
                scope.toolboxPanelRef.close();
                scope.toolboxPanelRef.destroy();
            }
            $rootScope.selectedAnnotationGuid = null;
            $rootScope.$apply();

            switch ($rootScope.selectedDrawingTool) {
                case 'select':
                    if (hitResult && hitResult.item.name) {
                        currentObject = hitResult.item;
                        currentObject.selected = true;
                        $rootScope.selectedAnnotationGuid = currentObject.name;
                        if (!$rootScope.$$phase) {
                            $rootScope.$apply();
                        }
                    }
                    else if (hitResult && hitResult.item._parent._name) {
                        currentObject = hitResult.item._parent;
                        currentObject.selected = true;
                        $rootScope.selectedAnnotationGuid = currentObject._name;
                        if (!$rootScope.$$phase) {
                            $rootScope.$apply();
                        }
                    }
                    break;
                case 'rectangle':
                    var shape = new ps.Rectangle(event.point.x, event.point.y, 1, 1);
                    currentObject = new ps.Path.Rectangle(shape);
                    currentObject.strokeColor = 'black';
                    currentObject.strokeWidth = 2;
                    currentObject.fillColor = new ps.Color(1, 1, 1, 0.001);
                    break;
                case 'pencil':
                    currentObject = new ps.Path();
                    currentObject.add(event.point);
                    currentObject.strokeColor = 'black';
                    currentObject.strokeWidth = 2;
                    break;
                case 'point':
                    var pt = new ps.Shape.Circle(event.point, 3);
                    currentObject = pt.toPath(true);
                    currentObject.strokeColor = 'black';
                    currentObject.fillColor = 'black';
                    currentObject.strokeWidth = 2;
                    break;
                case 'text-highlight':
                    textRowMouseDown = findRowUnderPoint($rootScope.docInfo, attrs.number, event.point, $rootScope.zoomFactor);
                    currentObject = new ps.Path.Rectangle(new ps.Rectangle(
                        event.point.x,
                        textRowMouseDown.LineTop * $rootScope.zoomFactor,
                        1,
                        textRowMouseDown.LineHeight * $rootScope.zoomFactor)
                    );
                    currentObject.fillColor = 'yellow';
                    currentObject.opacity = 0.3;
                    break;
                case 'underline':
                case 'strikeout':
                    textRowMouseDown = findRowUnderPoint($rootScope.docInfo, attrs.number, event.point, $rootScope.zoomFactor);
                    currentObject = new ps.Path.Rectangle(new ps.Rectangle(
                        event.point.x,
                        textRowMouseDown.LineTop * $rootScope.zoomFactor,
                        1,
                        textRowMouseDown.LineHeight * $rootScope.zoomFactor)
                    );
                    currentObject.fillColor = 'black';
                    currentObject.opacity = 0.3;
                    break;
            }
        };

        ps.tool.onMouseDrag = function (event) {
            switch ($rootScope.selectedDrawingTool) {
                case 'select':
                    var currentAnnotation = findAnnotationByGuid(scope.annotationsList, $rootScope.selectedAnnotationGuid);
                    if (currentObject !== null && currentAnnotation !== null) {
                        if ([0, 3, 11].indexOf(currentAnnotation.Annotation.Type) < 0) {
                            currentObject.position.x += event.delta.x;
                            currentObject.position.y += event.delta.y;
                        }
                    }
                    break;
                case 'rectangle':
                    currentObject.bounds.width += event.delta.x;
                    currentObject.bounds.height += event.delta.y;
                    break;
                case 'pencil':
                    currentObject.add(event.point);
                    break;
                case 'point':
                    currentObject.position.x += event.delta.x;
                    currentObject.position.y += event.delta.y;
                    break;
                case 'text-highlight':
                case 'underline':
                case 'strikeout':
                    if (currentObject !== null) {
                        if (currentObject.bounds.x + currentObject.bounds.width + event.delta.x <= (textRowMouseDown.LineLeft + textRowMouseDown.LineWidth) * $rootScope.zoomFactor) {
                            currentObject.bounds.width += event.delta.x;
                        }
                    }
                    break;
                case 'arrow':
                    if (currentObject) {
                        currentObject.remove();
                    }
                    var start = new ps.Point(event.downPoint);
                    var end = new ps.Point(event.point);

                    var tailLine = new ps.Path.Line(start, end);
                    var tailVector = end.subtract(start);
                    var headLine = tailVector.normalize(15);

                    currentObject = new ps.Group([
                        new ps.Path([start, end]),
                        new ps.Path([
                            end.add(headLine.rotate(150)),
                            end,
                            end.add(headLine.rotate(-150))
                        ])
                    ]);
                    currentObject.strokeColor = 'black';
                    currentObject.strokeWidth = 2;
                    break;
                case 'distance':
                    if (currentObject) {
                        currentObject.remove();
                    }
                    var start = new ps.Point(event.downPoint);
                    var end = new ps.Point(event.point);
                    var textX = (start.x + end.x) / 2;
                    var textY = (start.y + end.y) / 2;
                    var textPoint = new ps.Point(textX, textY);
                    var tailLine = new ps.Path.Line(start, end);
                    var textPosition = end.add(start);
                    var tailVector = end.subtract(start);
                    var headLine = tailVector.normalize(15);
                    var tailArrow = tailVector.normalize(-15);
                    currentObject = new ps.Group([
                        new ps.Path([start, end]),
                        new ps.Path([
                            end.add(headLine.rotate(150)),
                            end,
                            end.add(headLine.rotate(-150))
                        ]),
                        new ps.Path([
                            start.add(tailArrow.rotate(-150)),
                            start,
                            start.add(tailArrow.rotate(150))
                        ]),
                        new ps.PointText(textPoint)
                    ]);

                    currentObject.strokeColor = 'black';
                    currentObject.strokeWidth = 2;
                    currentObject._children[3].content = Math.floor(currentObject._children[0].length) + " px";
                    currentObject._children[3].strokeWidth = 0.5;
                    break;
            }
        };

        ps.tool.onMouseUp = function (event) {
            if ($rootScope.selectedAnnotationGuid !== null) {
                showToolbox($rootScope, $mdPanel, currentObject, scope, element, attrs);
            }

            var ant = {};

            switch ($rootScope.selectedDrawingTool) {
                case 'select':
                    var currentAnnotation = findAnnotationByGuid(scope.annotationsList, $rootScope.selectedAnnotationGuid);
                    if (currentObject !== null && currentAnnotation !== null) {
                        if ([0, 3, 11].indexOf(currentAnnotation.Annotation.Type) < 0 && (event.delta.x != 0 || event.delta.y != 0)) {
                            UpdateAnnotationPosition.updatePosition(
                                {
                                    jid: $rootScope.jid,
                                    guid: currentObject.name
                                },
                                {
                                    X: currentObject.bounds.x / $rootScope.zoomFactor,
                                    Y: currentObject.bounds.y / $rootScope.zoomFactor
                                },
                                function () { },
                                gdxResourceErrorHandler
                            );
                        }
                    }
                    break;
                case 'rectangle':
                    ant = {
                        Box: {
                            X: currentObject.bounds.x / $rootScope.zoomFactor,
                            Y: currentObject.bounds.y / $rootScope.zoomFactor,
                            Width: currentObject.bounds.width / $rootScope.zoomFactor,
                            Height: currentObject.bounds.height / $rootScope.zoomFactor
                        },
                        PenColor: 0x010101,
                        PenStyle: 0,
                        PenWidth: 1,
                        Type: 1
                    };
                    break;
                case 'pencil':
                    ant = angular.merge({}, ant, {
                        Box: {
                            X: currentObject.bounds.x / $rootScope.zoomFactor,
                            Y: currentObject.bounds.y / $rootScope.zoomFactor,
                            Width: currentObject.bounds.width / $rootScope.zoomFactor,
                            Height: currentObject.bounds.height / $rootScope.zoomFactor
                        },
                        PenColor: 0x010101,
                        PenStyle: 0,
                        PenWidth: 1,
                        SvgPath: extractSvgPathData(currentObject, $rootScope.zoomFactor),
                        Type: 4
                    });
                    break;
                case 'point':
                    ant = angular.merge({}, ant, {
                        PenColor: 0x010101,
                        PenStyle: 0,
                        PenWidth: 1,
                        Type: 2,
                        Box: {
                            X: event.point.x / $rootScope.zoomFactor,
                            Y: event.point.y / $rootScope.zoomFactor,
                            Width: 0,
                            Height: 0
                        }
                    });
                    break;
                case 'arrow':
                    ant = angular.merge({}, ant, {
                        Box: {
                            X: currentObject.bounds.x / $rootScope.zoomFactor,
                            Y: currentObject.bounds.y / $rootScope.zoomFactor,
                            Width: currentObject.bounds.width / $rootScope.zoomFactor,
                            Height: currentObject.bounds.height / $rootScope.zoomFactor
                        },
                        PenColor: 0x010101,
                        PenStyle: 0,
                        PenWidth: 1,
                        SvgPath: extractSvgPathData(currentObject, $rootScope.zoomFactor),
                        Type: 8
                    });
                    break;
                case 'distance':
                    ant = {
                        Box: {
                            X: currentObject.bounds.x / $rootScope.zoomFactor,
                            Y: currentObject.bounds.y / $rootScope.zoomFactor,
                            Width: currentObject.bounds.width / $rootScope.zoomFactor,
                            Height: currentObject.bounds.height / $rootScope.zoomFactor
                        },
                        PenColor: 0x010101,
                        PenStyle: 0,
                        PenWidth: 1,
                        Type: 12,
                        SvgPath: extractSvgPathData(currentObject, $rootScope.zoomFactor),
                        FieldText: currentObject.children[3].content
                    };
                    break;
                case 'text-highlight':
                case 'underline':
                case 'strikeout':
                    if (currentObject !== null) {
                        ant = angular.merge({}, ant, {
                            SvgPath: JSON.stringify([
                                {
                                    X: currentObject.bounds.x / $rootScope.zoomFactor,
                                    Y: attrs.height - currentObject.bounds.y / $rootScope.zoomFactor
                                },
                                {
                                    X: (currentObject.bounds.x + currentObject.bounds.width) / $rootScope.zoomFactor,
                                    Y: attrs.height - currentObject.bounds.y / $rootScope.zoomFactor
                                },
                                {
                                    X: currentObject.bounds.x / $rootScope.zoomFactor,
                                    Y: attrs.height - currentObject.bounds.y / $rootScope.zoomFactor - currentObject.bounds.height / $rootScope.zoomFactor
                                },
                                {
                                    X: (currentObject.bounds.x + currentObject.bounds.width) / $rootScope.zoomFactor,
                                    Y: attrs.height - currentObject.bounds.y / $rootScope.zoomFactor - currentObject.bounds.height / $rootScope.zoomFactor
                                }
                            ]),
                            Box: {
                                X: currentObject.bounds.x / $rootScope.zoomFactor,
                                Y: attrs.height - currentObject.bounds.y / $rootScope.zoomFactor,
                                Width: currentObject.bounds.width / $rootScope.zoomFactor,
                                Height: currentObject.bounds.height / $rootScope.zoomFactor
                            },
                            AnnotationPosition: {
                                X: currentObject.bounds.x / $rootScope.zoomFactor,
                                Y: attrs.height - currentObject.bounds.y / $rootScope.zoomFactor
                            }
                        });
                        console.log("text mouse up", ant);
                        currentObject.remove();
                        switch ($rootScope.selectedDrawingTool) {
                            case 'text-highlight':
                                currentObject = new ps.Path.Rectangle(new ps.Rectangle(
                                    currentObject.bounds.x,
                                    currentObject.bounds.y,
                                    currentObject.bounds.width,
                                    currentObject.bounds.height
                                ));
                                currentObject.fillColor = 'yellow';
                                currentObject.opacity = 0.3;
                                ant = angular.merge({}, ant, {
                                    BackgroundColor: 0xffff01,
                                    Type: 0
                                });
                                break;
                            case 'underline':
                                currentObject = new ps.Path.Line({
                                    from: [
                                        currentObject.bounds.x,
                                        currentObject.bounds.y + currentObject.bounds.height
                                    ],
                                    to: [
                                        currentObject.bounds.x + currentObject.bounds.width,
                                        currentObject.bounds.y + currentObject.bounds.height
                                    ],
                                    strokeColor: 'black'
                                });
                                ant = angular.merge({}, ant, {
                                    PenColor: 0x010101,
                                    PenStyle: 0,
                                    PenWidth: 1,
                                    Type: 11
                                });
                                break;
                            case 'strikeout':
                                currentObject = new ps.Path.Line({
                                    from: [
                                        currentObject.bounds.x,
                                        currentObject.bounds.y + currentObject.bounds.height / 2.0
                                    ],
                                    to: [
                                        currentObject.bounds.x + currentObject.bounds.width,
                                        currentObject.bounds.y + currentObject.bounds.height / 2.0
                                    ],
                                    strokeColor: 'black'
                                });
                                ant = angular.merge({}, ant, {
                                    PenColor: 0x010101,
                                    PenStyle: 0,
                                    PenWidth: 1,
                                    Type: 3
                                });
                                break;
                        }
                    }
                    break;
            }

            if (typeof(ant.Type) !== 'undefined') {
                ant = angular.merge({}, ant, {
                    PageNumber: attrs.number,
                });
                var a = new AddAnnotation(ant);
                a.$save(
                    {
                        jid: $rootScope.jid,
                        file: $rootScope.selectedFile
                    },
                    function (response) {
                        $rootScope.$broadcast('annotation-added', response.Guid);
                        currentObject.name = response.Guid;
                        currentObject.selected = true;
                        currentObject = null;
                        $rootScope.selectedAnnotationGuid = response.Guid;
                        if (!$rootScope.$$phase) {
                            $rootScope.$apply();
                        }
                    },
                    gdxResourceErrorHandler
                );
            } else {
                currentObject = null;
            }
        };

        ps.tool.onMouseMove = function (event) {
            //console.log("Mouse position:", new Date(), event.point);
            switch ($rootScope.selectedDrawingTool) {
                case 'text-highlight':
                case 'underline':
                case 'strikeout':
                    var r = findRowUnderPoint($rootScope.docInfo, attrs.number, event.point, $rootScope.zoomFactor);
                    if (typeof(r) !== 'undefined') {
                        document.body.style.cursor = 'text';
                    } else {
                        document.body.style.cursor = 'auto';
                    }
            }
        };

        ps.tool.onKeyDown = function (event) {
            if (event.key === 'delete') {
                angular.forEach(ps.project.selectedItems, function (item) {
                    if (item.name) {
                        $rootScope.$broadcast('request-annotation-deletion', item.name);
                    }
                    else if (item._parent._name) {
                        $rootScope.$broadcast('request-annotation-deletion', item._parent._name);
                    }
                });
            }
        }
    }

    function setupAnnotations($rootScope, scope, element, attrs) {
        var ps = paper.PaperScope.get(scope.paperScopeId);

        angular.forEach(scope.annotationsList, function (item) {

            if (attrs.number != item.Annotation.PageNumber) {
                return;
            }

            switch (item.Annotation.Type) {
                case 1:

                    var shape = new ps.Rectangle(
                        item.Annotation.Box.X * $rootScope.zoomFactor,
                        item.Annotation.Box.Y * $rootScope.zoomFactor,
                        item.Annotation.Box.Width * $rootScope.zoomFactor,
                        item.Annotation.Box.Height * $rootScope.zoomFactor
                    );
                    var path = new ps.Path.Rectangle(shape);
                    path.strokeColor = 'black';
                    path.strokeWidth = 2;
                    path.fillColor = new ps.Color(1, 1, 1, 0.001);
                    path.name = item.Annotation.Guid;

                    break;

                case 5:
                    var line = new ps.Path();
                    line.pathData = item.Annotation.SvgPath;
                    line.strokeColor = 'black';
                    line.strokeWidth = 2;
                    line.name = item.Annotation.Guid;

                    break;
                case 4:
                    var line = new ps.Path();
                    line.pathData = item.Annotation.SvgPath;
                    line.strokeColor = 'black';
                    line.strokeWidth = 2;
                    line.name = item.Annotation.Guid;
                    line.bounds.x = item.Annotation.Box.X * $rootScope.zoomFactor;
                    line.bounds.y = item.Annotation.Box.Y * $rootScope.zoomFactor;
                    line.bounds.width = item.Annotation.Box.Width * $rootScope.zoomFactor;
                    line.bounds.height = item.Annotation.Box.Height * $rootScope.zoomFactor;

                    break;
                case 2:
                    var pt = new ps.Shape.Circle(new ps.Point(item.Annotation.Box.X * $rootScope.zoomFactor + 3, item.Annotation.Box.Y * $rootScope.zoomFactor + 3), 3);
                    var ptp = pt.toPath(true);
                    ptp.strokeColor = 'black';
                    ptp.fillColor = 'black';
                    ptp.strokeWidth = 2;
                    ptp.name = item.Annotation.Guid;
                    break;
                case 8:
                    var arrow = new ps.Group([
                        new ps.Path(item.Annotation.SvgPath.split(" ")[0]),
                        new ps.Path(item.Annotation.SvgPath.split(" ")[1])
                    ]);
                    arrow.strokeColor = 'black';
                    arrow.strokeWidth = 2;
                    arrow.name = item.Annotation.Guid;
                    arrow.bounds.x = item.Annotation.Box.X * $rootScope.zoomFactor;
                    arrow.bounds.y = item.Annotation.Box.Y * $rootScope.zoomFactor;
                    arrow.bounds.width = item.Annotation.Box.Width * $rootScope.zoomFactor;
                    arrow.bounds.height = item.Annotation.Box.Height * $rootScope.zoomFactor;

                    break;
                case 11:
                    var line11 = new ps.Path.Line({
                        from: [
                            JSON.parse(item.Annotation.SvgPath)[2].X * $rootScope.zoomFactor,
                            (attrs.height - JSON.parse(item.Annotation.SvgPath)[2].Y) * $rootScope.zoomFactor
                        ],
                        to: [
                            JSON.parse(item.Annotation.SvgPath)[3].X * $rootScope.zoomFactor,
                            (attrs.height - JSON.parse(item.Annotation.SvgPath)[3].Y) * $rootScope.zoomFactor
                        ],
                        strokeColor: 'black',
                        strokeWidth: 1,
                        name: item.Annotation.Guid
                    });
                    break;
                case 3:
                    var line3 = new ps.Path.Line({
                        from: [
                            JSON.parse(item.Annotation.SvgPath)[2].X * $rootScope.zoomFactor,
                            (attrs.height - (JSON.parse(item.Annotation.SvgPath)[0].Y + JSON.parse(item.Annotation.SvgPath)[2].Y) / 2.0) * $rootScope.zoomFactor
                        ],
                        to: [
                            JSON.parse(item.Annotation.SvgPath)[3].X * $rootScope.zoomFactor,
                            (attrs.height - (JSON.parse(item.Annotation.SvgPath)[1].Y + JSON.parse(item.Annotation.SvgPath)[3].Y) / 2.0) * $rootScope.zoomFactor
                        ],
                        strokeColor: 'black',
                        strokeWidth: 1,
                        name: item.Annotation.Guid
                    });
                    break;
                case 12:
                    var distance = new ps.Group([
                        new ps.Path(item.Annotation.SvgPath.split(" ")[0]),
                        new ps.Path(item.Annotation.SvgPath.split(" ")[1]),
                        new ps.Path(item.Annotation.SvgPath.split(" ")[2]),
                        new ps.PointText(new ps.Point(item.Annotation.Box.X * $rootScope.zoomFactor, item.Annotation.Box.Y * $rootScope.zoomFactor))
                    ]);
                    distance.bounds.x = item.Annotation.Box.X * $rootScope.zoomFactor;
                    distance.bounds.y = item.Annotation.Box.Y * $rootScope.zoomFactor;
                    distance.bounds.width = item.Annotation.Box.Width * $rootScope.zoomFactor;
                    distance.bounds.height = item.Annotation.Box.Height * $rootScope.zoomFactor;
                    distance.strokeColor = 'black';
                    distance.strokeWidth = 2;
                    distance.children[3].content = Math.floor(distance.children[0].length) + " px";
                    distance.children[3].strokeWidth = 0.5;
                    distance.name = item.Annotation.Guid;
                    break;
                case 0:
                    var shape = new ps.Rectangle(
                        item.Annotation.Box.X * $rootScope.zoomFactor,
                        (attrs.height - item.Annotation.Box.Y) * $rootScope.zoomFactor,
                        item.Annotation.Box.Width * $rootScope.zoomFactor,
                        item.Annotation.Box.Height * $rootScope.zoomFactor
                    );
                    var path = new ps.Path.Rectangle(shape);
                    path.fillColor = 'yellow';
                    path.opacity = 0.3;
                    path.name = item.Annotation.Guid;
                    break;
            }
        })
    }

    function getStartRow(docInfo, start, attrs) {
        var startRow = [];
        for (var i = 0; i < 30; i++) {
            startRow = docInfo.Pages[attrs.number].Rows.filter(function (x) {
                return Math.floor(x.LineTop) === (Math.floor(start.y) - i )
            });
            if (startRow.length > 0) {
                return startRow;
            }
        }
        if (startRow.length === 0)
            for (var i = 0; i < 30; i++) {
                startRow = docInfo.pages[attrs.number].rows.filter(function (x) {
                    return Math.floor(x.lineTop) === (Math.floor(start.y) + i )
                });
                if (startRow.length > 0) {
                    return startRow;
                }
            }

    }

    function setupAnnotationDeletion($rootScope, scope, element, attrs) {
        var ps = paper.PaperScope.get(scope.paperScopeId);

        $rootScope.$on('annotation-deleted', function (event, guid) {
            var item = ps.project.activeLayer.children[guid];
            if (item) {
                ps.project.deselectAll();
                $rootScope.selectedAnnotationGuid = null;
                if (!$rootScope.$$phase) {
                    $rootScope.$apply();
                }
                item.remove();
            }

        });
    }

    function extractSvgPathData(object, scale) {
        var c = object.clone({
            insert: false,
            deep: true
        });
        c.scale(1.0 / scale);
        c.position.x = object.position.x / scale;
        c.position.y = object.position.y / scale;

        var svg = c.exportSVG();
        var data = '';

        if (svg.nodeName === 'path') {
            data = c.exportSVG().getAttribute('d')
        } else if (svg.nodeName === 'g') {
            angular.forEach(svg.children, function (value) {
                if (value.nodeName === 'path') {
                    data += value.getAttribute('d');
                    data += ' ';
                }
            });
        }
        c.remove();

        return data;
    }

    function findRowUnderPoint(docInfo, page, point, scale) {
        var currentRow = docInfo.Pages[page].Rows.filter(function (row) {
            return row.LineLeft * scale <= point.x && point.x <= row.LineLeft * scale + row.LineWidth * scale
                && row.LineTop * scale <= point.y && point.y <= row.LineTop * scale + row.LineHeight * scale;
        });

        return currentRow[0];
    }

    function findAnnotationByGuid(annotationInfo, guid) {
        var a = annotationInfo.filter(function (item) {
            return item.Annotation.Guid === guid;
        });

        if (a.length > 0) {
            return a[0];
        }

        return null;
    }

    function showToolbox($rootScope, $mdPanel, currentObject, scope, element, attrs) {
        if (scope.toolboxPanelRef) {
            scope.toolboxPanelRef.close();
            scope.toolboxPanelRef.destroy();
        }

        var povit = angular.element(document.createElement("div"))
            .css("z-index", -99999)
            .css("top", currentObject.bounds.y * $rootScope.zoomFactor)
            .css("left", currentObject.bounds.x * $rootScope.zoomFactor)
            .css("height", currentObject.bounds.height * $rootScope.zoomFactor + 11)
            .css("width", currentObject.bounds.width * $rootScope.zoomFactor)
            .css("display", "block")
            .css("position", "absolute")
            .css("visibility", "hidden");

        var canvas = angular.element("#page-canvas-" + attrs.number);

        povit.insertAfter(canvas);

        var position = $mdPanel.newPanelPosition()
            .relativeTo(povit)
            .addPanelPosition($mdPanel.xPosition.CENTER, $mdPanel.yPosition.BELOW)

        var config = {
            //attachTo: angular.element(document.body),
            //attachTo: povit,
            //origin: povit,
            //controller: PanelDialogCtrl,
            //disableParentScroll: this.disableParentScroll,
            template: angular.element("#toolbox")[0].innerHTML,
            panelClass: 'toolbox-panel-container',
            //hasBackdrop: true,
            //panelClass: 'demo-dialog-example',
            position: position,
            //trapFocus: true,
            propagateContainerEvents: true,
            //zIndex: 150,
            //clickOutsideToClose: true,
            //escapeToClose: true,
            focusOnOpen: false,
            onCloseSuccess: function (panelRef, closeReason) {
                povit.remove();
            }
        };

        $mdPanel.open(config).then(function (panelRef) {
            scope.toolboxPanelRef = panelRef
            $rootScope.$on('annotation-deleted', function (event, args) {
                panelRef.close();
                panelRef.destroy();
            });
        });
    }

    angular.module('GroupDocsAnnotationApp').directive('gdxAnnoPage', main, ['cfpLoadingBar']);

})();

