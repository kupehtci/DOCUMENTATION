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

### User-Agent

`User-Agent` http header is a request header that web clients send to servers to identify themselves. 
It normally contains information such as: 
* application name, such as Chrome, Firefox, Postman or others. 
* version of the application.
* Operating system and version such as windows 11, macos or android.
* Device details for mobile or IoT clients. 

An example of the header: 
```txt
GET / HTTP/1.1
Host: example.com
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) 
            AppleWebKit/537.36 (KHTML, like Gecko) 
            Chrome/117.0.0.0 Safari/537.36
```

It is used to: 
* **Content negotiation**: server can adapt the response to send mobile or desktop pages. 
* **Analytics and logging**: helps to track types of clients and usage analytics. 
* **Access control**: can be used to deny connections to specific clients. 