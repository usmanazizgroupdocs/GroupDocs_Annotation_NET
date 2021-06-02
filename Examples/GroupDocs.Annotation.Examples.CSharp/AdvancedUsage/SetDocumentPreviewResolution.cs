using System;
using System.IO;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    class SetDocumentPreviewResolution
    {
        public static void Run()
        {
            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
                {
                    var pagePath = Path.Combine(Constants.GetOutputDirectoryPath(), $"result_with_resolution_{pageNumber}.png");
                    return File.Create(pagePath);
                });

                previewOptions.PreviewFormat = PreviewFormats.PNG;
                previewOptions.Resolution = 144;

                annotator.Document.GeneratePreview(previewOptions);
            }

            Console.WriteLine($"\nDocument preview with resolution generated successfully.\nCheck output in {Constants.GetOutputDirectoryPath()}.");
        }
    }
}
