(function () {
    'use strict';

    function main($resource) {

        return $resource(
            GROUPDOCS_ANNOTATION_API_BASE + '/UpdateAnnotationPosition',
            {},
            {
                updatePosition: {
                    method: 'POST'
                }
            }
        );
    }

    angular.module('GroupDocsAnnotationApp').factory('UpdateAnnotationPosition', main);

})();

