#DATABASES 

### Concurrency control

In a <span style="color:orange;">multiuser environment</span> there are some problems when dealing with simultaneous accessing to the database. Database needs to be locked or ensured that two users don't try to access 

Three main problems: 

* Lost Update: 
* Uncommitted data: When two transactions are executed concurrently, only record T2 is performed

##### Lost Update product

update is done by a transaction is lost as it is overwritten by another transaction. 


##### Uncommitted data or `dirty read`

One transaction updates the data. But his change is not permanently committed in the database. Because of this failure, the transaction is rolled back and the data is returned to its previous value. A second transaction accesses the updated data before the rolling back. 

![[./IMAGES/Uncommited-data-dirty-read.png|350]]

In the previous image, as can be seen, when the `rollback` is done, the value returns to 100, but other user has updated the value increasing it by 2 and this change is no finally reflected. 

##### Unrepeatable read


##### Phantom read problem



To ensure serilizability of transactions in a multiuser database. 