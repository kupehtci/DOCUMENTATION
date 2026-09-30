#APACHE 

# Apache Airflow

**Apache Airflow** is an open-source platform to **author, schedule and monitor workflows**, defined as code in Python. Instead of running data pipelines with cron scripts and manual dependency tracking, Airflow models a pipeline as a graph of tasks with explicit dependencies, retries, and observability built in.

## Key concepts

* **DAG (Directed Acyclic Graph)**: a workflow is defined as a [[Graph]] of tasks with dependencies between them and no cycles — the same DAG concept used for dependency resolution in build systems. Each DAG typically has a schedule (e.g. "run daily at 2am").
* **Task / Operator**: a single unit of work in a DAG. **Operators** are reusable templates for common work: `PythonOperator`, `BashOperator`, `PostgresOperator`, or provider-specific ones like `SparkSubmitOperator` or `S3ToRedshiftOperator`.
* **Task instance**: a specific run of a task for a specific schedule interval, with its own state (queued, running, success, failed, retrying).
* **Scheduler**: the component that triggers DAG runs according to their schedule and hands ready tasks to workers.
* **Executor**: determines *how* tasks actually run — locally, or distributed across workers (Celery, Kubernetes executor).

## Example

```python
from airflow import DAG
from airflow.operators.python import PythonOperator
from datetime import datetime

def extract():
    ...

def transform():
    ...

def load():
    ...

with DAG("etl_pipeline", start_date=datetime(2024, 1, 1), schedule="@daily") as dag:
    t1 = PythonOperator(task_id="extract", python_callable=extract)
    t2 = PythonOperator(task_id="transform", python_callable=transform)
    t3 = PythonOperator(task_id="load", python_callable=load)

    t1 >> t2 >> t3  # t2 only runs after t1 succeeds, t3 only after t2
```

The `>>` operator declares dependencies: `transform` only starts once `extract` has finished successfully, and Airflow's UI shows the DAG, run history, logs and failures for each task.

## Use cases

* Orchestrating ETL/ELT pipelines: scheduling [[Apache Spark]] jobs, loading [[Apache Hive]] tables, moving data between a data lake and a warehouse.
* Coordinating dependent jobs across different systems (a database export, followed by a transformation, followed by a load into another store).
* Backfilling historical data runs and retrying failed steps automatically.

## Related

* [[Apache Spark]] and [[Apache Hive]] — commonly triggered and monitored as tasks inside an Airflow DAG.
* [[Graph]] — the DAG model Airflow workflows are built on.
