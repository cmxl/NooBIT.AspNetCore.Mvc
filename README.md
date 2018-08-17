# NooBIT.AspNetCore.Mvc

Some useful ASP.NET Core performance and security extensions

---

## Project Health

| Service | Status |
| --- | --- |
| AppVeyor | [![Build status](https://ci.appveyor.com/api/projects/status/jw2f5s8q57tlisgf/branch/master?svg=true)](https://ci.appveyor.com/project/cmxl/noobit-web/branch/master) |
| SonarCloud | [![Maintainability](https://sonarcloud.io/api/project_badges/measure?project=NooBIT.AspNetCore.Mvc&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=NooBIT.AspNetCore.Mvc) <br /> [![Maintainability](https://sonarcloud.io/api/project_badges/measure?project=NooBIT.AspNetCore.Mvc&metric=coverage)](https://sonarcloud.io/dashboard?id=NooBIT.AspNetCore.Mvc) |


## Packages

| Package | NuGet |
| --- | --- |
| NooBIT.AspNetCore.Mvc | [![NuGet](https://buildstats.info/nuget/NooBIT.AspNetCore.Mvc)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc) |
| NooBIT.AspNetCore.Mvc.AutoMapper | [![NuGet](https://buildstats.info/nuget/NooBIT.AspNetCore.Mvc.AutoMapper)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc.AutoMapper) |
| NooBIT.AspNetCore.Mvc.Optimizations | [![NuGet](https://buildstats.info/nuget/NooBIT.AspNetCore.Mvc.Optimizations)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc.Optimizations) |
| NooBIT.AspNetCore.Mvc.SimpleInjector | [![NuGet](https://buildstats.info/nuget/NooBIT.AspNetCore.Mvc.SimpleInjector)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc.SimpleInjector) |

---

## Usage

Most functions can be used directly in ASP.NET Core's `Startup.cs` class.

### WebOptimizations

Optimizations like caching, compression and bundling of styles and scripts can be configured like so:

```csharp
private readonly IWebOptimization _webOptimization;

public Startup(IHostingEnvironment environment)
{
    _webOptimization = new WebOptimization(environment);
}

public void ConfigureServices(IServiceCollection services)
{
    services.AddWebOptimizations(_webOptimization); 
}

public void Configure(IApplicationBuilder app)
{
    app.UseWebOptimizations(_webOptimizations);
}
```

Default values are gzip compression and a cache duration of 365 days.
You can implement your own rules by implementing `IWebOptimization` or inheriting from `WebOptimization`:

```csharp
public class WebOptimization : IWebOptimization
{
    public WebOptimization(IHostingEnvironment environment)
    {
        Environment = environment;
    }

    public IHostingEnvironment Environment { get; }
    public virtual TimeSpan CacheDuration { get; } = TimeSpan.FromDays(365);

    public virtual void ConfigurePipeline(IAssetPipeline pipeline)
    {
    }

    public virtual void ConfigureCompression(ResponseCompressionOptions options)
    {
        options.Providers.Add<GzipCompressionProvider>();
        options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
    }

    public virtual void ConfigureCaching(ResponseCachingOptions options)
    {
    }
}
```

### AutoMapper

An easy extension for AutoMapper to validate all mappings after adding the service.

```csharp
public static IServiceCollection AddAutoMapperWithValidation(this IServiceCollection services, params Assembly[] assemblies)
{
    services.AddAutoMapper(assemblies);
    Mapper.AssertConfigurationIsValid();
    return services;
}
```

### SimpleInjector

An extension to configure SimpleInjector with all common registrations and cross wiring.
You only need to register your own stuff via the registerComponents action.

```csharp
public static IServiceCollection AddSimpleInjector(this IServiceCollection services, Action<Container> registerComponents, out Container container)
{
    container = new Container();
    container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

    services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
    services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

    registerComponents?.Invoke(container);

    services.EnableSimpleInjectorCrossWiring(container);
    services.UseSimpleInjectorAspNetRequestScoping(container);

    return services;
}
```

An example could look like this:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSimpleInjector(container =>
    {
        // register your stuff here. basic wiring of controllers and stuff is already done internally
        container.Register<IMyImplementation, MyImplementation>(); 
    }, out _);
}
```

### Custom Headers

You can create your own headers by using the `Header` class.

```csharp
new Header("X-My-Header") { Value = "my value" };
```

Or just inherit from it.

```csharp
public class MyHeader : Header
{
    public MyHeader() : base("X-My-Header")
    {
    }
}
```

You can now use the header with the `HeaderPolicyBuilder` and the `CustomHeaderMiddleware`:

```csharp
app.UseCustomHeaders(new HeaderPolicyBuilder().AddHeader(new MyHeader() { Value = "My Custom Value!" }));
```

Another approach could be to create your own `IHeaderBuilder` implementation.

```csharp
public class MyCustomHeaderBuilder : IHeaderBuilder
{
    private string _value;

    public MyCustomHeaderBuilder WithValue(string value)
    {
        _value = value;
        return this;
    }

    public Header Build()
    {
        return new MyHeader() { Value = _value };
    }
}
```

Then use the builder directly with the `HeaderPolicyBuilder`.

```csharp
app.UseCustomHeaders(new HeaderPolicyBuilder().AddHeader(new MyCustomHeaderBuilder().WithValue("My Custom Value!")));
```

Built-in [Headers](https://github.com/cmxl/NooBIT.AspNetCore.Mvc/tree/master/src/NooBIT.AspNetCore.Mvc/Http/Headers) and [Builders](https://github.com/cmxl/NooBIT.AspNetCore.Mvc/tree/master/src/NooBIT.AspNetCore.Mvc/Security):

* `ContentSecurityPolicyBuilder`
* `FrameOptionsBuilder`
* `ReferrerPolicyBuilder`
* `StrictTransportSecurityBuilder`
* `XssProtectionBuilder`

You can use recommended security headers easily via the following extension:

```csharp
new HeaderPolicyBuilder().AddRecommendedSecurityHeaders(environment);
```

Which uses the following declarations

```csharp
public HeaderPolicyBuilder AddRecommendedSecurityHeaders(IHostingEnvironment environment)
{
    RemoveServerHeader()
        .RemovePoweredByHeader()
        .AddContentTypeOptionsNoSniff()
        .AddContentSecurity(new ContentSecurityPolicyBuilder()
            .Default())
        .AddXssProtection(new XssProtectionBuilder()
            .Block())
        .AddFrameOptions(new FrameOptionsBuilder()
            .UseSameOrigin())
        .AddReferrerPolicy(new ReferrerPolicyBuilder()
            .UseStrictOriginWhenCrossOrigin());

    if (!environment.IsDevelopment())
    {
        AddStrictTransportSecurity(new StrictTransportSecurityBuilder()
            .UseMaxAge((uint) TimeSpan.FromDays(365).TotalSeconds)
            .WithIncludeSubDomains()
            .WithPreload());
    }

    return this;
}
```

If you need more control over those header values you can just use the builders as you want 😉.
