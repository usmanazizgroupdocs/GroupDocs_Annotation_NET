using GroupDocs.Annotation.Config;
using GroupDocs.Annotation.Domain;
using GroupDocs.Annotation.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Annotation.CSharp
{
    class CellsAnnotation
    {

        /// <summary>
        /// Add text annotation in Cells
        /// </summary>
        /// Update CommonUtilities.filePath with path to Slides file before using this function
        public static void AddTextAnnotationInCells()
        {
            try
            {
                //ExStart:AddTextAnnotationInSlides
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize text annotation.
                AnnotationInfo textAnnotation = new AnnotationInfo
                {
                    PageNumber = 0,
                    AnnotationPosition = new Point(1, 2),
                    FieldText = "Hello!",
                    CreatorName = "John"
                };

                // Add annotation to list
                annotations.Add(textAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Cells);
                //ExEnd:AddTextAnnotationInCells
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Shows how to add Ellipse Annotation in Cells Document
        /// </summary>
        public static void AddEllipseAnnotationInCells()
        {
            try
            {
                //ExStart:AddEllipseAnnotationInCells
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize ellipse annotation.
                AnnotationInfo ellipse = new AnnotationInfo
                {
                    Box = new Rectangle(100, 100, 50, 50),
                    Type = AnnotationType.Ellipse
                };

                // Add annotation to list
                annotations.Add(ellipse);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Cells);
                //ExEnd:AddEllipseAnnotationInCells
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
