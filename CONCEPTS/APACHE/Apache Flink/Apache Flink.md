#APACHE 

# Apache Flink

**Apache Flink** is an open-source framework for **stateful stream processing**, used to process unbounded (streams) and bounded (batches) data at high throughput and low latency. Unlike batch-first engines that bolt streaming on top, Flink treats streaming as the fundamental model and runs batch processing as a special case of it (a stream with a defined end).

## Key concepts

* **DataStream API**: the core programming model for defining transformations (`map`, `filter`, `keyBy`, `window`, `reduce`) over unbounded streams of events.
* **Stateful processing**: Flink jobs can keep state (counters, aggregations, session data) per key, managed and checkpointed automatically by the engine — no external store required for most use cases.
* **Event time vs processing time**: Flink can process events based on the timestamp **when they happened** (event time) instead of when they arrived (processing time), correctly handling out-of-order and late events using **watermarks**.
* **Windows**: group events over a period to compute aggregations — tumbling (fixed, non-overlapping), sliding (fixed, overlapping) and session windows (gap-based).
* **Checkpointing**: Flink periodically snapshots the state of the whole job to durable storage, so it can recover and resume exactly where it left off after a failure — this is what guarantees **exactly-once** processing semantics.

## Architecture

* **JobManager**: coordinates the execution of a job — scheduling tasks, coordinating checkpoints, and handling recovery.
* **TaskManager**: worker nodes that actually execute the operators (map, filter, window, etc.) in parallel task slots.
* A Flink job is compiled into a **dataflow graph** of operators, distributed across TaskManagers and connected by data streams.

## Example

```java
DataStream<String> events = env.addSource(new FlinkKafkaConsumer<>("clicks", schema, props));

events
    .keyBy(event -> event.getUserId())
    .window(TumblingEventTimeWindows.of(Time.minutes(5)))
    .sum("clickCount")
    .addSink(new FlinkKafkaProducer<>("click-counts", schema, props));
```

This job reads click events from a [[Apache Kafka]] topic, counts clicks per user in 5-minute tumbling windows, and writes the results back to another topic.

## Use cases

* Real-time analytics and dashboards (fraud detection, monitoring, alerting).
* Complex event processing (CEP): detecting patterns across a stream of events.
* Continuous ETL: enriching and transforming events as they arrive instead of in nightly batch jobs.

## Related

* [[Apache Kafka]] — the most common source/sink for Flink streaming jobs.
* [[Apache Spark]] — the main alternative, batch-first with micro-batch streaming (Spark Structured Streaming) versus Flink's native streaming model.
