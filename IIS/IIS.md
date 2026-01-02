#IIS 

# Internet Information Services IIS

IIS or Internet information Services is a server functionality that can be enabled in a windows server to host websites, web application and backend services on this OS. 

It listens for HTTP or HTTPS requests and returns the appropriate content that can be either HTML pages, API responses and even files. 

The main characteristic is that is **modular** that can be adapted with modules to serve static content (HTML, images, CSS and JS) and even dynamic content (ASP.NET, classic ASP and others). 

Its normally used for: 
* Hosting internal or public: 
	* websites
	* REST APIs
	* Web Apps (ASP.NET / .NET). 
* File storage and transfer using FTP / FTPS and SMTP/NNTP. 


Its the **standard web server** for hosting .NET and .NET Framework applications on windows. 

## Licenses

IIS is proprietary and requires Windows Server license. 

## IIS vs NGINX

Nginx is the most widely used web server and as a difference with IIS, its more common to use in Linux / Unix systems. 

IIT runs only on Windows and its highly integrated with Windows Server functionalities, making it the natural choice for .NET and ASP.NET applications.

**Nginx** uses an asynchronous, event-driven architecture allowing a small set of worker processes to handle thousands of concurrent connections with minimal memory usage. 
On the other hand, **IIS** uses an event-based model using HTTP.sys and worker processes that efficiently handles multiple requests asynchronously. 

Nginx is open-source (free) while IIS require a Windows Server license. 
