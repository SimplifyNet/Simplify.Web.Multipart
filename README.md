# Simplify.Web.Multipart

[![Nuget Version](https://img.shields.io/nuget/v/Simplify.Web.Multipart)](https://www.nuget.org/packages/Simplify.Web.Multipart/)
[![Nuget Download](https://img.shields.io/nuget/dt/Simplify.Web.Multipart)](https://www.nuget.org/packages/Simplify.Web.Multipart/)
[![Build Package](https://github.com/SimplifyNet/Simplify.Web.Multipart/actions/workflows/build.yml/badge.svg)](https://github.com/SimplifyNet/Simplify.Web.Multipart/actions/workflows/build.yml)[![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/Simplify.Web.Multipart)](https://libraries.io/nuget/Simplify.Web.Multipart)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/SimplifyNet/Simplify.Web.Multipart)](https://www.codefactor.io/repository/github/simplifynet/simplify.web.Multipart)
![Platform](https://img.shields.io/badge/platform-.NET%205.0%20%7C%20.NET%20Standard%202.0-lightgrey)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen)](http://makeapullrequest.com)

[Simplify.Web.Multipart](https://www.nuget.org/packages/Simplify.Web.Multipart/) is a package which provides multipart form view model and model binder for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework.

## Quick start

### Registering binder

```csharp
public void Configuration(IApplicationBuilder app)
{
    ...
    HttpModelHandler.RegisterModelBinder<HttpMultipartFormModelBinder>();
    ...
    app.UseSimplifyWeb();
}

public void ConfigureServices(IServiceCollection services)
{
    ...
    DIContainer.Current.RegisterHttpMultipartFormModelBinder();
    ...
}
```

### Getting files from client

#### Asynchronous

```csharp
public class MyController : ControllerAsync<MultipartViewModel>
{
    public override async Task<ControllerResponse> Invoke()
    {
        await ReadModelAsync();

        Model.Files
    }
}
```

#### Synchronous

Multipart files will be deserialized to the controller model on first model access

```csharp
public class MyController : Controller<MultipartViewModel>
{
    public override ControllerResponse Invoke()
    {
        Model.Files
    }
}
```
