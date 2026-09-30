#APACHE 

# Apache Spark

**Apache Spark** is an open-source, distributed **general-purpose processing engine** for big data — batch processing, SQL analytics, streaming, machine learning and graph processing, all on the same engine. It became the de-facto successor to plain Hadoop MapReduce by keeping data **in memory** between processing steps instead of writing intermediate results to disk, making iterative workloads dramatically faster.

## Key concepts

* **RDD (Resilient Distributed Dataset)**: the original low-level abstraction, an immutable, partitioned collection of objects distributed across the cluster, that can be recomputed from its lineage if a partition is lost.
* **DataFrame / Dataset**: a higher-level, schema-aware abstraction (similar to a table) built on top of RDDs, optimized by Spark's **Catalyst** query optimizer — the API most Spark code uses today.
* **Lazy evaluation**: transformations (`filter`, `select`, `map`) are not executed immediately; Spark builds an execution plan and only runs it when an **action** (`count`, `collect`, `write`) triggers it, allowing the whole pipeline to be optimized before running.
* **Driver and Executors**: the driver program builds the execution plan and coordinates the job; executors are worker processes on the cluster that run the actual tasks in parallel.

## Modules

* **Spark SQL**: query structured data with SQL or the DataFrame API, reading from formats like [[Apache Parquet]], Avro, JSON, or tables in [[Apache Hive]].
* **Structured Streaming**: process streaming data using the same DataFrame API as batch, internally as a sequence of small batches (micro-batches) — an alternative to a native streaming engine like [[Apache Flink]].
* **MLlib**: distributed machine learning algorithms (classification, regression, clustering).
* **GraphX**: distributed graph processing and algorithms.

## Example

```python
from pyspark.sql import SparkSession

spark = SparkSession.builder.appName("sales").getOrCreate()

df = spark.read.parquet("s3://my-data-lake/sales/")

result = (
    df.filter(df.year == 2024)
      .groupBy("product")
      .sum("amount")
)

result.write.mode("overwrite").parquet("s3://my-data-lake/sales-summary/")
```

## Use cases

* Large-scale batch ETL and data transformation.
* SQL analytics over data lakes, often together with [[Apache Hive]] as the metadata catalog.
* Machine learning pipelines that need to train on datasets too large for a single machine.

## Related

* [[Apache Hadoop]] — Spark can run on top of a Hadoop cluster (YARN) and read/write from HDFS.
* [[Apache Hive]] — Spark can read/write Hive tables and even replace MapReduce/Tez as Hive's execution engine.
* [[Apache Parquet]] — the most common storage format for Spark DataFrames in a data lake.
* [[Apache Flink]] — the main alternative for native, low-latency stream processing.
