using System;
using System.Collections.Generic;
using System.Linq;
using NooBIT.Web.Security.ContentSecurityPolicy.Sources;

namespace NooBIT.Web.Security.ContentSecurityPolicy.Directives
{
    public class Directive
    {
        internal Directive(string name)
        {
            Name = name;
            Value = new HashSet<Source>();
        }

        public static Directive BaseUri => new BaseUri();
        public static Directive BlockAllMixedContent => new BlockAllMixedContent();
        public static Directive ConnectSource => new ConnectSource();
        public static Directive DefaultSource => new DefaultSource();
        public static Directive BaseFontSourceUri => new FontSource();
        public static Directive FrameAncestors => new FrameAncestors();
        public static Directive FrameSource => new FrameSource();
        public static Directive ImageSource => new ImageSource();
        public static Directive ManifestSource => new ManifestSource();
        public static Directive MediaSource => new MediaSource();
        public static Directive ObjectSource => new ObjectSource();
        public static Directive PluginTypes => new PluginTypes();
        public static Directive Referrer => new Referrer();
        public static Directive RequireSriFor => new RequireSriFor();
        public static Directive Sandbox => new Sandbox();
        public static Directive ScriptSource => new ScriptSource();
        public static Directive StyleSource => new StyleSource();
        public static Directive UpgradeInsecureRequests => new UpgradeInsecureRequests();
        public static Directive WorkerSource => new WorkerSource();

        internal string Name { get; }
        internal HashSet<Source> Value { get; }

        public void AddDataSource(string data)
        {
            AddSource(new DataSource(data));
        }

        public void AddUriSource(string uri)
        {
            AddUriSource(new Uri(uri));
        }

        public void AddUriSource(Uri uri)
        {
            AddSource(new UriSource(uri));
        }

        public void AddNonceSource(string nonceHash)
        {
            AddSource(new NonceSource(nonceHash));
        }

        public virtual void AddSource(Source source)
        {
            if (Value.Contains(source))
                return;

            Value.Add(source);
        }

        public override string ToString()
        {
            if (Value.Count > 0)
                return Name + " " + string.Join(" ", Value.Select(x => x.Value)) + ";";

            return Name + ";";
        }
    }
}