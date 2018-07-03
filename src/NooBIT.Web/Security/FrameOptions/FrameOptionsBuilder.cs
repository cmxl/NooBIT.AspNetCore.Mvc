using System;
using NooBIT.Web.Http.Headers;

namespace NooBIT.Web.Security.FrameOptions
{
    public class FrameOptionsBuilder
    {
        private string _allowFromUrl;

        private FrameOptionsType _type = FrameOptionsType.SameOrigin;

        public FrameOptionsBuilder UseDeny()
        {
            _type = FrameOptionsType.Deny;
            return this;
        }

        public FrameOptionsBuilder UseSameOrigin()
        {
            _type = FrameOptionsType.SameOrigin;
            return this;
        }

        public FrameOptionsBuilder UseAllowFrom(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            _type = FrameOptionsType.AllowFrom;
            _allowFromUrl = url;
            return this;
        }


        public string Build()
        {
            switch (_type)
            {
                case FrameOptionsType.Deny:
                    return FrameOptionsHeader.Deny;
                case FrameOptionsType.AllowFrom:
                    return FrameOptionsHeader.AllowFrom + " " + _allowFromUrl;
                case FrameOptionsType.SameOrigin:
                default:
                    return FrameOptionsHeader.SameOrigin;
            }
        }

        private enum FrameOptionsType
        {
            Deny,
            SameOrigin,
            AllowFrom
        }
    }
}