using System;
using System.Web.UI;

namespace GroupDocs.Annotation.Live.Demos.UI.AnnotationApp
{
	public partial class Launcher : Page
	{
        protected string extension = "";

        protected void Page_Load(object sender, EventArgs e)
		{
            if (RouteData.Values["extension"] != null)
            {
                extension = RouteData.Values["extension"].ToString();
            }

            if (String.IsNullOrEmpty(extension))
            {
                Title = "Free online document annotation app";
            }
            else
            {
                Title = String.Format(
                    "Free online document annotation app for {0}",
                    extension.ToUpper()
                );
            }

            MetaDescription = String.Format(
                "Annotate your {0}documents with many objects like rectangle, line, arrow etc. Add comments and reply to the comments. Add free form text and many more features.",
                extension.ToUpper() + " "
            );            
        }
    }
}
