using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

using WebParser.BavcNetFramework.DataTypes;
using WebParser.BavcNetFramework.Interfaces;

namespace WebParser.BavcNetFramework
{
    public class BasicParserWebRequest:IParserWebRequest
    {
        private string _accept;
        private string _method;
        private string _userAgent;
        private Uri _uri;
        private WebRequestType _requestType;
        private CookieCollection _cookies;
        
        #region Свойства
        public string Accept
        {
            get
            {
                return _accept;
            }
            set
            {
                _accept = value;
            }
        }
        public string Method 
        {
            get
            {
                return _method;
            }
            set
            {
                _method = value;
            }
        }
        public string UserAgent
        {
            get
            {
                return _userAgent;
            }
            set
            {
                _userAgent = value;
            }
        }
        public Uri Uri 
        {
            get
            {
                return _uri;
            }
            set
            {
                _uri = value;
            }
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
        #endregion

        public BasicParserWebRequest()
        {
            _accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            _method = WebRequestMethods.Http.Get;
            _userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
        }

        public BasicParserWebRequest(WebRequestType requestType, Uri uri)
            :this()
        {
            _requestType = requestType;
            _uri = uri;
        }

        public static BasicParserWebRequest Create<TRequestType>(TRequestType requestType, Uri uri)
        {
            var type = (WebRequestType)Convert.ToInt32(requestType);
            return new BasicParserWebRequest(type, uri);
        }
    }
}
