namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources
{
    public class MediaTypeSource : Source
    {
        public MediaTypeSource(string type, string subtype) : base(type + "/" + subtype)
        {
        }
    }
}