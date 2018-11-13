using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Security.XssProtection
{
    public class XssProtectionBuilder : IHeaderBuilder
    {
        private readonly Header _header;

        public XssProtectionBuilder()
        {
            _header = Header.XssProtection;
            _header.Value = XssProtectionHeader.Block;
        }

        public Header Build() => _header;

        public XssProtectionBuilder Disable() => SetXssProtection(XssProtectionHeader.Disable);

        public XssProtectionBuilder Enable() => SetXssProtection(XssProtectionHeader.Enable);

        public XssProtectionBuilder Block() => SetXssProtection(XssProtectionHeader.Block);

        private XssProtectionBuilder SetXssProtection(string value)
        {
            _header.Value = value;
            return this;
        }
    }
}