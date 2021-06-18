(function (window, location) {
    "use strict";

    switch (String(location.hostname)) {
        case "products.groupdocs.app":
            window.GROUPDOCS_ANNOTATION_API_BASE = "/GroupDocsAPI/api/GroupDocsAnnotation";
            break;
        case "products-qa.groupdocs.app":
            window.GROUPDOCS_ANNOTATION_API_BASE = "/GroupDocsAPI/api/GroupDocsAnnotation";
            break;
        case "localhost":
            window.GROUPDOCS_ANNOTATION_API_BASE = "http://localhost:2122/api/GroupDocsAnnotation";
            break;
    }
})(window, location);

