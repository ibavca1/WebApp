using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;

using WebParser.BavcNetFramework.DataTypes;
using WebParser.BavcNetFramework.Interfaces;

namespace WebParser.BavcNetFramework
{
    public class HttpParserWebRequest
    {
        #region Свойства
        public WebRequestType RequestType { get { return WebRequestType.Http; } }
        #endregion

        #region LoadPageContent
        /// <summary>
        /// Загрузить страницу с сервера
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encoding"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual WebPageContent LoadPageContent(BasicParserWebRequest request, Encoding encoding, TimeSpan timeout)
        {
            //Временно устанавливаем time out 20 сек.
            WebRequest webRequest = Create(request, TimeSpan.FromSeconds(20));
            WebResponse webResponse = webRequest.GetResponse();
            return CreateContent(webResponse, encoding);
            //throw new NotImplementedException();
        }
        #endregion

        #region Create
        /// <summary>
        /// Создать запрос к серверу.
        /// RequestType = HTTP
        /// static для размещения в High Frequency Heap (HFH)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private static WebRequest Create(BasicParserWebRequest request, TimeSpan timeout, WebProxy proxy = null)
        {
            HttpWebRequest webRequest = WebRequest.CreateDefault(request.Uri) as HttpWebRequest;
            webRequest.Proxy = proxy;
            webRequest.Timeout = (int)timeout.TotalMilliseconds;
            webRequest.Method = request.Method;
            webRequest.CookieContainer = new CookieContainer();
            webRequest.CookieContainer.Add(request.Cookies);
            webRequest.Accept = request.Accept;
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            webRequest.UserAgent = request.UserAgent;
            return webRequest;
            //throw new NotImplementedException();
        }
        #endregion

        #region CreateContent
        /// <summary>
        /// Получить ответ и создать страницу.
        /// static для размещения в High Frequency Heap (HFH)
        /// </summary>
        /// <param name="resonse"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static WebPageContent CreateContent(WebResponse response, Encoding encoding)
        {
            string text = GetResponseText(response, encoding);
            WebPageContent content = new WebPageContent(text) { Encoding = encoding };
            HttpWebResponse httpResponse = response as HttpWebResponse;
            if (httpResponse != null)
                content.Cookies = httpResponse.Cookies;
            return content;
            throw new NotImplementedException();
        }
        #endregion 

        #region GetResponseText
        /// <summary>
        /// Получить текст ответа сервера
        /// static для размещения в High Frequency Heap (HFH)
        /// </summary>
        /// <param name="response"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string GetResponseText(WebResponse response, Encoding encoding)
        {
            using(Stream responseStream=response.GetResponseStream())
            {
                if (responseStream == null)
                    return null;
                using (StreamReader reader=new StreamReader(responseStream,encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion 
    }


    /// <summary>
    /// Набросок класс содержания веб страницы
    /// </summary>
    #region class WebPageContent
    public class WebPageContent
    {
        private Encoding _encoding;
        private CookieCollection _cookies;
        private readonly string _content;

        protected WebPageContent(Encoding encoding)
        {
            _encoding = encoding;
        }

        protected WebPageContent()
            :this(Encoding.UTF8)
        {

        }

        public WebPageContent(string content)
        {
            _content = content;
        }

        public CookieCollection Cookies
        {
            get
            {
                return _cookies ?? (_cookies = new CookieCollection());
            }
            set
            {
                _cookies = value;
            }
        }

        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        protected virtual string Content
        {
            get { return _content; }
        }

        public virtual byte[] ReadAsByte()
        {
            return Encoding.GetBytes(Content);
        }

        public virtual string ReadAsString()
        {
            return Content;
        }
    }
    #endregion
}
