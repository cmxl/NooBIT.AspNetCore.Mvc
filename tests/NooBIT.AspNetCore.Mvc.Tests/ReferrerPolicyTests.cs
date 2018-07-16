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
            var header = builder.UseNoReferrer().Build();
            Assert.Equal(ReferrerPolicyHeader.NoReferrer, header.Value);

            header = builder.UseNoReferrerWhenDowngrade().Build();
            Assert.Equal(ReferrerPolicyHeader.NoReferrerWhenDowngrade, header.Value);

            header = builder.UseOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.Origin, header.Value);

            header = builder.UseOriginWhenCrossOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.OriginWhenCrossOrigin, header.Value);

            header = builder.UseSameOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.SameOrigin, header.Value);

            header = builder.UseStrictOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.StrictOrigin, header.Value);

            header = builder.UseStrictOriginWhenCrossOrigin().Build();
            Assert.Equal(ReferrerPolicyHeader.StrictOriginWhenCrossOrigin, header.Value);

            header = builder.UseUnsafeUrl().Build();
            Assert.Equal(ReferrerPolicyHeader.UnsafeUrl, header.Value);
        }
    }
}