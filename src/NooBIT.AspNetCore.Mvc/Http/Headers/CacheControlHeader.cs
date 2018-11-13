using NooBIT.AspNetCore.Mvc.Attributes;

namespace NooBIT.AspNetCore.Mvc.Http.Headers
{
    public sealed class CacheControlHeader : Header
    {
        public static readonly string Public = "public";
        public static readonly string Private = "private";
        public static readonly string NoCache = "no-cache";
        public static readonly string OnlyIfCached = "only-if-cached";
        public static readonly string MustRevalidate = "must-revalidate";
        public static readonly string ProxyRevalidate = "proxy-revalidate";

        [Experimental, NonStandard]
        public static readonly string Immutable = "immutable";

        public static readonly string NoStore = "no-store";
        public static readonly string NoTransform = "no-transform";
        public static readonly string MaxAge = "max-age={0}";

        public static readonly string SMaxAge = "s-maxage={0}";

        // time is optional here!
        public static readonly string MaxStale = "max-stale{0}";
        public static readonly string MinFresh = "min-fresh={0}";

        [Experimental, NonStandard]
        public static readonly string StaleWhileRevalidate = "stale-while-revalidate={0}";

        [Experimental, NonStandard]
        public static readonly string StaleIfError = "stale-if-error={0}";

        internal CacheControlHeader() : base("Cache-Control")
        {
        }
    }
}