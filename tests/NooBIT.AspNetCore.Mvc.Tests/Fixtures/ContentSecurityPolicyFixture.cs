namespace NooBIT.AspNetCore.Mvc.Tests.Fixtures
{
    public class ContentSecurityPolicyFixture
    {
        public readonly string DefaultCsp = "default-src 'self'; base-uri data:; script-src 'self'; style-src 'self'; font-src 'self';";
        public readonly string ContentSecurityPolicy = "default-src 'self'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline' https://fonts.googleapis.com:443; font-src 'self' https://fonts.gstatic.com:443 data:; base-uri 'self';";
    }
}