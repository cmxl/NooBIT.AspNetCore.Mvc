namespace NooBIT.AspNetCore.Mvc.Http.Headers
{
    internal class ContentTypeOptionsHeader : Header
    {
        public static readonly string NoSniff = "nosniff";

        internal ContentTypeOptionsHeader() : base("X-Content-Type-Options")
        {
        }
    }
}