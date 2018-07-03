using System;
using NooBIT.Web.Http;
using NooBIT.Web.Http.Headers;
using NooBIT.Web.Security.ContentSecurityPolicy;
using NooBIT.Web.Security.ContentSecurityPolicy.Sources;
using NooBIT.Web.Security.FrameOptions;
using NooBIT.Web.Security.ReferrerPolicy;
using NooBIT.Web.Security.StrictTransportSecurity;
using NooBIT.Web.Security.XssProtection;

namespace NooBIT.Web.Security
{
    public class CustomHeaderPolicyBuilder
    {
        private readonly HeaderPolicy _policy = new HeaderPolicy();

        public CustomHeaderPolicyBuilder AddHeader(Header header, string value)
        {
            if (_policy.SetHeaders.ContainsKey(header))
                _policy.SetHeaders[header] = value;
            else
                _policy.SetHeaders.Add(header, value);
            return this;
        }

        public CustomHeaderPolicyBuilder RemoveHeader(Header header)
        {
            if (_policy.RemoveHeaders.Contains(header))
                return this;

            _policy.RemoveHeaders.Add(header);
            return this;
        }

        public HeaderPolicy Build()
        {
            return _policy;
        }

        public CustomHeaderPolicyBuilder AddRecommendedSecurityHeaders()
        {
            RemoveServerHeader();
            RemovePoweredByHeader();
            AddContentTypeOptionsNoSniff();
            AddStrictTransportSecurity(new StrictTransportSecurityBuilder()
                .UseMaxAge((uint)TimeSpan.FromDays(365).TotalSeconds)
                .WithIncludeSubDomains()
                .WithPreload());
            AddContentSecurity(new ContentSecurityPolicyBuilder()
                .AddDefaultSource(x => x.AddSource(Source.Self))
                .AddBaseUri(x => x.AddDataSource(string.Empty))
                .AddScriptSource(x => x.AddSource(Source.Self))
                .AddStyleSource(x => x.AddSource(Source.Self))
                .AddFontSource(x => x.AddSource(Source.Self)));
            AddXssProtection(new XssProtectionBuilder()
                .Block());
            AddFrameOptions(new FrameOptionsBuilder()
                .UseSameOrigin());
            AddReferrerPolicy(new ReferrerPolicyBuilder()
                .UseStrictOriginWhenCrossOrigin());

            return this;
        }

        public CustomHeaderPolicyBuilder RemoveServerHeader()
        {
            return RemoveHeader(Header.Server);
        }

        public CustomHeaderPolicyBuilder RemovePoweredByHeader()
        {
            return RemoveHeader(Header.PoweredBy);
        }

        public CustomHeaderPolicyBuilder AddStrictTransportSecurity(StrictTransportSecurityBuilder builder)
        {
            return AddHeader(Header.StrictTransportSecurity, builder.Build());
        }

        public CustomHeaderPolicyBuilder AddContentSecurity(ContentSecurityPolicyBuilder builder)
        {
            return AddHeader(Header.ContentSecurityPolicy, builder.Build());
        }

        public CustomHeaderPolicyBuilder AddXssProtection(XssProtectionBuilder builder)
        {
            return AddHeader(Header.XssProtection, builder.Build());
        }

        public CustomHeaderPolicyBuilder AddFrameOptions(FrameOptionsBuilder builder)
        {
            return AddHeader(Header.FrameOptions, builder.Build());
        }

        public CustomHeaderPolicyBuilder AddReferrerPolicy(ReferrerPolicyBuilder builder)
        {
            return AddHeader(Header.ReferrerPolicy, builder.Build());
        }

        public CustomHeaderPolicyBuilder AddContentTypeOptionsNoSniff()
        {
            return AddHeader(Header.ContentTypeOptions, ContentTypeOptionsHeader.NoSniff);
        }
    }
}