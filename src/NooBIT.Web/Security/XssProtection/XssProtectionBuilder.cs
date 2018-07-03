using NooBIT.Web.Http.Headers;

namespace NooBIT.Web.Security.XssProtection
{
    public class XssProtectionBuilder
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

        public string Build()
        {
            switch (_type)
            {
                case XssProtectionType.Disable:
                    return XssProtectionHeader.Disable;
                case XssProtectionType.Enable:
                    return XssProtectionHeader.Enable;
                case XssProtectionType.Block:
                default:
                    return XssProtectionHeader.Block;
            }
        }

        private enum XssProtectionType
        {
            Disable,
            Enable,
            Block
        }
    }
}