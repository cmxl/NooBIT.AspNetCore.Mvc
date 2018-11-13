using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Security.ReferrerPolicy
{
    public class ReferrerPolicyBuilder : IHeaderBuilder
    {
        private readonly Header _header;

        public ReferrerPolicyBuilder()
        {
            _header = Header.ReferrerPolicy;
            _header.Value = ReferrerPolicyHeader.StrictOriginWhenCrossOrigin;
        }

        public Header Build() => _header;

        public ReferrerPolicyBuilder NoReferrer() => SetPolicy(ReferrerPolicyHeader.NoReferrer);

        public ReferrerPolicyBuilder NoReferrerWhenDowngrade() => SetPolicy(ReferrerPolicyHeader.NoReferrerWhenDowngrade);

        public ReferrerPolicyBuilder Origin() => SetPolicy(ReferrerPolicyHeader.Origin);

        public ReferrerPolicyBuilder OriginWhenCrossOrigin() => SetPolicy(ReferrerPolicyHeader.OriginWhenCrossOrigin);

        public ReferrerPolicyBuilder SameOrigin() => SetPolicy(ReferrerPolicyHeader.SameOrigin);

        public ReferrerPolicyBuilder StrictOrigin() => SetPolicy(ReferrerPolicyHeader.StrictOrigin);

        public ReferrerPolicyBuilder StrictOriginWhenCrossOrigin() => SetPolicy(ReferrerPolicyHeader.StrictOriginWhenCrossOrigin);

        public ReferrerPolicyBuilder UnsafeUrl() => SetPolicy(ReferrerPolicyHeader.UnsafeUrl);

        private ReferrerPolicyBuilder SetPolicy(string value)
        {
            _header.Value = value;
            return this;
        }
    }
}