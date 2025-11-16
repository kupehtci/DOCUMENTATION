#AWS 

# AWS Transfer Family SFTP service

**AWS Transfer Family SFTP service** its a fully managed service that gives an SFTP or SSH File Transfer Protocol [^1] endpoint that allow data transfer with one of this storage backends: 
* Amazon S3[^2].
* Amazon EFS or Elastic File System [^3]

So an SFTP cliente like WinSCP, FileZilla or `sftp` can be used to access S3 or EFS file system controlled by AWS. 

It has the following features:
* It allow SFTP to identity resources: 
	* Service Managed users (Username + SSH key or password stored in AWS Transfer Familly)
	* AWS Directory Service (Linked to AD)
	* Custom Identity Provider via an Amazon API Gateway. 
* Storage backends require to attach an IAM role appropriate to access the storage backend: 
	* S3 buckets
	* EFS system. 
* Auto-Scaling and Multi-AZ.
* Data is encrypted in transit by default using SSH or TLS over FTPS and can be encrypted at rest by S3 or EFS configuration. 


# Other AWS Transfer Family protocols

AWS Transfer Family also allows other protocols to access the data: 

* FTP (Plain FTP) over port 21: 
	* Only allows EFS connection. 
	* Username and Password authentication
* FTPS (FTP over TLS) over port 21 or 990:  
	* Only allows EFS connection. 
	* Requires an X.509 certificate 
	* Username and Password authentication.


[^1]: SFTP or FTP [[FTP File Transfer Protocol]]
[^2]: Amazon S3 [[AWS - S3]]
[^3]: EFS or Elastic File System [[AWS - EFS Elastic File System]]