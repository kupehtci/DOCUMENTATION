#ELASTIC #LOGSTASH

# LogStash - Settings and Queues

Configuration of the LogStash **instance**: `logstash.yml`, multiple pipelines (`pipelines.yml`), queues, dead letter queue, secrets and performance tuning. For the content of the pipelines (inputs, filters, outputs) see [[LogStash - Pipeline Configuration]]. General overview in [[LogStash]].

## `logstash.yml`

`/etc/logstash/logstash.yml`. Settings here are the defaults for every pipeline; `pipelines.yml` can override them per pipeline.

```yaml
node.name: logstash01

path.data: /var/lib/logstash
path.logs: /var/log/logstash

# Pipeline defaults
pipeline.workers: 4                # Default: number of CPU cores
pipeline.batch.size: 125           # Events per worker batch
pipeline.batch.delay: 50           # ms waiting to fill a batch
pipeline.ecs_compatibility: v8

# Reload pipeline files automatically when they change
config.reload.automatic: true
config.reload.interval: 3s

# Queues (see below)
queue.type: persisted
queue.max_bytes: 4gb
dead_letter_queue.enable: true

# Monitoring API
api.http.host: 127.0.0.1
api.http.port: 9600

log.level: info
```

| Setting                       | Default            | Description                                                  |
| ----------------------------- | ------------------ | ------------------------------------------------------------ |
| `pipeline.workers`            | CPU cores          | Threads running filters + outputs                            |
| `pipeline.batch.size`         | `125`              | Bigger batches = more throughput and more heap               |
| `pipeline.ordered`            | `auto`             | Keep the event order (only possible with 1 worker)           |
| `queue.type`                  | `memory`           | `memory` or `persisted`                                      |
| `config.reload.automatic`     | `false`            | Reload changed pipelines without restarting                  |
| `allow_superuser`             | `false` (9.x)      | Allow running as root                                        |
| `api.http.host` / `api.http.port` | `127.0.0.1` / `9600` | Monitoring API                                    |

> [!note] Settings can also be passed as command line flags (`--pipeline.workers 4`) or environment variables in Docker (`PIPELINE_WORKERS=4`).

## Multiple pipelines: `pipelines.yml`

`/etc/logstash/pipelines.yml` (used when LogStash starts **without** `-f` / `-e`):

```yaml
- pipeline.id: beats
  path.config: "/etc/logstash/conf.d/beats.conf"
  pipeline.workers: 4

- pipeline.id: syslog
  path.config: "/etc/logstash/conf.d/syslog.conf"
  queue.type: persisted

- pipeline.id: jdbc-orders
  path.config: "/etc/logstash/conf.d/jdbc-orders.conf"
  pipeline.workers: 1
```

> [!important] The default `pipelines.yml` has a single pipeline `main` with `path.config: "/etc/logstash/conf.d/*.conf"`. **All the files are concatenated into one pipeline**: every event goes through every filter and every output of every file. Either wrap everything with conditionals or, better, define one pipeline per flow.

Advantages of separate pipelines: independent workers, queues and settings, a failure in one output doesn't block the others, and simpler configs without big conditionals.

### Pipeline-to-pipeline communication

Pipelines of the same instance can send events to each other with the `pipeline` input / output (in memory, no network):

```ruby
# beats.conf: one input, routes to other pipelines
input  { beats { port => 5044 } }
output {
  if [service] == "nginx" { pipeline { send_to => ["nginx"] } }
  else                    { pipeline { send_to => ["generic"] } }
}

# nginx.conf
input  { pipeline { address => "nginx" } }
filter { grok { ... } }
output { elasticsearch { ... } }
```

Common patterns:

| Pattern               | Description                                                                         |
| --------------------- | ----------------------------------------------------------------------------------- |
| **Distributor**       | One input pipeline routes events by type to specialised pipelines                   |
| **Output isolator**   | One pipeline sends to N pipelines, one per destination, each with its own **persistent queue**. If one destination is down the others keep working |
| **Forked path**       | The same event is sent to several pipelines that transform it differently           |
| **Collector**         | Several pipelines send to one common output pipeline                                |

```ruby
# Output isolator
output { pipeline { send_to => ["to-es", "to-kafka"] } }
```

```yaml
- pipeline.id: to-es
  config.string: 'input { pipeline { address => "to-es" } } output { elasticsearch { ... } }'
  queue.type: persisted
- pipeline.id: to-kafka
  config.string: 'input { pipeline { address => "to-kafka" } } output { kafka { ... } }'
  queue.type: persisted
```

## Queues

| Type          | Durability                                     | Use                                                   |
| ------------- | ---------------------------------------------- | ----------------------------------------------------- |
| `memory`      | Events in flight are **lost** if LogStash crashes | Default. OK when the source can resend (Beats, Kafka) |
| `persisted`   | Events stored on disk, survive restarts. *At-least-once* delivery | Sources that can't resend (syslog, TCP, HTTP), absorb peaks |

