using NooBIT.AspNetCore.Mvc.Http;
using Xunit;

namespace NooBIT.AspNetCore.Mvc.Tests
{
    public class HeaderTests
    {
        [Fact]
        public void Header_ToString_Is_Http_Conform_Header_String()
        {
            Assert.Equal("Cache-Control: ", Header.CacheControl.ToString());
            Assert.Equal("Content-Security-Policy: ", Header.ContentSecurityPolicy.ToString());
            Assert.Equal("Expires: ", Header.Expires.ToString());
            Assert.Equal("Referrer-Policy: ", Header.ReferrerPolicy.ToString());
            Assert.Equal("Server: ", Header.Server.ToString());
            Assert.Equal("Strict-Transport-Security: ", Header.StrictTransportSecurity.ToString());
            Assert.Equal("X-Content-Type-Options: ", Header.ContentTypeOptions.ToString());
            Assert.Equal("X-Frame-Options: ", Header.FrameOptions.ToString());
            Assert.Equal("X-Powered-By: ", Header.PoweredBy.ToString());
            Assert.Equal("X-XSS-Protection: ", Header.XssProtection.ToString());

            Assert.Equal("X-Foo-Bar: my value", new Header("X-Foo-Bar") { Value = "my value" }.ToString());
        }
    }
}