using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage
{
    class LoadingCustomFonts
    {
        public static void Run()
        {
            using (Annotator annotator = new Annotator(Constants.INPUT_WITH_CUSTOM_FONT, new LoadOptions { FontDirectories = new List<string> { Constants.GetFontDirectory() } }))
            {
                PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
                {
                    var pagePath = Path.Combine(Constants.GetOutputDirectoryPath(), $"result_with_font_{pageNumber}.png");
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
