
This is a quick summary about the steps to follow and the configuration that can be done for making a web monitoring in Zabbix. 

##### Web Monitoring

For an active web monitoring you need to define "web scenarios". 

This web scenario consist of a number of steps that are repeatedly executed by Zabbix server in a defined order. This steps consist in GET or POST request to the web page and an status code that will check.  

This can be configured to imitate some steps performed on the web page to verify its correct behavior.

##### How to create a web scenario. 

You need to select the host in the **Monitoring** > **Hosts** section and click on inventory. 


![[zabbix-host-inventory.png]]

Once in the selected host inventory, click on web. 

![[zabbix-hosts-web.png]]

Here we can see the different web monitoring that has been configured to the host. 

We can click on an existing one or create a new web scenario. 

![[zabbix-web-create.png]]

Here we can define the basic parameters of the web scenario. 

![[zabbix-web-scenario-1.png]]

But the most important configuration is defining the steps that zabbix will apply to simulate the behavior to check the web availability. 

For creating steps of the sequencial check of the web page, we go to the Steps tab and go to **Add**: 

![[zabbix-web-scenario-step-creation.png]]

We can configure a Post with an specific form or some headers to send to the web URL specified in the top of the window. 

As an example for configuring a basic URL check to see if the web page return a 200 OK status code, we can select: 

* Retrieve Mode: Headers to only send headers and no body in the request. 
* URL: specify the URL that this step will check. 
* Required status codes: 200 as the expected status code when doing the request

![[zabbix-web-scenario-step-1.png]]

Also more parameters can be configured: 

* Name: unique step name for the step. 
* URL: url that is connected to in the step and retrieve data. 
* Query fields: HTTP **GET** variables for attaching in the GET request. 
* Post: HTTP **POST** variables. Those can be inputted as Form data in an attribute and value pairs or in raw data format as attribute and value attached with an **&** symbol (Example user=example&userid=1234)
* Variables: attributes and value pairs for GET and POST requests. 
* Follow redirects: if checked, follow the redirects that the URL can cause. 
* Required string: string of the HTML content that the page need to return. If its empty, wont check that the pattern is matched. 
* Required status codes: List of the expected HTTP status codes that page need to return as response to the defined request. Its a comma separated list (Example: 200, 2001,210-299) 

Also tags can be added to the web scenario in the tags section as a key, value pair that can be then used to filter and retrieve web scenarios configurations. 

If the website return the appropriate status codes or the appropriate string in the body when all the steps are done, the **web scenario** will return an OK status code.  

![[zabbix-web-status.png]]


##### Proxy

If the host is monitored by a Zabbix proxy, this web scenario is executed by the proxy and reported the check to the main server.