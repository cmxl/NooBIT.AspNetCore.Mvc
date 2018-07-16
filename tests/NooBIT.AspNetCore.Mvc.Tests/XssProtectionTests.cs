using NooBIT.AspNetCore.Mvc.Http.Headers;
using NooBIT.AspNetCore.Mvc.Security.XssProtection;
using Xunit;

namespace NooBIT.AspNetCore.Mvc.Tests
{
    public class XssProtectionTests
    {
        [Fact]
        public void Builder_Creates_Header_With_Correct_Value()
        {
            var builder = new XssProtectionBuilder();

            var header1 = builder.Disable().Build();
            var header2 = builder.Enable().Build();
            var header3 = builder.Block().Build();

            Assert.Equal(XssProtectionHeader.Disable, header1.Value);
            Assert.Equal(XssProtectionHeader.Enable, header2.Value);
            Assert.Equal(XssProtectionHeader.Block, header3.Value);
        }
    }
}