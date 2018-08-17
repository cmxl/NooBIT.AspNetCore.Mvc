using NooBIT.AspNetCore.Mvc.Attributes;

namespace NooBIT.AspNetCore.Mvc.Http.Headers
{
    [Experimental]
    public sealed class ClearSiteDataHeader : Header
    {
        public static readonly string All = "\"*\"";
        public static readonly string Cache = "\"cache\"";
        public static readonly string Cookies = "\"cookies\"";
        public static readonly string Storage = "\"storage\"";
        public static readonly string ExecutionContexts = "\"executionContexts\"";

        internal ClearSiteDataHeader() : base("Clear-Site-Data")
        {
        }
    }
}