#HTTP #NET 

### Connection

The **connection** header attribute specified what happens with the connection once the current transaction is performed.
These are the possible values: 

* `close`: the connection is closed once the transaction is finished
* `keep-alive`: the connection is persistent, allowing for subsequent message exchange. 


### Accept-Ranges

Is a flag written by the server to notify that a transfer can be resumed or can be sent partially. 

The possible values are: 

* `none`
* `bytes`