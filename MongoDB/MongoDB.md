#DATABASES 


### CREATE COLLECTION

Once you have created or select a database, you need to create a collection to store the values. 

`db.createCollection(<name>, <options>)`


### INSERT

```
db.collection_name.insertMany(\[{"att_name":"att_value", ...}, {"att_name":"att_value", ...}])

// Example: 

db.collection_name.insertMany(\[{"id": 3, "name": "Daniel",}, {"id": 4, "name":"Marta", "age":21}\])

```
![[mongodb_insert.png]]


### FIND

Find can be done to search data within a database and a collection: 

```
db.collection.find(<filter>)
```

An example can be: 
```
db.professors.find({"name":"Alicia"})
```

### FILTERING

Greater than can be written as: 
```json
{"age":{$gt:30}}
```

Lower than: 
```json
{"age" : {$lt:34}}
```

Not equal: 
```json
{"age":{$nt:30}}
```

That don't exists: 
```json
{"age" : { $exists : false } }
// or
{"age" : null}
```

Value equals to one inside a list: 
```json
{"age" : {$in: [20,24, 30, 34]}}
```

Combine conditions: 
```json
{"age" : {$gt:10}, "age" : {$lt:34}}
```

OR operation: 
```json
{$or : [{"age": 34}, {"name": "Alicia"}]}
```


Filtering can be done in aggregation section by using a `$match` stage and write the filtering option within it: 

```JSON
$match
---------------------------
{
  classification:"Class A"
}
---------------------------
```

### PROJECTIONS

IN order to project (SELECT) some attributes, needs to be applied as a project. 

You need to mark as 1 the attributes that you want and as 0 to exclude attributes: 

```json
{"age" : 0}
```

### SORT

Data can be sorted by a value by specifying as json: 

```json 
{"name": 1} // Order ascendently by name
{"name": -1} // Order descendently by name
```

### AVERAGE

An average of a value can be calculated by grouping it in the aggregation: 
```JSON
$group 
---------------------------
{
  _id: null,
  avg_value: {
    $avg: "$cloud_cover"
  }
}
---------------------------
```

### JOINS

There is no exactly join in MongoDB, you can embend the data into another collection. 

In aggregation section, you can make a MapReduce in order to join two tables. 

MapReduce is a programming model or pattern. 
Instead of MapReduce, MongoDB uses an aggregation pipeline. 

In this you need to add some stages of the pipeline that filter in each step. 

as $lookup is the pipeline step in order to enbed two collections: 

![[mongodb_lookup.png]]

```json
// join
{
  from: 'professors',         //collection that are aggregagted
  localField: 'professor',    //field to compare in actual collection
  foreignField: 'id',         //field to compare in other collection
  as: 'professors'            //new aggregation attribute name
}
```

### ACCESSING ARRAYS

in order to access an attribute inside an array, just use a dot ".": 

```json
$exercises.score
```