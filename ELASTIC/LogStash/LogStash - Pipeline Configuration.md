#ELASTIC #LOGSTASH

# LogStash - Pipeline Configuration

A pipeline is defined in a `.conf` file (usually in `/etc/logstash/conf.d/`) with three sections. See [[LogStash]] for the architecture and [[LogStash - Settings and Queues]] for `logstash.yml` and `pipelines.yml`.

```ruby
input {
  # Where the events come from
}

filter {
  # Optional: how to transform them (executed in order)
}

output {
  # Where to send them
}
```

## Syntax

### Field references

| Syntax                    | Meaning                                                    |
| ------------------------- | ---------------------------------------------------------- |
| `[message]`               | Top level field                                            |
| `[log][level]`            | Nested field `log.level`                                   |
| `"%{[host][name]}"`       | **sprintf**: value of the field inside a string            |
| `"%{+yyyy.MM.dd}"`        | Date of `@timestamp` formatted (Joda format)               |
| `[@metadata][target]`     | Temporary field, never sent by the outputs                 |

```ruby
mutate {
  add_field => { "[@metadata][index]" => "myapp-%{[service]}" }
}
```

### Conditionals

```ruby
filter {
  if [service] == "nginx" {
    # ...
  } else if [log][level] in ["debug", "trace"] {
    drop {}
  } else if [message] =~ /^\{/ {
    json { source => "message" }
  }

  if "_grokparsefailure" in [tags] { ... }
  if ![user][name] { ... }                      # Field doesn't exist
  if [http][status] >= 500 and [env] == "prod" { ... }
}
```

Operators: `==`, `!=`, `<`, `>`, `<=`, `>=`, `=~` / `!~` (regex), `in` / `not in`, `and`, `or`, `nand`, `xor`, `!`.

### Environment variables and secrets

```ruby
output {
  elasticsearch {
    hosts    => ["${ES_HOST:https://localhost:9200}"]    # With default value
    password => "${ES_PWD}"                               # From the keystore
  }
}
```

### Common options of every plugin

| Option          | Description                                                       |
| --------------- | ----------------------------------------------------------------- |
| `id`            | Name of the plugin instance. **Set it**: it appears in the monitoring API and logs |
| `add_field` / `remove_field` | Add / remove fields if the filter succeeds          |
| `add_tag` / `remove_tag`     | Add / remove tags if the filter succeeds            |
| `tag_on_failure` | Tag added when the filter fails (`_grokparsefailure`, `_dateparsefailure`...) |
| `codec`         | Inputs / outputs: how to decode / encode the data                 |

## Inputs

| Input            | Use                                                                         |
| ---------------- | --------------------------------------------------------------------------- |
| `beats`          | Receive from FileBeat / other Beats / Elastic Agent (port `5044`). See [[FileBeat - Configuration for LogStash]] |
| `tcp` / `udp`    | Raw network data (`codec => json_lines` for JSON per line)                  |
| `syslog`         | Syslog messages (RFC3164). For RFC5424 use `tcp`/`udp` + grok              |
| `http`           | Receive events with HTTP POST (webhooks)                                    |
| `kafka`          | Consume Kafka topics                                                        |
| `file`           | Read files on the LogStash host (state in `sincedb`)                        |
| `jdbc`           | Run SQL queries periodically (needs the JDBC driver `.jar`)                 |
| `s3`             | Read objects from an S3 bucket                                              |
| `pipeline`       | Receive from another pipeline of the same instance                          |
| `dead_letter_queue` | Reprocess events stored in the DLQ                                       |
| `stdin` / `generator` | Testing                                                                |

