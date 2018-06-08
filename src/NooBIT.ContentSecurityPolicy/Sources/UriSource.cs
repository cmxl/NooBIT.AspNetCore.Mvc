using System;

namespace NooBIT.ContentSecurityPolicy.Sources
{
    internal class UriSource : Source
    {
        internal UriSource(string uri) : this(new Uri(uri))
        {
        }

        internal UriSource(Uri uri) : base(uri.Scheme + "://" + uri.Host + ":" + uri.Port)
        {
        }
    }
}