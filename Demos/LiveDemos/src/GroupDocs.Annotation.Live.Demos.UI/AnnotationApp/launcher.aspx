<%@ Page Language="C#" CodeBehind="launcher.aspx.cs" Inherits="GroupDocs.Annotation.Live.Demos.UI.AnnotationApp.Launcher" AutoEventWireup="true" MasterPageFile="~/site.Master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<script src="https://cms.dynabic.com/templates/aspose/js/bootstrap.js?v=331"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.7.7/angular.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.7.7/angular-route.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.7.7/angular-animate.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.7.7/angular-aria.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.7.7/angular-resource.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.7.7/angular-messages.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/danialfarid-angular-file-upload/12.2.13/ng-file-upload-all.min.js"></script>

<script src="/AnnotationApp/const.js"></script>
<script type="text/javascript">
    var REQUESTED_EXTENSION = <%= Page.RouteData.Values["extension"] != null ? "\"" + Page.RouteData.Values["extension"] + "\"" : "null" %>;
    var REQUESTED_FILEFORMAT = <%= "null" %>;
</script>
<script src="/AnnotationApp/launcher.js"></script>

<div ng-app="GroupDocsAnnotationLauncher" ng-cloak ng-controller="Main">

    <div class="container-fluid GroupDocsApps pb5">
        <div class="container">
            <div class="row">

                <div class="col-md-12 pt-5 pb-5">
                    <h1 id="hFeatureTitle" ng-hide="REQUESTED_EXTENSION">Free Online Document Annotation</h1>
                    <h1 id="hFeatureTitle" ng-show="REQUESTED_EXTENSION">Free Online {{REQUESTED_EXTENSION}} file Annotation</h1>
                    <h4 id="hPageTitle" ng-hide="REQUESTED_EXTENSION">Annotate, Comment and Tag and your Document Contents for Efficient Collaboration</h4>
                    <h4 id="hPageTitle" ng-show="REQUESTED_EXTENSION">Annotate, Comment and Tag and your {{REQUESTED_EXTENSION}} file for Efficient Collaboration</h4>
                    <ng-form class="form" onsubmit="return false">
                        <div class="uploadfile">

                            <div class="filedropdown">
                                <div class="filedrop">
                                    <label class="dz-message needsclick">
                                        Drop or upload your file
                                    </label>
                                    <input type="file"
                                           ngf-select
                                           ng-model="inputFile.file"
                                           accept="{{ REQUESTED_EXTENSION ? '.' + REQUESTED_EXTENSION : '*/*'  }}"
                                           ngf-max-size="100MB"
                                           ngf-model-invalid="inputFile.error"
                                           required/>
                                    <br/>

                                    <div class="fileupload" ng-show="inputFile.file">
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-striped progress-bar-success progress-bar-animated"
                                                 style="width:{{inputFile.progress}}%"></div>
                                        </div>
                                        <span class="filename" ng-show="inputFile.file.name">
                                            <a ng-click="inputFile={}">
                                                <label class="custom-file-upload">{{inputFile.file.name}}</label>
                                                <i class="fa fa-times">&nbsp;</i>
                                            </a>
                                        </span>
                                    </div>
                                </div>

                                <p id="pMessage"
                                   style="width: 65%; position: relative; color: red; margin: 50px auto 30px;">
                                </p>

                                <div class="convertbtn">
                                    <span ng-click="uploadInputFile()" class="btn btn-success btn-lg"
                                            ng-disabled="!inputFile.file || inputFile.progress">
                                        <i class="fa fa-file-upload">&nbsp;</i>
                                        Upload &amp; Start
                                    </span>
                                </div>
                            </div>
                        </div>
                    </ng-form>

                </div>
            </div>
        </div>
    </div>


    <section class="col-md-12 pull-left d-flex d-wrap bg-gray appfeaturesectionlist" ng-show="REQUESTED_FILEFORMAT">
        <div class="col-md-6 cardbox tc col-md-offset-3 b6">
            <h3>
                <em class="icofile"><b>{{REQUESTED_FILEFORMAT.Extension}}</b></em>
                <span>{{REQUESTED_FILEFORMAT.Name}}</span>
            </h3>
            <p>
                {{REQUESTED_FILEFORMAT.Description}}
                <br><br>
                <a target="_blank" href="{{REQUESTED_FILEFORMAT.FileFormat_Com_URL}}" class="btn btn-success btn-sm">Read More</a>
            </p>
        </div>
    </section>

    <section class="col-md-12 pt-5 bg-gray tc" ng-show="REQUESTED_FILEFORMAT === null">
        <div class="container">
            <div class="col-md-12 pull-left">
                <h2 class="h2title">GroupDocs.Annotation App</h2>
                <p>GroupDocs.Annotation App Supported Document Formats</p>
            </div>
        </div>
        <div class="clearfix"></div>
        <div>
            <div class="diagram1 d2 d1-net">
                <div class="d1-row">
                    <div class="d1-col d1-left">
                        <header>Microsoft Office Formats</header>
                        <ul>
                            <li><strong>Microsoft Word:</strong> DOC, DOCX, DOCM, DOT, DOTX, RTF</li>
                            <li><strong>Microsoft Excel:</strong> XLS, XLSX, XLSM, XLSB, CSV</li>
                            <li><strong>Microsoft PowerPoint:</strong> PPT, PPTX, PPTM, POTX, POTM, PPSM, PPS, PPSX</li>
                            <li><strong>Microsoft Visio:</strong> VSD, VSS, VSDX, VST</li>
                        </ul>
                    </div>
                    <div class="d1-col d1-right">
                        <header>Other Formats</header>
                        <ul>
                            <li><strong>Portable:</strong> PDF (PDF/A-1a, PDF/A-1b, PDF/A-2a)</li>
                            <li><strong>OpenDocument:</strong> OTP, ODT, OTT, ODS, ODP</li>
                            <li><strong>Images:</strong> BMP, GIF, JPG, JPEG, PNG, TIFF</li>
                            <li><strong>AutoCAD:</strong> CAD, DWG, DXF</li>
                            <li><strong>Metafiles:</strong> EMF, WMF</li>
                            <li><strong>Email:</strong> EML, EMLX, MSG</li>
                            <li><strong>Web:</strong> HTM, HTML</li>
                            <li><strong>Others:</strong> DICOM, DjVu</li>
                        </ul>
                    </div>
                </div>
                <div class="d1-logo">
                    <img src="//www.groupdocs.cloud/templates/groupdocs/images/product-logos/90x90-noborder/groupdocs-annotation-net.png" alt="GroupDocs.Annotation App">
                    <header>GroupDocs.Annotation App</header>
                </div>
            </div>
        </div>
    </section>

    <section class="col-md-12 tl bg-darkgray howtolist">
		<div class="container tl dflex">

			<div class="col-md-4 howtosectiongfx">
				<img src="/img/howto.png">
			</div>
			<div class="howtosection col-md-8">
				<div>
					<h4><i class="fa fa-question-circle "></i>&nbsp;<b>How to annotate a {{REQUESTED_EXTENSION}} file using GroupDocs.Annotation App</b></h4>
					<ul>
						<li>Click inside the file drop area to upload a {{REQUESTED_EXTENSION}} file or drag &amp; drop a {{REQUESTED_EXTENSION}} file.</li>
                        <li>Click Upload to start uploading.</li>
						<li>File will be automatically rendered for you to view instantly.</li>
						<li>View your {{REQUESTED_EXTENSION}} file and navigate through pages.</li>
						<li>Create annotations on your {{REQUESTED_EXTENSION}} file.</li>
						<li>Download the annotated version of your {{REQUESTED_EXTENSION}} file.</li>
					</ul>
				</div>
			</div>
		</div>
	</section>

    <section class="col-md-12 pt-5 app-features-section">
        <div class="container tc pt-5">
            <div class="row m-0">
            <div class="col-md-4">
                <div class="imgcircle fasteasy">
                    <img src="//products.groupdocs.app/img/fast-easy.png">
                </div>
                <h4>Fast and Easy Annotation</h4>
                <p>Upload your file to start annotating.</p>
            </div>
            <div class="col-md-4">
                <div class="imgcircle anywhere">
                    <img src="//products.groupdocs.app/img/anywhere.png">
                </div>
                <h4>Annotate from Anywhere</h4>
                <p>It works from all platforms including Windows, Mac, Android and iOS. All files are processed on our servers. No plugin or software installation required for you.</p>
            </div>
            <div class="col-md-4">
                <div class="imgcircle quality">
                    <img src="//products.groupdocs.app/img/quality.png">
                </div>
                <h4>Annotation Quality</h4>
                <p>Powered by <a href="https://products.groupdocs.com/annotation/net" target="_blank">GroupDocs.Annotation</a>. All files are processed using GroupDocs APIs.</p>
            </div>
            </div>
        </div>
    </section>

</div>

</asp:Content>
