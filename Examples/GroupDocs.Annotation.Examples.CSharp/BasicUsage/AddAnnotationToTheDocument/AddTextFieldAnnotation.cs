using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Annotation.Models;
using GroupDocs.Annotation.Models.AnnotationModels;
using GroupDocs.Annotation.Options;

namespace GroupDocs.Annotation.Examples.CSharp.BasicUsage.AddAnnotationToTheDocument
{
    /// <summary>
    /// This example demonstrates adding text field annotation.
    /// </summary>
    class AddTextFieldAnnotation
    {
        public static void Run()
        {
            string outputPath = Path.Combine(Constants.GetOutputDirectoryPath(), "result" + Path.GetExtension(Constants.INPUT));

            using (Annotator annotator = new Annotator(Constants.INPUT))
            {
                TextFieldAnnotation textField = new TextFieldAnnotation
                {
                    BackgroundColor = 65535,
                    Box = new Rectangle(100, 100, 100, 100),
                    CreatedOn = DateTime.Now,
                    Text = "Some text",
                    FontColor = 65535,
                    FontSize = 12,
                    Message = "This is text field annotation",
                    Opacity = 0.7,
                    PageNumber = 0,
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
                annotator.Add(textField);
                annotator.Save(outputPath);
            }
            Console.WriteLine($"\nDocument saved successfully.\nCheck output in {outputPath}.");
        }
    }
}
