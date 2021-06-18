(function () {
    'use strict';

    function main($resource) {
        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/AddReply',
            {},
            {
                save: {
                    method: 'POST'
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('AddReply', main);

})();

