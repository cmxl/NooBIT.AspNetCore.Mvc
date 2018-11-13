using NooBIT.AspNetCore.Mvc.Http.Headers;
using NooBIT.AspNetCore.Mvc.Security.ReferrerPolicy;
using Xunit;

namespace NooBIT.AspNetCore.Mvc.Tests
{
    public class ReferrerPolicyTests
    {
        [Fact]
        public void Builder_Creates_Header_With_Correct_Value()
        {
            var builder = new ReferrerPolicyBuilder();
            var header = builder.NoReferrer().Build();
            Assert.Equal(ReferrerPolicyHeader.NoReferrer, header.Value);

            header = builder.NoReferrerWhenDowngrade().Build();
            Assert.Equal(ReferrerPolicyHeader.NoReferrerWhenDowngrade, header.Value);

            header = builder.Origin().Build();
            Assert.Equal(ReferrerPolicyHeader.Origin, header.Value);

            header = builder.OriginWhenCrossOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.OriginWhenCrossOrigin, header.Value);

            header = builder.SameOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.SameOrigin, header.Value);

            header = builder.StrictOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.StrictOrigin, header.Value);

            header = builder.StrictOriginWhenCrossOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.StrictOriginWhenCrossOrigin, header.Value);

            header = builder.UnsafeUrl().Build();
            Assert.Equal(ReferrerPolicyHeader.UnsafeUrl, header.Value);
        }
    }
}