using System;
using NooBIT.ContentSecurityPolicy.Sources;

namespace NooBIT.ContentSecurityPolicy.Directives
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