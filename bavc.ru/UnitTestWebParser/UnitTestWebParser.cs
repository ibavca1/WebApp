using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebParser.BavcNetFramework;
using WebParser.BavcNetFramework.DataTypes;

namespace UnitTestWebParser
{
    [TestClass]
    public class UnitTestWebParser
    {
        /// <summary>
        /// Тест всего класса
        /// </summary>
        [TestMethod]
        public void TestMethodCreate()
        {
            Parser _parser = new Parser(WebRequestType.Http);
            //HttpParserWebRequest httpParser = new HttpParserWebRequest();
            var _p = _parser.ParserWebRequest;
            var _t = _p.GetType();
            WebPageContent content = ((HttpParserWebRequest)_parser.ParserWebRequest).LoadPageContent(_parser, Encoding.UTF8, TimeSpan.FromSeconds(1));
            //WebPageContent content = httpParser.LoadPageContent(_parser, Encoding.UTF8, TimeSpan.FromSeconds(1));
            Assert.IsNotNull(content);
        }
    }
}
