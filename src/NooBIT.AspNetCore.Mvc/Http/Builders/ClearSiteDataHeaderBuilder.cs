using System.Collections.Generic;
using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Http.Builders
{
    public class ClearSiteDataHeaderBuilder : IHeaderBuilder
    {
        private readonly HashSet<string> _values = new HashSet<string>();

        public Header Build()
        {
            var header = Header.ClearSiteData;
            header.Value = _values.Contains(ClearSiteDataHeader.All)
                ? ClearSiteDataHeader.All
                : string.Join(", ", _values);
            
            return header;
        }

        public IHeaderBuilder All()
        {
            return Add(ClearSiteDataHeader.All);
        }

        public IHeaderBuilder Cache()
        {
            return Add(ClearSiteDataHeader.Cache);
        }

        public IHeaderBuilder Cookies()
        {
            return Add(ClearSiteDataHeader.Cookies);
        }

        public IHeaderBuilder Storage()
        {
            return Add(ClearSiteDataHeader.Storage);
        }

        public IHeaderBuilder ExecutionContexts()
        {
            return Add(ClearSiteDataHeader.ExecutionContexts);
        }

        private IHeaderBuilder Add(string value)
        {
            if (_values.Contains(ClearSiteDataHeader.All))
                return this;

            if (!_values.Contains(value))
                _values.Add(value);

            return this;
        }
    }
}