using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.Infrastructure.Sites
{
    public class WebPage
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public WebPageType PageType { get; set; }
        public string Content { get; set; }
    }
}
