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



