#IIS 

# Web.config

The `web.config` is an **XML configuration file** that IIS reads to know how a site, application or folder must behave. It lets you configure IIS (and ASP.NET) **per application** without touching the global server configuration, so the configuration travels together with the deployed code.

It's placed in the **root folder** of the site / application, and optionally in subfolders to override settings only for that path.

Some important characteristics: 

* Changes are **applied automatically** when the file is saved, no IIS restart is needed. For ASP.NET apps saving it **recycles the application** (sessions in memory are lost).
* It's **case sensitive** (`system.webServer` ≠ `system.WebServer`).
* An invalid XML or an unknown section breaks the whole site with an **HTTP 500.19** error.
* IIS never serves the `web.config` file to clients (it's blocked by request filtering).

## Configuration hierarchy

The configuration is **inherited** from the most global level to the most specific one. Each level can add, remove or override what comes from the parent:

```
machine.config                     (.NET Framework - whole machine)
└── root web.config                (.NET Framework - whole machine)
    └── applicationHost.config     (IIS - whole server)
        └── Site\web.config        (site root)
            └── App\web.config     (application / virtual directory)
                └── Folder\web.config (only that folder)
```

| File | Location | Scope |
|---|---|---|
| `machine.config` | `%windir%\Microsoft.NET\Framework64\v4.0.30319\Config\` | .NET settings for the machine |
| `web.config` (root) | Same folder as `machine.config` | ASP.NET defaults for the machine |
| `applicationHost.config` | `%windir%\System32\inetsrv\config\` | IIS global config: sites, bindings, app pools, modules |
| `web.config` | Site / app / folder | Only that site, app or folder |

> Sites, bindings, application pools and certificates are **not** configured in the `web.config`, they live in `applicationHost.config` (IIS Manager or `appcmd`).

## Basic structure

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>

  <!-- Key/value settings readable from the application -->
  <appSettings>
    <add key="Environment" value="Production" />
  </appSettings>

  <!-- Database connection strings -->
  <connectionStrings>
    <add name="Default" connectionString="Server=[SERVER];Database=[DB];User Id=[USER];Password=[PASSWORD];" providerName="System.Data.SqlClient" />
  </connectionStrings>

  <!-- ASP.NET (classic pipeline / .NET Framework) settings -->
  <system.web>
    <compilation debug="false" targetFramework="4.8" />
    <httpRuntime targetFramework="4.8" />
  </system.web>

  <!-- IIS 7+ settings (integrated pipeline) -->
  <system.webServer>
    ...
  </system.webServer>

</configuration>
```

### system.web vs system.webServer

| Section | Who reads it | Used for |
|---|---|---|
| `<system.web>` | ASP.NET (.NET Framework) | Compilation, sessions, ASP.NET authentication, `maxRequestLength`, custom errors of ASP.NET |
| `<system.webServer>` | IIS 7+ | Everything related to IIS: static files, headers, rewrite, handlers, modules, compression, IIS errors... |

For static sites, SPAs or ASP.NET Core apps, practically everything goes inside `<system.webServer>`.

## Main sections of system.webServer

### Default document

Which file is served when the request points to a folder (`https://myapp.com/`).

```xml
<defaultDocument enabled="true">
  <files>
    <clear />
    <add value="index.html" />
    <add value="default.aspx" />
  </files>
</defaultDocument>
```

`<clear />` removes the inherited list (`Default.htm`, `iisstart.htm`...) so only the defined ones are used, in order.

### Directory browsing

```xml
<directoryBrowse enabled="false" />
```

Should be **disabled** in production. If there is no default document and browsing is disabled, IIS responds with **403.14**.

### Static content and MIME types

IIS **only serves files whose extension has a MIME type registered**. Any unknown extension returns a **404.3**.

```xml
<staticContent>
  <!-- Remove first to avoid "duplicate collection entry" error if it's already defined at server level -->
  <remove fileExtension=".json" />
  <mimeMap fileExtension=".json" mimeType="application/json" />

  <remove fileExtension=".webp" />
  <mimeMap fileExtension=".webp" mimeType="image/webp" />

  <remove fileExtension=".woff2" />
  <mimeMap fileExtension=".woff2" mimeType="font/woff2" />

  <!-- Client cache for static files: 7 days -->
  <clientCache cacheControlMode="UseMaxAge" cacheControlMaxAge="7.00:00:00" />
</staticContent>
```

> Adding a `mimeMap` that already exists at a parent level throws a **500.19 (duplicate collection entry)**. Using `<remove>` before `<mimeMap>` avoids it.

The `clientCache` modes are: `NoControl`, `DisableCache`, `UseMaxAge` and `UseExpires`.

### Custom headers (and security headers)

```xml
<httpProtocol>
  <customHeaders>
    <!-- Remove headers that expose technology -->
    <remove name="X-Powered-By" />

    <!-- Security headers -->
    <add name="Strict-Transport-Security" value="max-age=31536000; includeSubDomains" />
    <add name="X-Content-Type-Options" value="nosniff" />
    <add name="X-Frame-Options" value="SAMEORIGIN" />
    <add name="Referrer-Policy" value="strict-origin-when-cross-origin" />
    <add name="Content-Security-Policy" value="default-src 'self'" />
  </customHeaders>
</httpProtocol>
```

To also remove the `Server: Microsoft-IIS/10.0` header (IIS 10, Windows Server 2016 v1709+):

```xml
<security>
  <requestFiltering removeServerHeader="true" />
</security>
```

For ASP.NET Framework apps, the `X-AspNet-Version` header is removed in `system.web`:

```xml
<system.web>
  <httpRuntime enableVersionHeader="false" />
</system.web>
```

### Request filtering (upload size, blocked paths...)

```xml
<security>
  <requestFiltering>
    <!-- Max request body in BYTES (default 30000000 ≈ 28.6 MB). Here 100 MB -->
    <requestLimits maxAllowedContentLength="104857600" maxUrl="4096" maxQueryString="2048" />

    <!-- Block access to folders / extensions -->
    <hiddenSegments>
      <add segment="logs" />
    </hiddenSegments>
    <fileExtensions>
      <add fileExtension=".bak" allowed="false" />
    </fileExtensions>

    <!-- Allowed HTTP verbs -->
    <verbs allowUnlisted="true">
      <add verb="TRACE" allowed="false" />
    </verbs>
  </requestFiltering>
</security>
```

If a file bigger than the limit is uploaded, IIS returns **404.13**. 

> In ASP.NET Framework there is a **second limit** that also has to be increased, and it's in **KILOBYTES** (default 4096 = 4 MB):
>
> ```xml
> <system.web>
>   <httpRuntime maxRequestLength="102400" executionTimeout="300" />
> </system.web>
> ```
>
> The effective limit is always the **smallest** of both.

### Custom error pages

```xml
<httpErrors errorMode="Custom" existingResponse="Replace">
  <remove statusCode="404" />
  <error statusCode="404" path="/errors/404.html" responseMode="ExecuteURL" />
  <remove statusCode="500" />
  <error statusCode="500" path="/errors/500.html" responseMode="ExecuteURL" />
</httpErrors>
```

| Attribute | Values |
|---|---|
| `errorMode` | `DetailedLocalOnly` (default: detailed errors only from the server itself), `Custom`, `Detailed` |
| `existingResponse` | `Auto`, `Replace` (always use the IIS page), `PassThrough` (keep the response generated by the app, **recommended for APIs**) |
| `responseMode` | `File` (relative path), `ExecuteURL` (URL of the same site), `Redirect` (302 to another URL) |

> While debugging a broken site, `errorMode="Detailed"` temporarily shows the real error. Never leave it in production.

### Compression

```xml
<urlCompression doStaticCompression="true" doDynamicCompression="true" />
```

Requires the **Static / Dynamic Content Compression** role features installed. The `httpCompression` section (algorithms, MIME types to compress) can **only** be configured in `applicationHost.config`.

### Redirects

Simple redirect of the whole site / folder (requires the **HTTP Redirection** feature):

```xml
<httpRedirect enabled="true" destination="https://www.newdomain.com" httpResponseStatus="Permanent" exactDestination="false" />
```

For anything more complex use URL Rewrite.

## URL Rewrite

The **URL Rewrite** module is not installed by default, it must be downloaded and installed from Microsoft. If the `<rewrite>` section is used without the module installed, IIS returns **500.19**.

Main concepts of a rule:

* `match`: regular expression applied to the URL path (without domain and without the first `/`).
* `conditions`: extra checks over server variables (`{HTTPS}`, `{HTTP_HOST}`, `{REQUEST_FILENAME}`, `{QUERY_STRING}`...).
* `action`:
	* `Rewrite`: internally serves another URL, the browser URL doesn't change.
	* `Redirect`: sends a 301/302/307 to the browser.
	* `CustomResponse`, `AbortRequest`, `None`.
* `stopProcessing="true"`: if the rule matches, the following rules are not evaluated.
* Back references: `{R:1}` group of the `match`, `{C:1}` group of the last condition.

### HTTP → HTTPS

```xml
<rewrite>
  <rules>
    <rule name="HTTP to HTTPS" stopProcessing="true">
      <match url="(.*)" />
      <conditions>
        <add input="{HTTPS}" pattern="^OFF$" />
      </conditions>
      <action type="Redirect" url="https://{HTTP_HOST}/{R:1}" redirectType="Permanent" />
    </rule>
  </rules>
</rewrite>
```

### Non www → www

```xml
<rule name="Force www" stopProcessing="true">
  <match url="(.*)" />
  <conditions>
    <add input="{HTTP_HOST}" pattern="^myapp\.com$" />
  </conditions>
  <action type="Redirect" url="https://www.myapp.com/{R:1}" redirectType="Permanent" />
</rule>
```

### SPA (React, Angular, Vue)

Send every route that is not a real file or folder to `index.html`. Explained in detail in [[IIS - WebConfig React]].

```xml
<rule name="SPA Routes" stopProcessing="true">
  <match url=".*" />
  <conditions logicalGrouping="MatchAll">
    <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
    <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
    <add input="{REQUEST_URI}" pattern="^/api/" negate="true" />
  </conditions>
  <action type="Rewrite" url="/index.html" />
</rule>
```

### Reverse proxy

IIS can act as a reverse proxy in front of another backend (Node, Java, a container...). It requires **URL Rewrite + Application Request Routing (ARR)** and enabling the proxy at server level (IIS Manager → Server → Application Request Routing Cache → Server Proxy Settings → *Enable proxy*).

```xml
<rule name="Proxy API" stopProcessing="true">
  <match url="^api/(.*)" />
  <action type="Rewrite" url="http://localhost:5000/api/{R:1}" />
</rule>
```

## Handlers and modules

* **Modules**: components that participate in **every** request of the pipeline (authentication, compression, rewrite, logging...).
* **Handlers**: decide **who generates the response** depending on the path / extension / verb (static file, ASP.NET, PHP via FastCGI, ASP.NET Core...).

```xml
<handlers>
  <!-- Remove the WebDAV handler that blocks PUT / DELETE in REST APIs -->
  <remove name="WebDAV" />

  <!-- PHP using FastCGI -->
  <add name="PHP_via_FastCGI" path="*.php" verb="*" modules="FastCgiModule" scriptProcessor="C:\PHP\php-cgi.exe" resourceType="Either" />
</handlers>

<modules>
  <remove name="WebDAVModule" />
</modules>
```

> A typical problem: an API returns **405 Method Not Allowed** in `PUT` / `DELETE` requests. It's caused by WebDAV, removing both the module and the handler like above fixes it.

## Authentication and authorization

```xml
<security>
  <authentication>
    <anonymousAuthentication enabled="false" />
    <windowsAuthentication enabled="true" />
  </authentication>

  <authorization>
    <remove users="*" roles="" verbs="" />
    <add accessType="Allow" roles="DOMAIN\WebUsers" />
  </authorization>

  <!-- Restrict by IP (requires the "IP and Domain Restrictions" feature) -->
  <ipSecurity allowUnlisted="false">
    <add ipAddress="10.0.0.0" subnetMask="255.0.0.0" allowed="true" />
  </ipSecurity>
</security>
```

> The `authentication` and `ipSecurity` sections are **locked by default** at server level. Using them in a `web.config` produces **500.19 - This configuration section cannot be used at this path**. They must be unlocked first (see [[#Locked sections]]).

## CORS

With the **IIS CORS Module** installed:

```xml
<cors enabled="true" failUnlistedOrigins="true">
  <add origin="https://app.myapp.com" allowCredentials="true" maxAge="3600">
    <allowHeaders allowAllRequestedHeaders="true" />
    <allowMethods>
      <add method="GET" />
      <add method="POST" />
      <add method="PUT" />
      <add method="DELETE" />
    </allowMethods>
  </add>
</cors>
```

Without the module it can be done with `customHeaders` (`Access-Control-Allow-Origin`...), but the preflight `OPTIONS` requests would need to be handled by the application.

## ASP.NET Core

ASP.NET Core apps don't use `system.web`. IIS forwards the requests to the app through the **ASP.NET Core Module (ANCM)**, which is installed with the **.NET Hosting Bundle**. The `dotnet publish` command generates this `web.config` automatically:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath="dotnet"
                  arguments=".\MyApp.dll"
                  stdoutLogEnabled="false"
                  stdoutLogFile=".\logs\stdout"
                  hostingModel="inprocess">
        <environmentVariables>
          <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Production" />
        </environmentVariables>
      </aspNetCore>
    </system.webServer>
  </location>
</configuration>
```

| Attribute | Meaning |
|---|---|
| `processPath` | `dotnet` for framework-dependent apps, or `.\MyApp.exe` for self-contained apps |
| `arguments` | The DLL of the application |
| `hostingModel` | `inprocess` (runs inside the IIS worker process `w3wp.exe`, faster) or `outofprocess` (Kestrel in a separate process with IIS as proxy) |
| `stdoutLogEnabled` | Writes the console output to `stdoutLogFile`. Very useful to diagnose startup errors, **disable it afterwards** because files are never rotated |
| `environmentVariables` | Environment variables for the app process |

> The application pool for ASP.NET Core should use **.NET CLR version: No Managed Code**.

## The location tag

`<location>` applies configuration to a specific path **from the same file**, without creating a `web.config` in each folder.

```xml
<configuration>
  <!-- Cache 1 year only for the hashed assets folder -->
  <location path="assets">
    <system.webServer>
      <staticContent>
        <clientCache cacheControlMode="UseMaxAge" cacheControlMaxAge="365.00:00:00" />
      </staticContent>
    </system.webServer>
  </location>

  <!-- Never cache index.html so new deployments are picked up -->
  <location path="index.html">
    <system.webServer>
      <httpProtocol>
        <customHeaders>
          <add name="Cache-Control" value="no-cache, no-store, must-revalidate" />
        </customHeaders>
      </httpProtocol>
    </system.webServer>
  </location>
</configuration>
```

`inheritInChildApplications="false"` avoids that the configuration of a parent site is inherited by the applications hosted under it (a common cause of errors when an app is nested inside another site).

## Locked sections

Each section in `applicationHost.config` has an `overrideModeDefault` (`Allow` / `Deny`). If it's `Deny`, the section can't be defined in a `web.config` and IIS returns **500.19 (Config Error: This configuration section cannot be used at this path)**.

To unlock a section for the whole server:

```bash
%windir%\system32\inetsrv\appcmd.exe unlock config -section:system.webServer/security/authentication/windowsAuthentication
```

Or in IIS Manager → Server → **Configuration Editor** → select the section → **Unlock Section**.

Some sections can **never** be set in a `web.config` (`allowDefinition="AppHostOnly"`), for example `httpCompression`, `fastCgi` or `globalModules`.

## Config transformations

In Visual Studio / .NET Framework projects, environment-specific variations are defined with **XDT transformations** (`Web.Debug.config`, `Web.Release.config`...) that are applied over the base `web.config` when publishing:

```xml
<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <appSettings>
    <add key="Environment" value="Production" xdt:Transform="SetAttributes" xdt:Locator="Match(key)" />
  </appSettings>

  <system.web>
    <compilation xdt:Transform="RemoveAttributes(debug)" />
  </system.web>
</configuration>
```

Most used transforms: `Replace`, `Insert`, `Remove`, `SetAttributes`, `RemoveAttributes`. Locators: `Match(attr)`, `Condition(xpath)`, `XPath(xpath)`.

## Protecting secrets

Storing passwords or connection strings in plain text inside the `web.config` is a bad practice. Options:

* **Encrypt sections** (.NET Framework) with `aspnet_regiis`. The app reads them decrypted transparently:

```bash
%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe -pef "connectionStrings" "C:\inetpub\wwwroot\MyApp"
```

```bash
%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe -pdf "connectionStrings" "C:\inetpub\wwwroot\MyApp"
```

* Use **environment variables** (`environmentVariables` in ASP.NET Core or at app pool level).
* Use an external secret store ([[Vault]], Azure Key Vault...).
* Keep the `web.config` with real secrets **out of the repository**.

## Editing from the command line

`appcmd` modifies the `web.config` of a site without editing the XML manually:

```bash
%windir%\system32\inetsrv\appcmd.exe set config "Default Web Site/MyApp" -section:system.webServer/directoryBrowse /enabled:false
```

```bash
%windir%\system32\inetsrv\appcmd.exe list config "Default Web Site/MyApp" -section:system.webServer/defaultDocument
```

With PowerShell (`WebAdministration` / `IISAdministration` modules):

```powershell
Set-WebConfigurationProperty -PSPath 'IIS:\Sites\Default Web Site\MyApp' -Filter 'system.webServer/directoryBrowse' -Name 'enabled' -Value $false
```

## Troubleshooting: common errors

| Error | Usual cause |
|---|---|
| **500.19** | Malformed XML, section of a **module not installed** (e.g. `<rewrite>` without URL Rewrite, `<aspNetCore>` without Hosting Bundle), **locked section**, duplicated entry (`mimeMap`, `add` in a collection), or IIS user without read permission over the folder |
| **500.21** | Handler references a module not installed (typical in ASP.NET Core without Hosting Bundle) |
| **500.30 / 502.5** | ASP.NET Core app failed to start (enable `stdoutLogEnabled` and check the logs / Event Viewer) |
| **403.14** | No default document and directory browsing disabled |
| **404.3** | Extension without MIME type registered |
| **404.13** | Request body bigger than `maxAllowedContentLength` |
| **405** in PUT/DELETE | WebDAV module intercepting the request |
| **401.2 / 401.3** | Authentication config or NTFS permissions of the app pool identity (`IIS AppPool\<PoolName>`) |

Tips: 
* The 500.19 page shows the **exact line** of the `web.config` that fails (from the server itself or with detailed errors).
* Check `Event Viewer → Windows Logs → Application` and the IIS logs at `%SystemDrive%\inetpub\logs\LogFiles`.
* **Failed Request Tracing** (FREB) shows step by step what each module did with the request.

## Complete example

A production-ready `web.config` for a static SPA with security headers, HTTPS and caching:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.webServer>

    <defaultDocument>
      <files>
        <clear />
        <add value="index.html" />
      </files>
    </defaultDocument>

    <directoryBrowse enabled="false" />

    <staticContent>
      <remove fileExtension=".json" />
      <mimeMap fileExtension=".json" mimeType="application/json" />
      <remove fileExtension=".webp" />
      <mimeMap fileExtension=".webp" mimeType="image/webp" />
      <remove fileExtension=".woff2" />
      <mimeMap fileExtension=".woff2" mimeType="font/woff2" />
      <clientCache cacheControlMode="UseMaxAge" cacheControlMaxAge="7.00:00:00" />
    </staticContent>

    <urlCompression doStaticCompression="true" doDynamicCompression="true" />

    <httpProtocol>
      <customHeaders>
        <remove name="X-Powered-By" />
        <add name="Strict-Transport-Security" value="max-age=31536000; includeSubDomains" />
        <add name="X-Content-Type-Options" value="nosniff" />
        <add name="X-Frame-Options" value="SAMEORIGIN" />
        <add name="Referrer-Policy" value="strict-origin-when-cross-origin" />
      </customHeaders>
    </httpProtocol>

    <security>
      <requestFiltering removeServerHeader="true" />
    </security>

    <rewrite>
      <rules>
        <rule name="HTTP to HTTPS" stopProcessing="true">
          <match url="(.*)" />
          <conditions>
            <add input="{HTTPS}" pattern="^OFF$" />
          </conditions>
          <action type="Redirect" url="https://{HTTP_HOST}/{R:1}" redirectType="Permanent" />
        </rule>
        <rule name="SPA Routes" stopProcessing="true">
          <match url=".*" />
          <conditions logicalGrouping="MatchAll">
            <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
          </conditions>
          <action type="Rewrite" url="/index.html" />
        </rule>
      </rules>
    </rewrite>

  </system.webServer>

  <location path="index.html">
    <system.webServer>
      <httpProtocol>
        <customHeaders>
          <add name="Cache-Control" value="no-cache, no-store, must-revalidate" />
        </customHeaders>
      </httpProtocol>
    </system.webServer>
  </location>
</configuration>
```

## Best practices

* Keep **one `web.config` per application** and use `<location>` instead of spreading files across subfolders.
* Use `<remove>` / `<clear />` before adding entries to collections to avoid duplicates with inherited config.
* Never deploy with `debug="true"`, `errorMode="Detailed"` or `stdoutLogEnabled="true"` in production.
* Disable directory browsing and remove headers that expose the technology (`Server`, `X-Powered-By`, `X-AspNet-Version`).
* Don't store secrets in plain text.
* Validate the XML before deploying: a single error takes down the whole site.
* Version the `web.config` together with the code (without secrets) so the IIS behaviour is reproducible.

## Related

* [[IIS]]
* [[IIS - Static website]]
* [[IIS - WebConfig React]]
