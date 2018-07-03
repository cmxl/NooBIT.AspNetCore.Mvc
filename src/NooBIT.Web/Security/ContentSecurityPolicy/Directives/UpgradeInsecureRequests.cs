using System;
using NooBIT.Web.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.Web.Security.ContentSecurityPolicy.Directives
{
    public class UpgradeInsecureRequests : Directive
    {
        internal UpgradeInsecureRequests() : base("upgrade-insecure-requests")
        {
        }

        public override void AddSource(Source source)
        {
            throw new NotSupportedException();
        }
    }
}