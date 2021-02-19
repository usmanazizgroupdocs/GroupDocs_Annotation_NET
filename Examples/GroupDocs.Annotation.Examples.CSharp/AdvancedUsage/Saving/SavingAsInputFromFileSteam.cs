using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GroupDocs.Annotation.Examples.CSharp.AdvancedUsage.Saving
{
    /// <summary>
    /// This example demonstrates saving result document as document given to create annotator class
    /// </summary>
    class SavingAsInputFromFileStream
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(),
                "result" + Path.GetExtension(Constants.INPUT));
            using (FileStream fs = new FileStream(Constants.INPUT, FileMode.Open))
            {
                using (Annotator annotator = new Annotator(fs))
                {
                    annotator.Save();
                }
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
