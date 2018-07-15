namespace NooBIT.AspNetCore.Mvc.Http.Headers
{
    public sealed class XssProtectionHeader : Header
    {
        public static readonly string Disable = "0";
        public static readonly string Enable = "1";
        public static readonly string Block = "1; mode=block";

        internal XssProtectionHeader() : base("X-XSS-Protection")
        {
        }
    }
}