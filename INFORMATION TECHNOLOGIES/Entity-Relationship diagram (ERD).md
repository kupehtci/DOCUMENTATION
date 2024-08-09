#DATABASES 

An <span style="color:orange;">entity-relationship diagram</span> is a type of flowchart that represents how different entities of data are related among them, 

Its composed of various common symbols: 


- **Entities**, which are represented by rectangles. An entity is an object or concept about which you want to store information. A weak entity is an entity that must be defined by a foreign key relationship with another entity as it cannot be uniquely identified by its own attributes alone.

- **Relationships**, which are represented by diamond shapes, show how two entities share information in the database. In some cases, entities can be self-linked.

- **Attributes**, which are represented by ovals. A key attribute is the unique, distinguishing characteristic of the entity. For example, an employee's social security number might be the employee's key attribute.  

	* A <span style="color:cyan;">multivalued</span> attribute can have more than one value. For example, an employee entity can have multiple skill values.
	* If the attribute is a <span style="color:cyan;">derivate</span> from other attribute, is rounded in a dotted line oval. For example, an employee's monthly salary is based on the employee's annual salary.

- **Connecting lines**, solid lines that connect attributes and show the relationships of entities in the diagram.

- **Cardinality** specifies the numerical attribute of the relationship between entities. It can be: 
	- ***one-to-one***: Meaning that each one of the records in one table is linked or relationed with one of the another one. 
	- ***many-to-one***: one of the records can be associated with one or more records of the other entity, but the other entities are only relationed with one. 
	- ***many-to-many***: 

![[ER-symbols.png|250]]

The cardinality between two different entities can be represented also with lines and symbols. 


Minimun cardinality is placed in the initial flow of the line of the relation-ship and is represented as: 
* minimum 0 instances in relation: 1 line
* minimum 1 instances in relation: 2 lines

In complex diagrams is represented as: 

![[er-cardinality-representation.png|250]]
