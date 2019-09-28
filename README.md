# Simplify.Web.Multipart

`Simplify.Web.Multipart` is a package which provides multipart form view model and model binder for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework.

## Package status

| Latest version       | [![Nuget version](http://img.shields.io/badge/nuget-v1.0.1-blue.png)](https://www.nuget.org/packages/Simplify.Web.Multipart/) |
| :------------------- | :---------------------------------------------------------------------------------------------------------------------------: |
| **Target Framework** |                                                         Standard 2.0                                                          |

## Build status

| Branch     | Status                                                                                                                                                                                      |
| :--------- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **master** | [![AppVeyor Build status](https://ci.appveyor.com/api/projects/status/i8sons2botn3xxiw/branch/master?svg=true)](https://ci.appveyor.com/project/i4004/simplify-web-multipart/branch/master) |

## Examples

## Getting files from client

### Registering binder

```csharp
public void Configuration(IAppBuilder app)
{
    ...
    HttpModelHandler.RegisterModelBinder<HttpMultipartFormModelBinder>();
    ...
    app.UseSimplifyWeb();
}
```

### Accessing model

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
