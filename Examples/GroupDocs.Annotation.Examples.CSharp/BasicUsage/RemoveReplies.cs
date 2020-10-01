using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using GroupDocs.Annotation.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to remove replies from annotated document
    /// </summary>
    class RemoveReplies
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            // NOTE: Input document already contain annotations with replies
            using (Annotator annotator = new Annotator(Constants.ANNOTATED_WITH_REPLIES))
            {
                // Obtain annotations collection from document
                List<AnnotationBase> annotations = annotator.Get();
                
                // Remove first reply by index
                annotations[0].Replies.RemoveAt(0);
                
                // Save changes
                annotator.Update(annotations);
                annotator.Save(outputPath);
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
