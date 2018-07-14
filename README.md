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
| NooBIT.AspNetCore.Mvc | [![NuGet](https://img.shields.io/nuget/v/NooBIT.AspNetCore.Mvc.svg?style=flat)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc) |
| NooBIT.AspNetCore.Mvc.AutoMapper | [![NuGet](https://img.shields.io/nuget/v/NooBIT.AspNetCore.Mvc.AutoMapper.svg?style=flat)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc.AutoMapper) |
| NooBIT.AspNetCore.Mvc.Optimizations | [![NuGet](https://img.shields.io/nuget/v/NooBIT.AspNetCore.Mvc.Optimizations.svg?style=flat)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc.Optimizations) |
| NooBIT.AspNetCore.Mvc.SimpleInjector | [![NuGet](https://img.shields.io/nuget/v/NooBIT.AspNetCore.Mvc.SimpleInjector.svg?style=flat)](https://www.nuget.org/packages/NooBIT.AspNetCore.Mvc.SimpleInjector) |

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
To make it even more robust `Verify()` will be called automatically.
You can sepcifiy the `VerificationOption` to adjust to gain a bit more performance in production environments.


```csharp
public static IServiceCollection AddSimpleInjector(this IServiceCollection services, Action<Container> registerComponents, VerificationOption verificationOption = VerificationOption.VerifyAndDiagnose)
{
    var container = new Container();
    container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

    services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
    services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

    registerComponents?.Invoke(container);

    services.EnableSimpleInjectorCrossWiring(container);
    services.UseSimpleInjectorAspNetRequestScoping(container);

    container.Verify(verificationOption);

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
    }, VerificationOption.VerifyOnly);
}
```

### Custom Headers

This is gonna be a bit more to write.
*To be continued...*