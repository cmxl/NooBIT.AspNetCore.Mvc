using NooBIT.Web.Http.Headers;

namespace NooBIT.Web.Http
{
    public class Header
    {
        public static readonly Header Server = new ServerHeader();
        public static readonly Header FrameOptions = new FrameOptionsHeader();
        public static readonly Header ContentTypeOptions = new ContentTypeOptionsHeader();
        public static readonly Header ReferrerPolicy = new ReferrerPolicyHeader();
        public static readonly Header XssProtection = new XssProtectionHeader();
        public static readonly Header StrictTransportSecurity = new StrictTransportSecurityHeader();
        public static readonly Header ContentSecurityPolicy = new ContentSecurityPolicyHeader();
        public static readonly Header PoweredBy = new PoweredByHeader();

        public Header(string name)
        {
            Name = name;
        }

        internal string Name { get; }
    }
}