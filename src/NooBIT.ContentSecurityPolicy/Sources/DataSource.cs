namespace NooBIT.ContentSecurityPolicy.Sources
{
    internal class DataSource : Source
    {
        internal DataSource(string value) : base("data:" + value)
        {
        }
    }
}