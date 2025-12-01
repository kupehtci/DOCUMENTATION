#DOCKER 

# DockerFile - .Net

A basic DockerFile template for a .Net application for an ASP.NET Core Web API project is: 

```DockerFile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

EXPOSE 80

ENTRYPOINT ["dotnet", "MyApi.dll"]
```

Its a multi-stage docker file, so the "runtime" stage only has the necessary artifact from the compilation and doesn't has the unnecessary SDK in the final image.


It uses two different base images: 
* sdk: contains the full .Net SDK: compilers, build, tools, dotnet cli and nuget. 
	* Intended for development and build stages
* aspnet: contains the .NET Runtime plus the ASP.NET core runtime and libraries for hosting the web applications.
	* Has no compilers or build tools, unnecessary in the final image for running the application. 