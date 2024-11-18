
Command to list buckets

```bash
aws s3 ls
```

To create a bucket: 

```bash
aws s3 mb s3://<bucket-name>
```

And to upload a file to the newly created S3 bucket: 
```bash
aws s3 cp /home/ssm-user/HappyFace.jpg s3://<bucket-name>
```

Also AWS s3 list command can be use to list the content within an S3 bucket: 

```bash
aws s3 ls s3://<bucket-name>
```
