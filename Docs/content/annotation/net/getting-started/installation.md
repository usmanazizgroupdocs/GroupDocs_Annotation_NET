---
id: installation
url: annotation/net/installation
title: Development Environment Installation and Configuration
weight: 4
description: ""
keywords: 
productName: GroupDocs.Annotation for .NET
hideChildren: False
---
## Install from Nuget

NuGet is the easiest way to download and install GroupDocs.Annotation for .NET. There are ways to install it in your project.

#### Install via Package Manager GUI

Follow these steps to reference GroupDocs.Annotation using Package Manager GUI:

*   Open your solution/project in Visual Studio.
*   Click **Tools** -> **NuGet Package Manager** -> **Manage NuGet Packages for Solution**. You can also access the same option through the Solution Explorer. Right-click the solution or project and select Manage NuGet Packages from the context menu.
*   Select Browse tab and type **"GroupDocs.Annotation"** in the search text box.
*   Click the **Install** button to install the latest version of the API into your project as shown in the following screenshot.
![](annotation/net/images/installation.png)
    

#### Using Package Manager Console

You can follow the steps below to reference GroupDocs.Annotation for .NET using the Package Manager Console:

*   Open your solution/project in Visual Studio.
*   Select **Tools** -> **NuGet Package Manager** -> **Package Manager Console** from the menu to open package manager console.
*   Type the command **"Install-Package GroupDocs.Annotation"** and press enter to install the latest release into your application.
*   After successful installation, GroupDocs.Annotation will be referenced in your application.  
    
![](annotation/net/images/installation_1.png)
    

## Install from official GroupDocs website

You can follow the steps below to reference GroupDocs.Annotation for .NET downloaded from official website [Downloads section](https://downloads.groupdocs.com/annotation/net):

1.  Unpack zip archive or follow MSI install wizard instructions.
2.  In the **Solution Explorer**, expand the project node you want to add a reference to.
3.  Right-click the **References** node for the project and select **Add Reference** from the menu.
4.  In the Add Reference dialog box, select the **.NET** tab (it's usually selected by default).
5.  If you have used MSI installer to install GroupDocs.Annotation, you will see GroupDocs.Annotation in the top pane. Select it and then click the **Select** button.
6.  If you have downloaded and unpacked the DLL only, click the **Browse** button and locate the GroupDocs.Annotation.dll file.   
    You have referenced GroupDocs.Annotation and it should appear in the **SelectedComponents** pane of the dialog box.
7.  Click **OK**.   
    GroupDocs.Annotation reference appears under the **References** node of the project.
