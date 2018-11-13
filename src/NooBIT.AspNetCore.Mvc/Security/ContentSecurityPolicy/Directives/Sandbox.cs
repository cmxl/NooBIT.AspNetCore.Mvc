using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources;
using System;

namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Directives
{
    public class Sandbox : Directive
    {
        internal Sandbox() : base("sandbox")
        {
        }

        public override void AddSource(Source source)
        {
            if (source is SandboxSource)
                base.AddSource(source);

            throw new NotSupportedException();
        }

        public void AddSandboxSource(SandboxSource source) => AddSource(source);
    }
}