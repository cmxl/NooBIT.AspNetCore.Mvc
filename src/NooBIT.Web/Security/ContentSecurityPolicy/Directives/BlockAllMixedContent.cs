using System;
using NooBIT.Web.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.Web.Security.ContentSecurityPolicy.Directives
{
    public class BlockAllMixedContent : Directive
    {
        internal BlockAllMixedContent() : base("block-all-mixed-content")
        {
        }

        public override void AddSource(Source source)
        {
            throw new NotSupportedException();
        }
    }
}