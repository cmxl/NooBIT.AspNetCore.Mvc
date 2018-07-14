using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Security.ReferrerPolicy
{
    public class ReferrerPolicyBuilder : IHeaderBuilder
    {
        private ReferrerPolicyType _type = ReferrerPolicyType.StrictOriginWhenCrossOrigin;

        public Header Build()
        {
            var header = Header.ReferrerPolicy;

            switch (_type)
            {
                case ReferrerPolicyType.NoReferrer:
                    header.Value = ReferrerPolicyHeader.NoReferrer;
                    break;
                case ReferrerPolicyType.NoReferrerWhenDowngrade:
                    header.Value = ReferrerPolicyHeader.NoReferrerWhenDowngrade;
                    break;
                case ReferrerPolicyType.Origin:
                    header.Value = ReferrerPolicyHeader.Origin;
                    break;
                case ReferrerPolicyType.OriginWhenCrossOrigin:
                    header.Value = ReferrerPolicyHeader.OriginWhenCrossOrigin;
                    break;
                case ReferrerPolicyType.SameOrigin:
                    header.Value = ReferrerPolicyHeader.SameOrigin;
                    break;
                case ReferrerPolicyType.StrictOrigin:
                    header.Value = ReferrerPolicyHeader.StrictOrigin;
                    break;
                case ReferrerPolicyType.UnsafeUrl:
                    header.Value = ReferrerPolicyHeader.UnsafeUrl;
                    break;
                case ReferrerPolicyType.StrictOriginWhenCrossOrigin:
                default:
                    header.Value = ReferrerPolicyHeader.StrictOriginWhenCrossOrigin;
                    break;
            }

            return header;
        }

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