using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

using WebParser.Infrastructure.Sites;

namespace WebParser.ServerRequest
{
    public class RequestServer
    {
        private Uri _uri;
        private readonly WebPageType _pageType;
        private readonly RequestType _requestType;
        private CookieCollection _cookies;
        private string _method;

        private RequestServer()
        {
            _method = WebRequestMethods.Http.Get;
            Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        }

        private RequestServer(WebPageType pageType, RequestType requestType, Uri uri)
            :this()
        {
            _uri = uri;
            _pageType = pageType;
            _requestType = requestType;
        }

        public static RequestServer Create<TPageType, TRequestType>(TPageType pageType, TRequestType requestType, Uri uri)
        {
            return new RequestServer(
                ((WebPageType)Convert.ToInt32(pageType)),
                ((RequestType)Convert.ToInt32(requestType)),
                uri);
        }


        #region Определение свойств WebPageRequest
        public virtual Uri Uri { get; set; }

        public virtual CookieCollection Cookies { get; set; }

        public virtual string Method { get; set; }

        public virtual string ContentType { get; set; }

        public virtual string Accept { get; set; }

        public virtual string Referer { get; set; }

        public virtual object Data { get; set; }
        #endregion

    }
}
