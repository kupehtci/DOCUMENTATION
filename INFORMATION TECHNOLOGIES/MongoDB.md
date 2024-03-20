#DATABASES 



`INSERT`

db.collection_name.insertMany(\[\])

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

### JOINS

There is no exactly join in MongoDB, you can embend the data into another collection. 

In aggregation section, you can make a MapReduce in order to join two tables. 

MapReduce is a programming model or pattern. 
Instead of MapReduce, MongoDB uses an aggregation pipeline. 

In this you need to add some stages of the pipeline that filter in each step. 

as $lookup is the pipeline step in order to enbed two collections: 

![[./IMAGES/mongodb_lookup.png]]

```json
// join
{
  from: 'professors',
  localField: 'professor',
  foreignField: 'id',
  as: 'professors'
}
```

### ACCESSING ARRAYS

in order to access an attribute inside an array, just use a dot ".": 

```json
$exercises.score
```