(function () {
    'use strict';

    function main($resource) {
        return $resource(GROUPDOCS_ANNOTATION_API_BASE + '/GetAnnotationsList', {}, {
            query: {
                method: 'GET',
                isArray: true
            }
        });
    }

    angular.module('GroupDocsAnnotationApp').factory('GetAnnotationsList', main);

})();

