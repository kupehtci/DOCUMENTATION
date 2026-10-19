#FileBeat #ELASTIC

# FileBeat - Configuration

FileBeat is configured with a YAML file, by default `/etc/filebeat/filebeat.yml` (see [[FileBeat]]).

The file has these main sections:

```yaml
filebeat.inputs:      # Where to read from
filebeat.config.modules: # Load modules from modules.d/
processors:           # Transformations applied to every event
output.<type>:        # Where to send (only ONE)
logging:              # FileBeat own logs
```

> [!warning] YAML is indentation sensitive. Use **spaces, never tabs**, and validate every change with `filebeat test config`.

## Inputs

### `filestream` input

`filestream` is the recommended input to read files. The old `log` input is deprecated.

```yaml
filebeat.inputs:
  - type: filestream
    id: app-logs                 # REQUIRED and UNIQUE per filestream input
    enabled: true
    paths:
      - /var/log/myapp/*.log
      - /opt/app/logs/**/*.log   # ** = recursive
    exclude_files: ['\.gz$']
    ignore_older: 72h            # Ignore files not modified in the last 72h
    fields:
      service: myapp
      env: production
    fields_under_root: true      # Put the fields at the root instead of under "fields."
    tags: ["myapp"]
```

> [!important] The `id` is used to store the state of the input in the registry. If you change the `id`, FileBeat considers it a new input and **reads the files again from the beginning**.

Useful options:

| Option                                  | Description                                                           |
| --------------------------------------- | --------------------------------------------------------------------- |
| `paths`                                 | List of glob paths to read                                            |
| `exclude_files` / `include_lines` / `exclude_lines` | Regex filters on files or lines                           |
| `ignore_older`                          | Skip files older than this duration                                   |
| `prospector.scanner.check_interval`     | How often to look for new files (default `10s`)                       |
| `close.on_state_change.inactive`        | Close the harvester if the file has no changes for this time          |
| `clean_removed`                         | Remove the state from the registry when the file is deleted           |
| `file_identity`                         | How a file is identified: `fingerprint`, `native` (inode + device), `path` |

### Parsers

Parsers are applied while reading the file, before the processors.

**JSON logs** (one JSON object per line):

```yaml
    parsers:
      - ndjson:
          target: ""             # "" = decode fields at the root of the event
          add_error_key: true
          overwrite_keys: true
```

**Multiline** (e.g. Java stack traces). Every line that does **not** start with a date is appended to the previous one:

```yaml
    parsers:
      - multiline:
          type: pattern
          pattern: '^\d{4}-\d{2}-\d{2}'
          negate: true
          match: after
```

```
2026-10-19 10:00:00 ERROR Something failed     <- new event
java.lang.NullPointerException                 <- appended
    at com.example.Main.run(Main.java:10)      <- appended
```

### Other inputs

| Type        | Use                                                  |
| ----------- | ---------------------------------------------------- |
| `journald`  | Read systemd journal (useful on RHEL)                |
| `syslog` / `tcp` / `udp` | Receive logs over the network            |
| `container` / `filestream` with `container` parser | Docker / Kubernetes logs |
| `kafka`     | Read from a Kafka topic                              |

```yaml
  - type: journald
    id: system-journal
    include_matches.match:
      - _SYSTEMD_UNIT=sshd.service
```

## Modules

Modules are predefined configurations for common services. They live in `/etc/filebeat/modules.d/` as `<module>.yml.disabled` until you enable them.

```bash
filebeat modules enable system nginx
```

```yaml
# filebeat.yml
filebeat.config.modules:
  path: ${path.config}/modules.d/*.yml
  reload.enabled: false
```

```yaml
# modules.d/nginx.yml
- module: nginx
  access:
    enabled: true
    var.paths: ["/var/log/nginx/access.log*"]
  error:
    enabled: true
```

> [!note] Most of the module parsing is done by **[[ElasticSearch - Ingest Pipelines|ElasticSearch ingest pipelines]]**, so it only works fully with `output.elasticsearch` (and `filebeat setup` loaded). With LogStash or Graylog you receive the raw message and must parse it there.

## Processors

Processors transform events inside FileBeat. They can be defined globally or inside an input.

```yaml
processors:
  - add_host_metadata: ~
  - add_fields:
      target: ""
      fields:
        datacenter: madrid
  - drop_event:
      when:
        contains:
          message: "DEBUG"
  - dissect:
      tokenizer: "%{ts} %{level} %{msg}"
      field: "message"
      target_prefix: "parsed"
  - decode_json_fields:
      fields: ["message"]
      target: ""
  - drop_fields:
      fields: ["agent.ephemeral_id", "ecs.version"]
      ignore_missing: true
```

Conditions available in `when`: `equals`, `contains`, `regexp`, `range`, `has_fields`, `network`, `and`, `or`, `not`.

