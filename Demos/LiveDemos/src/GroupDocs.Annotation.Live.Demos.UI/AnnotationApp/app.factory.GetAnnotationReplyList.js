(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/GetAnnotationReplyList',
            {},
            {
                query: {
                    method: 'GET',
                    isArray: true
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('GetAnnotationReplyList', main);

})();

