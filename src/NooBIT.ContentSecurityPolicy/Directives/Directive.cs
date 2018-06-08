using System;
using System.Collections.Generic;
using System.Linq;
using NooBIT.ContentSecurityPolicy.Sources;

namespace NooBIT.ContentSecurityPolicy.Directives
{
    public class Directive
    {
        internal Directive(string name)
        {
            Name = name;
            Value = new HashSet<Source>();
        }

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
            if(Value.Count > 0)
                return Name + " " + string.Join(" ", Value.Select(x => x.Value)) + ";";

            return Name + ";";
        }
    }
}