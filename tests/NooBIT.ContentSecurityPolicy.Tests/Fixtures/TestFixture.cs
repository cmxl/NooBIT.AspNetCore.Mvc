namespace NooBIT.ContentSecurityPolicy.Tests.Fixtures
{
    public class TestFixture
    {
        public readonly string ContentSecurityPolicy = "default-src 'self'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline' https://fonts.googleapis.com:443; font-src 'self' https://fonts.gstatic.com:443 data:; base-uri 'self';";
    }
}