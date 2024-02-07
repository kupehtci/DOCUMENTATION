#DATABASES

## Relational Models


### Design the relational model from Entity Relationship model

For being able to transform the relational model into a set of tables designed for implemented in a database, its necessary to model the different tables from the set of instances that has the <span style="color:orange;">entity-relationship diagram</span>. 

First step is to transform the model into a set of classes that would be consider as tables (instances to class)

A multi-valued attribute in ER model is turned into a table. 

1. Create a table for the attribute
2. Add the key attribute of the parent entity as a foreign key for the new table (multi-valued table)



Attributes with sub-attributes are not combined, each attribute is saved independently, 

```
Entity()
Address(Street, ZipCode, Number, TypeHouse)
```

The next step is to model the <span style="color:orange;">relationships</span> between the different tables. 
For doing this we can encounter different cases: 


`1 to 1 relationship`

The instance primary key can be stored as a foreign key in the other instance's table. 

`1 to many relationship`

In one to many, we can do the same as _1 to 1 relationship_. We keep the foreign key as reference to the one that can only have 1 of the other one. 

`many-to-many relationship`

We need to add a new <span style="color:orange;">junction table</span> that performs the relation between the classes in many to many relationships. 
This table would have two foreign keys that refer to the primary keys of the two instances to link. 

`Generalization / specialization`

For generalization, a table is created for entity (super entity and sub-entities)
The key attribute of the super-entity. 



---
#### EXAMPLE

Design the relational model from the ER model designed for the Gallery Problem. 
![[artwoork-entity-relationship-example.png]]

* Address 
* artwoork type attribute has $n$ types a finite set, so can be considered as a class for saving space. 
* Phone is also a multi-value, with a finite set of numbers so can be also considered as a class. 

The ER model would have the following structure: 

Artwoorks(*title*, year, type, price, groupName$^*$, artistName$^*$)
Artists(_artistName_, style, birthdate, birthplace)
Customers(_idCustomer_, name, street, ZipCode, city, country)
Groups(groupName)

Type(type)
Phone(number, idCustomer)
CustomerLikeArtist(CustomerID$^*$, ArtistID$^*$)
CustomerLikeGroup(CustomerID$^*$, GroupID$^*$)




---

