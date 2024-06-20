#REDIS #DATABASES 

## REDIS Transactions

Redis incorporates serialized transactions. 

But Redis doesn't met the ACID[^1] theorem: 
* Atomicity and Durability can be granted. 
* Concurrency is not granted.
* Isolation between transactions is keep. 

There are no isolation levels that can be establish to ensure Isolation between different Redis transactions. 


[^1]: [[ACID]] compliance is Atomicity, Consistency, Isolation and Durability. Transactions need to met this 4 aspects in order to be secure within a multiuser database environment . 