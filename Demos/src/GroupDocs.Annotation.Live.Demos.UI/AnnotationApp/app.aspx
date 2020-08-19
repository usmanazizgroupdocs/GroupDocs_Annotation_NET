<!DOCTYPE html>
<html lang="en" ng-app="GroupDocsAnnotationApp">
<head>
    <title>GroupDocs.Annotation App</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="//ajax.googleapis.com/ajax/libs/angular_material/1.1.4/angular-material.min.css">
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/angular-loading-bar/0.9.0/loading-bar.min.css">
    <link rel='stylesheet' href="//fonts.googleapis.com/icon?family=Material+Icons|Roboto+Condensed:400,700">
    <script src="//code.jquery.com/jquery-latest.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/angular-loading-bar/0.9.0/loading-bar.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular-animate.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular-aria.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular-messages.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular-resource.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/angular_material/1.1.4/angular-material.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/paper.js/0.11.4/paper-full.min.js"></script>

    <script src="/AnnotationApp/const.js"></script>
    <script src="/AnnotationApp/app.js"></script>
    <script src="/AnnotationApp/app.factory.files.js"></script>
    <script src="/AnnotationApp/app.factory.AddAnnotation.js"></script>
    <script src="/AnnotationApp/app.factory.AddReply.js"></script>
    <script src="/AnnotationApp/app.factory.DeleteAnnotation.js"></script>
    <script src="/AnnotationApp/app.factory.DeleteReply.js"></script>
    <script src="/AnnotationApp/app.factory.GetAnnotation.js"></script>
    <script src="/AnnotationApp/app.factory.GetAnnotationReplyList.js"></script>
    <script src="/AnnotationApp/app.factory.GetAnnotationsList.js"></script>
    <script src="/AnnotationApp/app.factory.GetDocumentInfo.js"></script>
    <script src="/AnnotationApp/app.factory.UpdateAnnotationFieldText.js"></script>
    <script src="/AnnotationApp/app.factory.UpdateAnnotationPosition.js"></script>
    <script src="/AnnotationApp/app.factory.UpdateReplyMessage.js"></script>
    <script src="/AnnotationApp/app.directive.gdxAnnoPage.js"></script>
    <script src="/AnnotationApp/app.controller.pageCanvas.js"></script>
    <script src="/AnnotationApp/app.controller.thread.js"></script>
    <script src="/AnnotationApp/app.controller.tools.js"></script>
    <script src="/AnnotationApp/app.controller.toolbar.js"></script>
    <script src="/AnnotationApp/app.controller.toolbox.js"></script>
    <script src="/AnnotationApp/app.controller.errorlog.js"></script>
    <script src="/AnnotationApp/app.config.js"></script>
    <script src="/AnnotationApp/app.run.js"></script>
    <link rel='stylesheet' href="/AnnotationApp/style.css">

</head>
<body ng-cloak>

<md-toolbar ng-controller="ToolbarController" layout="row" class="md-toolbar-tools md-scroll-shrink md-whiteframe-4dp" style="background-color:black">
    <md-button class="md-icon-button" ng-click="exitApp()">
        <md-icon>arrow_back_ios</md-icon>
        <md-tooltip>Exit and Go Back</md-tooltip>
    </md-button>
    <img src="//cms.admin.containerize.com/templates/groupdocs/images/logos/groupdocs-logo.png"/>
    <h1>{{$root.selectedFile}}</h1>
    <md-button class="md-icon-button" ng-href="{{ getAnnotatedFileUrl() }}" target="_blank">
        <md-icon>file_download</md-icon>
        <md-tooltip>Download the annotated file</md-tooltip>
    </md-button>
    <span flex></span>
    <md-button class="md-icon-button" ng-click="zoomIn()" ng-if="$root.zoomFactor <= 3">
        <md-icon>zoom_in</md-icon>
        <md-tooltip>Zoom In</md-tooltip>
    </md-button>
    <md-button class="md-icon-button" ng-click="zoomOut()" ng-if="$root.zoomFactor >= 0.1">
        <md-icon>zoom_out</md-icon>
        <md-tooltip>Zoom Out</md-tooltip>
    </md-button>
    <md-button class="md-icon-button md-raised md-warn" ng-click="openErrorlog()" ng-if="$root.errors.length > 0">
        <md-icon>error</md-icon>
        <md-tooltip>Show Errors</md-tooltip>
    </md-button>
    <md-button class="md-icon-button" ng-click="exitApp()">
        <md-icon>close</md-icon>
        <md-tooltip>Close</md-tooltip>
    </md-button>
</md-toolbar>

