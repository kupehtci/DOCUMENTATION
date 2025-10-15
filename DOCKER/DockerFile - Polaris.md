#DOCKER 

# DockerFile - Polaris


The Polaris project has the following `DockerFile` for running Polaris Doc API: 

```DockerFile

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/PolarisDoc.Api/PolarisDoc.Api.csproj", "src/Apps/PolarisDoc.Api/"]
COPY ["src/Common/PolarisDoc.Infrastructure/PolarisDoc.Infrastructure.csproj", "src/Common/PolarisDoc.Api.Infrastructure/"]
COPY ["src/Common/PolarisDoc.Application/PolarisDoc.Application.csproj", "src/Common/PolarisDoc.Api.Application/"]
COPY ["src/Common/PolarisDoc.Domain/PolarisDoc.Domain.csproj", "src/Common/PolarisDoc.Api.Domain/"]
RUN dotnet restore "src/Apps/PolarisDoc.Api/PolarisDoc.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/PolarisDoc.Api"
RUN dotnet build "PolarisDoc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PolarisDoc.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PolarisDoc.Api.dll"]%
```