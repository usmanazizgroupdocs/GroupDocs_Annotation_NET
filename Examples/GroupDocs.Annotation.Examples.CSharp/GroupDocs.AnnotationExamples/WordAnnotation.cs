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
      
    class WordAnnotation
    {

        public static void AddTextAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize text annotation.
                AnnotationInfo textAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)265.44, (float)153.86, 206, 36),
                    PageNumber = 0,
                    SvgPath = "[{\"x\":265.44,\"y\":388.83},{\"x\":472.19,\"y\":388.83},{\"x\": 265.44,\"y\":349.14},{\"x\":472.19,\"y\":349.14}]",
                    Type = AnnotationType.Text,
                    CreatorName = "Anonym A."
                };

                // Add annotation to list
                annotations.Add(textAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }


        /// <summary>
        /// Adds area annotation with replies in words document
        /// </summary>
        public static void AddAreaAnnotationWithRepliesforWords()
        {
            try
            {
                //ExStart:AddAreaAnnotationWithRepliesforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Area annotation with 2 replies
                AnnotationInfo areaAnnnotationforWords = new AnnotationInfo()
                {
                    AnnotationPosition = new Point(852.0, 59.0),
                    Replies = new AnnotationReplyInfo[]
                {
                    new AnnotationReplyInfo
                    {
                        Message = "Hello!",
                        RepliedOn = DateTime.Now,
                        UserName = "John"
                    },
                    new AnnotationReplyInfo
                    {
                        Message = "Hi!",
                        RepliedOn = DateTime.Now,
                        UserName = "Judy"
                    }
                },
                    BackgroundColor = 11111111,
                    Box = new Rectangle(300f, 200f, 88f, 37f),
                    PageNumber = 0,
                    PenColor = 2222222,
                    PenStyle = 1,
                    PenWidth = 1,
                    Type = AnnotationType.Area,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(areaAnnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddAreaAnnotationWithRepliesforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds point annotation in words document
        /// </summary>
        public static void AddPointAnnotationforWords()
        {
            try
            {
                //ExStart:AddPointAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Point annotation
                AnnotationInfo pointAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 81.0),
                    Box = new Rectangle(212f, 81f, 142f, 0.0f),
                    PageNumber = 0,
                    Type = AnnotationType.Point,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(pointAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddPointAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text strikeout annotation in words document
        /// </summary>
        public static void AddTextStrikeOutAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextStrikeOutAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text strikeout annotation
                AnnotationInfo strikeoutAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)101.76, (float)688.73, (float)321.85, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":101.76,\"y\":400.05},{\"x\":255.9,\"y\":400.05},{\"x\":101.76,\"y\":378.42},{\"x\":255.91,\"y\":378.42},{\"x\":101.76,\"y\":374.13},{\"x\":423.61,\"y\":374.13},{\"x\":101.76,\"y\":352.5},{\"x\":423.61,\"y\":352.5}]",
                    Type = AnnotationType.TextStrikeout,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(strikeoutAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextStrikeOutAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text field annotation in words document
        /// </summary>
        public static void AddTextFieldAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextFieldAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text field annotation
                AnnotationInfo textFieldAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 201.0),
                    FieldText = "text in the box",
                    FontFamily = "Arial",
                    FontSize = 10,
                    Box = new Rectangle(66f, 201f, 64f, 37f),
                    PageNumber = 0,
                    Type = AnnotationType.TextField,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(textFieldAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextFieldAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text replacement annotation in words document
        /// </summary>
        public static void AddTextReplacementAnnotationforWords()
        {
            try
            {

                //ExStart:AddTextReplacementAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text replacement annotation
                AnnotationInfo textReplacementAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)101.76, (float)826.73, (float)229, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":101.76,\"y\":264.69},{\"x\":331,\"y\":264.69},{\"x\":101.76,\"y\":243.06},{\"x\":331,\"y\":243}]",
                    Type = AnnotationType.TextReplacement,
                    CreatorName = "Anonym A.",
                    FieldText = "Replaced text",
                    FontSize = 10
                };
                // Add annotation to list
                annotations.Add(textReplacementAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextReplacementAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds arrow annotation in words document
        /// </summary>
        public static void AddArrowAnnotationforWords()
        {
            try
            {
                //ExStart:AddArrowAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Arrow annotation
                AnnotationInfo arrowAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 252.0),
                    Box = new Rectangle(279.4742f, 252.9241f, 129.9555f, -9.781596f),
                    PageNumber = 0,
                    PenColor = 1201033,
                    PenStyle = 0,
                    PenWidth = 1,
                    SvgPath = "M279.47417840375584,252.92413145539905 L129.9554929577465,-9.781596244131455",
                    Type = AnnotationType.Arrow,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(arrowAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddArrowAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text redaction annotation in words document
        /// </summary>
        public static void AddTextRedactionAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextRedactionAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text redaction annotation
                AnnotationInfo textRedactionAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)448.56, (float)212.4, 210, 27),
                    PageNumber = 0,
                    SvgPath = "[{\"x\":448.56,\"y\":326.5},{\"x\":658.7,\"y\":326.5},{\"x\":448.56,\"y\":302.43},{\"x\":658.7,\"y\":302.43}]",
                    Type = AnnotationType.TextRedaction,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(textRedactionAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextRedactionAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds underline annotation in words document
        /// </summary>
        public static void AddUnderLineAnnotationforWords()
        {
            try
            {
                //ExStart:AddUnderLineAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Underline annotation
                AnnotationInfo underlineAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)248.57, (float)1135.78, (float)222.67, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":248.57,\"y\":503.507},{\"x\":471,\"y\":503.507},{\"x\":248.57,\"y\":468.9},{\"x\":471,\"y\":468.9}]",
                    Type = AnnotationType.TextUnderline,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(underlineAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddUnderLineAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        
        /// <summary>
        /// Adds resource redaction annotation in words document
        /// </summary>
        public static void AddResourceRedactionAnnotationforWords()
        {
            try
            {
                //ExStart:AddResourceRedactionAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Resource redaction annotation
                AnnotationInfo resourceRedactionAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 271.78),
                    BackgroundColor = 3355443,
                    Box = new Rectangle(466f, 271f, 69f, 62f),
                    PageNumber = 0,
                    PenColor = 3355443,
                    Type = AnnotationType.ResourcesRedaction,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(resourceRedactionAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddResourceRedactionAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Import and Export Annotations from Words document.
        /// </summary>
        /// Update CommonUtilities.filePath with path to word document files before using this function
        public static void ImportAndExportAnnotationsFromWords()
        {
            try
            {
                //ExStart:ImportAndExportAnnotationsFromWords
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();

                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);

                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                //importing annotations from Words document
                AnnotationInfo[] annotations = annotator.ImportAnnotations(inputFile, DocumentType.Words);

                //export imported annotation to another document (just for check)
                Stream clearDocument = new FileStream(CommonUtilities.MapDestinationFilePath("Clear.docx"), FileMode.Open, FileAccess.ReadWrite);
                Stream output = annotator.ExportAnnotationsToDocument(clearDocument, annotations.ToList(), DocumentType.Words);


                // Export annotation and save output file
                //save results after export
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("AnnotationImportAndExportAnnotated.docx"), FileMode.Create))
                {
                    byte[] buffer = new byte[output.Length];
                    output.Seek(0L, SeekOrigin.Begin);
                    output.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:ImportAndExportAnnotationsFromWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Distance annotation in words document
        /// </summary>
        public static void AddDistanceAnnotationforWords()
        {
            try
            {
                //ExStart:AddDistanceAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Distance annotation
                AnnotationInfo distanceAnnnotation = new AnnotationInfo
                {
                    Box = new Rectangle((float)248.73202514648438, (float)287.85653686523438, (float)115.9178466796875, (float)25.143020629882812),
                    Opacity = 0.3,
                    PageNumber = 0,
                    SvgPath = "M248.73201877934272,295.5439436619718 l115.28309859154929,-4.192112676056338",
                    Type = AnnotationType.Distance,
                };
                // Add annotation to list
                annotations.Add(distanceAnnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddDistanceAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Watermark annotation in words document
        /// </summary>
        public static void AddWatermarkAnnotationforWords()
        {
            try
            {
                //ExStart:AddWatermarkAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Watermark annotation
                AnnotationInfo watermarkAnnotation = new AnnotationInfo
                {
                    FieldText = "watermark text",
                    FontFamily = "Microsoft Sans Serif",
                    FontSize = 17,
                    Box = new Rectangle(195.225f, 216.464f, 230.73f, 58.18f),
                    PageNumber = 0,
                    Type = AnnotationType.Watermark,
                    FontColor = 16711680
                };
                // Add annotation to list
                annotations.Add(watermarkAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddWatermarkAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Polyline annotation in words document
        /// </summary>
        public static void AddPolylineAnnotationforWords()
        {
            try
            {
                //ExStart:AddPolylineAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Polyline annotation
                AnnotationInfo polylineAnnotation = new AnnotationInfo
                {
                    PageNumber = 0,
                    Type = AnnotationType.Polyline,
                    Box = new Rectangle(288.760559f, 533.7042f, 216.929581f, 171.676056f),
                    SvgPath = "M504.9718309859155,678.0845070422536l-0.7183098591549296,0l-0.7183098591549296,0l-0.7183098591549296,0.7183098591549296l-0.7183098591549296,0.7183098591549296l-1.4366197183098592,0.7183098591549296l-2.154929577464789,2.154929577464789l-2.8732394366197185,0.7183098591549296l-5.028169014084507,2.154929577464789l-6.464788732394367,3.591549295774648l-10.774647887323944,3.591549295774648l-10.056338028169014,2.154929577464789l-9.338028169014084,2.154929577464789l-8.619718309859156,2.154929577464789l-9.338028169014084,3.591549295774648l-7.183098591549296,0l-7.183098591549296,0.7183098591549296l-5.028169014084507,0.7183098591549296l-5.746478873239437,1.4366197183098592l-5.746478873239437,0l-8.619718309859156,0l-12.211267605633804,0l-6.464788732394367,0l-8.619718309859156,-1.4366197183098592l-7.901408450704226,-3.591549295774648l-10.774647887323944,-5.746478873239437l-8.619718309859156,-5.028169014084507l-9.338028169014084,-5.746478873239437l-12.211267605633804,-9.338028169014084l-10.056338028169014,-10.056338028169014l-5.746478873239437,-7.901408450704226l-           6.464788732394367,-12.211267605633804l-2.154929577464789,-3.591549295774648l-5.028169014084507,-13.647887323943662l-2.154929577464789,-7.901408450704226l0,-7.183098591549296l0,-9.338028169014084l0,-5.746478873239437l2.8732394366197185,-7.901408450704226l5.028169014084507,-5.746478873239437l6.464788732394367,-7.183098591549296l10.774647887323944,-7.901408450704226l10.774647887323944,-6.464788732394367l15.084507042253522,-6.464788732394367l14.366197183098592,-6.464788732394367l22.267605633802816,-7.183098591549296l13.647887323943662,-3.591549295774648l14.366197183098592,-3.591549295774648l16.52112676056338,-0.7183098591549296l16.52112676056338,0l15.084507042253522,0l10.774647887323944,0l7.183098591549296,2.154929577464789l4.309859154929578,2.154929577464789l5.028169014084507,2.8732394366197185l3.591549295774648,2.154929577464789l3.591549295774648,2.8732394366197185l6.464788732394367,6.464788732394367l2.8732394366197185,4.309859154929578l2.154929577464789,2.154929577464789l2.154929577464789,4.309859154929578l1.4366197183098592,2.8732394366197185l2.154929577464789,5.028169014084507l0.7183098591549296,3.591549295774648l0.7183098591549296,5.028169014084507l0,5.028169014084507l0,4.309859154929578l0,7.183098591549296l-0.7183098591549296,2.8732394366197185l-3.591549295774648,6.464788732394367l-3.591549295774648,6.464788732394367l-4.309859154929578,5.028169014084507l-5.028169014084507,5.028169014084507l-7.183098591549296,4.309859154929578l-7.183098591549296,4.309859154929578l-10.774647887323944,6.464788732394367l-9.338028169014084,4.309859154929578l-9.338028169014084,4.309859154929578l-10.056338028169014,2.8732394366197185l-7.901408450704226,2.8732394366197185l-10.774647887323944,1.4366197183098592l-5.028169014084507,0.7183098591549296l-3.591549295774648,0l-2.8732394366197185,0l-3.591549295774648,0l-5.028169014084507,0l-5.746478873239437,0l-7.183098591549296,-1.4366197183098592l-5.746478873239437,-1.4366197183098592l-6.464788732394367,-2.8732394366197185l-4.309859154929578,-1.4366197183098592l-2.154929577464789,-1.4366197183098592l-1.4366197183098592,-0.7183098591549296l-1.4366197183098592,-0.7183098591549296l-0.7183098591549296,-0.7183098591549296l-1.4366197183098592,-1.4366197183098592l0,-0.7183098591549296l-1.4366197183098592,-0.7183098591549296l0,-1.4366197183098592l-0.7183098591549296,-0.7183098591549296l0,-0.7183098591549296",
                };
                // Add annotation to list
                annotations.Add(polylineAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddPolylineAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Add link annotation in Words
        /// </summary>
        public static void AddLinkAnnotationInWords()
        {
            try
            {
                //ExStart:AddLinkAnnotationInWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Polyline annotation
                AnnotationInfo link = new AnnotationInfo
                {
                    Box = new Rectangle(173.2986f, 154.3131f, 142.5f, 9),
                    //URL
                    FieldText = "https://www.google.com",
                    SvgPath = "[{\"x\":265.44,\"y\":388.83},{\"x\":472.19,\"y\":388.83},{\"x\": 265.44,\"y\":349.14},{\"x\":472.19,\"y\":349.14}]",
                    Type = AnnotationType.Link,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(link);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddLinkAnnotationInWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Shows how to add Ellipse Annotation in Words Document 
        /// </summary>
        public static void AddEllipseAnnotationInWords()
        {
            try
            {
                //ExStart:AddEllipseAnnotationInWords
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
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddEllipseAnnotationInWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }

}