```ruby
input {
  beats {
    id => "beats_5044"
    port => 5044
    ssl_enabled => true
    ssl_certificate => "/etc/logstash/certs/logstash.crt"
    ssl_key => "/etc/logstash/certs/logstash.pkcs8.key"
  }

  tcp {
    id => "app_json_5000"
    port => 5000
    codec => json_lines
  }

  kafka {
    id => "kafka_logs"
    bootstrap_servers => "kafka01:9092,kafka02:9092"
    topics => ["app-logs"]
    group_id => "logstash"
    codec => json
  }

  jdbc {
    jdbc_driver_library => "/etc/logstash/drivers/postgresql.jar"
    jdbc_driver_class => "org.postgresql.Driver"
    jdbc_connection_string => "jdbc:postgresql://db01:5432/app"
    jdbc_user => "reader"
    jdbc_password => "${DB_PWD}"
    schedule => "*/5 * * * *"
    statement => "SELECT * FROM orders WHERE updated_at > :sql_last_value"
    use_column_value => true
    tracking_column => "updated_at"
    tracking_column_type => "timestamp"
  }
}
```

## Filters

Filters are executed **in the order** they are written.

| Filter          | Use                                                                            |
| --------------- | ------------------------------------------------------------------------------ |
| `grok`          | Parse unstructured text with patterns (`%{IP:[source][ip]}`)                   |
| `dissect`       | Split text by delimiters. Faster than grok for fixed formats                   |
| `json` / `kv` / `csv` / `xml` | Parse structured text                                            |
| `date`          | Parse a date into `@timestamp`                                                 |
| `mutate`        | Rename, remove, convert, replace, gsub, lowercase, split, copy fields          |
| `geoip`         | Location from an IP                                                            |
| `useragent`     | Parse user agent strings                                                       |
| `translate`     | Lookup in a dictionary (YAML / JSON / CSV file or inline)                      |
| `elasticsearch` | Lookup data from an ElasticSearch index                                        |
| `jdbc_streaming` / `jdbc_static` | Lookup data from a database                                   |
| `fingerprint`   | Hash of fields (to build a unique `_id` and avoid duplicates)                  |
| `drop`          | Discard the event                                                              |
| `clone`         | Duplicate the event (e.g. to send a reduced copy somewhere else)               |
| `aggregate`     | Combine several events into one (needs `pipeline.workers: 1`)                  |
| `ruby`          | Custom code                                                                    |
| `prune`         | Keep only the allowed fields                                                   |

### grok

```ruby
filter {
  grok {
    id => "grok_myapp"
    match => {
      "message" => [
        "%{TIMESTAMP_ISO8601:[@metadata][ts]} %{LOGLEVEL:[log][level]} \[%{DATA:[process][thread][name]}\] %{GREEDYDATA:[event][original_msg]}",
        "%{GREEDYDATA:[event][original_msg]}"
      ]
    }
    pattern_definitions => { "ORDERID" => "ORD-[0-9]{8}" }
    tag_on_failure => ["_grokparsefailure_myapp"]
  }
}
```

- Several patterns in the list: the **first** that matches is used. Put the most specific first.
- `%{NUMBER:[bytes]:int}` converts the value to integer.
- Use **anchors** (`^...$`) and avoid many `GREEDYDATA` / `DATA` in the same pattern: a non-matching line with greedy patterns can be very slow.
- Test the patterns in **Kibana → Dev Tools → Grok Debugger**.

### dissect

```ruby
# 2026-10-19 10:00:00 ERROR [main] Connection refused
dissect {
  mapping => { "message" => "%{[@metadata][date]} %{[@metadata][time]} %{[log][level]} [%{[process][thread][name]}] %{[event][original_msg]}" }
}
```

### date

```ruby
date {
  match    => ["[@metadata][ts]", "ISO8601", "yyyy-MM-dd HH:mm:ss,SSS", "dd/MMM/yyyy:HH:mm:ss Z"]
  target   => "@timestamp"
  timezone => "Europe/Madrid"
}
```

> [!important] If the date is not parsed, `@timestamp` keeps the time when LogStash **received** the event, not when it happened. Check the `_dateparsefailure` tag.

### mutate