<md-content flex layout="row" style="min-height:100%">
    <div layout="column" ng-controller="ToolsController">
        <div flex layout="column" layout-align="start center">
            <md-button class="md-icon-button" aria-label="Select" ng-click="selectSelectTool()">
                <md-icon>pan_tool</md-icon>
                <md-tooltip>Select and Move</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Point" ng-click="selectPointTool()">
                <md-icon>location_on</md-icon>
                <md-tooltip>Point</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Pencil" ng-click="selectPencilTool()">
                <md-icon>edit_mode</md-icon>
                <md-tooltip>Line</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Rectangle" ng-click="selectRectangleTool()">
                <md-icon>check_box_outline_blank</md-icon>
                <md-tooltip>Area</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Arrow" ng-click="selectArrowTool()">
                <md-icon>arrow_forward</md-icon>
                <md-tooltip>Arrow</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Distance" ng-click="selectDistanceTool()">
                <md-icon>compare_arrows</md-icon>
                <md-tooltip>Distance</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Text Highlight" ng-click="selectTextHighlightTool()">
                <md-icon>format_paint</md-icon>
                <md-tooltip>Text Highlight</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Underline" ng-click="selectUnderlineTool()">
                <md-icon>format_underlined</md-icon>
                <md-tooltip>Underline</md-tooltip>
            </md-button>
            <md-button class="md-icon-button" aria-label="Strikeout" ng-click="selectStrikeoutTool()">
                <md-icon>format_strikethrough</md-icon>
                <md-tooltip>Strikeout</md-tooltip>
            </md-button>
        </div>
    </div>
    <md-content flex id="content" ng-controller="PageCanvasController">
        <md-card ng-repeat="pageInfo in docInfo.Pages">
            <gdx-anno-page
                    file="{{ $root.selectedFile }}"
                    number="{{ pageInfo.Number - 1 }}"
                    width="{{ pageInfo.Width }}"
                    height="{{ pageInfo.Height }}"
                    oncontextmenu="return false">
            </gdx-anno-page>
        </md-card>
    </md-content>
    <md-sidenav class="md-whiteframe-4dp" md-is-locked-open="$mdMedia('gt-sm')" md-component-id="right">
        <md-tabs md-dynamic-height md-border-bottom>
            <md-tab label="Comments">
                <md-content ng-controller="ThreadController" class="thread-container">
                    <md-content ng-repeat="ant in $root.annotationsList" class="thread" ng-class="ant.Annotation.Guid === $root.selectedAnnotationGuid ?'selected':''">
                        <md-card class="comment" id="comment-{{ant.Annotation.Guid}}">
                            <md-card-header style="padding-bottom:0">
                                <md-card-avatar>
                                    <md-icon>person</md-icon>
                                </md-card-avatar>
                                <md-card-header-text>
                                    <span class="md-title" ng-if="ant.Annotation.CreatorName">
                                        {{ ant.Annotation.CreatorName }}
                                    </span>
                                    <span class="md-title" ng-if="!ant.Annotation.CreatorName">
                                        Anonymous
                                    </span>
                                    <span class="md-subhead">
                                        {{ ant.Annotation.CreatedOn|date:'HH:mm'}}
                                        on
                                        {{ ant.Annotation.CreatedOn|date:'yyyy-MM-dd'}}
                                    </span>
                                </md-card-header-text>
                            </md-card-header>
                            <md-card-content style="padding-bottom:0">
                                <md-input-container style="margin:0;width:100%">
                                    <label ng-show="!ant.Annotation.Replies[0].Message">Comments...</label>
                                    <textarea ng-model="ant.Annotation.Replies[0].Message"
                                                id="comment-message-{{ant.Annotation.Guid}}"
                                                ng-disabled="ant.Annotation.Guid !== $root.selectedAnnotationGuid"
                                                ng-change="ant.Annotation.unsaved=true"
                                                aria-label="Comments">
                                    </textarea>
                                </md-input-container>
                            </md-card-content>
                            <md-card-actions layout="row" layout-align="end center" style="margin-top:0">
                                <md-button class="md-icon-button" aria-label="Reply"
                                            ng-if="ant.Annotation.Guid === $root.selectedAnnotationGuid"
                                            ng-click="addReply(ant.Annotation)">
                                    <md-icon>reply</md-icon>
                                </md-button>
                                <md-button class="md-icon-button" aria-label="Save" ng-show="ant.Annotation.unsaved"
                                            ng-click="saveAnnotationComment(ant.Annotation)">
                                    <md-icon>save</md-icon>
                                </md-button>
                                <md-button class="md-icon-button" aria-label="Delete"
                                            ng-click="deleteAnnotation(ant.Annotation)">
                                    <md-icon>delete</md-icon>
                                </md-button>
                            </md-card-actions>
                        </md-card>
                        <md-card ng-repeat="reply in ant.Annotation.Replies" ng-hide="$first" class="reply" ng-if="ant.Annotation.Guid === $root.selectedAnnotationGuid">
                            <md-card-header>
                                <md-card-avatar>
                                    <md-icon>person</md-icon>
                                </md-card-avatar>
                                <md-card-header-text>
                                    <span class="md-title" ng-if="reply.UserName">
                                        {{ reply.UserName }}
                                    </span>
                                    <span class="md-title" ng-if="!reply.UserName">
                                        Anonymous
                                    </span>
                                    <span class="md-subhead">
                                        {{ reply.RepliedOn|date:'HH:mm'}}
                                        on
                                        {{ reply.RepliedOn|date:'yyyy-MM-dd'}}
                                    </span>
                                </md-card-header-text>
                            </md-card-header>
                            <md-card-content>
                                <md-input-container>
                                    <label ng-show="!reply.Message">Reply...</label>
                                    <textarea ng-model="reply.Message" ng-change="reply.unsaved=true"
                                                aria-label="Reply">
                                    </textarea>
                                </md-input-container>
                            </md-card-content>
                            <md-card-actions layout="row" layout-align="end center">
                                <md-button class="md-icon-button" aria-label="Reply"
                                            ng-click="addReply(ant.Annotation)">
                                    <md-icon>reply</md-icon>
                                </md-button>
                                <md-button class="md-icon-button" aria-label="Save" ng-show="reply.unsaved"
                                            ng-click="saveReplyMessage(reply)">
                                    <md-icon>save</md-icon>
                                </md-button>
                                <md-button class="md-icon-button" aria-label="Delete"
                                            ng-click="deleteReply(reply.Guid)">
                                    <md-icon>delete</md-icon>
                                </md-button>
                            </md-card-actions>
                        </md-card>
                    </md-content>
                </md-content>
            </md-tab>
            <md-tab label="Help" controller="ToolsController">
                <md-content class="md-padding">
                    <md-card ng-show="$root.selectedDrawingTool === 'select'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Select and Move</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                Use your mouse to select and move annotations.
                            </p>
                            <p>
                                Hover mouse on annotation objects and click to select.
                            </p>
                            <p>
                                To move an object, click and drag it. Drop it on your desired location. Some objects cannot be moved, once created.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedDrawingTool === 'select'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Draw new annotations</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                Choose annotation from right toolbar to start drawing.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedDrawingTool === 'point'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Point annotation</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                Click anywhere on the document to create <b>Point</b> annotaions.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedDrawingTool === 'pencil'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Line Annotation</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                <b>Line</b> annotation allows you to draw free-hand lines on the document.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedDrawingTool === 'rectangle'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Area Annotation</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                Annotate a rectangular or square area of document.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedDrawingTool === 'arrow'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Arrow Annotation</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                Draw pointed arrows on document.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedDrawingTool === 'distance'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Distance Annotation</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                Measure and highlight distance between document elements.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedDrawingTool === 'text-highlight' || $root.selectedDrawingTool === 'underline' || $root.selectedDrawingTool === 'strikeout'">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Highlight, Underline and Strike-though text</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                You can annotate text elements in various styles.
                            </p>
                        </md-card-content>
                    </md-card>
                    <md-card ng-show="$root.selectedAnnotationGuid !== null">
                        <md-card-title>
                            <md-card-title-text>
                                <span class="md-headline">Delete an annotation</span>
                            </md-card-title-text>
                        </md-card-title>
                        <md-card-content>
                            <p>
                                Press the delete button on your keyboard to delete an annotation.
                            </p>
                            <p>
                                You can also delete annotations from Comments sidebar.
                            </p>
                        </md-card-content>
                    </md-card>
                </md-content>
            </md-tab>
        </md-tabs>
    </md-sidenav>
