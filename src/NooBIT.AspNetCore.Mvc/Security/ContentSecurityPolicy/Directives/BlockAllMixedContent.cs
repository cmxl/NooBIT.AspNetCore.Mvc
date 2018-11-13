using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources;
using System;

namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Directives
{
    public class BlockAllMixedContent : Directive
    {
        internal BlockAllMixedContent() : base("block-all-mixed-content")
        {
        }

        public override void AddSource(Source source) => throw new NotSupportedException();
    }
}