# Simplify.Web.Multipart

[![Nuget Version](https://img.shields.io/nuget/v/Simplify.Web.Multipart)](https://www.nuget.org/packages/Simplify.Web.Multipart/)
[![Nuget Download](https://img.shields.io/nuget/dt/Simplify.Web.Multipart)](https://www.nuget.org/packages/Simplify.Web.Multipart/)
[![Build Package](https://github.com/SimplifyNet/Simplify.Web.Multipart/actions/workflows/build.yml/badge.svg)](https://github.com/SimplifyNet/Simplify.Web.Multipart/actions/workflows/build.yml)
[![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/Simplify.Web.Multipart)](https://libraries.io/nuget/Simplify.Web.Multipart)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/SimplifyNet/Simplify.Web.Multipart)](https://www.codefactor.io/repository/github/simplifynet/simplify.web.Multipart)
![Platform](https://img.shields.io/badge/platform-.NET%2010.0%20%7C%20.NET%20Standard%202.1-lightgrey)

[Simplify.Web.Multipart](https://www.nuget.org/packages/Simplify.Web.Multipart/) is a package which provides multipart form view model and model binder for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework.

## Quick start

### Registering binder

```csharp
public void Configuration(IApplicationBuilder app)
{
    // ...existing code...
    HttpModelHandler.RegisterModelBinder<HttpMultipartFormModelBinder>();
    // ...existing code...
    app.UseSimplifyWeb();
}

public void ConfigureServices(IServiceCollection services)
{
    // ...existing code...
    DIContainer.Current.RegisterHttpMultipartFormModelBinder();
    // ...existing code...
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

        Model.Files;
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
        Model.Files;
    }
}
```

### Binding parameters to a strongly typed model

Instead of searching through the `Parameters` list manually, you can bind the multipart form parameters to a strongly typed model the same way as for a regular query/form/JSON request. Inherit your model from `MultipartModel` (which exposes `Files`) and add your own properties:

```csharp
public class UploadModel : MultipartModel
{
    public string Title { get; set; }

    public int Count { get; set; }
}
```

The parameters are parsed into the model properties automatically (the same parser as `Simplify.Web` query/form binding is reused, so `[BindProperty]`, `[Exclude]`, `[Format]`, `IList<T>` properties and validation attributes are all supported), while the uploaded files remain accessible via `Model.Files`:

```csharp
public class MyController : Controller2<UploadModel>
{
    public async Task<ControllerResponse> Invoke()
    {
        Model.Title; // bound from the "Title" multipart parameter
        Model.Count; // bound from the "Count" multipart parameter
        Model.Files; // uploaded files
    }
}
```

The legacy `MultipartViewModel` (which exposes the raw `Parameters` list) still works as before and now also inherits from `MultipartModel`.
