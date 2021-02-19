(function () {
    'use strict';

    function main($scope, $rootScope, $mdToast, $mdDialog) {

        $scope.deleteSelectedAnnotation = function () {
            $rootScope.$broadcast('request-annotation-deletion', $rootScope.selectedAnnotationGuid);
        };

        $scope.editCommentMessage = function (item) {
            angular.element("#comment-message-" + $rootScope.selectedAnnotationGuid).focus().select();
        };

    }

    angular.module('GroupDocsAnnotationApp').controller('ToolboxController', main);

})();

