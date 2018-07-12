using NooBIT.Web.Http;
using NooBIT.Web.Security.ContentSecurityPolicy;
using NooBIT.Web.Security.ContentSecurityPolicy.Directives;
using NooBIT.Web.Security.ContentSecurityPolicy.Sources;
using NooBIT.Web.Tests.Fixtures;
using Xunit;

namespace NooBIT.Web.Tests
{
    public class ContentSecurityPolicyTests : IClassFixture<ContentSecurityPolicyFixture>
    {
        public ContentSecurityPolicyTests(ContentSecurityPolicyFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly ContentSecurityPolicyFixture _fixture;

        [Fact]
        public void Add_Directive_Without_Helper_Method_Has_Same_Result_As_With()
        {
            var nonce = "1abc2df63bc";
            var data = "abcbabcbabcbba12315245523875abc";

            var builder = new ContentSecurityPolicyBuilder();
            var builder2 = new ContentSecurityPolicyBuilder();

            builder.AddDirective(Directive.BaseUri, x =>
            {
                x.AddNonceSource(nonce);
                x.AddDataSource(data);
            });

            builder2.AddBaseUri(x =>
            {
                x.AddNonceSource(nonce);
                x.AddDataSource(data);
            });

            var header = builder.Build();
            var header2 = builder2.Build();

            Assert.NotNull(header);
            Assert.NotEmpty(header.Value);
            Assert.Equal(Header.ContentSecurityPolicy.Name, header.Name);
            Assert.Equal($"base-uri 'nonce-{nonce}' data:{data};", header.Value);

            Assert.Equal(header.Name, header2.Name);
            Assert.Equal(header.Value, header2.Value);

            Assert.NotEqual(header, header2);
        }

        [Fact]
        public void Default_CSP_Is_Always_The_Same()
        {
            var builder = new ContentSecurityPolicyBuilder();
            var header = builder.Default().Build();

            Assert.NotNull(header);
            Assert.NotEmpty(header.Value);
            Assert.Equal(Header.ContentSecurityPolicy.Name, header.Name);
            Assert.Equal(_fixture.DefaultCsp, header.Value);
        }

        [Fact]
        public void ContentSecurityPolicyBuilder_Will_Generate_Expected_Header_Value()
        {
            var builder = new ContentSecurityPolicyBuilder()
                .AddDefaultSource(x => x.AddSource(Source.Self))
                .AddScriptSource(x =>
                {
                    x.AddSource(Source.Self);
                    x.AddSource(Source.UnsafeInline);
                })
                .AddStyleSource(x =>
                {
                    x.AddSource(Source.Self);
                    x.AddSource(Source.UnsafeInline);
                    x.AddUriSource("https://fonts.googleapis.com");
                })
                .AddFontSource(x =>
                {
                    x.AddSource(Source.Self);
                    x.AddUriSource("https://fonts.gstatic.com");
                    x.AddDataSource("");
                })
                .AddBaseUri(x => x.AddSource(Source.Self));

            var csp = builder.Build();
            Assert.Equal(_fixture.ContentSecurityPolicy, csp.Value);
        }

        [Fact]
        public void No_Options_Return_Header_Without_Value()
        {
            var builder = new ContentSecurityPolicyBuilder();
            var header = builder.Build();
            Assert.NotNull(header);
            Assert.Empty(header.Value);
            Assert.Equal(Header.ContentSecurityPolicy.Name, header.Name);
        }
    }
}