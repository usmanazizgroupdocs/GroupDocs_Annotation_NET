(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/GetAnnotation',
            {},
            {
                get: {
                    method: 'GET',
                    responseType: 'application/json'
                },
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('GetAnnotation', main);

})();

