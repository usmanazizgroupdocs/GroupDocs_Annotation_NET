using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage
{
    class RemoveAnnotationsByIds
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.ANNOTATED))
            {
                annotator.Remove(new List<int>{0,1});
                annotator.Save(outputPath);
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
