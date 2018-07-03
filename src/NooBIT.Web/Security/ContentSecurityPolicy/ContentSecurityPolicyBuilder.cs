using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NooBIT.Web.Security.ContentSecurityPolicy.Directives;

namespace NooBIT.Web.Security.ContentSecurityPolicy
{
    public class ContentSecurityPolicyBuilder
    {
        private readonly List<Directive> _directives = new List<Directive>();

        public ContentSecurityPolicyBuilder AddBaseUri(Action<Directive> directiveAction)
        {
            return AddDirective(new BaseUri(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddBlockAllMixedContent()
        {
            return AddDirective(new BlockAllMixedContent(), null);
        }

        public ContentSecurityPolicyBuilder AddConnectSource(Action<BlockAllMixedContent> directiveAction)
        {
            return AddDirective(new BlockAllMixedContent(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddDefaultSource(Action<DefaultSource> directiveAction)
        {
            return AddDirective(new DefaultSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddFontSource(Action<FontSource> directiveAction)
        {
            return AddDirective(new FontSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddFrameAncestors(Action<FrameAncestors> directiveAction)
        {
            return AddDirective(new FrameAncestors(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddFrameSource(Action<FrameSource> directiveAction)
        {
            return AddDirective(new FrameSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddImageSource(Action<ImageSource> directiveAction)
        {
            return AddDirective(new ImageSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddManifestSource(Action<ManifestSource> directiveAction)
        {
            return AddDirective(new ManifestSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddMediaSource(Action<MediaSource> directiveAction)
        {
            return AddDirective(new MediaSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddObjectSource(Action<ObjectSource> directiveAction)
        {
            return AddDirective(new ObjectSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddPluginTypes(Action<PluginTypes> directiveAction)
        {
            return AddDirective(new PluginTypes(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddReferrer(Action<Referrer> directiveAction)
        {
            return AddDirective(new Referrer(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddRequireSriFor(Action<RequireSriFor> directiveAction)
        {
            return AddDirective(new RequireSriFor(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddSandbox(Action<Sandbox> directiveAction)
        {
            return AddDirective(new Sandbox(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddScriptSource(Action<ScriptSource> directiveAction)
        {
            return AddDirective(new ScriptSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddStyleSource(Action<StyleSource> directiveAction)
        {
            return AddDirective(new StyleSource(), directiveAction);
        }

        public ContentSecurityPolicyBuilder AddUpgradeInsecureRequests()
        {
            return AddDirective(new UpgradeInsecureRequests(), null);
        }

        public ContentSecurityPolicyBuilder AddWorkerSource(Action<WorkerSource> directiveAction)
        {
            return AddDirective(new WorkerSource(), directiveAction);
        }

        private ContentSecurityPolicyBuilder AddDirective<T>(T directive, Action<T> directiveAction) where T : Directive
        {
            directiveAction?.Invoke(directive);
            _directives.Add(directive);
            return this;
        }

        public string Build()
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

            return sb.ToString().TrimEnd();
        }
    }
}