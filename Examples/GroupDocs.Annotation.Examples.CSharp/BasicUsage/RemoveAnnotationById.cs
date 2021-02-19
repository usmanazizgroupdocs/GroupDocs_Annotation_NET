using System;
using System.IO;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to remove annotations from annotated document by Id
    /// </summary>
    class RemoveAnnotationById
    {
        public static void Run()
            {
                string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

                using (Annotator annotator = new Annotator(Constants.ANNOTATED))
                {
                    annotator.Remove(0);
                    annotator.Save(outputPath);
                }
                Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
            }
        
    }
}
