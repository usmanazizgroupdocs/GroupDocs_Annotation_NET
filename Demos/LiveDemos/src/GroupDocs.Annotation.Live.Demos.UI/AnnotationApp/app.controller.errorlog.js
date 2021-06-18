(function () {
    'use strict';

    function main($scope, $rootScope, $mdToast, $mdDialog) {

        $scope.$on('open-errorlog', function ($event, args) {
            $scope.open();
        });

        $rootScope.$on('error', function ($event, args) {
            $rootScope.$broadcast('open-errorlog');
        });

        $scope.open = function () {
            $mdDialog.show({
                contentElement: '#errorlog',
                parent: angular.element(document.body),
                clickOutsideToClose: true,
            });
        }

        $scope.close = function () {
            $mdDialog.hide();
        }

        // look for startup errors
        if ($rootScope.errors.length) {
            $rootScope.$broadcast('open-errorlog');
        }
    }

    angular.module('GroupDocsAnnotationApp').controller('ErrorlogController', main);

})();

