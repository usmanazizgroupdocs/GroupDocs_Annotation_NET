(function () {
    'use strict';

    function main($rootScope, $scope, GetAnnotationsList, GetDocumentInfo) {

        $scope.$on('request-annotation-list', function (event, args) {
            $rootScope.annotationsList = GetAnnotationsList.query(
                {
                    jid: $rootScope.jid,
                    file: $rootScope.selectedFile
                },
                function(){},
                gdxResourceErrorHandler
            );
        });

        $scope.$on('request-document-info', function (event, args) {
            $rootScope.docInfo = GetDocumentInfo.get(
                {
                    jid: $rootScope.jid,
                    file: $rootScope.selectedFile
                },
                function(){},
                gdxResourceErrorHandler
            );
        });

        $scope.$on('annotation-deleted', function (event, args) {
            $rootScope.$broadcast('request-annotation-list');
        });

        $scope.$on('comment-reply-deleted', function (event, args) {
            $rootScope.$broadcast('request-annotation-list');
        });

        $scope.$on('comment-reply-added', function (event, args) {
            $rootScope.$broadcast('request-annotation-list');
        });

        $scope.$on('annotation-added', function (event, args) {
            $rootScope.$broadcast('request-annotation-list');
        });

        $rootScope.$watch('selectedFile', function () {
            if (typeof ($rootScope.selectedFile) !== 'string' || !$rootScope.selectedFile.length) {
                return;
            }
            $rootScope.$broadcast('request-document-info');
            $rootScope.$broadcast('request-annotation-list');
        });

        $rootScope.$watch('selectedFile', function () {
            $rootScope.selectedDrawingTool = 'select';
            $rootScope.selectedAnnotationGuid = null;
        });

    }

    angular.module('GroupDocsAnnotationApp').controller('PageCanvasController', main);
})();

