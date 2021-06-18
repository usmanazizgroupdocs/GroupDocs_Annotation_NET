using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using GroupDocs.Annotation.Config;
using GroupDocs.Annotation.Domain;
using GroupDocs.Annotation.Domain.Containers;
using GroupDocs.Annotation.Domain.Image;
using GroupDocs.Annotation.Domain.Options;
using GroupDocs.Annotation.Domain.Results;
using GroupDocs.Annotation.Handler;
using GroupDocs.Annotation.Handler.Input;
using GroupDocs.Annotation.Handler.Input.DataObjects;

namespace GroupDocs.Annotation.Live.Demos.UI.Controllers
{
    public class GroupDocsAnnotationController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Upload(string jid)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return createErrorResponse("UnsupportedMediaType", "The request must be MIME multipart content.", HttpStatusCode.UnsupportedMediaType);
            }

            string file = null;

            try
            {
                var provider = new MultipartFormDataStreamProvider(getStoragePath(jid));
                await Request.Content.ReadAsMultipartAsync(provider);

                MultipartFileData fd = provider.FileData.First<MultipartFileData>();
                file = fd.Headers.ContentDisposition.FileName.Trim('"');
                File.Copy(fd.LocalFileName, Path.Combine(getStoragePath(jid), file), true);
                File.Delete(fd.LocalFileName);
            } catch (System.Exception x)
            {
                return createErrorResponseAndReport("File could not be uploaded. Please try again.", x.Message + " jid=" + jid, x);
            }

            if (file != null)
            {
                try
                {
                    AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
                    imageHandler.RemoveDocument(file);
                    imageHandler.CreateDocument(file);
                    return createJsonResponseFromObject(null);
                } catch (System.Exception x)
                {
                    return createErrorResponseAndReport("Could not import the uploaded file", x.Message, x);
                }
            }

            return createErrorResponse("Load error", "Could not import the uploaded file");
        }

        [HttpGet]
        public HttpResponseMessage GetDocumentInfo(string jid, string file)
        {
            AnnotationImageHandler handler = createAnnotationImageHandler(jid);
            try
            {
                DocumentInfoContainer result = handler.GetDocumentInfo(file);
                return createJsonResponseFromObject(result);
            } catch (System.Exception x)
            {
                return createErrorResponseAndReport("Error occurred while processing document info", x.Message + " jid=" + jid, x);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAnnotationsList(string jid, string file)
        {
            try
            {
                AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
                Document doc = findDocumentByName(jid, file);
                ListAnnotationsResult listResult = imageHandler.GetAnnotations(doc.Id);
                List<GetAnnotationResult> list = new List<GetAnnotationResult>();
                foreach (AnnotationInfo inf in listResult.Annotations)
                {
                    list.Add(imageHandler.GetAnnotation(inf.Guid));
                }
                return createJsonResponseFromObject(list);
            }
            catch (System.Exception x)
            {
                return createErrorResponseAndReport("Error occurred while processing document annotations", x.Message  + " jid=" + jid, x);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddAnnotation(string jid, string file)
        {
            AnnotationInfo annotation = createObjectFromJsonRequest<AnnotationInfo>(Request);
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            Document doc = findDocumentByName(jid, file);
            annotation.DocumentGuid = doc.Id;
            CreateAnnotationResult result = imageHandler.CreateAnnotation(annotation);
            imageHandler.CreateAnnotationReply(result.Id, "");
            return createJsonResponseFromObject(result);
        }

        [HttpGet]
        public HttpResponseMessage GetAnnotation(string jid, string guid)
        {
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            AnnotationInfo result = imageHandler.GetAnnotation(guid).Annotation;
            return createJsonResponseFromObject(result);
        }

        [HttpPost]
        public HttpResponseMessage DeleteAnnotation(string jid, string guid)
        {
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            long annotationId = imageHandler.GetAnnotation(guid).Id;
            DeleteAnnotationResult result = imageHandler.DeleteAnnotation(annotationId);
            return createJsonResponseFromObject(result);
        }

        [HttpPost]
        public HttpResponseMessage UpdateAnnotationFieldText(string jid, string guid)
        {
            TextFieldInfo info = createObjectFromJsonRequest<TextFieldInfo>(Request);
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            AnnotationInfo annotationInfo = imageHandler.GetAnnotation(guid).Annotation;
            long annotationId = imageHandler.GetAnnotation(guid).Id;
            SaveAnnotationTextResult result = imageHandler.SaveTextField(annotationId, info);
            return createJsonResponseFromObject(result);
        }

        [HttpPost]
        public HttpResponseMessage UpdateAnnotationPosition(string jid, string guid)
        {
            Point point = createObjectFromJsonRequest<Point>(Request);
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            AnnotationInfo annotationInfo = imageHandler.GetAnnotation(guid).Annotation;
            long annotationId = imageHandler.GetAnnotation(guid).Id;
            MoveAnnotationResult result = imageHandler.MoveAnnotationMarker(annotationId, point, annotationInfo.PageNumber);
            return createJsonResponseFromObject(result);
        }

        [HttpGet]
        public HttpResponseMessage GetPageImage_1(string jid, string file, int page, int width=0, int height=0)
        {
            AnnotationImageHandler handler = createAnnotationImageHandler(jid);
            ImageOptions o = new ImageOptions();
            //o.PageNumber = page;
            o.WithoutAnnotations = true;
            o.Width = width;
            o.Height = height;
            o.EnableCaching = true;
            Stream stream = null;
            List<PageImage> list = handler.GetPages(file, o);
            foreach (PageImage pageImage in list.Where(x => x.PageNumber == page))
            {
                stream = pageImage.Stream;
            }
            if (stream == null || !stream.CanSeek)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            stream.Seek(0, SeekOrigin.Begin);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return result;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPageImage(string jid, string file, int page, int width = 0, int height = 0)
        {
            return await Task.Run(() => {
                AnnotationImageHandler handler = createAnnotationImageHandler(jid);
                ImageOptions o = new ImageOptions();
                //o.PageNumber = page;
                o.WithoutAnnotations = true;
                o.Width = width;
                o.Height = height;
                o.EnableCaching = true;
                Stream stream = null;
                List<PageImage> list = handler.GetPages(file, o);
                foreach (PageImage pageImage in list.Where(x => x.PageNumber == page))
                {
                    stream = pageImage.Stream;
                }
                if (stream == null || !stream.CanSeek)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                stream.Seek(0, SeekOrigin.Begin);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            });
        }

        [HttpGet]
        public async Task<HttpResponseMessage> DownloadAnnotatedFile(string jid, string file)
        {
            return await Task.Run(()=> {
                try
                {
                    AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
                    Document document = findDocumentByName(jid, file);
                    List<AnnotationInfo> list = imageHandler.GetAnnotations(document.Id).Annotations.ToList<AnnotationInfo>();
                    Stream exported;
                    using (FileStream original = new FileStream(Path.Combine(getStoragePath(jid), file), FileMode.Open))
                    {
                        exported = imageHandler.ExportAnnotationsToDocument(original, list);
                    }
                    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                    exported.Seek(0, SeekOrigin.Begin);
                    result.Content = new StreamContent(exported);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = "Annotated " + file;
                    return result;
                }
                catch (System.Exception x)
                {
                    return createErrorResponseAndReport(
                        "Unable to export annotated document",
                        x.Message + " jid=" + jid,
                        x
                    );
                }
            });
        }

        [HttpGet]
        public HttpResponseMessage GetAnnotationReplyList(string jid, string guid)
        {
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            GetAnnotationResult annotationResult = imageHandler.GetAnnotation(guid);
            if (annotationResult == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            long annotationId = annotationResult.Id;
            List<AnnotationReplyInfo> list = imageHandler.ListAnnotationReplies(annotationId).Replies.ToList<AnnotationReplyInfo>();
            return createJsonResponseFromObject(list);
        }

        [HttpPost]
        public HttpResponseMessage AddReply(string jid, string guid)
        {
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            long annotationId = imageHandler.GetAnnotation(guid).Id;
            AddReplyResult result = imageHandler.CreateAnnotationReply(annotationId, "");
            return createJsonResponseFromObject(result);
        }

        [HttpPost]
        public HttpResponseMessage DeleteReply(string jid, string guid)
        {
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            DeleteReplyResult result = imageHandler.DeleteAnnotationReply(guid);
            return createJsonResponseFromObject(result);
        }

        [HttpPost]
        public HttpResponseMessage UpdateReplyMessage(string jid)
        {
            AnnotationReplyInfo info = createObjectFromJsonRequest<AnnotationReplyInfo>(Request);
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            EditReplyResult result = imageHandler.EditAnnotationReply(info.Guid, info.Message);
            return createJsonResponseFromObject(result);
        }

        private AnnotationImageHandler createAnnotationImageHandler(string jid)
        {
            AnnotationConfig cfg = new AnnotationConfig();
            cfg.StoragePath = getStoragePath(jid);
            AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
            return annotator;
        }

        private Document findDocumentByName(string jid, string file)
        {
            AnnotationImageHandler imageHandler = createAnnotationImageHandler(jid);
            IDocumentDataHandler documentDataHandler = imageHandler.GetDocumentDataHandler();
            Document doc = documentDataHandler.GetDocument(file);
            return doc;
        }

        private string getStoragePath(string jid)
        {
            string path = Path.Combine(AppSettings.WorkingDirectory, jid);
            Directory.CreateDirectory(path);
            return path;
        }

        private HttpResponseMessage createJsonResponseFromObject(object o)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(o));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        private HttpResponseMessage createErrorResponse(string message, string details, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            HttpResponseMessage response = new HttpResponseMessage(status);
            Hashtable result = new Hashtable();
            result["status"] = (int) status;
            result["message"] = message;
            result["details"] = details;
            response.Content = new StringContent(JsonConvert.SerializeObject(result));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        private HttpResponseMessage createErrorResponseAndReport(string message, string details, System.Exception x, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return createErrorResponse(message, details, status);
            }

        private T createObjectFromJsonRequest<T>(HttpRequestMessage request)
        {
            T result = JsonConvert.DeserializeObject<T>(request.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult());
            return result;
        }

    }
}