</md-content>

<script type="text/html" id="toolbox">
    <md-toolbar ng-controller="ToolboxController" layout="row" class="md-toolbar-tools md-primary" style="box-shadow:0 0 11px 5px silver;background-color:black">
        <md-button class="md-icon-button" ng-click="editCommentMessage()">
            <md-icon>edit</md-icon>
        </md-button>
        <md-button class="md-icon-button" ng-click="deleteSelectedAnnotation()">
            <md-icon>delete</md-icon>
        </md-button>
    </md-toolbar>
</script>

<div style="visibility: hidden" ng-controller="ErrorlogController">
  <div class="md-dialog-container" id="errorlog">
    <md-dialog>
        <md-toolbar class="md-toolbar-tools" style="background-color: #df0000 !important;">
            <h2>Error Log</h2>
            <span flex></span>
            <md-button class="md-icon-button" ng-click="close()">
                <md-icon>close</md-icon>
            </md-button>
        </md-toolbar>
        <md-dialog-content>
            <div class="md-dialog-content">
                <md-list flex>
                    <md-list-item class="md-2-line" ng-repeat="error in $root.errors">
                      <div class="md-list-item-text">
                        <h3 ng-if="error.title">{{ error.title }}</h3>
                        <p>{{ error.description }}</p>
                      </div>
                    </md-list-item>
                </md-list>
                {{$root.error}}
            </div>
        </md-dialog-content>
    </md-dialog>
  </div>
</div>

</body>
</html>
