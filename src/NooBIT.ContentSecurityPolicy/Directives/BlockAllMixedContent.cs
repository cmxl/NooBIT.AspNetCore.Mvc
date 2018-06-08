using System;
using NooBIT.ContentSecurityPolicy.Sources;

namespace NooBIT.ContentSecurityPolicy.Directives
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