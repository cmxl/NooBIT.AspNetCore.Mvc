namespace NooBIT.Web.Security.ContentSecurityPolicy.Sources
{
    internal class NonceSource : Source
    {
        internal NonceSource(string hash) : base($"'nonce-{hash}'")
        {
        }
    }
}