using System.Linq;
using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;
using Xunit;

namespace NooBIT.AspNetCore.Mvc.Tests
{
    public class ContentTypeOptionsTests
    {
        [Fact]
        public void NoSniff_ContentTypeOptionsHeader_Has_Correct_Value()
        {
            var builder = new HeaderPolicyBuilder();
            builder.AddContentTypeOptionsNoSniff();
            var headerPolicy = builder.Build();
            Assert.Single(headerPolicy.SetHeaders);
            Assert.Equal(ContentTypeOptionsHeader.NoSniff, headerPolicy.SetHeaders.Single().Value.Value);
        }
    }
}