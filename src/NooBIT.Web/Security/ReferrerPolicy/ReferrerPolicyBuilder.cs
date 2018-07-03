using NooBIT.Web.Http.Headers;

namespace NooBIT.Web.Security.ReferrerPolicy
{
    public class ReferrerPolicyBuilder
    {
        private ReferrerPolicyType _type = ReferrerPolicyType.StrictOriginWhenCrossOrigin;

        public ReferrerPolicyBuilder UseNoReferrer()
        {
            _type = ReferrerPolicyType.NoReferrer;
            return this;
        }

        public ReferrerPolicyBuilder UseNoReferrerWhenDowngrade()
        {
            _type = ReferrerPolicyType.NoReferrerWhenDowngrade;
            return this;
        }

        public ReferrerPolicyBuilder UseOrigin()
        {
            _type = ReferrerPolicyType.Origin;
            return this;
        }

        public ReferrerPolicyBuilder UseOriginWhenCrossOrigin()
        {
            _type = ReferrerPolicyType.OriginWhenCrossOrigin;
            return this;
        }

        public ReferrerPolicyBuilder UseSameOrigin()
        {
            _type = ReferrerPolicyType.SameOrigin;
            return this;
        }

        public ReferrerPolicyBuilder UseStrictOrigin()
        {
            _type = ReferrerPolicyType.StrictOrigin;
            return this;
        }

        public ReferrerPolicyBuilder UseStrictOriginWhenCrossOrigin()
        {
            _type = ReferrerPolicyType.StrictOriginWhenCrossOrigin;
            return this;
        }

        public ReferrerPolicyBuilder UseUnsafeUrl()
        {
            _type = ReferrerPolicyType.UnsafeUrl;
            return this;
        }

        public string Build()
        {
            switch (_type)
            {
                case ReferrerPolicyType.NoReferrer:
                    return ReferrerPolicyHeader.NoReferrer;
                case ReferrerPolicyType.NoReferrerWhenDowngrade:
                    return ReferrerPolicyHeader.NoReferrerWhenDowngrade;
                case ReferrerPolicyType.Origin:
                    return ReferrerPolicyHeader.Origin;
                case ReferrerPolicyType.OriginWhenCrossOrigin:
                    return ReferrerPolicyHeader.OriginWhenCrossOrigin;
                case ReferrerPolicyType.SameOrigin:
                    return ReferrerPolicyHeader.SameOrigin;
                case ReferrerPolicyType.StrictOrigin:
                    return ReferrerPolicyHeader.StrictOrigin;
                case ReferrerPolicyType.UnsafeUrl:
                    return ReferrerPolicyHeader.UnsafeUrl;
                case ReferrerPolicyType.StrictOriginWhenCrossOrigin:
                default:
                    return ReferrerPolicyHeader.StrictOriginWhenCrossOrigin;
            }
        }

        private enum ReferrerPolicyType
        {
            NoReferrer,
            NoReferrerWhenDowngrade,
            Origin,
            OriginWhenCrossOrigin,
            SameOrigin,
            StrictOrigin,
            StrictOriginWhenCrossOrigin,
            UnsafeUrl
        }
    }
}