#NEO4J 

### NEO4J Cheat notes

## CREATE OR MERGE

You can create a data instance by specifying the label of the data: 

```
CREATE(<temporal_name>:<label_name> {property1 : value1 , ...})
```

Example: 

```
CREATE(p:person {name:'Julia',lastname:'Garcia', age: 32})
CREARE(b:book {title:'The lord of the rings I', publication_year:1995})
```


##### SELECT NODES

You can `select` the values with a simple command: 

`match (<temporal_name>:<label_name>) return <temporal_name>` 

Will select all the elements that has the label specified. 

Example: 
```neo4j
match (b:book) return b
```

You can also select more than one label: 
```neo4j
match (b:book),(p:person) return b, p
```

This selection can also be filtered with a where command: 
```neo4j
match (b:book) where b.title='The lord of the rings I' return b
```
##### SELECT A RELATIONSHIP

Same as with nodes, you can retreive the nodes that are linked by a relationship: 

```neo4j
match (r) --> [r:buy] --> (n) return r, n
```

##### CREATE A RELATIONSHIP

In this graph database, all values are relationes by themselves by relations between this nodes. 

In order to create a relation between two nodes, we need to select them and create the relationship that is defined as: 

```
Relation: 
(p ) -[r:buy]-> (b )
```

Example: 

```
match (b:book), (p:person) where b.title='The lord of the rings I' and p.name='Julia' create (p)-[r:buy]->(b) return b, p
```

##### UPDATE

In order to update, first select and then modify: 

```neo4j
match(p:person) where p.name = 'Julia' set p.name='Alberto' return p
```

##### CHANGE DATA TYPE

Data types of a property can be changed by casting them when updating. 

Example:
```
match (b:book) where b.title='The Lord of the rings I' set b.published = toString(b.published) return b; 
```
### VISUALIZE SCHEMA

By visualizing the schema you can see the present relationships between the data in order to understand the graph. 

```
call db.schema.visualization()
```