using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GroupDocs.Annotation.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            CommonUtilities.StorageFolderPath = "../../../../Data/Samples/";
            CommonUtilities.DestinationFolderPath = "../../../../Data/Output/";
            CommonUtilities.LicenseFilePath = "E://Groupdocs.Total.lic";

            /* Apply product license
             * Uncomment following function if you have product license
             * */

            //CommonUtilities.ApplyLicense();

            #region Annotation Functions for PDF

            //CommonUtilities.filePath = "sample.pdf";

            //////Add text annotation in pdf
            //PDFAnnotation.AddTextAnnotation(); 

            //////Add area annotation with replies 
            //PDFAnnotation.AddAreaAnnotationWithReplies();

            //////Add point annotation
            //PDFAnnotation.AddPointAnnotation();

            //////Add text strike out annotation
            //PDFAnnotation.AddTextStrikeOutAnnotation();

            //////Add polyline annotation
            //PDFAnnotation.AddPolylineAnnotation();

            //////Add text field annotation
            //PDFAnnotation.AddTextFieldAnnotation();

            //////Add watermark annotation
            //PDFAnnotation.AddWatermarkAnnotation();

            //////Add text replacement annotation
            //PDFAnnotation.AddTextReplacementAnnotation();

            //////Add arrow annotation
            //PDFAnnotation.AddArrowAnnotation();

            //////Add text redaction annotation
            //PDFAnnotation.AddTextRedactionAnnotation();

            //////Add underline annotation
            //PDFAnnotation.AddUnderLineAnnotation();

            //////Add distance annotation
            //PDFAnnotation.AddDistanceAnnotation();

            //////Add resource redaction annotation
            //PDFAnnotation.AddResourceRedactionAnnotation();

            //////Remove all annotations
            //PDFAnnotation.RemoveAllAnnotationsFromDocument();

            //////Get Image Representation of Pages for PDF 
            //PDFAnnotation.GetImageRepresentationOfPagesForPDF();

            //////Add Ellipse Annotation 
            //PDFAnnotation.AddEllipseAnnotation();

            //////Get Thumnails of Pages for PDF 
            //PDFAnnotation.GetThumnailsOfPagesForPDF();

            //////Set Watermark angle for PDF 
            //PDFAnnotation.SetWatermarkAngleForPDF();

            //////Add link annotation
            //PDFAnnotation.AddLinkAnnotation();

            #endregion

            #region Annotation Functions for Words Document format


            //CommonUtilities.filePath = "Annotated.docx";

            //////Add area annotation with replies  for Words Document format
            //WordAnnotation.AddAreaAnnotationWithRepliesforWords();

            //////Add point annotation for Words Document format
            //WordAnnotation.AddPointAnnotationforWords();

            //////Add text strike out annotation for Words Document format
            //WordAnnotation.AddTextStrikeOutAnnotationforWords();


            //////Add text field annotation for Words Document format
            //WordAnnotation.AddTextFieldAnnotationforWords();

            //////Add text replacement annotation for Words Document format
            //WordAnnotation.AddTextReplacementAnnotationforWords();

            //////Add arrow annotation for Words Document format
            //WordAnnotation.AddArrowAnnotationforWords();

            //////Add text redaction annotation for Words Document format
            //WordAnnotation.AddTextRedactionAnnotationforWords();

            //////Add underline annotation for Words Document format
            //WordAnnotation.AddUnderLineAnnotationforWords();


            //////Add resource redaction annotation for Words Document format
            //WordAnnotation.AddResourceRedactionAnnotationforWords();

            //////Import and Export Annotations from Words document.
            //WordAnnotation.ImportAndExportAnnotationsFromWords();

            ////Add distance annotation for Words Document format
            //WordAnnotation.AddDistanceAnnotationforWords();

            ////Add watermark annotation for Words Document format
            //WordAnnotation.AddWatermarkAnnotationforWords();

            ////Add polyline annotation for Words Document format
            //WordAnnotation.AddPolylineAnnotationforWords();

            //////Add link annotation in Words
            //WordAnnotation.AddLinkAnnotationInWords();

            #endregion

            #region Annotation Functions for Slides

            //CommonUtilities.filePath = "sample.pptx";

            ////Add text annotation
            //SlidesAnnotation.AddTextAnnotation(); 

            ////Add text annotation in slides
            //SlidesAnnotation.AddTextFieldAnnotation();

            ////Add area annotation with replies 
            //SlidesAnnotation.AddAreaAnnotationWithReplies();

            ////Add point annotation
            //SlidesAnnotation.AddPointAnnotation();

            ////Add text strike out annotation
            //SlidesAnnotation.AddTextStrikeOutAnnotation();

            ////Add polyline annotation
            //SlidesAnnotation.AddPolylineAnnotation();

            ////Add text field annotation
            //SlidesAnnotation.AddTextFieldAnnotation();

            ////Add watermark annotation
            //SlidesAnnotation.AddWatermarkAnnotation();

            ////Add text replacement annotation
            //SlidesAnnotation.AddTextReplacementAnnotation();

            ////Add arrow annotation
            //SlidesAnnotation.AddArrowAnnotation();

            ////Add text redaction annotation
            //SlidesAnnotation.AddTextRedactionAnnotation();

            ////Add underline annotation
            //SlidesAnnotation.AddUnderLineAnnotation();

            ////Add distance annotation
            //SlidesAnnotation.AddDistanceAnnotation();

            ////Add resource redaction annotation
            //SlidesAnnotation.AddResourceRedactionAnnotation();

            ////Remove all annotations
            //SlidesAnnotation.RemoveAllAnnotationsFromDocument();

            //////Add link annotation in Slides
            //SlidesAnnotation.AddLinkAnnotationInSlides();

            #endregion

            #region Cells
            //CommonUtilities.filePath = "excel.xlsx";
            ////Add text annotation in Cells
            //CellsAnnotation.AddTextAnnotationInCells(); 
            #endregion

            #region Annotation Functions for Image

            //CommonUtilities.filePath = "sample.png";

            //////Add text annotation in pdf
            //ImagesAnnotation.AddTextAnnotation();

            //////Add area annotation with replies 
            //ImagesAnnotation.AddAreaAnnotationWithReplies();

            //////Add point annotation
            //ImagesAnnotation.AddPointAnnotation();

            //////Add text strike out annotation
            //ImagesAnnotation.AddTextStrikeOutAnnotation();

            //////Add polyline annotation
            //ImagesAnnotation.AddPolylineAnnotation();

            //////Add text field annotation
            //ImagesAnnotation.AddTextFieldAnnotation();

            //////Add watermark annotation
            //ImagesAnnotation.AddWatermarkAnnotation();

            //////Add text replacement annotation
            //ImagesAnnotation.AddTextReplacementAnnotation();

            //////Add arrow annotation
            //ImagesAnnotation.AddArrowAnnotation();

            //////Add text redaction annotation
            //ImagesAnnotation.AddTextRedactionAnnotation();

            //////Add underline annotation
            //ImagesAnnotation.AddUnderLineAnnotation();

            //////Add distance annotation
            //ImagesAnnotation.AddDistanceAnnotation();

            //////Add resource redaction annotation
            //ImagesAnnotation.AddResourceRedactionAnnotation();

            //////Remove all annotations
            //ImagesAnnotation.RemoveAllAnnotationsFromDocument();

            #endregion

            #region DataStorage Functions

            ////Create document
            ////DataStorage.CreateDocument();

            //////Assign access rights
            ////DataStorage.AssignAccessRights();

            //////Create and get annotation
            ////DataStorage.CreateAndGetAnnotation();

            //////Get all annotation of a document
            ////DataStorage.GetAllDocumentAnnotation();

            //////Resize annotation 
            ////DataStorage.ResizeAnnotationResult();

            //////Move an anotation 
            ////DataStorage.MoveAnnotationResult();

            //////Set background color
            ////DataStorage.SetBackgroundColorResult();

            //////Edit annotation
            ////DataStorage.EditTextFieldAnnotation();

            //////Remove annotation
            ////DataStorage.RemoveAnnotation();

            //////Add annotation reply
            ////DataStorage.AddAnnotationReply();

            //////Add document collaborator
            ////DataStorage.AddCollaborator();

            //////Get document collaborator
            ////DataStorage.GetCollaborator();

            //////Update document collaborator
            ////DataStorage.UpdateCollaborator();

            //////Delete document collaborator
            ////DataStorage.DeleteCollaborator();

            //////Delete document collaborator
            ////DataStorage.ManageCollaboratorRights();

            //////Export annotation to document
            ////DataStorage.ExportAnnotationInFile();

            //#endregion

            //#region Other Operations

            //////Get image representation of the document
            ////CommonUtilities.GetImageRepresentation("sample.pdf");

            //////Get text coordinates in image representation of the document
            ////CommonUtilities.GetTextCoordinates("sample.pdf");
            #endregion

            #region Working with Diagrams

            //CommonUtilities.filePath = "sample.vsd";

            ////Add area annotation in Diagrams
            //DiagramsAnnotation.AddAreaAnnotationInDiagrams();

            ////Add polyline annotation
            //DiagramsAnnotation.AddPolylineAnnotationInDiagrams();

            ////Add text field annotation
            //DiagramsAnnotation.AddTextFieldAnnotationInDiagrams();

            ////Add arrow annotation
            //DiagramsAnnotation.AddArrowAnnotationInDiagrams();

            ////Add resource redaction annotation
            //DiagramsAnnotation.AddResourceRedactionAnnotationInDiagrams();

            ////Add distance annotation
            //DiagramsAnnotation.AddDistanceAnnotationInDiagrams();

            ////Add point annotation
            //DiagramsAnnotation.AddPointAnnotationInDiagrams();

            ////Add watermark annotation
            //DiagramsAnnotation.AddWatermarkAnnotationInDiagrams();


            #endregion

            Console.ReadKey();

        }


    }
}
