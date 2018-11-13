using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Http
{
    public class Header
    {
        public static Header Server => new ServerHeader();
        public static Header FrameOptions => new FrameOptionsHeader();
        public static Header ContentTypeOptions => new ContentTypeOptionsHeader();
        public static Header ReferrerPolicy => new ReferrerPolicyHeader();
        public static Header XssProtection => new XssProtectionHeader();
        public static Header StrictTransportSecurity => new StrictTransportSecurityHeader();
        public static Header ContentSecurityPolicy => new ContentSecurityPolicyHeader();
        public static Header PoweredBy => new PoweredByHeader();
        public static Header CacheControl => new CacheControlHeader();
        public static Header ClearSiteData => new ClearSiteDataHeader();
        public static Header Expires => new ExpiresHeader();

        public Header(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public string Value { get; set; }

        public sealed override string ToString() => Name + ": " + Value;
    }
}