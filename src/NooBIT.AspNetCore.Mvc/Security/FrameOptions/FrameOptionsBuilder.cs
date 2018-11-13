using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;
using System;

namespace NooBIT.AspNetCore.Mvc.Security.FrameOptions
{
    public class FrameOptionsBuilder : IHeaderBuilder
    {
        private readonly Header _header;

        public FrameOptionsBuilder()
        {
            _header = Header.FrameOptions;
            _header.Value = FrameOptionsHeader.SameOrigin;
        }

        public Header Build() => _header;

        public FrameOptionsBuilder Deny() => SetFrameOptions(FrameOptionsHeader.Deny);

        public FrameOptionsBuilder SameOrigin() => SetFrameOptions(FrameOptionsHeader.SameOrigin);

        public FrameOptionsBuilder AllowFrom(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            return SetFrameOptions(FrameOptionsHeader.AllowFrom + " " + url);
        }

        private FrameOptionsBuilder SetFrameOptions(string value)
        {
            _header.Value = value;
            return this;
        }
    }
}