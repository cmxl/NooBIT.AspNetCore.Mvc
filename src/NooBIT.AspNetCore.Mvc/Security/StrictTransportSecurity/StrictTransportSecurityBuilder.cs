using NooBIT.AspNetCore.Mvc.Http;
using System;
using System.Text;

namespace NooBIT.AspNetCore.Mvc.Security.StrictTransportSecurity
{
    public class StrictTransportSecurityBuilder : IHeaderBuilder
    {
        private const string _maxAgeDirectiveFormat = "max-age={0}";
        private const string _includeSubDomainsDirective = "; includeSubDomains";
        private const string _preloadDirective = "; preload";
        private static readonly TimeSpan _minimumPreloadMaxAge = TimeSpan.FromDays(126);

        private uint _maxAge;
        private bool _includeSubDmonains;
        private bool _preload;

        public StrictTransportSecurityBuilder UseMaxAge(uint maxAge)
        {
            _maxAge = maxAge;
            return this;
        }

        public StrictTransportSecurityBuilder WithIncludeSubDomains()
        {
            _includeSubDmonains = true;
            return this;
        }

        public StrictTransportSecurityBuilder WithPreload()
        {
            _preload = true;
            return this;
        }

        public Header Build()
        {
            if (_maxAge < _minimumPreloadMaxAge.TotalSeconds && _preload)
                throw new InvalidOperationException($"In order to confirm HSTS preload list subscription expiry must be at least eighteen weeks ({_minimumPreloadMaxAge.TotalSeconds} seconds).");

            if (_preload && !_includeSubDmonains)
                throw new InvalidOperationException("In order to confirm HSTS preload list subscription subdomains must be included.");

            var sb = new StringBuilder();
            sb.AppendFormat(_maxAgeDirectiveFormat, _maxAge);

            if (_includeSubDmonains)
                sb.Append(_includeSubDomainsDirective);

            if (_preload)
                sb.Append(_preloadDirective);

            var header = Header.StrictTransportSecurity;
            header.Value = sb.ToString();
            return header;
        }
    }
}
