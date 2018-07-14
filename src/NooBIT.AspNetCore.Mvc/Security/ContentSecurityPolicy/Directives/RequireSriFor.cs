using System;
using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Directives
{
    public class RequireSriFor : Directive
    {
        public override void AddSource(Source source)
        {
            if (source is RequireSriForSource)
                base.AddSource(source);

            throw new NotSupportedException();
        }

        public void AddRequireSriForSource(RequireSriForSource source)
        {
            AddSource(source);
        }

        internal RequireSriFor() : base("require-sri-for")
        {
        }
    }
}