## Outputs

Only **one** output can be enabled at the same time. Each destination has its own note with the full setup:

| Destination   | FileBeat output         | Note                                    |
| ------------- | ----------------------- | --------------------------------------- |
| ElasticSearch | `output.elasticsearch`  | [[FileBeat - Configuration for ElasticSearch]] |
| LogStash      | `output.logstash`       | [[FileBeat - Configuration for LogStash]]      |
| GrayLog       | `output.logstash` (Beats input) | [[FileBeat - Configuration for GrayLog]] |

Other outputs:

```yaml
# Kafka
output.kafka:
  hosts: ["kafka01:9092"]
  topic: "logs-%{[fields.service]}"
  required_acks: 1
  compression: gzip

# Console (debug)
output.console:
  pretty: true
```

## Secrets: keystore

Never write passwords in `filebeat.yml`. Use the keystore and reference the key with `${KEY}`:

```bash
filebeat keystore create
filebeat keystore add ES_PWD
filebeat keystore list
```

## Queue and performance

```yaml
queue.mem:
  events: 4096                 # Max events in memory
  flush.min_events: 512
  flush.timeout: 5s

output.logstash:
  bulk_max_size: 2048
  worker: 2
```

Use `queue.disk` if you need to keep events when the output is down for a long time (they survive restarts).

## FileBeat own logging

```yaml
logging.level: info            # debug | info | warning | error
logging.to_files: true
logging.files:
  path: /var/log/filebeat
  name: filebeat
  keepfiles: 7
  permissions: 0640
```

To debug a single component: `logging.selectors: ["input", "harvester", "publisher"]` with `logging.level: debug`.

## Kubernetes (DaemonSet)

In Kubernetes FileBeat runs as a **DaemonSet** (one pod per node), reading `/var/log/containers/*.log` from the node and enriching events with pod metadata.

```yaml
filebeat.autodiscover:
  providers:
    - type: kubernetes
      node: ${NODE_NAME}
      hints.enabled: true
      hints.default_config:
        type: filestream
        id: kubernetes-container-logs-${data.kubernetes.pod.name}-${data.kubernetes.container.id}
        paths:
          - /var/log/containers/*-${data.kubernetes.container.id}.log
        parsers:
          - container: ~

processors:
  - add_kubernetes_metadata: ~
```

With **hints** enabled, each pod can configure its own logs using annotations:

```yaml
metadata:
  annotations:
    co.elastic.logs/enabled: "true"
    co.elastic.logs/multiline.pattern: '^\['
    co.elastic.logs/multiline.negate: "true"
    co.elastic.logs/multiline.match: after
```

Elastic provides a ready manifest (`filebeat-kubernetes.yaml`) with the DaemonSet, ServiceAccount and RBAC.

## Troubleshooting

| Problem                                    | Check                                                                                         |
| ------------------------------------------ | --------------------------------------------------------------------------------------------- |
| FileBeat doesn't start                     | `filebeat test config`, `journalctl -u filebeat`. Config file must be owned by root and not writable by others (`--strict.perms`) |
| No events sent                             | `filebeat test output`, firewall, TLS certificates, DNS of the host                          |
| Files are not read                         | Paths / globs, read permissions of the `filebeat` user, `ignore_older`, SELinux context on RHEL |
| Logs are read again from the beginning     | Changed input `id`, registry deleted, file rotated with copy-truncate                        |
| Stack traces split in several events       | Missing or wrong `multiline` parser                                                           |
| Events delayed                             | Output slow → backpressure. Check `queue`, `bulk_max_size`, `worker`                          |

> [!tip] Run `filebeat -e -d "*"` in the foreground to see everything FileBeat is doing. Stop the service first.

## Full example

```yaml
filebeat.inputs:
  - type: filestream
    id: myapp
    paths: ["/var/log/myapp/*.log"]
    parsers:
      - multiline:
          type: pattern
          pattern: '^\d{4}-\d{2}-\d{2}'
          negate: true
          match: after
    fields:
      service: myapp
      env: production
    fields_under_root: true

  - type: journald
    id: system-journal

filebeat.config.modules:
  path: ${path.config}/modules.d/*.yml
  reload.enabled: false

processors:
  - add_host_metadata: ~
  - drop_event:
      when:
        regexp:
          message: "healthcheck"

output.logstash:
  hosts: ["logstash01.example.com:5044"]
  ssl.certificate_authorities: ["/etc/filebeat/certs/ca.crt"]

logging.level: info
logging.to_files: true
logging.files:
  path: /var/log/filebeat
  keepfiles: 7
```

## Related notes

- [[FileBeat]]
- [[ElasticSearch]]
- [[LogStash]]
- [[FileBeat - Configuration for ElasticSearch]]
- [[FileBeat - Configuration for LogStash]]
- [[FileBeat - Configuration for GrayLog]]
