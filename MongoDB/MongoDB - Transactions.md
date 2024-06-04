#MongoDB #DATABASES 

### Transactions

MongoDB allows the use of transactions[^1] but there are three types: 

* Single-record transactions
* Multi-records transactions
* Distributed multi-record transactions

We need to take into account that <span style="color:Salmon;">transactions</span> are in order to ensure that transactions meet the <span style="color:MediumSlateBlue;">ACID</span>[^2]. 

![[MongoDB/IMAGES/ACID.png]]

There are also some isolation levels depending on the operation to do:

* <span style="color:green;">READ</span> concern
	* local
	* majority
	* available
	* linearizable
	* snapshot
* <span style="color:red;">WRITE</span> concern
	* majority
	* \[majority\]
	* \[custom\]

![[mongo_db_transactions.png]]


[^1]: Transactions [[Database Transactions]]
[^2]: ACID. Atomicity, Consistency, Isolation and Durability [[ACID]]