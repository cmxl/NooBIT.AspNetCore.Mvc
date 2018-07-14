namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources
{
    internal class DataSource : Source
    {
        internal DataSource(string value) : base("data:" + value)
        {
        }
    }
}