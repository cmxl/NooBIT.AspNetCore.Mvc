using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources;
using System;

namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Directives
{
    public class Referrer : Directive
    {
        public override void AddSource(Source source)
        {
            if (source is ReferrerSource)
                base.AddSource(source);

            throw new NotSupportedException();
        }

        public void AddReferrerSource(ReferrerSource source) => AddSource(source);

        internal Referrer() : base("referrer")
        {
        }
    }
}