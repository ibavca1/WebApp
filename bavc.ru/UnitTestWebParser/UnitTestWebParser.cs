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
            Parser _parser = new Parser(WebRequestType.Http, new Uri("http://yandex.ru"));
            
            HttpParserWebRequest httpParser = new HttpParserWebRequest();
            foreach (var item in _parser)
            {
                var t = item.GetType();
            }
            WebPageContent content = httpParser.LoadPageContent(_parser, Encoding.UTF8, TimeSpan.FromSeconds(1));
            Assert.IsNotNull(content);
        }
    }
}
