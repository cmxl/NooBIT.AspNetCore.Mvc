using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Security.FrameOptions;
using Xunit;

namespace NooBIT.AspNetCore.Mvc.Tests
{
    public class FrameOptionsTests
    {
        [Fact]
        public void Only_One_Options_Is_Possible_And_Only_The_Last_One_Will_Be_Used()
        {
            var url = "https://www.google.com";

            var builder = new FrameOptionsBuilder();
            var header = builder.UseDeny().UseSameOrigin().UseAllowFrom(url).Build();

            Assert.NotNull(header);
            Assert.Equal(Header.FrameOptions.Name, header.Name);
            Assert.Equal($"ALLOW-FROM {url}", header.Value);
        }
    }
}