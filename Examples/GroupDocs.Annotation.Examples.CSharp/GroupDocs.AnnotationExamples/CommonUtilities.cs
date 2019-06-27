using GroupDocs.Annotation.Common.License;
using GroupDocs.Annotation.Config;
using GroupDocs.Annotation.Domain;
using GroupDocs.Annotation.Domain.Containers;
using GroupDocs.Annotation.Domain.Image;
using GroupDocs.Annotation.Domain.Options;
using GroupDocs.Annotation.Handler;
using GroupDocs.Annotation.Handler.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Annotation.CSharp
{
    //ExStart:CommonUtilities
    class CommonUtilities
    {
        //ExStart:CommonProperties
        public static string StorageFolderPath = "../../../../Data/Samples/";
        public static string DestinationFolderPath = "../../../../Data/Output/";
        public static string LicenseFilePath = "E://License/Groupdocs.Total.lic";
        public static string filePath = "Annotated.pdf";
        //ExEnd:CommonProperties



        //ExStart:MapSourceFilePath
        /// <summary>
        /// Maps source file path
        /// </summary>
        /// <param name="SourceFileName">Source File Name</param>
        /// <returns>Returns complete path of source file</returns>
        public static string MapSourceFilePath(string SourceFileName)
        {
            try
            {
                return StorageFolderPath + SourceFileName;
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        //ExEnd:MapSourceFilePath
        //ExStart:MapDestinationFilePath
        /// <summary>
        /// Maps destination file path
        /// </summary>
        /// <param name="DestinationFileName">Destination File Name</param>
        /// <returns>Returns complete path of destination file</returns>
        public static string MapDestinationFilePath(string DestinationFileName)
        {
            try
            {
                return DestinationFolderPath + DestinationFileName;
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        //ExEnd:MapDestinationFilePath

        /// <summary>
        /// Saves output document
        /// </summary>
        public static void SaveOutputDocument(Stream inputFile, List<AnnotationInfo> annotations, DocumentType type)
        {
            try
            {
                //ExStart:SaveOutputDocument
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();

                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);

                IDocumentDataHandler documentRepository = annotator.GetDocumentDataHandler();
                if (!Directory.Exists(cfg.StoragePath))
                {
                    Directory.CreateDirectory(cfg.StoragePath);
                }

                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations, type);

                FileStream getFileStream = inputFile as FileStream;
                string extensionWithDot = Path.GetExtension(getFileStream.Name);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(MapDestinationFilePath("Annotated" + extensionWithDot), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:SaveOutputDocument
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        //ExStart:ApplyLicense
        /// <summary>
        /// Applies product license
        /// </summary>
        public static void ApplyLicense()
        {
            try
            {
                // initialize License
                License lic = new License();
                // apply license
                lic.SetLicense(LicenseFilePath);
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        //ExEnd:ApplyLicense

        //ExStart:SetMeteredLicense
        /// <summary>
        /// Set Metered License
        /// </summary>
        public static void SetMeteredLicense(Stream licenseStream)
        {
            string PublicKey = ""; // Your public license key
            string PrivateKey = ""; // Your private license key
            GroupDocs.Annotation.Common.License.Metered metered = new GroupDocs.Annotation.Common.License.Metered();
            metered.SetMeteredKey(PublicKey, PrivateKey);
        }
        //ExEnd:SetMeteredLicense

        //ExStart:GetAlreadyUsedCredit
        /// <summary>
        /// Number of already used credits
        /// </summary>
        public static decimal GetAlreadyUsedCredit()
        {
            //Retrieves amount of already used credits
            return Metered.GetConsumptionCredit();
        }
        //ExEnd:GetAlreadyUsedCredit

        //ExStart:GetConfiguration
        /// <summary>
        /// Sets annotation configuration
        /// </summary>
        /// <returns>Returns AnnotationConfig object</returns>
        public static AnnotationConfig GetConfiguration()
        {
            try
            {
                AnnotationConfig cfg = new AnnotationConfig();

                //Set storage path 
                cfg.StoragePath = StorageFolderPath;

                return cfg;
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
                return null;
            }
        }
        //ExEnd:GetConfiguration

        //ExStart:GetImageRepresentation
        /// <summary>
        /// Gets image representation of document
        /// </summary>
        /// <param name="CommonUtilities.filePath">Source file path</param> 
        public static void GetImageRepresentation(string filePath)
        {
            try
            {
                Stream document = new FileStream(MapSourceFilePath(filePath), FileMode.Open);
                AnnotationConfig cfg = GetConfiguration();

                AnnotationImageHandler annotationHandler = new AnnotationImageHandler(cfg);

                List<PageImage> images = annotationHandler.GetPages(document, new ImageOptions());

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(MapDestinationFilePath("image.png"), FileMode.Create))
                {
                    byte[] buffer = new byte[images[0].Stream.Length];
                    images[0].Stream.Seek(0, SeekOrigin.Begin);
                    images[0].Stream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }
        //ExEnd:GetImageRepresentation

        //ExStart:GetTextCoordinatesInImage
        /// <summary>
        /// Gets text coordinates in image representation of document
        /// </summary>
        /// <param name="CommonUtilities.filePath">Source file path</param> 
        public static void GetTextCoordinates(string filePath)
        {
            try
            {
                // Set configuration
                AnnotationConfig cfg = GetConfiguration();

                // Initialize annotator 
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                try
                {
                    annotator.CreateDocument(filePath);
                }
                catch { }

                var documentInfoContainer = annotator.GetDocumentInfo(filePath);

                // Go through all pages
                foreach (PageData pageData in documentInfoContainer.Pages)
                {
                    Console.WriteLine("Page number: " + pageData.Number);

                    //Go through all page rows
                    for (int i = 0; i < pageData.Rows.Count; i++)
                    {
                        RowData rowData = pageData.Rows[i];

                        // Write data to console
                        Console.WriteLine("Row: " + (i + 1));
                        Console.WriteLine("Text: " + rowData.Text);
                        Console.WriteLine("Text width: " + rowData.LineWidth);
                        Console.WriteLine("Text height: " + rowData.LineHeight);
                        Console.WriteLine("Distance from left: " + rowData.LineLeft);
                        Console.WriteLine("Distance from top: " + rowData.LineTop);

                        // Get words
                        string[] words = rowData.Text.Split(' ');

                        // Go through all word coordinates
                        for (int j = 0; j < words.Length; j++)
                        {
                            int coordinateIndex = j == 0 ? 0 : j + 1;
                            // Write data to console
                            Console.WriteLine(string.Empty);
                            Console.WriteLine("Word:'" + words[j] + "'");
                            Console.WriteLine("Word distance from left: " + rowData.TextCoordinates[coordinateIndex]);
                            Console.WriteLine("Word width: " + rowData.TextCoordinates[coordinateIndex + 1]);
                            Console.WriteLine(string.Empty);
                        }
                        Console.ReadKey();
                    }
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            //ExEnd:GetTextCoordinatesInImage
        }


        /// <summary>
        /// Get Password Protected Documents
        /// </summary>
        public static FileContainer GetPasswordProtectedDocuments(Stream protectedDocument,String password)
        {            
            //ExStart:GetPasswordProtectedDocuments
            AnnotationConfig cfg = CommonUtilities.GetConfiguration();
            AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);

            FileContainer convertedDocument = annotator.GetPdfFile(protectedDocument, password);
            
            return convertedDocument;

            //ExEnd:GetPasswordProtectedDocuments
        }
    }
    //ExEnd:CommonUtilities
}
