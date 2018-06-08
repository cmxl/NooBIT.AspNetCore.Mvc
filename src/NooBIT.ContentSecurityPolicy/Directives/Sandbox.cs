using System;
using NooBIT.ContentSecurityPolicy.Sources;

namespace NooBIT.ContentSecurityPolicy.Directives
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