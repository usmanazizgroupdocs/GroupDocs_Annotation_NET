(function () {
    'use strict';

    angular.module('GroupDocsAnnotationLauncher', [
        'ngRoute',
        'ngMessages',
        'ngResource',
        'ngFileUpload'
    ]).info({
        version: '1.0',
    });
    
    angular.module('GroupDocsAnnotationLauncher').controller('Main', function main($rootScope, $scope, $http, $window, Upload) {
        $scope.jid = randomString();
        $scope.inputFile = {};

        if (REQUESTED_EXTENSION === null) {
            $scope.REQUESTED_EXTENSION = null;
        } else {
            $scope.REQUESTED_EXTENSION = REQUESTED_EXTENSION.toUpperCase();
        }

        $scope.REQUESTED_FILEFORMAT = REQUESTED_FILEFORMAT;

        $scope.uploadInputFile = function () {
            $scope.uploadFile(
                $scope.inputFile.file,
                function (response) {
                    $scope.launchApp();
                },
                function (response) {
                    alertError(response);
                },
                function (e) {
                    $scope.inputFile.loadedSize = e.loaded;
                    $scope.inputFile.totalSize = e.total;
                    $scope.inputFile.progress = Math.min(100, parseInt(100.0 * e.loaded / e.total));
                }
            );
        };

        $scope.launchApp = function () {
            var href = '/annotation/file/' + $scope.jid + '?'
                + 'jid=' + $scope.jid
                + '&'
                + 'file=' + encodeURIComponent($scope.inputFile.file.name);
            window.location.href = href;
        }

        $scope.uploadFile = function (file, success, error, progress) {
            Upload.upload({
                url: GROUPDOCS_ANNOTATION_API_BASE + "/Upload?" + $.param({
                    jid: $scope.jid,
                }),
                data: {
                    file: file,
                }
            }).then(success, error, progress);
        };

    });

    function randomString() {
        return Math.random().toString(36).substring(2)
            + Math.random().toString(36).substring(2)
            + Math.random().toString(36).substring(2);
    }

    function alertError(response) {
        console.error('Error occurred while uploading file', response.data);
        alert('Error occurred while uploading file. Please try again later.');
    }

})();
