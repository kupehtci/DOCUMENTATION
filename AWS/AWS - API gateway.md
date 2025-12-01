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

# API Connection Types

API Gateway allow different types of API endpoints connections: 

* **HTTP API**: lightweight and lower-latency for HTTP backend: 
	* Native JWT or OIDC authentication. 
	* Simple routing
	* Integrations with Lambda or HTTP Services. 
	* Only Regional Endpoints (No edge-optimized or private)
	* Recommended for new public APIs with advanced REST API functionalities. 
* **REST API**[^3] : oldest but has more features for fine-grained resources and methods: 
	* Mapping templates
	* Request and response transformations
	* API Keys and usage plans, request validations, custom gateway responses, caching. 
	* Allows Regional, Edge-optimized and private modes (VPC-Only exposition)
	* Global POP acceleration using CloudFront. 
* **WebSocket API**[^4]: Full duplex, event-driven communication over WebSocket protocol. 
	* Bidirectional and low-latency interaction. 
	* Ideal for chat, live dashboards or multiplayer videogames signaling. 

HTTP API has less cost associated than REST API but less functionalities for establishing an HTTP endpoint. 


# Features
## Import-to-update

Import-to-update is an API Gateway feature that allow to import an OpenAPI (swagger) definition and apply to an existing API REST to update its resources and methods without manually recreate the API. 

## Private Integration

Private Integration allows to route incoming API Requests directly to private resources like EC2 or containers without exposing those resources to the internet. 

In this case, the API Gateway acts as a managed entry point that routes the private backend services. 



[^1]: API or Application Programming Interface [[API - Application Programming Interface]]
[^m]: HTTP Method: GET, POST, PUT, DELETE [[API REST - HTTP Methods]]
[^3]: API REST or RESTfull is an stateless API endpoint [[API REST - HTTP Methods [[API - Application Programming Interface]]]]
[^4]: WebSocket 