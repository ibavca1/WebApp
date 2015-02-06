using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebParser.BavcNetFramework.DataTypes;

namespace WebParser.BavcNetFramework
{
    public class Parser:BasicParserWebRequest
    {
        private static HttpParserWebRequest _httpWebRequest;
        private static JsonParserWebRequest _jsonWebRequest;
        private class Parsers:IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return _httpWebRequest;
                yield return _jsonWebRequest;
            }

        }
        private WebRequestType _requestType;

        public Parser(WebRequestType requestType)
            : base(requestType, new Uri("http://google.com"))
        {
            _requestType = requestType;
            switch(_requestType)
            {
                case WebRequestType.Http:
                    _httpWebRequest = new HttpParserWebRequest();
                    break;
                case WebRequestType.Json:
                    _jsonWebRequest = new JsonParserWebRequest();
                    break;
            }
        }

        public Object ParserWebRequest 
        { 
            get
            {
                foreach(var p in new Parsers())
                {
                    if (p != null)
                        return p;
                }
                return null;
            }
        }
    }
}
