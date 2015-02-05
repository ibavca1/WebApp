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
        [TestMethod]
        public void TestMethodCreate()
        {
            BasicParserWebRequest basicParser = new BasicParserWebRequest(WebRequestType.Http, new Uri("http://google1.com"));
            HttpParserWebRequest httpParser = new HttpParserWebRequest();
            WebPageContent content = httpParser.LoadPageContent(basicParser, Encoding.UTF8, TimeSpan.FromSeconds(1));
            Assert.IsNotNull(content);
        }
    }
}
