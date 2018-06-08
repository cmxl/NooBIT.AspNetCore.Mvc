using System;
using NooBIT.ContentSecurityPolicy.Sources;

namespace NooBIT.ContentSecurityPolicy.Directives
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