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
    public class RequestHttp
    {
        private WebPageType _pageType;
        private readonly RequestType _requestType;
        private Uri _uri;

        private readonly RequestServer _requestServer;

        public RequestHttp()
        {
            _requestType = RequestType.Http;
            _requestServer = RequestServer.Create(_pageType, _requestType, _uri);
        }

        public RequestHttp(WebPageType pageType, Uri uri) :
            this()
        {
            _pageType = pageType;
            _uri = uri;
        }

        public RequestServer WebRequestServer
        {
            get
            {
                return _requestServer;
            }
        }

        public HttpWebRequest WebRequestHttp
        {
            get 
            {
                var request=WebRequest.Create(_uri) as HttpWebRequest;
                request.Accept = _requestServer.Accept;
                request.Method = _requestServer.Method;
                return request;
            }
        }
    }
}
