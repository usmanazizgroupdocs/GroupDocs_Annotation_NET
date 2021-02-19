(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/DeleteReply',
            {},
            {
                remove: {
                    method: 'POST'
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('DeleteReply', main);

})();

