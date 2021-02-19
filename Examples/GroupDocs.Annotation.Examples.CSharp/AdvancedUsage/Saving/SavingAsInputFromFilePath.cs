using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage.Saving
{
    /// <summary>
    /// This example demonstrates saving result document as document given to create annotator class
    /// </summary>
    class SavingAsInputFromFilePath
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                annotator.Save();
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
