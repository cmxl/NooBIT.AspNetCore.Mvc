using System;
using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Directives
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