```ruby
mutate {
  rename       => { "[srcip]" => "[source][ip]" }
  convert      => { "[http][response][status_code]" => "integer" }
  lowercase    => ["[log][level]"]
  gsub         => ["message", "password=\S+", "password=***"]
  copy         => { "[host][name]" => "[observer][hostname]" }
  remove_field => ["[agent][ephemeral_id]", "[ecs]"]
  add_tag      => ["parsed"]
}
```

> [!note] Inside one `mutate` the operations run in a **fixed internal order** (rename, update, replace, convert, gsub, uppercase, lowercase, strip, remove, split, join, merge, copy...), not in the order you write them. If the order matters, use several `mutate` blocks.

### translate (lookup)

```ruby
translate {
  source          => "[host][name]"
  target          => "[owner][team]"
  dictionary_path => "/etc/logstash/dictionaries/hosts.yml"
  refresh_interval => 300
  fallback        => "unknown"
}
```

## Outputs

| Output          | Use                                                                    |
| --------------- | ---------------------------------------------------------------------- |
| `elasticsearch` | Index in ElasticSearch (indices or data streams)                       |
| `kafka`         | Produce to a Kafka topic                                               |
| `s3` / `file`   | Archive the events                                                     |
| `http` / `tcp` / `udp` | Send to other systems                                           |
| `gelf`          | Send to GrayLog with the GELF format (plugin `logstash-output-gelf`)   |
| `pipeline`      | Send to another pipeline of the same instance                          |
| `stdout`        | Debug (`codec => rubydebug`)                                           |

### ElasticSearch output

The user needs a role like this in ElasticSearch (see [[ElasticSearch]] → *Users and security*):

```json
POST /_security/role/logstash_writer
{
  "cluster": ["monitor", "manage_index_templates", "manage_ilm"],
  "indices": [
    {
      "names": ["logstash-*", "logs-*", "filebeat-*"],
      "privileges": ["write", "create", "create_index", "manage", "manage_ilm"]
    }
  ]
}
```

**To a data stream** (recommended for logs). The name is `<type>-<dataset>-<namespace>` and the built-in `logs-*-*` template is used (see [[ElasticSearch - Index Management]]):

```ruby
output {
  elasticsearch {
    id => "es_logs"
    hosts => ["https://es01.example.com:9200", "https://es02.example.com:9200"]
    api_key => "${ES_API_KEY}"                       # "id:api_key"
    ssl_certificate_authorities => ["/etc/logstash/certs/ca.crt"]
    data_stream => true
    data_stream_type => "logs"
    data_stream_dataset => "myapp"
    data_stream_namespace => "production"
  }
}
```

With `data_stream => true` the output also reads the `[data_stream][type]`, `[data_stream][dataset]` and `[data_stream][namespace]` fields of each event (*auto routing*), so one output can write to several data streams.

**To an index / FileBeat data stream** with a custom name:

```ruby
output {
  elasticsearch {
    hosts => ["https://es01.example.com:9200"]
    user => "logstash_writer"
    password => "${ES_PWD}"
    ssl_certificate_authorities => ["/etc/logstash/certs/ca.crt"]
    index => "%{[@metadata][beat]}-%{[@metadata][version]}"
    action => "create"                               # Required for data streams
    pipeline => "%{[@metadata][pipeline]}"           # Optional: run an ES ingest pipeline
  }
}
```

The `pipeline` option executes an [[ElasticSearch - Ingest Pipelines|ingest pipeline]] in ElasticSearch after LogStash. It's how the FileBeat modules keep working through LogStash (full example in [[FileBeat - Configuration for LogStash]]).

> [!tip] To avoid duplicates when an event is retried, generate the `_id` with the `fingerprint` filter and use `document_id => "%{[@metadata][fingerprint]}"`.

### Several outputs

All the outputs receive every event, unless you use conditionals:

```ruby
output {
  elasticsearch { ... }                       # Everything to ElasticSearch

  if [log][level] == "error" {
    kafka {
      bootstrap_servers => "kafka01:9092"
      topic_id => "alerts"
      codec => json
    }
  }

  s3 {
    bucket => "logs-archive"
    region => "eu-west-1"
    prefix => "%{[service]}/%{+yyyy/MM/dd}"
    codec => json_lines
  }
}
```

