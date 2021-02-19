(function () {
    'use strict';

    function main($rootScope, $scope, $resource, UpdateAnnotationFieldText, GetAnnotation, DeleteAnnotation, AddReply, UpdateReplyMessage, DeleteReply) {

        $scope.deleteAnnotation = function (item) {
            $rootScope.$broadcast('request-annotation-deletion', item.Guid);
        };

        $rootScope.$on('request-annotation-deletion', function (event, guid) {
            if (typeof (guid) !== 'string') {
                return;
            }

            DeleteAnnotation.remove(
                {
                    jid: $rootScope.jid,
                    guid: guid
                },
                {}
            ).$promise.then(
                function (response) {
                    $rootScope.$broadcast('annotation-deleted', guid);
                },
                gdxResourceErrorHandler
            );
        });

        $scope.saveAnnotationFieldText = function (item) {
            UpdateAnnotationFieldText
                .updateFieldText(
                    {
                        jid: $rootScope.jid,
                        guid: item.Guid
                    },
                    {
                        FieldText: item.FieldText
                    }
                )
                .$promise
                .then(function (response) {
                    item.unsaved = false;
                });
        };

        $scope.saveAnnotationComment = function (item) {
            new UpdateReplyMessage(item.Replies[0]).$save(
                {
                    jid: $rootScope.jid,
                },
                function (response) {
                    item.unsaved = false;
                },
                gdxResourceErrorHandler
            );
        };

        $scope.addReply = function (item) {
            new AddReply().$save(
                {
                    jid: $rootScope.jid,
                    guid: item.Guid
                },
                function (response) {
                    $scope.fetchAnnotation();
                    $rootScope.$broadcast('comment-reply-added');
                },
                gdxResourceErrorHandler
            )
        };

        $scope.deleteReply = function (guid) {
            DeleteReply.remove(
                {
                    jid: $rootScope.jid, guid: guid
                },
                {}
            ).$promise.then(
                function (response) {
                    $scope.fetchAnnotation();
                    $rootScope.$broadcast('comment-reply-added');
                },
                gdxResourceErrorHandler
            );
        };

        $scope.saveReplyMessage = function (reply) {
            new UpdateReplyMessage(reply).$save(
                {
                    jid: $rootScope.jid,
                },
                function (response) {
                    reply.unsaved = false;
                },
                gdxResourceErrorHandler
            );
        };

        $scope.fetchAnnotation = function () {
            if (typeof($rootScope.selectedAnnotationGuid) === 'string') {
                $scope.selectedAnnotation = GetAnnotation.get({
                    jid: $rootScope.jid,
                    guid: $rootScope.selectedAnnotationGuid
                });
            } else {
                $scope.selectedAnnotation = null;
            }
        };

    }

    angular.module('GroupDocsAnnotationApp').controller('ThreadController', main);

})();

