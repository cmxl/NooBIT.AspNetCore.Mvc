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

            if (_values.Contains(ClearSiteDataHeader.All))
                header.Value = ClearSiteDataHeader.All;
            else
                header.Value = string.Join(", ", _values);
            return header;
        }

        public IHeaderBuilder All()
        {
            return Add(ClearSiteDataHeader.All);
        }

        public IHeaderBuilder Cache()
        {
            if (_values.Contains(ClearSiteDataHeader.All)) return this;
            return Add(ClearSiteDataHeader.Cache);
        }

        public IHeaderBuilder Cookies()
        {
            if (_values.Contains(ClearSiteDataHeader.All)) return this;
            return Add(ClearSiteDataHeader.Cookies);
        }

        public IHeaderBuilder Storage()
        {
            if (_values.Contains(ClearSiteDataHeader.All)) return this;
            return Add(ClearSiteDataHeader.Storage);
        }

        public IHeaderBuilder ExecutionContexts()
        {
            if (_values.Contains(ClearSiteDataHeader.All)) return this;
            return Add(ClearSiteDataHeader.ExecutionContexts);
        }

        private IHeaderBuilder Add(string value)
        {
            if (!_values.Contains(value))
                _values.Add(value);

            return this;
        }
    }
}