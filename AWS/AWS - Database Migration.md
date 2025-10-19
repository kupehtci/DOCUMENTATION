#AWS 

# AWS - Database Migration

AWS offers some tools and services to help you migrate your on-premise databases or other cloud databases to any kind of DB service existing on AWS. 

This is a list of the different tools or services for migrate the data: 

## AWS Database Migration Service (AWS DMS)

**AWS Database Migration Service** or **AWS DMS** is a fully managed service to migrate data from one database to another quickly and secure. 

It offers *minimal downtime* as DMS continuously migrates data from the source to the target, so the application **can stay online** during the migration. 

It supports two different types of migrations: 

* **homogeneous**: source and target has the same database engine (Example Oracle -> Oracle)
* **heterogeneous**: migration between two different engines (Example Oracle -> PostgreSQL), this is usually combined with AWS SCT to convert the schema first. 

It supports multiple data sources like: 
* On-premises databases with many commercial engines (Oracle, SQL Server, MySQL, MariaDB, PostgreSQL, SAP ASE and more).
* Amazon RDS
* Amazon Aurora
* Amazon Redshift
* Amazon S3 (and data lakes)

It allows one-time usage or <span style="color:orange;">continuous replication</span> that maintain two databases consistent (Hybrid or multi-region architectures). 

## AWS Schema Conversion Tool (AWS SCT)

**AWS Schema Conversion Tool** or **AWS SCT** is a *free* tool from AWS to migrate database schemas from one database engine to another using minimal manual effort (Less operational overhead).

It helps to translate and convert different schema objects such as: 

* Tables
* Indexes
* Views
* Stored procedures
* Functions
* Triggers

Translating database-specific code from the source engine to the target engine (Example SQL -> PostgreSQL or Oracle SQL to PostgreSQL). 

It also do a "code conversion assessment" showing the resources or code that can be converted automatically and what requires manual intervention. 

AWS SCT needs to be installed locally and by connecting source database and the target database you can run the schema conversion and assessment report and apply the converted schema on the target database. Once the schema is applied you can use <span style="color:DodgerBlue;">AWS DMS</span> to migrate the data from the source to the target. 

