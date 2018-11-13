using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Directives;
using NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy
{
    public class ContentSecurityPolicyBuilder : IHeaderBuilder
    {
        private readonly List<Directive> _directives = new List<Directive>();

        public ContentSecurityPolicyBuilder AddBaseUri(Action<Directive> directiveAction) => AddDirective(new BaseUri(), directiveAction);

        public ContentSecurityPolicyBuilder AddBlockAllMixedContent() => AddDirective(new BlockAllMixedContent(), null);

        public ContentSecurityPolicyBuilder AddConnectSource(Action<BlockAllMixedContent> directiveAction) => AddDirective(new BlockAllMixedContent(), directiveAction);

        public ContentSecurityPolicyBuilder AddDefaultSource(Action<DefaultSource> directiveAction) => AddDirective(new DefaultSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddFontSource(Action<FontSource> directiveAction) => AddDirective(new FontSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddFrameAncestors(Action<FrameAncestors> directiveAction) => AddDirective(new FrameAncestors(), directiveAction);

        public ContentSecurityPolicyBuilder AddFrameSource(Action<FrameSource> directiveAction) => AddDirective(new FrameSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddImageSource(Action<ImageSource> directiveAction) => AddDirective(new ImageSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddManifestSource(Action<ManifestSource> directiveAction) => AddDirective(new ManifestSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddMediaSource(Action<MediaSource> directiveAction) => AddDirective(new MediaSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddObjectSource(Action<ObjectSource> directiveAction) => AddDirective(new ObjectSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddPluginTypes(Action<PluginTypes> directiveAction) => AddDirective(new PluginTypes(), directiveAction);

        public ContentSecurityPolicyBuilder AddReferrer(Action<Referrer> directiveAction) => AddDirective(new Referrer(), directiveAction);

        public ContentSecurityPolicyBuilder AddRequireSriFor(Action<RequireSriFor> directiveAction) => AddDirective(new RequireSriFor(), directiveAction);

        public ContentSecurityPolicyBuilder AddSandbox(Action<Sandbox> directiveAction) => AddDirective(new Sandbox(), directiveAction);

        public ContentSecurityPolicyBuilder AddScriptSource(Action<ScriptSource> directiveAction) => AddDirective(new ScriptSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddStyleSource(Action<StyleSource> directiveAction) => AddDirective(new StyleSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddUpgradeInsecureRequests() => AddDirective(new UpgradeInsecureRequests(), null);

        public ContentSecurityPolicyBuilder AddWorkerSource(Action<WorkerSource> directiveAction) => AddDirective(new WorkerSource(), directiveAction);

        public ContentSecurityPolicyBuilder AddDirective<T>(T directive, Action<T> directiveAction) where T : Directive
        {
            directiveAction?.Invoke(directive);
            _directives.Add(directive);
            return this;
        }

        public ContentSecurityPolicyBuilder Default() => 
                AddDefaultSource(x => x.AddSource(Source.Self))
                .AddBaseUri(x => x.AddSource(Source.Self))
                .AddScriptSource(x => x.AddSource(Source.Self))
                .AddStyleSource(x => x.AddSource(Source.Self))
                .AddFontSource(x => x.AddSource(Source.Self));

        public Header Build()
        {
            var directives = _directives.GroupBy(x => x.Name);

            var sb = new StringBuilder();
            foreach (var directive in directives)
            {
                var values = directive.SelectMany(x => x.Value).ToList();
                if (values.Count <= 0)
                    sb.AppendFormat("{0}; ", directive.Key);
                else
                    sb.AppendFormat("{0} {1}; ", directive.Key, string.Join(" ", values));
            }

            var header = Header.ContentSecurityPolicy;
            header.Value = sb.ToString().TrimEnd();
            return header;
        }
    }
}