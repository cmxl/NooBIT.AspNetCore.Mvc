using NooBIT.AspNetCore.Mvc.Http;
using NooBIT.AspNetCore.Mvc.Http.Headers;

namespace NooBIT.AspNetCore.Mvc.Security.XssProtection
{
    public class XssProtectionBuilder : IHeaderBuilder
    {
        private XssProtectionType _type = XssProtectionType.Block;

        public XssProtectionBuilder Disable()
        {
            _type = XssProtectionType.Disable;
            return this;
        }

        public XssProtectionBuilder Enable()
        {
            _type = XssProtectionType.Enable;
            return this;
        }

        public XssProtectionBuilder Block()
        {
            _type = XssProtectionType.Block;
            return this;
        }

        public Header Build()
        {
            var header = Header.XssProtection;
            switch (_type)
            {
                case XssProtectionType.Disable:
                    header.Value = XssProtectionHeader.Disable;
                    break;
                case XssProtectionType.Enable:
                    header.Value =XssProtectionHeader.Enable;
                    break;
                default:
                    header.Value = XssProtectionHeader.Block;
                    break;
            }

            return header;
        }

        private enum XssProtectionType
        {
            Disable,
            Enable,
            Block
        }
    }
}