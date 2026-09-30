#APACHE 

# Apache Avro

**Apache Avro** is an open-source **row-based data serialization format**, designed to be compact, fast, and to handle **schema evolution** gracefully — making it a common choice for streaming data, such as messages flowing through [[Apache Kafka]].

## Key characteristics

* **Schema-based**: every Avro file/message is described by a schema, written in JSON, defining the fields and their types.
* **Schema stored with the data (or alongside it)**: an Avro file embeds its schema in the header; in streaming systems the schema is typically kept in a separate **Schema Registry** and only a small reference id is sent with each message, to avoid repeating the schema on every record.
* **Compact binary encoding**: data is serialized in a dense binary format, without field names repeated per record (unlike JSON).
* **Schema evolution**: Avro defines clear rules for adding, removing or renaming fields (with defaults) while keeping old and new schema versions compatible — readers and writers don't need to update in lockstep.

## Schema example

```json
{
  "type": "record",
  "name": "ClickEvent",
  "fields": [
    { "name": "userId", "type": "string" },
    { "name": "url", "type": "string" },
    { "name": "timestamp", "type": "long" },
    { "name": "referrer", "type": ["null", "string"], "default": null }
  ]
}
```

Adding the optional `referrer` field with a `default` value means older consumers reading data written with a newer schema (or vice versa) don't break — this is what schema evolution buys you.

## Avro vs Parquet

| | Avro | [[Apache Parquet]] |
| --- | --- | --- |
| Orientation | Row-based | Columnar |
| Best for | Writing/reading whole records one at a time (streaming) | Reading a subset of columns across many rows (analytics) |
| Typical home | Kafka messages, event logs | Data lake tables, Spark/Hive analytical storage |

A common pattern is to use Avro for data **in motion** (Kafka topics) and convert it to Parquet for data **at rest** in the data lake, once it's ready for analytical querying.

## Use cases

* Serializing messages in [[Apache Kafka]] topics, paired with a Schema Registry.
* Data interchange between services written in different languages, thanks to Avro's language-agnostic schema.
* Hadoop ecosystem storage where schema evolution across a long-lived dataset matters.

## Related

* [[Apache Kafka]] — the most common transport for Avro-encoded messages.
* [[Apache Parquet]] — the columnar counterpart used for analytical storage.
