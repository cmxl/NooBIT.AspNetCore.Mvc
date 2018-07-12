using System;
using NooBIT.Web.Http.Headers;
using NooBIT.Web.Security.ContentSecurityPolicy;
using NooBIT.Web.Security.FrameOptions;
using NooBIT.Web.Security.ReferrerPolicy;
using NooBIT.Web.Security.StrictTransportSecurity;
using NooBIT.Web.Security.XssProtection;

namespace NooBIT.Web.Http
{
    public class HeaderPolicyBuilder
    {
        private readonly HeaderPolicy _policy = new HeaderPolicy();

        public HeaderPolicyBuilder AddHeader(Header header)
        {
            if (_policy.SetHeaders.ContainsKey(header.Name))
                _policy.SetHeaders[header.Name] = header;
            else
                _policy.SetHeaders.Add(header.Name, header);
            return this;
        }

        public HeaderPolicyBuilder AddHeader(IHeaderBuilder builder)
        {
            var header = builder.Build();
            return AddHeader(header);
        }

        public HeaderPolicyBuilder RemoveHeader(Header header)
        {
            if (_policy.RemoveHeaders.Contains(header.Name))
                return this;

            _policy.RemoveHeaders.Add(header.Name);
            return this;
        }

        public HeaderPolicy Build()
        {
            return _policy;
        }

        public HeaderPolicyBuilder AddRecommendedSecurityHeaders()
        {
            return RemoveServerHeader()
                .RemovePoweredByHeader()
                .AddContentTypeOptionsNoSniff()
                .AddStrictTransportSecurity(new StrictTransportSecurityBuilder()
                    .UseMaxAge((uint) TimeSpan.FromDays(365).TotalSeconds)
                    .WithIncludeSubDomains()
                    .WithPreload())
                .AddContentSecurity(new ContentSecurityPolicyBuilder()
                    .Default())
                .AddXssProtection(new XssProtectionBuilder()
                    .Block())
                .AddFrameOptions(new FrameOptionsBuilder()
                    .UseSameOrigin())
                .AddReferrerPolicy(new ReferrerPolicyBuilder()
                    .UseStrictOriginWhenCrossOrigin());
        }

        public HeaderPolicyBuilder RemoveServerHeader()
        {
            return RemoveHeader(Header.Server);
        }

        public HeaderPolicyBuilder RemovePoweredByHeader()
        {
            return RemoveHeader(Header.PoweredBy);
        }

        public HeaderPolicyBuilder AddStrictTransportSecurity(StrictTransportSecurityBuilder builder)
        {
            return AddHeader(builder);
        }

        public HeaderPolicyBuilder AddContentSecurity(ContentSecurityPolicyBuilder builder)
        {
            return AddHeader(builder);
        }

        public HeaderPolicyBuilder AddXssProtection(XssProtectionBuilder builder)
        {
            return AddHeader(builder);
        }

        public HeaderPolicyBuilder AddFrameOptions(FrameOptionsBuilder builder)
        {
            return AddHeader(builder);
        }

        public HeaderPolicyBuilder AddReferrerPolicy(ReferrerPolicyBuilder builder)
        {
            return AddHeader(builder);
        }

        public HeaderPolicyBuilder AddContentTypeOptionsNoSniff()
        {
            var header = Header.ContentTypeOptions;
            header.Value = ContentTypeOptionsHeader.NoSniff;
            return AddHeader(header);
        }
    }
}