using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage.AddAnnotationToTheDocument
{
    /// <summary>
    /// This example demonstrates adding ellipse annotation.
    /// </summary>
    class AddEllipseAnnotation
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                EllipseAnnotation ellipse = new EllipseAnnotation
                {
                    BackgroundColor = 65535,
                    Box = new Rectangle(100, 100, 100, 100),
                    CreatedOn = DateTime.Now,
                    Message = "This is ellipse annotation",
                    Opacity = 0.7,
                    PageNumber = 0,
                    PenColor = 65535,
                    PenStyle = PenStyle.Dot,
                    PenWidth = 3,
                    Replies = new List<Reply>
                    {
                        new Reply
                        {
                            Comment = "First comment",
                            RepliedOn = DateTime.Now
                        },
                        new Reply
                        {
                            Comment = "Second comment",
                            RepliedOn = DateTime.Now
                        }
                    }
                };
                annotator.Add(ellipse);
                annotator.Save(outputPath);
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
