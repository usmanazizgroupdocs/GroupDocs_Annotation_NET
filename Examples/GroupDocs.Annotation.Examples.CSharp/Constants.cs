using System.IO;
using System.Runtime.CompilerServices;

namespace GroupDocs.Annotation.Examples.CSharp
{
    internal static class Constants
    {
        public const string LicensePath = "C://licenses//GroupDocs.Annotation.lic";
        public const string SamplesPath = "../../../Resources/SampleFiles";
        public const string OutputPath = "../../Output/";
        public static string INPUT => GetSampleFilePath("input.pdf");
        public static string ANNOTATED_WITH_REPLIES => GetSampleFilePath("annotated_with_replies.pdf");
        
        public static string INPUT_PROTECTED => GetSampleFilePath("input_protected.pdf");
        public static string RESULT => GetSampleFilePath("result.pdf");
        public static string ANNOTATED => GetSampleFilePath("annotated.pdf");
        private static string GetSampleFilePath(string filePath) => Path.Combine(SamplesPath, filePath);

        public static string GetOutputDirectoryPath([CallerFilePath] string callerFilePath = null)
        {
            string outputDirectory = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(callerFilePath));
            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);
            return outputDirectory;
        }
    }
}