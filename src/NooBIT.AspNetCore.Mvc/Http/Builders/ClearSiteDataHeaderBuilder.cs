using NooBIT.AspNetCore.Mvc.Http.Headers;
using System.Collections.Generic;

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

        public IHeaderBuilder All() => Add(ClearSiteDataHeader.All);

        public IHeaderBuilder Cache() => Add(ClearSiteDataHeader.Cache);

        public IHeaderBuilder Cookies() => Add(ClearSiteDataHeader.Cookies);

        public IHeaderBuilder Storage() => Add(ClearSiteDataHeader.Storage);

        public IHeaderBuilder ExecutionContexts() => Add(ClearSiteDataHeader.ExecutionContexts);

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