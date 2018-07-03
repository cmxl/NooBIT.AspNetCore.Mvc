using System.Collections.Generic;
using NooBIT.Web.Http;

namespace NooBIT.Web.Security
{
    public class HeaderPolicy
    {
        public IDictionary<Header, string> SetHeaders { get; } = new Dictionary<Header, string>();

        public ISet<Header> RemoveHeaders { get; } = new HashSet<Header>();
    }
}