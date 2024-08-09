#DATABASES 

### WEAK RELATIONSHIPS

An entity should have an unique identifier that identify the instance in the entity set. But there exists some types of entities that an unique identifier cannot be defined for them. 

This are the weak entities. This weak entities depend on other entity to be identified via a partial key that is joined with the owner entity key to form its identifier. 

In the following example, a subject in the university can be in repeated in various different degrees, so its a weak entity. But the subject is unique per degree, so degree is the owner entity of subject. 
![[weak_relationship_diagram.png|200]]

For representing weak relationships in entity relationships models: 

* weak entity is with a two line square
* relationship to the owner
* the relation-ship is a double-lined diamond. 
#### HOW TO DECLARE TWO PRIMARY KEYS


In case of a weak relationships, the <span style="color:orange;">unique primary key of the weak entity</span> depends on one attribute of it and the primary key of the relationed instance. 

For declaring this, the primary key of the relationed one need to be specified as a attribute foreign key in the weak instance and declared both as primary keys. 

For doing this, an example in postgreSQL: 

```PostgreSQL
CREATE TABLE IF NOT EXISTS Videogames  
(  
    name varchar(32) NOT NULL,  
    platform_name varchar(32) NOT NULL,  
    image varchar(64) NOT NULL DEFAULT "/",  
    description text DEFAULT "default_description",  
    price numeric DEFAULT 0.0,   
    PRIMARY KEY (name, platform_name)  
);
```