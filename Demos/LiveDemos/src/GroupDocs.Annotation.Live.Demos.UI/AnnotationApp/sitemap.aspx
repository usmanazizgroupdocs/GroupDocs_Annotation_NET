<%@ Page Language="C#" AutoEventWireup="true" ContentType="text/xml"%>

<%
    string[] extensions = "DOC DOCX DOCM DOT DOTX RTF XLS XLSX XLSM XLSB CSV PPT PPTX PPTM POTX POTM PPSM PPS PPSX VSD VSS VSDX VST PDF OTP ODT OTT ODS ODP BMP GIF JPG JPEG PNG TIFF CAD DWG DXF EMF WMF EML EMLX MSG HTM HTML DICOM DjVu".Split(' ');
%>

<!-- Generated on <%= System.DateTime.Now.ToString("MMMM d, yyyy") %> -->

<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
    <url>
        <loc>https://products.groupdocs.app/annotation/total</loc>
        <priority>0.9</priority>
    </url>
    <%foreach (var e in extensions) { %><url>
        <loc>https://products.groupdocs.app/annotation/<%= e.ToLower() %></loc>
        <priority>0.9</priority>
    </url><% } %>
</urlset>
