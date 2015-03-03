using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebParser.BavcNetFramework;
using WebParser.BavcNetFramework.DataTypes;

using WebParser.BavcNetModel;

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

        [TestMethod]
        public void TestCompanyCreate()
        {
            myCompany company = new myCompany("Mvideo.ru");
            Assert.Equals(company.Id, 1);
        }
    }

    public class myCompany:Company
    {
        //Подумать как сделать много сайтов
        Site _site = new Site();
        private string _name;

        public myCompany()
        {
            _site.Id = 1;
            //_site.Pages.Add(new Page());
        }
        public myCompany(string name)
            : this()
        {
            _name = name;
        }
    }
}
