#MongoDB  #DATABASES 
## MongoDB Query optimization


### Query planner

The query planner of MongoDB: 

* Firstly check in cache. 
* Evaluate the performance, generate candidate plans. 

Generates Indexes, that are unique identifiers of a collection: 
* Single field: identified by one index
* Compound: by two indexes or more
* Multikey: a single index made of a combination of two or more. 
* Geospatial: depending on the geometry of the earth, by location. 
