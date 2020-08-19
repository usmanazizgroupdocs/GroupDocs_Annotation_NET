(function () {
    'use strict';

    function main($resource) {

        return $resource(GROUPDOCS_ANNOTATION_API_BASE + '/GetDocumentInfo',
            {},
            {
                get: {
                    method: 'GET'
                }
            });
    }

    angular.module('GroupDocsAnnotationApp').factory('GetDocumentInfo', main);

})();

