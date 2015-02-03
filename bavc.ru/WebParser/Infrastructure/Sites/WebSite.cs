using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using WebParser.Infrastructure.Sites;

namespace WebParser.Infrastructure.Sites
{
    public abstract class WebSite
    {
        public abstract Encoding Encoding { get; }

        public abstract Uri Uri { get; }

        public abstract WebSiteMetadata Metadata { get; }

        public virtual Uri MakeUri(string _siteRelativeUri)
        {
            Contract.Requires<ArgumentNullException>(_siteRelativeUri != null, "Не возможно создать пустой Uri");
            Uri _uri = Uri;
            NameValueCollection _siteQuery = HttpUtility.ParseQueryString(_uri.Query);
            Uri uri;
            bool IsAbsoluteUrl = Uri.TryCreate(_siteRelativeUri, UriKind.Absolute, out uri);
            uri = IsAbsoluteUrl ? new Uri(_siteRelativeUri) : new Uri(_uri, _siteRelativeUri);
            return uri;
            //uri=uri
        }
    }
}