> [!warning] If one output is down, it blocks the **whole pipeline** (all outputs) by backpressure. To isolate destinations use the *output isolator* pattern with several pipelines (see [[LogStash - Settings and Queues]]).

## Full example: FileBeat → LogStash → ElasticSearch

`/etc/logstash/conf.d/myapp.conf`:

```ruby
input {
  beats {
    id => "beats_5044"
    port => 5044
    ssl_enabled => true
    ssl_certificate => "/etc/logstash/certs/logstash.crt"
    ssl_key => "/etc/logstash/certs/logstash.pkcs8.key"
  }
}

filter {
  if [service] == "myapp" {
    grok {
      id => "grok_myapp"
      match => { "message" => "^%{TIMESTAMP_ISO8601:[@metadata][ts]} %{LOGLEVEL:[log][level]} %{GREEDYDATA:[event][original_msg]}$" }
    }
    date {
      id => "date_myapp"
      match => ["[@metadata][ts]", "ISO8601", "yyyy-MM-dd HH:mm:ss,SSS"]
      timezone => "Europe/Madrid"
    }
    mutate {
      lowercase => ["[log][level]"]
      # Route to the data stream logs-myapp-default (see output es_custom)
      add_field => { "[data_stream][dataset]" => "%{[service]}" }
    }

    if [log][level] == "debug" { drop {} }
  }
}

output {
  if [@metadata][pipeline] {
    elasticsearch {
      id => "es_modules"
      hosts => ["https://es01.example.com:9200"]
      api_key => "${ES_API_KEY}"
      ssl_certificate_authorities => ["/etc/logstash/certs/ca.crt"]
      index => "%{[@metadata][beat]}-%{[@metadata][version]}"
      action => "create"
      pipeline => "%{[@metadata][pipeline]}"
    }
  } else {
    elasticsearch {
      id => "es_custom"
      hosts => ["https://es01.example.com:9200"]
      api_key => "${ES_API_KEY}"
      ssl_certificate_authorities => ["/etc/logstash/certs/ca.crt"]
      data_stream => true            # Uses [data_stream][type|dataset|namespace] of the event
    }
  }
}
```

## Debugging a pipeline

```ruby
output {
  stdout { codec => rubydebug { metadata => true } }   # Shows also @metadata
}
```

```bash
# Test the syntax
sudo -u logstash /usr/share/logstash/bin/logstash --path.settings /etc/logstash -t

# Try a filter with sample lines
echo '2026-10-19 10:00:00,123 ERROR Connection refused' | \
  /usr/share/logstash/bin/logstash -f test.conf      # test.conf with input { stdin {} }
```

## Troubleshooting

| Problem                                    | Check                                                                         |
| ------------------------------------------ | ----------------------------------------------------------------------------- |
| `Expected one of [ \t\r\n], "#", ...`      | Syntax error: missing `}` or `"`. The message shows line and column           |
| Events go through filters of other apps    | All `.conf` files of a pipeline are **merged**. Use conditionals or separate pipelines |
| `_grokparsefailure` / `_dissectfailure`    | Pattern doesn't match the line. Grok Debugger, check spaces and escapes       |
| Wrong `@timestamp`                         | `_dateparsefailure`, missing `timezone`                                       |
| `Could not index event ... mapper_parsing_exception` | Field type conflict in ElasticSearch. Fix the mapping or the filter; enable the DLQ |
| `only write ops with an op_type of create are allowed in data streams` | Add `action => "create"` or `data_stream => true` |
| Fields with dots not found (`[log.level]`) | In LogStash use `[log][level]`. `[log.level]` is a field literally named `log.level` |

## Related notes

- [[LogStash]]
- [[LogStash - Settings and Queues]]
- [[FileBeat - Configuration for LogStash]]
- [[ElasticSearch - Ingest Pipelines]]
- [[ElasticSearch - Index Management]]
