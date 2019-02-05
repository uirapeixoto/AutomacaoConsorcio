using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Automacao.Core.Helper
{
    public class BrowserSession : IDisposable
    {
        private bool _isPost;
        private HtmlDocument _htmlDoc;

        #region Novos Atributos

        public Dictionary<string, string> extraHeader;

        public List<string> toRemoveHeader;

        public bool IsXMLPost { get; set; }

        public string XmlToPost { get; set; }

        public string lasUrl;


        public string EncodingTexto { get; set; }
        
        public string JavaScriptText { get; set; }

        public bool UseCredentials { get; set; }

        public NetworkCredential Credentials { get; set; }

        public bool AutoRedirect { get; set; }

        public string FileName { get; set; }

        public string LastContentType { get; set; }
        public string RTFData { get; private set; }
        public string InternalError { get; private set; }

        #endregion

        /// <summary>
        /// System.Net.CookieCollection. Provides a collection container for instances of Cookie class 
        /// </summary>
        public CookieCollection Cookies { get; set; }

        /// <summary>
        /// Provide a key-value-pair collection of form elements 
        /// </summary>
        public FormElementCollection FormElements { get; set; }

        /// <summary>
        /// Makes a HTTP GET request to the given URL
        /// </summary>
        public string Get(string url)
        {
            _isPost = false;
            CreateWebRequestObject().Load(url);
            return _htmlDoc.DocumentNode.InnerHtml;
        }

        /// <summary>
        /// Makes a HTTP POST request to the given URL
        /// </summary>
        public string Post(string url)
        {
            _isPost = true;
            CreateWebRequestObject().Load(url, "POST");
            return _htmlDoc.DocumentNode.InnerHtml;
        }

        

        /// <summary>
        /// Event handler for HtmlWeb.PreRequestHandler. Occurs before an HTTP request is executed.
        /// </summary>
        /*protected bool OnPreRequest(HttpWebRequest request)
        {
            AddCookiesTo(request);               // Add cookies that were saved from previous requests
            if (_isPost) AddPostDataTo(request); // We only need to add post data on a POST request
            return true;
        }*/

        /// <summary>
        /// Event handler for HtmlWeb.PostResponseHandler. Occurs after a HTTP response is received
        /// </summary>
        protected void OnAfterResponse(HttpWebRequest request, HttpWebResponse response)
        {
            SaveCookiesFrom(response); // Save cookies for subsequent requests
        }

        /// <summary>
        /// Event handler for HtmlWeb.PreHandleDocumentHandler. Occurs before a HTML document is handled
        /// </summary>
        protected void OnPreHandleDocument(HtmlDocument document)
        {
            SaveHtmlDocument(document);
        }

        /// <summary>
        /// Creates the HtmlWeb object and initializes all event handlers. 
        /// </summary>
        private HtmlWeb CreateWebRequestObject()
        {
            var dsEnc = "ISO-8859-1";
            if (EncodingTexto != null)
                if (EncodingTexto != string.Empty)
                    dsEnc = EncodingTexto;
            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding(dsEnc)
            };


            web.UseCookies = true;
            web.PreRequest = new HtmlWeb.PreRequestHandler(OnPreRequest);
            web.PostResponse = new HtmlWeb.PostResponseHandler(OnAfterResponse);
            web.PreHandleDocument = new HtmlWeb.PreHandleDocumentHandler(OnPreHandleDocument);
            return web;
        }

        /// <summary>
        /// Assembles the Post data and attaches to the request object
        /// </summary>
        private void AddPostDataTo(HttpWebRequest request)
        {
            string payload = FormElements.AssemblePostPayload();
            byte[] buff = Encoding.UTF8.GetBytes(payload.ToCharArray());
            request.ContentLength = buff.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            System.IO.Stream reqStream = request.GetRequestStream();
            reqStream.Write(buff, 0, buff.Length);
        }

        /// <summary>
        /// Add cookies to the request object
        /// </summary>
        private void AddCookiesTo(HttpWebRequest request)
        {
            if (Cookies != null && Cookies.Count > 0)
            {
                request.CookieContainer.Add(Cookies);
            }
        }

        /// <summary>
        /// Saves cookies from the response object to the local CookieCollection object
        /// </summary>
        private void SaveCookiesFrom(HttpWebResponse response)
        {
            if (response.Cookies.Count > 0)
            {
                if (Cookies == null) Cookies = new CookieCollection();
                Cookies.Add(response.Cookies);
            }
        }

        /// <summary>
        /// Saves the form elements collection by parsing the HTML document
        /// </summary>
        private void SaveHtmlDocument(HtmlDocument document)
        {
            _htmlDoc = document;
            FormElements = new FormElementCollection(_htmlDoc);
        }

        /// <summary>
        /// Author: Felipe Guaneri
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string PostJs(string url)
        {
            _isPost = true;

            CreateWebRequestObject().Load(url, "POST");
            if (string.IsNullOrEmpty(this.JavaScriptText))
                return _htmlDoc.DocumentNode.InnerHtml;
            return this.JavaScriptText;
        }

        /// <summary>
        /// Author: Felipe Guaneri 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmlDocument PostAndReturnDocumentNode(string url)
        {
            _isPost = true;

            CreateWebRequestObject().Load(url, "POST");
            return _htmlDoc;
        }

        /// <summary>
        /// Event handler for HtmlWeb.PreRequestHandler. Occurs before an HTTP request is executed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected bool OnPreRequest(HttpWebRequest request)
        {
            request.UserAgent = SettingsManager.GetSessionUserAgent();
            WebHeaderCollection myWebHeaderCollection = request.Headers;

            if (UseCredentials)
            {
                request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
                request.Credentials = Credentials;
            }
            request.AllowAutoRedirect = this.AutoRedirect;
            myWebHeaderCollection.Add("Accept-Language", SettingsManager.GetSessionAcceptLanguage());
            myWebHeaderCollection.Add("AcceptCharset", SettingsManager.GetSessionAcceptCharset());
            myWebHeaderCollection.Add("TransferEncoding", SettingsManager.GetSessionTransferEncoding());
            if (extraHeader != null)
            {
                foreach (var kv in extraHeader)
                {
                    if (myWebHeaderCollection.Get(kv.Key) == null)
                        myWebHeaderCollection.Add(kv.Key, kv.Value);
                }
            }
            if (toRemoveHeader != null)
            {
                foreach (var r in toRemoveHeader)
                {
                    if (myWebHeaderCollection.Get(r) != null)
                        myWebHeaderCollection.Remove(r);
                }
            }

            request.Referer = lasUrl;


            AddCookiesTo(request);               // Add cookies that were saved from previous requests

            if (_isPost) AddPostDataTo(request); // We only need to add post data on a POST request
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetRTF(string url)
        {
            _isPost = false;
            try
            {


                CreateWebRequestObject().Load(url);

                if (string.IsNullOrEmpty(this.RTFData))
                    return _htmlDoc.DocumentNode.InnerHtml;
            }
            catch (Exception ex)
            {
                this.InternalError = ex.ToString();
            }
            return this.RTFData;
        }

        public void Dispose()
        {
        }
    }
}
