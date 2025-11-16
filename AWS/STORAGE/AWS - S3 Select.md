#AWS 

# AWS - S3 Select

**S3 Select** its an S3 feature that let you perform queries using simple SQL [^sql] over a single S3 object like CSV, JSON and Apache Parquet[^ap]

It filters and query a single obejct at a time and return matching rows or columns from this type of formats so can simplify the retrieval for large objects. 

S3 Select its executed via API or SDK. 


## S3 Select vs Amazon Athena

Amazon Athena[^athena], in comparison with S3 Select, support interactive queries using a more complete ANSI SQL than S3 select across many fles. 

It support queries like joins and aggregations and its integrated with AWS Glue data catalog for Schemas. 

### Limitations

* One object at a time
* Simple queries, so JOIN, GROUP BY are not supported. 


[^sql]: SQL or Simple Query Language [[SQL - Introduction]]. You can perform simple queries like SELECT, FROM, WHERE and LIMIT. 
[^ap]: Apache Parquet is a column based optimized file for storing data [[Apache Parquet]]
[^athena]: Amazon Athena [[AWS - Athena]]
