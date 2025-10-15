
For hosting a **static HTML application** (plain HTML, CSS, JS files) on **IIS**, your `web.config` is simple. 
This is a clean example that ensures static files are served correctly and applies some useful defaults (MIME types, caching, compression):

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.webServer>
    <!-- Allow serving static content -->
    <staticContent>
      <!-- Ensure common MIME types -->
      <mimeMap fileExtension=".html" mimeType="text/html" />
      <mimeMap fileExtension=".htm" mimeType="text/html" />
      <mimeMap fileExtension=".css" mimeType="text/css" />
      <mimeMap fileExtension=".js" mimeType="application/javascript" />
      <mimeMap fileExtension=".json" mimeType="application/json" />
      <mimeMap fileExtension=".svg" mimeType="image/svg+xml" />
      <mimeMap fileExtension=".ico" mimeType="image/x-icon" />
      <mimeMap fileExtension=".woff" mimeType="font/woff" />
      <mimeMap fileExtension=".woff2" mimeType="font/woff2" />
    </staticContent>

    <!-- Enable directory browsing if needed (usually off for security) -->
    <directoryBrowse enabled="false" />

    <!-- Enable default documents -->
    <defaultDocument>
      <files>
        <add value="index.html" />
      </files>
    </defaultDocument>

    <!-- Optional: Enable compression -->
    <urlCompression doStaticCompression="true" doDynamicCompression="true" />

    <!-- Optional: Caching headers for static files -->
    <httpProtocol>
      <customHeaders>
        <add name="Cache-Control" value="public, max-age=604800" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>
</configuration>
```

### Notes: 

- Place this `web.config` file in the **root folder** of your static HTML app.
- It tells IIS to look for `index.html` as the entry point (you can change it).
- Compression and caching are optional but improve performance.
- You can add/remove MIME types depending on your assets (images, fonts, etc.).