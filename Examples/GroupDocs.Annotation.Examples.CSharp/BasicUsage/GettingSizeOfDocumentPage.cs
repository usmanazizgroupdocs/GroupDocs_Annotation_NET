using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates getting document pages width and height
    /// </summary>
    class GettingSizeOfDocumentPage
    {
        public static void Run()
        {
            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                IDocumentInfo info = annotator.Document.GetDocumentInfo();
                int width = info.PagesInfo[0].Width;
                int height = info.PagesInfo[0].Height;
            }
        }
    }
}
