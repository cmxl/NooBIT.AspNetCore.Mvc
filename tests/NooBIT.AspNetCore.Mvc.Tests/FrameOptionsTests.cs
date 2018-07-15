using System;
using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;
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

        [Fact]
        public void Empty_Allow_From_Url_Throws_ArgumentNullException()
        {
            var builder = new FrameOptionsBuilder();
            Assert.Throws<ArgumentNullException>(() => builder.UseAllowFrom(null));
            Assert.Throws<ArgumentNullException>(() => builder.UseAllowFrom(string.Empty));
            Assert.Throws<ArgumentNullException>(() => builder.UseAllowFrom("       "));
        }

        [Fact]
        public void UseDeny_Has_Correct_Value()
        {
            var builder = new FrameOptionsBuilder();
            Assert.Equal(FrameOptionsHeader.Deny, builder.UseDeny().Build().Value);
        }

        [Fact]
        public void UseSameOrigin_Has_Correct_Value()
        {
            var builder = new FrameOptionsBuilder();
            Assert.Equal(FrameOptionsHeader.SameOrigin, builder.UseSameOrigin().Build().Value);
        }

        [Fact]
        public void UseAllowFrom_Has_Correct_Value()
        {
            var builder = new FrameOptionsBuilder();
            Assert.Equal(FrameOptionsHeader.AllowFrom + " https://www.google.com", builder.UseAllowFrom("https://www.google.com").Build().Value);
        }
    }
}