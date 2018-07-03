using System;
using System.Text;

namespace NooBIT.Web.Security.StrictTransportSecurity
{
    public class StrictTransportSecurityBuilder
    {
        private const string MaxAgeDirectiveFormat = "max-age={0}";
        private const string IncludeSubDomainsDirective = "; includeSubDomains";
        private const string PreloadDirective = "; preload";
        private const uint MinimumPreloadMaxAge = 10886400;

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

        public string Build()
        {
            if(_maxAge < MinimumPreloadMaxAge && _preload)
                throw new InvalidOperationException($"In order to confirm HSTS preload list subscription expiry must be at least eighteen weeks ({MinimumPreloadMaxAge} seconds).");

            if(_preload && !_includeSubDmonains)
                throw new InvalidOperationException("In order to confirm HSTS preload list subscription subdomains must be included.");

            var sb = new StringBuilder();
            sb.AppendFormat(MaxAgeDirectiveFormat, _maxAge);

            if (_includeSubDmonains)
                sb.Append(IncludeSubDomainsDirective);

            if (_preload)
                sb.Append(PreloadDirective);

            return sb.ToString();
        }
    }
}
