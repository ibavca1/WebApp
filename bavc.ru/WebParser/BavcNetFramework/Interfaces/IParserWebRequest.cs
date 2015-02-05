using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.BavcNetFramework.Interfaces
{
    public interface IParserWebRequest
    {
        #region Сигнатура свойств
        string Method { get; set; }
        string Accept { get; set; }
        Uri Uri { get; set; }
        string UserAgent { get; set; }
        #endregion
    }
}
