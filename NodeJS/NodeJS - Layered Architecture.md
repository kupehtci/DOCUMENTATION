#NodeJS 

# NodeJS Layered Architecture

A layered architecture design consist in dividing an application into distinct layers, each one of them with specific responsabilities and dependencies. 

Each layer maintains modularity by separating the application's logic into different parts. 

Also maintains an arranged **hierarchy**, where each layer relies only in the layer below it and expose functionality to the layer above. 

It has some advantages: 

* Improves code maintainability: reduces complexity because the code is structured in small and manageable units and makes modifications easier. 
* Easier testing: Each layer can be tested isolated from others and problemas are easier to be isolated and pinpointed. 
* Scalability; it improves the growth of the application, an easy integration with other third party services and makes an efficient collaboration between team members, because each one can be involved in a single unit of work. 

This architecture in NodeJS is consisted in three different layers: 

* <span style="color:DodgerBlue;">Controllers</span>: HTTP and logic
* <span style="color:DodgerBlue;">Services</span>: Business logic
* <span style="color:DodgerBlue;">Repositories</span>: Database logic
* <span style="color:DodgerBlue;">Models</span>: Data representation

%%TODO: Work in progress%%