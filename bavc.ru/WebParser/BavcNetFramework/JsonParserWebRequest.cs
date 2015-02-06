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
    public class JsonParserWebRequest
    {
        #region Свойства
        public WebRequestType RequestType { get { return WebRequestType.Json; } }
        #endregion
    }
}
