(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/DeleteAnnotation',
            {},
            {
                remove: {
                    method: 'POST',
                    responseType: 'application/json'
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('DeleteAnnotation', main);

})();

