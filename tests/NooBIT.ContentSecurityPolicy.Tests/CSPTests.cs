using NooBIT.ContentSecurityPolicy.Sources;
using NooBIT.ContentSecurityPolicy.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace NooBIT.ContentSecurityPolicy.Tests
{
    public class CSPTests : IClassFixture<TestFixture>
    {
        public CSPTests(ITestOutputHelper outputHelper, TestFixture fixture)
        {
            _outputHelper = outputHelper;
            _fixture = fixture;
        }

        private readonly TestFixture _fixture;

        private readonly ITestOutputHelper _outputHelper;

        [Fact]
        public void Test1()
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
            Assert.Equal(_fixture.ContentSecurityPolicy, csp);

            _outputHelper.WriteLine(csp);
        }
    }
}