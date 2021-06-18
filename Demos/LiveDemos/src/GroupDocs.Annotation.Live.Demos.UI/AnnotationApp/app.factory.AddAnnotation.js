(function () {
    'use strict';

    function main($resource) {
        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/AddAnnotation',
            {},
            {
                save: {
                    method: 'POST'
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('AddAnnotation', main);

})();

