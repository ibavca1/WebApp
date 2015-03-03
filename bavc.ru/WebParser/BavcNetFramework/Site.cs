using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

using WebParser.BavcNetModel;
using WebParser.BavcNetFramework.DataTypes;

namespace WebParser.BavcNetFramework
{
    public class Site
    {
        private int _pageCount = 0;
        private int _pageId = 0;
        private List<Page> _pages;
        private CookieCollection _cookies;
        private Object _lockObj;
        private Encoding _encoding;
        public int Id { get; set; }
        public virtual List<Page> Pages 
        {
            get 
            {
                return _pages;
            } 
        }

        public Site()
        {
            _pages = new List<Page>();
        }

        public Site(Encoding encoding)
            :this()
        {
            _encoding = encoding;
        }

        public virtual void AddPage()
        {
        }

        public virtual void AddPage(Page page)
        {
            _pages.Add(page);
        }

        public virtual void AddPage(string name)
        {
            _pages.Add(new Page { Id = _pageId, Name = name, PageType = WebPageType.Main, PageStatus = WebPageStatus.New });
            _pageId++;
        }

        public virtual WebPageContent GetPageContent(int id)
        {
            WebPageContent webContent;
            lock (_lockObj)
            {
                Page page = _pages.Single(x => (x.Id == id) && (x.PageStatus == WebPageStatus.New));
                page.PageStatus = WebPageStatus.Busy;
                Parser parser = new Parser(WebRequestType.Http, page.Uri);
                HttpParserWebRequest httpParser = new HttpParserWebRequest();
                try
                {
                    webContent = httpParser.LoadPageContent(parser, _encoding, TimeSpan.FromSeconds(1));
                }
                catch(WebException ex)
                {
                    string status = ((HttpWebResponse)ex.Response).StatusCode.ToString();
                    page.PageStatus = WebPageStatus.Error;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    page.PageStatus = WebPageStatus.Error;
                }
            }
            return null;
        }
    }
}
