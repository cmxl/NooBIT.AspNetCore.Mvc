namespace NooBIT.Web.Security.ContentSecurityPolicy.Sources
{
    internal class DataSource : Source
    {
        internal DataSource(string value) : base("data:" + value)
        {
        }
    }
}