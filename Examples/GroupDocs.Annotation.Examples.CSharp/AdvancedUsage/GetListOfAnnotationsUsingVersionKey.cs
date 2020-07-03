using System;
using System.Collections.Generic;
using System.Text;
using GroupDocs.Annotation.Models.AnnotationModels;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates getting list of annotations from document using version key
    /// </summary>
    class GetListOfAnnotationsUsingVersionKey
    {
        public static void Run()
        {
            using (Annotator annotator = new Annotator(Constants.ANNOTATED_WITH_VERSIONS))
            {
                List<AnnotationBase> annotations = annotator.GetVersion("CUSTOM_VERSION");
            }
        }
    }
}
