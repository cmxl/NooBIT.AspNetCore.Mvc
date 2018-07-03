using System;
using NooBIT.Web.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.Web.Security.ContentSecurityPolicy.Directives
{
    public class Sandbox : Directive
    {
        internal Sandbox() : base("sandbox")
        {
        }

        public override void AddSource(Source source)
        {
            if(source is SandboxSource)
                base.AddSource(source);

            throw new NotSupportedException();
        }

        public void AddSandboxSource(SandboxSource source)
        {
            AddSource(source);
        }
    }
}