#AWS 

# Encrypt S3 objects


If there are object before encrypting the S3 bucket: 
1. Turn on default encryption using S3-AMK
2. Use the S3 Inventory feature to create a .csv file that lists the unencrypted objects. 
3. Run an S3 Batch Operations job that uses the copy command to encrypt those objects.
	1. This operation needs to copy the items from the bucket again to it. 