#NodeJS 

## NodeJS API Design

Designing a RESTful API involves different approaches: 
* Data driven
* Process driven

But a good API design is based on 4 principles: 
* RESTful principles: they adhere to architectural constrains like stateless and uniform interfaces
* HTTP Methods: the way to work with the API is using HTTP methods such as GET, POST, PUT or DELETE. 
* Resource Representation: API expose resources using formats like JSON or XML to exchange the data. 
* Versioning: API Versioning allows for backward compatibility and controlled updates. 

### Data driven approach

Data driven prioritizes the data by defining the resources based on the entities that are managed. 

Its more flexible, reusable and scalable when hanlding large volumes of data and complex relationships

### Process driven approach

It focuses on the workflow and sequence of actions that are required to complete a task. 
Each step in the process is represented as a resource. 

Its more centered in the logicas organization of the API logic by breaking down the different operations into manageable steps. 
Also is more flexible becase changes in data models and business logic has less impact in API's structure. 

In the process driven approach, data access operations retrieves information and Data modification data update or create data. 


### Steps of the design

Designing an API has some different steps: 

* Identify Process Steps: break down the process into discrete actions and each one of them could be mapped into a resource. 
* Categorise Data Flow: Determine which actions involve accessing or modifying data, so they correspond to resources. 
* Define business logic: identify actions that involve business logic or rules and also can be mapped to resources. 

Then design the endpoints accordingly to the actions that you previously defined: 

* Logical structure: keep them organized reflecting the structure of the API
* User friendly: make them understandable and easy to use. 
* HTTP Verb: use the appropriate HTTP verb for each endpoint. 
* Parameters: use the parameters effectively to filter, sort and paginate the data. 
