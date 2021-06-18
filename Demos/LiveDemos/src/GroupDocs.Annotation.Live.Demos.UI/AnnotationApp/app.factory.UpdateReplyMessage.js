(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/UpdateReplyMessage',
            {},
            {
                save: {
                    method: 'POST'
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('UpdateReplyMessage', main);

})();

