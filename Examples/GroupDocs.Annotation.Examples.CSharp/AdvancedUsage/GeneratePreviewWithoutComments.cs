using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates generating preview of document without rendering comments
    /// </summary>
    class GeneratePreviewWithoutComments
    {
        public static void Run()
        {
            Annotator annotator = new Annotator(Constants.ANNOTATED_DOCX);
            PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
            {
                var pagePath = $"result{pageNumber}.png";
                return File.Create(pagePath);
            });
            previewOptions.PreviewFormat = PreviewFormats.PNG;
            previewOptions.PageNumbers = new int[] {1, 2, 3, 4, 5, 6};
            previewOptions.RenderComments = false;
            annotator.Document.GeneratePreview(previewOptions);
        }
    }
}
