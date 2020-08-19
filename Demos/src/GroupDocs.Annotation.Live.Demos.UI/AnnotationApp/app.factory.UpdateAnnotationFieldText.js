(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/UpdateAnnotationFieldText',
            {},
            {
                updateFieldText: {
                    method: 'POST'
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('UpdateAnnotationFieldText', main);

})();

