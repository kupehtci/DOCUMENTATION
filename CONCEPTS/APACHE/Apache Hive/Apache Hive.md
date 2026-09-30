#APACHE 

# Apache Hive

**Apache Hive** is an open-source **data warehouse** system built on top of [[Apache Hadoop]], that lets you query and manage large datasets stored in distributed storage (HDFS or object stores like S3) using **SQL**, instead of writing low-level MapReduce or Spark jobs by hand.

Hive translates SQL-like queries (**HiveQL**) into execution jobs (MapReduce, Tez or Spark) that run across the cluster.

## Architecture

* **Metastore**: a relational database (traditionally MySQL/Derby) that stores the **schema and metadata** of tables — column names, types, partitions, and where the underlying files live. This is the piece that makes files in a data lake queryable as "tables".
* **Driver**: parses, compiles and optimizes the HiveQL query into an execution plan.
* **Execution engine**: runs the compiled plan, pluggable between MapReduce, **Tez** or **Spark**.
* **Storage**: the actual data files, commonly stored as [[Apache Parquet]], ORC or Avro on HDFS or a cloud object store.

## Tables

* **Managed tables**: Hive owns both the metadata and the underlying data files. Dropping the table deletes the data.
* **External tables**: Hive only owns the metadata; the data lives independently (e.g. an S3 bucket also used by other tools). Dropping the table only removes the metadata.
* **Partitioning**: splits a table into directories based on a column's value (e.g. `year=2024/month=01/`), so queries filtering on that column only scan the relevant partitions instead of the whole table.
* **Bucketing**: further splits data within a partition into a fixed number of files, hashed by a column, to speed up joins and sampling.

## Example

```sql
CREATE EXTERNAL TABLE sales (
    id INT,
    product STRING,
    amount DECIMAL(10,2)
)
PARTITIONED BY (year INT, month INT)
STORED AS PARQUET
LOCATION 's3://my-data-lake/sales/';

SELECT product, SUM(amount)
FROM sales
WHERE year = 2024
GROUP BY product;
```

Because the table is partitioned by `year`, this query only reads the `year=2024` partition files instead of the entire dataset.

## Use cases

* SQL analytics on large datasets stored in a data lake, without moving the data into a traditional database.
* Batch ETL / data warehousing on top of Hadoop-based infrastructure.
* Providing a common, queryable table layer shared by multiple engines (Hive, Spark, Presto/Trino) over the same underlying files.

## Related

* [[Apache Hadoop]] — the distributed storage (HDFS) and cluster resource management Hive traditionally runs on.
* [[Apache Parquet]] — a common columnar storage format for Hive tables.
* [[AWS - Lake Formation]] and [[AWS - Redshift]] — AWS-managed equivalents for cataloging and querying data lakes.