```yaml
queue.type: persisted
path.queue: /var/lib/logstash/queue     # Default: path.data/queue
queue.max_bytes: 4gb                    # Per pipeline. When full → backpressure
queue.page_capacity: 64mb
queue.checkpoint.writes: 1024           # 1 = safest, slowest
```

> [!tip] With FileBeat in front, a memory queue is usually enough: FileBeat keeps the position in its registry and resends the events that weren't acknowledged. Use the persistent queue for inputs that push data and can't retry.

> [!warning] Size the disk for `queue.max_bytes` × number of pipelines with persisted queue, and monitor it. If ElasticSearch is down for a long time the queue fills and inputs block.

## Dead letter queue (DLQ)

When ElasticSearch rejects an event with a **400 / 404** error (mapping conflict, invalid data...) it's normally dropped and logged. With the DLQ the event is stored on disk with the error reason:

```yaml
dead_letter_queue.enable: true
dead_letter_queue.max_bytes: 1024mb
dead_letter_queue.retain.age: 7d
```

Reprocess it with another pipeline after fixing the problem:

```ruby
input {
  dead_letter_queue {
    path => "/var/lib/logstash/dead_letter_queue"
    pipeline_id => "beats"
    commit_offsets => true
  }
}

filter {
  mutate {
    add_field => { "[error][message]" => "%{[@metadata][dead_letter_queue][reason]}" }
  }
  # Fix the event, e.g. rename the conflicting field
}

output {
  elasticsearch { ... }
}
```

> [!note] The DLQ only works with the `elasticsearch` output. Events that fail in filters (grok, date...) are **not** sent to the DLQ: they continue with a failure tag.

## Secrets: keystore

Never write passwords in the `.conf` files. Store them in the keystore and reference them as `${KEY}`:

```bash
sudo -u logstash /usr/share/logstash/bin/logstash-keystore --path.settings /etc/logstash create
sudo -u logstash /usr/share/logstash/bin/logstash-keystore --path.settings /etc/logstash add ES_PWD
sudo -u logstash /usr/share/logstash/bin/logstash-keystore --path.settings /etc/logstash list
```

The keystore is stored in `/etc/logstash/logstash.keystore`. To protect it with a password, set `LOGSTASH_KEYSTORE_PASS` before creating it and in the service environment (`/etc/sysconfig/logstash` on RHEL).

## Performance tuning

**JVM heap** (`/etc/logstash/jvm.options`):

```
-Xms4g
-Xmx4g
```

- Default is 1 GB. Use the same value for min and max, between **4 and 8 GB** for most cases, and leave memory for the OS.
- If GC is frequent (logs show long pauses) or there are `OutOfMemoryError`, increase the heap or reduce `pipeline.batch.size` × `pipeline.workers`.

**Process**:

1. Check `/_node/stats/pipelines` (see [[LogStash]] → *Monitoring API*) to find the slowest filter / output.
2. If CPU is not saturated and outputs are fast, increase `pipeline.workers`.
3. If outputs are the bottleneck (e.g. ElasticSearch indexing), more workers won't help: scale ElasticSearch or add more LogStash nodes.
4. Increase `pipeline.batch.size` (e.g. `250`–`1000`) to send bigger bulk requests to ElasticSearch.
5. Optimise grok (anchors, fewer patterns, `dissect` when possible) and avoid `ruby` in hot paths.

## High availability

LogStash nodes are **independent**, there's no cluster. For HA run several nodes with the same pipelines and:

- **Beats**: list all nodes in `output.logstash.hosts` with `loadbalance: true` (see [[FileBeat - Configuration for LogStash]]).
- **Syslog / TCP / HTTP**: put a load balancer in front (TCP/L4 for syslog and Beats).
- **Kafka**: all LogStash nodes in the same `group_id` share the partitions.
- Use persistent queues so an instance restart doesn't lose events.

## Troubleshooting

| Problem                                        | Check                                                                          |
| ---------------------------------------------- | ------------------------------------------------------------------------------ |
| LogStash doesn't start                         | `journalctl -u logstash`, `/var/log/logstash/logstash-plain.log`, config test (`-t`) |
| `Running Logstash as superuser is not allowed` | Run as the `logstash` user, or `allow_superuser: true` (not recommended)       |
| `Logstash could not be started because there is already another instance using the configured data directory` | Another LogStash running, or stale `.lock` in `path.data` |
| Pipeline loaded but not the one expected       | `-f` / `-e` ignore `pipelines.yml`. `curl localhost:9600/_node/pipelines?pretty` |
| Queue keeps growing                            | Output slow or down; check output errors and `/_node/stats/pipelines`          |
| Keystore values not resolved (`${ES_PWD}` literal) | Keystore created with another `--path.settings`, or wrong owner / password |
| High CPU                                       | `/_node/hot_threads`, slow grok patterns                                       |

## Related notes

- [[LogStash]]
- [[LogStash - Pipeline Configuration]]
- [[FileBeat - Configuration for LogStash]]
- [[ElasticSearch]]
