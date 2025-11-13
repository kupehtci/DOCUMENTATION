#AWS

# AWS - Lake Formation

**Lake Formation** is a fully managed service that makes it easier to set up, secure and manage a data lake[^1] stored in Amazon S3[^2].

An data lake stores structured data (Like Apache Parquet[^3]), semi-structured data (JSON or logs) and un-structured data (Like images) and all of this data can be stored directly in an object based storage like S3. 

**AWS Lake Formation** allows to: 
* **Data ingestion**: import data from databases, streaming sources (Like Kinesis[^4]) and build an ETL automation[^5]
	* **Data transformation**: allows cleaning, deduplication and transform or raw data during the ingestion
* **Centralized catalog**: Uses AWS Glue Data Catalog[^6] to store metadata like tables, columns or partitions so the lake's data is discoverable. 
* **Access Control**: can define a fine-grained access at table, column or row level integrated with IAM and AWS SSO. 
* **Audit**: you can track access and usage via CloudTrail[^7]

[^1]: Data Lake [[Data Lake]]
[^2]: Amazon Simple Storage Service [[AWS - S3]]
[^3]: Apache Parquet is a column-based file for storing structured data [[Apache Parquet]]
[^4]: Kinesis is meant for real-time streaming data processing in a serverless service [[AWS - Kinesis]] 
[^5]: Extract, Transform and Load operations for modifying data and storing it in data lakes [[DATA WAREHOUSING - Basics]]. 
[^6]: Glue Data Catalog is a central metadata repository that stores table definitions, schemas and location of the data[[AWS - Glue]]
[^7]: CloudTrail its an fully managed service that records account-level activity and store it as logs. [[AWS - CloudTrail]] 