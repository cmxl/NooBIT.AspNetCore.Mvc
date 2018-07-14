namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources
{
    public class RequireSriForSource : Source
    {
        public static Source Script => new RequireSriForSource("script");
        public static Source Style => new RequireSriForSource("style");

        internal RequireSriForSource(string name) : base(name)
        {
        }
    }
}