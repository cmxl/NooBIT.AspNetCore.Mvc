using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;
using System;

namespace NooBIT.AspNetCore.Mvc.Security.FrameOptions
{
    public class FrameOptionsBuilder : IHeaderBuilder
    {
        private string _value = FrameOptionsHeader.SameOrigin;

        public Header Build()
        {
            var header = Header.FrameOptions;
            header.Value = _value;
            return header;
        }

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
            _value = value;
            return this;
        }
    }
}