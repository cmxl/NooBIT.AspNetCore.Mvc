namespace NooBIT.Web.Security.ContentSecurityPolicy.Sources
{
    public class ReferrerSource : Source
    {
        public static Source NoReferrer => new ReferrerSource("'no-referrer'");
        public static Source NoneWhenDowngrade => new ReferrerSource("'none-when-downgrade'");
        public static Source Origin => new ReferrerSource("'origin'");
        public static Source OriginWhenCrossOrigin => new ReferrerSource("'origin-when-cross-origin'");
        public static Source UnsafeUrl => new ReferrerSource("'unsafe-url'");

        internal ReferrerSource(string name) : base(name)
        {
        }
    }
}