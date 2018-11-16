# moxiworks-dotnet ![Codacy Badge](https://api.codacy.com/project/badge/Grade/d3e46b3d41624fea8f61b1da33cb7139)

 .net Standards 2.0 SDK for interacting with Moxi Works API.

## Getting Started


### Prerequisites

  Access to NuGet Package Manger or .NET CLI


### Installing

Install through Package Manager

```
PM> Install-Package MoxiWorks.Platform -Version 1.2.11

```

Install through .NET CLI

```
> dotnet add package MoxiWorks.Platform --version 1.2.11

```
###### ASP.NET Core  
MVC Application Example [Here](https://github.com/ahatch1490/moxiworks_platform_example).


appsettings.json
```
{
    "AppSettings": {
        "Secret": "the_secret",
        "Identifier": "the_identifier"
    }
}
```
.Net Core requires AppSettings to be passed to the  ConfigurationManager in Startup.cs .
```
public class Startup
{
   public Startup(IConfiguration configuration)
   {
       Configuration = configuration;
       ConfigurationManager.AppSettings["Secret"] = Configuration["Secret"];
       ConfigurationManager.AppSettings["Identifier"] = Configuration["Identifier"];
   }

}
```
Inject services as singletons
```
public void ConfigureServices(IServiceCollection services)
{

    services.AddSingleton<IMoxiWorksClient, MoxiWorksClient>();
    services.AddSingleton<IAgentService, AgentService>();
    services.AddSingleton<ICompanyService, CompanyService>();
    services.AddSingleton<IOfficeService, OfficeService>();
    services.AddMvc();

}
```
## Platforms 
* .NET Core 2.0
* .NET Framework 4.6.1
* Mono 5.4
* Xamarin.iOS 10.14
* Xamarin.Mac 3.8
* Xamarin.Android 7.5
* Universal Windows Platform vNext

## Built With

* Uses [.NET Stardard 2.0](https://blogs.msdn.microsoft.com/dotnet/2017/08/14/announcing-net-standard-2-0/) 
* [NuGet](https://www.nuget.org/) - Dependency Management
* [Visual Studio](https://www.visualstudio.com/) - Coding
* [Rider](https://www.jetbrains.com/rider/) - Coding


## Versioning
For the versions available, see the [tags on this repository](https://github.com/moxiworks-platform/moxiworks-dotnet/tags).

## Authors

* **Anthony Hatch** - *Initial work* - [ahatch1490](https://github.com/ahatch1490/)

See also the list of [contributors](https://github.com/moxiworks-platform/moxiworks-dotnet/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License
