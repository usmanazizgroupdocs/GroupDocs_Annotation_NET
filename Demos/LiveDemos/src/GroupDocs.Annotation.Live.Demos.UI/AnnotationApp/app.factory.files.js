(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/Files',
            {},
            {
                query: {
                    method: 'GET',
                    isArray: true
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('Files', main);

})();

