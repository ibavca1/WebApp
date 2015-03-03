using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebParser.BavcNetFramework.DataTypes;

namespace WebParser.BavcNetFramework
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WebPageType PageType { get; set; }
        public WebPageStatus PageStatus { get; set; }
        public Uri Uri { get; set; }
    }
}
