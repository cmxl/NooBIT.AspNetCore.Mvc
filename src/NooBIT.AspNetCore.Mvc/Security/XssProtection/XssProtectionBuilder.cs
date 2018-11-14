using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Security.XssProtection
{
    public class XssProtectionBuilder : IHeaderBuilder
    {
        private string _value = XssProtectionHeader.Block;

        public Header Build()
        {
            var header = Header.XssProtection;
            header.Value = _value;
            return header;
        }

        public XssProtectionBuilder Disable() => SetXssProtection(XssProtectionHeader.Disable);

        public XssProtectionBuilder Enable() => SetXssProtection(XssProtectionHeader.Enable);

        public XssProtectionBuilder Block() => SetXssProtection(XssProtectionHeader.Block);

        private XssProtectionBuilder SetXssProtection(string value)
        {
            _value = value;
            return this;
        }
    }
}