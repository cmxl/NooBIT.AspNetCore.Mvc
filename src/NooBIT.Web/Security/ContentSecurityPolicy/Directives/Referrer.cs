using System;
using NooBIT.Web.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.Web.Security.ContentSecurityPolicy.Directives
{
    public class Referrer : Directive
    {
        public override void AddSource(Source source)
        {
            if(source is ReferrerSource)
                base.AddSource(source);

            throw new NotSupportedException();
        }

        public void AddReferrerSource(ReferrerSource source)
        {
            AddSource(source);
        }

        internal Referrer() : base("referrer")
        {
        }
    }
}