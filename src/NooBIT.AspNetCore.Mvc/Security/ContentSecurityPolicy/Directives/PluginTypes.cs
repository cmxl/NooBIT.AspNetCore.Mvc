using System;
using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Directives
{
    public class PluginTypes : Directive
    {
        internal PluginTypes() : base("plugin-types")
        {
        }

        public override void AddSource(Source source)
        {
            if(source is MediaTypeSource)
                base.AddSource(source);

            throw new NotSupportedException();
        }

        public void AddMediaTypeSource(MediaTypeSource source)
        {
            AddSource(source);
        }
    }
}
