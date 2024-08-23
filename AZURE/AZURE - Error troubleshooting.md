 #AZURE 

## File share endpoint error

determining file endpoint for Storage Account  (Storage account properties): missing primary endpoint. 

This error can be caused because storage account is not set with a primary endpoint because is defined as "BlobStorage". Change the storage account to "StorageV2" in order to set a file share resource. 



