#GCP 

# GCP Cloud Storage

GCP Cloud storage is an scalable, fully managed and secure object storage service offered by Google. 

It allow to store and retrieve any amount of unstructured data such as images, videos, backups and other files from anywhere in the web. 


### GCP Buckets

Buckets are basic containers within the Cloud Storage Service that holds the data. Everything stored in the Cloud Storage must be contained in a bucket. 

This buckets allows to manage the data and control the access to it. 

Buckets have an <span style="color:MediumSlateBlue;">unique name</span> and a <span style="color:orange;">geographical location</span> where the bucket and its contents are stored. 
Once created you <span style="color:crimson;">cannot change its name and location</span>. You only can create a new bucket and move the content from the old one to the new and delete the previous. 

You can use IAM[^1] to grant and control Bucket access to some principals

Take into account that buckets don't act like directories, you cannot nest buckets within another. 

[^1]: IAM Identity Access Management [[GCP - IAM Identity and Access Management]]
