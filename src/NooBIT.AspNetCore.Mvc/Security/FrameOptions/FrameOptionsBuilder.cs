using System;
using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Security.FrameOptions
{
    public class FrameOptionsBuilder : IHeaderBuilder
    {
        private string _allowFromUrl;

        private FrameOptionsType _type = FrameOptionsType.SameOrigin;


        public Header Build()
        {
            var header = Header.FrameOptions;

            switch (_type)
            {
                case FrameOptionsType.Deny:
                    header.Value = FrameOptionsHeader.Deny;
                    break;
                case FrameOptionsType.AllowFrom:
                    header.Value = FrameOptionsHeader.AllowFrom + " " + _allowFromUrl;
                    break;
                case FrameOptionsType.SameOrigin:
                default:
                    header.Value = FrameOptionsHeader.SameOrigin;
                    break;
            }

            return header;
        }

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

        private enum FrameOptionsType
        {
            Deny,
            SameOrigin,
            AllowFrom
        }
    }
}