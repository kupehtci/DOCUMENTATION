## ACID property
#DATABASES #CONCEPTS #INFORMATION_TECHNOLOGIES 

<span style="color:Salmon;">ACID</span> are four basic transaction[^1] properties in a database system. 

If the <span style="color:Salmon;">ACID</span> properties are meet, the application environment won't affect when the app is running. 

* <span style="color:MediumSlateBlue;">(A) Atomicity</span>: The transaction takes place at once or doesn't happen at all. 
* <span style="color:DeepSkyBlue;">(C) Consistency</span>: Database is consisten before and after the transaction. 
* <span style="color:LightSkyBlue;">(I) Isolation</span>: different transactions are isolated between them, so they doesn't interfer. 
* <span style="color:PowderBlue;">(D) Durability</span>: Data changes are made and persistent, even if system fails

![[INFORMATION TECHNOLOGIES/IMAGES/ACID.png]]


[^1]: transactions a sequence of operations that are done within a single unit of work. This means that the whole operation is only correctly executed if all the operations within it are correctly executed. [[Database Transactions]]