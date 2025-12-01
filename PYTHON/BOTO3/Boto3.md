#PYTHON 

# Boto3

**Boto3** its the official AWS SDK for python to automate, create and manage AWS services like S3, EC2, Dynamo and others directly from python code. 

This code can be easily placed into an AWS Lambda[^1] for execution. 


An example of automation can be: 
```python
import boto3

s3 = boto3.client("s3")

response = s3.list_buckets()

for bucket in response["Buckets"]:
    print(bucket["Name"])
```

AWS Credentials need to be set in `~/.aws/credentials` and/or `~/.aws/config`. 




[^1]: AWS Lambda [[AWS - Lambda]]