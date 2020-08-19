(function () {
    'use strict';

    function main($scope, $rootScope, $mdToast, $mdDialog) {

        $scope.zoomIn = function () {
            $rootScope.zoomFactor += 0.1;
        };

        $scope.zoomOut = function () {
            $rootScope.zoomFactor -= 0.1;
        };

        $scope.$on('annotation-added', function (event, args) {
            $mdToast.show(
                $mdToast.simple().textContent('Saved')
            );
        });

        $scope.$on('annotation-deleted', function (event, args) {
            $mdToast.show(
                $mdToast.simple().textContent('Saved')
            );
        });

        $scope.getAnnotatedFileUrl = function () {
            return GROUPDOCS_ANNOTATION_API_BASE + '/DownloadAnnotatedFile'
                + '?jid=' + $rootScope.jid
                + '&file=' + $rootScope.selectedFile
        };

        $scope.openErrorlog = function () {
            $rootScope.$broadcast('open-errorlog');
        };

        $scope.exitApp = function () {
            $mdDialog.show($mdDialog.confirm()
                .title('Close?')
                .textContent('Are you sure you want to exit the App?')
                .ariaLabel('Exit')
                .ok('Yes')
                .cancel('No')
            ).then(
                function () {
                    window.location.href = "/annotation/total";
                },
                function(){}
           );
        }

        angular.element(function () {
            setTimeout(function () {
                loadStartupFile($rootScope);
            }, 313);
        });

    }

    function loadStartupFile($rootScope) {
        var selectedFile = getStartupFile();
        var jid = getJid();

        if (!selectedFile || selectedFile.length < 3) {
            $rootScope.$broadcast('error', [
                "Invalid argument",
                "The argument 'file' is not valid. Go to homepage and try again."
            ]);
        }

        if (!jid || jid.length < 3) {
            $rootScope.$broadcast('error', [
                "Invalid argument",
                "The argument 'jid' is not valid. Go to homepage and try again."
            ]);
        }
        $rootScope.selectedFile = selectedFile;
        $rootScope.jid = jid;
        $rootScope.$apply();
    }

    function getStartupFile() {
        var re = /([^&=]+)=([^&]*)/g;
        var m, s;

        if (typeof (s) === 'undefined') {
            while (m = re.exec(location.hash.slice(1))) {
                if (decodeURIComponent(m[1]) === 'file') {
                    s = decodeURIComponent(m[2]);
                    break;
                }
            }
        }
        if (typeof (s) === 'undefined') {
            while (m = re.exec(location.search.slice(1))) {
                if (decodeURIComponent(m[1]) === 'file') {
                    s = decodeURIComponent(m[2]);
                    break;
                }
            }
        }

        return s;
    }

    function getJid() {
        var re = /([^&=]+)=([^&]*)/g;
        var m, s;

        if (typeof (s) === 'undefined') {
            while (m = re.exec(location.hash.slice(1))) {
                if (decodeURIComponent(m[1]) === 'jid') {
                    s = decodeURIComponent(m[2]);
                    break;
                }
            }
        }
        if (typeof (s) === 'undefined') {
            while (m = re.exec(location.search.slice(1))) {
                if (decodeURIComponent(m[1]) === 'jid') {
                    s = decodeURIComponent(m[2]);
                    break;
                }
            }
        }

        return s;
    }

    angular.module('GroupDocsAnnotationApp').controller('ToolbarController', main);

})();

