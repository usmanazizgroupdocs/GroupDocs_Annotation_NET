using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates getting all version keys from document
    /// </summary>
    class GetAllVersionKeysOnDocument
    {
        public static void Run()
        {
            using (Annotator annotator = new Annotator(Constants.ANNOTATED_WITH_VERSIONS))
            {
                List<object> versionKeys = annotator.GetVersionsList();
            }
        }
    }
}
