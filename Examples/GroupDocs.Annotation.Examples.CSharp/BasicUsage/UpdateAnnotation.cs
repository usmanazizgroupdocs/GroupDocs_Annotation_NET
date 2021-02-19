using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using GroupDocs.Annotation.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to update annotation
    /// </summary>
    class UpdateAnnotation
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                AreaAnnotation original = new AreaAnnotation
                {
                    Id = 1,
                    BackgroundColor = 65535,
                    Box = new Rectangle(100, 100, 100, 100),
                    CreatedOn = DateTime.Now,
                    Message = "This is original annotation",
                    Replies = new List<Reply>
                    {
                        new Reply
                        {
                            Comment = "Original first comment",
                            RepliedOn = DateTime.Now
                        },
                        new Reply
                        {
                            Comment = "Original second comment",
                            RepliedOn = DateTime.Now
                        }
                    }
                };
                // add original annotation
                annotator.Add(original);
                annotator.Save(outputPath);
            }

            // open annotated document
            using (Annotator annotator = new Annotator(outputPath))
            {
                // suggest we want change some properties of existed annotation
                AreaAnnotation updated = new AreaAnnotation
                {
                    // It's important to set existed annotation Id
                    Id = 1,
                    BackgroundColor = 255,
                    Box = new Rectangle(0, 0, 50, 200),
                    CreatedOn = DateTime.Now,
                    Message = "This is updated annotation",
                    Replies = new List<Reply>
                    {
                        new Reply
                        {
                            Comment = "Updated first comment",
                            RepliedOn = DateTime.Now
                        },
                        new Reply
                        {
                            Comment = "Updated second comment",
                            RepliedOn = DateTime.Now
                        }
                    }
                };
                // update annotation
                annotator.Update(updated);
                annotator.Save(outputPath);
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
