(function () {
    'use strict';

    function main($rootScope) {
        $rootScope.GROUPDOCS_ANNOTATION_API_BASE = window.GROUPDOCS_ANNOTATION_API_BASE;
        $rootScope.zoomFactor = 1.0;

        setupErrorlog($rootScope);

        window.gdxResourceErrorHandler = function (response) {
            console.error('gdxResourceErrorHandler', this, arguments);
            var m = '';
            var d = '';

            if (response) {
                if (response.data) {
                    if (response.data.message) {
                        m = response.data.message;
                    } else {
                        m = 'Unknown Error';
                    }
                    if (response.data.details) {
                        d = response.data.details;
                    } else {
                        JSON.stringify(response.data);
                    }
                } else {
                    m = 'Unknown Error';
                    d = 'Check console for details.';
                }
            } else {
                m = 'Unknown Error';
                d = 'Check console for details.';
            }

            $rootScope.$broadcast('error', [
                response.data.message,
                response.data.details
            ]);
        }
    }

    function setupErrorlog($rootScope) {
        $rootScope.errors = [];
        $rootScope.$on('error', function ($event, args) {
            $rootScope.errors.splice(0, 0, {
                'title': args[0],
                'description': args[1]
            });
        });
    }


    angular.module('GroupDocsAnnotationApp').run(main);

})();

