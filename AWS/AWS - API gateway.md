#AWS 

# AWS - Amazon API Gateway

**Amazon API Gateway** its a managed service that lets you create, publish, monitor and operate APIs [^1]


## Resources

A **resource** in API Gateway its an specific path segment of the API's endpoint hierarchy  that lets to define: 
* HTTP Method [^m] that trigger the resource.
* If use Lambda proxy integration
* Integration type: 
	* Trigger a Lambda function
	* HTTP integration with another service (Proxy)
	* Mock
	* AWS Service
	* VPC link

In a REST API, resources can have a main resource like `/pets` and nested resources like `/pets/{id}` or another resources `/pets/getall`.

As a resume, resources in API Gateway lets you link `paths` with backend services.

## Import-to-update

Import-to-update is an API Gateway feature that allow to import an OpenAPI (swagger) definition and apply to an existing API REST to update its resources and methods without manually recreate the API. 


[^1]: API or Application Programming Interface [[API - Application Programming Interface]]
[^m]: HTTP Method: GET, POST, PUT, DELETE [[API REST - HTTP Methods]]