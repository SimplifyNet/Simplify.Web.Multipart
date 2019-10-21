# Simplify.Web.Multipart

[![Nuget Version](https://img.shields.io/nuget/v/Simplify.Web.Multipart)](https://www.nuget.org/packages/Simplify.Web.Multipart/)
[![Nuget Download](https://img.shields.io/nuget/dt/Simplify.Web.Multipart)](https://www.nuget.org/packages/Simplify.Web.Multipart/)
[![AppVeyor branch](https://img.shields.io/appveyor/ci/i4004/simplify-web-multipart/master)](https://ci.appveyor.com/project/i4004/simplify-web-multipart)
[![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/Simplify.Web.Multipart)](https://libraries.io/nuget/Simplify.Web.Multipart)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/SimplifyNet/Simplify.Web.Multipart)](https://www.codefactor.io/repository/github/simplifynet/simplify.web.Multipart)
![Platform](https://img.shields.io/badge/platform-.NET%20Standard%202.0-lightgrey)

`Simplify.Web.Multipart` is a package which provides multipart form view model and model binder for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework.

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
