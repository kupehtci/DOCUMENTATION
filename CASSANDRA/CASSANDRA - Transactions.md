#CASSANDRA #DATABASES 


### CASSANDRA Transactions

Cassandra by itself <span style="color:Crimson;">don't offer full ACID transactions</span> by rolling back and locking mechanisms. 

It supports atomicity and isolation at row-level, but maintains its fastness and high availability. 


When a value its updated, it replicates through all nodes but no automatically. 
Also if an updated value fails to replicate, reports an error but the rollback of the correct nodes is not automatically. 


Cassandra use <span style="color:CornflowerBlue;">time-stamps</span> in order to use always the most recent value updated. 