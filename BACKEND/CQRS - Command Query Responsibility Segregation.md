#BACKEND 

# CQRS - Command Query Responsibility Segregation

**CQRS** is a **Command Query Responsibility Segregation** is a design pattern in Backend ([[Backend]]) that separates the read (Queries) and the write (command) operations into different models. 

* The **write model** handles the commands that change the state like creating, updating or deleting the data including the domain logic, validation and consistency using normalized schemas or transactional databases. 
* The **read model** serves the data in an efficient way used for views, DTOs and projections from separated stores like caches or NoSQL databases. This model lacks the business logic and its main focus is the performance. 

This model allows to optimize each model independently, allowing to use different data sores or structures for read and write. 

Its also normal in CQRS to use normalized databases (relational[[SQL - Introduction]]) for writes and denormalized (NoSQL [[No-SQL]]) for reads. 

A write command needs to trigger events to update the read models asynchronously (Eventual consistency). 