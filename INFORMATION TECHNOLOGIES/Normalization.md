#DATABASES 

## Why Normalization? 

Normalization became important to reduce <span style="color:orange;">data redundancy</span> because in the past, in 1956 there weren't 1GB disk drive. A disk has a capacity of 3.75 MB. 

When the first <span style="color:orange;">relational databases</span> appeared, it was more important to make a good use of the space. 

Nowadays, with no-relational databases or <span style="color:LightSeaGreen;">NoSQL</span>, this type of databases take advantage of <span style="color:orange;">data redundancy</span>

### Normalization

<span style="color:MediumSlateBlue;">Normalization</span> is the process of structuring a relational database, in accordance to a set of rules called <span style="color:LightSeaGreen;">normal forms</span> in order to reduce <span style="color:orange;">data redundancy</span> and improve <span style="color:orange;">data integrity</span>

* <span style="color:LIghtSeaGreen;">Data redundancy</span>: information should not de duplicated. For example: if 
		Students(id, name, ZipCode, City)
		You can have various students living in the same `City` and same `ZipCode`. For avoiding this, separate City and ZipCode into another data entity in the database diagram. 
* <span style="color:LIghtSeaGreen;">Data Integrity</span>: With no duplicated data, updates only modify a value once. 

### Normal Forms


There exists so much normalization rules classified and grouped by <span style="color:LightSeaGreen;">Normal Forms</span>. 

```mermaid 
flowchart LR
1NF --> 2NF --> 3NF --> id1(BCNF:Boyce-Codd normal form) --> 4NF --> 5NF --> 6NF

```

The normal forms are consecutively grouped, meaning that for meeting 3NF, 2NF and 1NF needs to be fullfiled. 

If a database meets the three first normal forms (1NF, 2NF and 3NF) its considered as <span style="color:orange;">normalized</span>. 


###### 1º Normal Form

Must fullfil the following rules: 
* None of the attributes has more than 1 value. 
* If an attribute is present in different tables, it must have the same data type
* Attributes names are unique, cannot be more than 1 with the same name. 
* Order of tuples doesn't matter. 

###### 2º Normal Form

Satisfy 1NF and the following rules: 
*  It must not have any <span style="color:LightSeaGreen;">partial relation-ships</span>. 

<span style="color:LightSeaGreen;">Partial dependency or relation-ship</span> is the relation of an attribute with another attribute that is not the primary key. 

In the following example, the entire relation-ship is splitted up into two different relation-ships that involve the `primary key`. 

![[normalization-partial-dependency.png|400]]

###### 3º Normal Form

Satisfy 2NF and follow the next rules: 
* It must not have any <span style="color:LightSeaGreen;">transitive dependency</span>: 

<span style="color:LightSeaGreen;">Transitive dependency</span>: transitivity in databases means that one attribute A imply a B attribute and B attribute also imply a third one. In this case, the relation may be splitted up into two relations. 






