
For SPA applications, the main configuration of the `web.config` file that needs to be done in order to redirect all the requests into the main index.html is URL Rewrite module. 

This module needs to be installed and configure the `web.config` with something like this: 


```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>
    <staticContent>
      <!-- Add the MIME type for webp -->
      <mimeMap fileExtension=".webp" mimeType="image/webp" />
    </staticContent>
	<rewrite>
      <rules>        
        <rule name="React Routes" stopProcessing="true">
          <match url=".*" />
          <conditions logicalGrouping="MatchAll">
            <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
          </conditions>
          <action type="Rewrite" url="/PolarisDocShowcase/index.html" />
        </rule>
      </rules>
    </rewrite>
	    <httpProtocol>
        <customHeaders>
            <add name="X-UA-Compatible" value="IE=edge" />
        </customHeaders>
    </httpProtocol>
  </system.webServer>
</configuration>
```

### Why is this??

In SPA or Single Page Applications the pages and the routes are handled by the client side through React router or similar. 

If its not configured correctly, as the client request for example `https://www.myapp.com/dashboard`, it will make a request over `dashboard` to the IIS server and it will respond with an 404 as it doesnt exists. 

In this case it needs to have the configuration to redirect the incoming request that belong to react main index.html to that file. 

#### Steps

* IIS receive a request (for example: /dashboard).
* If the physical file or directory doesn't exists (/dashboard/index.html), URL Rewrite intercept the request.
* Rewrites the URL to return index.html instead.
* React Router receives it and render the appropriate route. 
