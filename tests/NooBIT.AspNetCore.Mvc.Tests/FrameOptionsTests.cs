using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;
using NooBIT.AspNetCore.Mvc.Security.FrameOptions;
using System;
using Xunit;

namespace NooBIT.AspNetCore.Mvc.Tests
{
    public class FrameOptionsTests
    {
        [Fact]
        public void Only_One_Options_Is_Possible_And_Only_The_Last_One_Will_Be_Used()
        {
            const string url = "https://www.google.com";

            var builder = new FrameOptionsBuilder();
            var header = builder.Deny().SameOrigin().AllowFrom(url).Build();

            Assert.NotNull(header);
            Assert.Equal(Header.FrameOptions.Name, header.Name);
            Assert.Equal($"{FrameOptionsHeader.AllowFrom} {url}", header.Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("      ")]
        public void Empty_Allow_From_Url_Throws_ArgumentNullException(string url)
        {
            var builder = new FrameOptionsBuilder();
            Assert.Throws<ArgumentNullException>(() => builder.AllowFrom(url));
        }

        [Fact]
        public void UseDeny_Has_Correct_Value()
        {
            var builder = new FrameOptionsBuilder();
            Assert.Equal(FrameOptionsHeader.Deny, builder.Deny().Build().Value);
        }

        [Fact]
        public void UseSameOrigin_Has_Correct_Value()
        {
            var builder = new FrameOptionsBuilder();
            Assert.Equal(FrameOptionsHeader.SameOrigin, builder.SameOrigin().Build().Value);
        }

        [Fact]
        public void UseAllowFrom_Has_Correct_Value()
        {
            const string url = "https://www.google.com";
            var builder = new FrameOptionsBuilder();
            Assert.Equal($"{FrameOptionsHeader.AllowFrom} {url}", builder.AllowFrom(url).Build().Value);
        }
    }
}
