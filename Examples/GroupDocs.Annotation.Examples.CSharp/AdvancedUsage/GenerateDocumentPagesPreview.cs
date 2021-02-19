using GroupDocs.Annotation.Options;
using System;
using System.IO;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates annotating generating previews from document
    /// </summary>
    internal class GenerateDocumentPagesPreview
    {
        public static void Run()
        {
            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
                {
                    var pagePath = Path.Combine(Constants.GetOutputDirectoryPath(), $"result_{pageNumber}.png");
                    return File.Create(pagePath);
                });
                previewOptions.PreviewFormat = PreviewFormats.PNG;

                previewOptions.PageNumbers = new int[] { 1, 2, 3, 4 };
                annotator.Document.GeneratePreview(previewOptions);
            }
            Console.WriteLine($"\nDocument previews generated successfully.\nCheck output in {Constants.GetOutputDirectoryPath()}.");
        }
    }
}