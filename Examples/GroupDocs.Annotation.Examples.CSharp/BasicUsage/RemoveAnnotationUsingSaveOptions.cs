using GroupDocs.Annotation.Options;
using System;
using System.IO;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to remove annotations from document using SaveOptions Property
    /// </summary>
    class RemoveAnnotationUsingSaveOptions
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.ANNOTATED))
            {
                annotator.Save(outputPath, new SaveOptions() { AnnotationTypes = AnnotationType.None });
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
