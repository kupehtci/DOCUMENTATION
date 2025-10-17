#AWS 

# AWS - Amazon Quantum Ledger Database

**Amazon Quantum Ledger Database**[^1] is a fully managed ledger database service that provides a **centralized, inmutable and cryptographically verifiable transaction log** for your application data. 

Its mainly designed for use cases when you need a **trustworthy and auditable history of all changes** to your data. 

The key characteristics of this service are: 
* **Inmutable and verifiable**: every change to the data is recorded in an append-only journal that can be cryptographically verify that the history has not been altered. 
* **Fully managed**: AWS handles the infrastructure, scaling, patching and backups so you don't need to manage servers or other tasks. 
* **ACID transactions**: [^2] supports ACID transaction integrity. Guarantees that each transaction is fully applied or not applied at all. 
* **SQL-like querying**: Uses PartiQL that is a SQL-Compatible query language for interaction with the data. 
* **Cryptographic verification**: digest files allow verification that the journal has not been altered. Ensures trust and auditability without requiring a blockchain network. 


Main use cases of this **trustworthy database**: 

* **Financial or accounting systems** for tracking all transactions with an inmutable history
* **Supply chain management**: record all changes in inventory or shipments.
* **regulatory compliance** with auditable records. 
* **healthcare** store medical records or clinical data with provable history. 


[^1]: [[Ledger Database]] Ledger Database
[^2]: [[ACID]] ACID Transactions