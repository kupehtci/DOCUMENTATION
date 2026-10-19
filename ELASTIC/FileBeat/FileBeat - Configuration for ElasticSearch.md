#FileBeat #ELASTIC

# FileBeat - Configuration for ElasticSearch

FileBeat can send events **directly** to [[ElasticSearch]] with `output.elasticsearch`. This is the simplest architecture and the only one where FileBeat **modules** work completely, because their parsing runs in ElasticSearch **[[ElasticSearch - Ingest Pipelines|ingest pipelines]]**. See [[FileBeat - Configuration]] for inputs, parsers and processors.

```mermaid
flowchart LR
	A[Host logs] --> B[FileBeat]
	B -- "HTTPS :9200 (bulk API)" --> C[ElasticSearch]
	C --> P[Ingest pipelines]
	P --> D[(Data stream filebeat-*)]
	D --> K[Kibana]
```

## 1. Create a user for FileBeat

Use a dedicated user (or API key) with the minimum privileges. Two roles are recommended:

| Role               | Used for                     | Privileges                                                                                         |
| ------------------ | ---------------------------- | -------------------------------------------------------------------------------------------------- |
| `filebeat_setup`   | Running `filebeat setup` once | Cluster: `monitor`, `manage_ilm`, `manage_index_templates`, `manage_pipeline`. Index `filebeat-*`: `manage` |
| `filebeat_writer`  | Sending events every day     | Cluster: `monitor`, `read_ilm`, `read_pipeline`. Index `filebeat-*`: `create_doc`, `view_index_metadata`, `auto_configure` |

Example creating the writer role with the API (Kibana → Dev Tools):

```json
POST /_security/role/filebeat_writer
{
  "cluster": ["monitor", "read_ilm", "read_pipeline"],
  "indices": [
    {
      "names": ["filebeat-*"],
      "privileges": ["create_doc", "view_index_metadata", "auto_configure"]
    }
  ]
}

POST /_security/user/filebeat_internal
{
  "password": "[CONTRASEÑA]",
  "roles": ["filebeat_writer"]
}
```

Or create an **API key** (preferred, it can be revoked without touching users):

```json
POST /_security/api_key
{
  "name": "filebeat_host01",
  "role_descriptors": {
    "filebeat_writer": {
      "cluster": ["monitor", "read_ilm", "read_pipeline"],
      "index": [
        { "names": ["filebeat-*"], "privileges": ["create_doc", "view_index_metadata", "auto_configure"] }
      ]
    }
  }
}
```

The response returns `id` and `api_key`; FileBeat uses them as `id:api_key`.

## 2. Store the credentials in the keystore

```bash
sudo filebeat keystore create
sudo filebeat keystore add ES_PWD       # or ES_API_KEY with "id:api_key"
```

## 3. Configure FileBeat

`/etc/filebeat/filebeat.yml`:

```yaml
filebeat.inputs:
  - type: filestream
    id: myapp
    paths:
      - /var/log/myapp/*.log
    fields:
      service: myapp
    fields_under_root: true

filebeat.config.modules:
  path: ${path.config}/modules.d/*.yml
  reload.enabled: false

processors:
  - add_host_metadata: ~

output.elasticsearch:
  hosts: ["https://es01.example.com:9200", "https://es02.example.com:9200"]
  # Option A: user + password
  username: "filebeat_internal"
  password: "${ES_PWD}"
  # Option B: API key
  # api_key: "${ES_API_KEY}"
  ssl.certificate_authorities: ["/etc/filebeat/certs/ca.crt"]
  # Optional: ingest pipeline for the events that don't come from modules
  # (see [[ElasticSearch - Ingest Pipelines]])
  # pipeline: "myapp-pipeline"

setup.kibana:
  host: "https://kibana.example.com:5601"
  ssl.certificate_authorities: ["/etc/filebeat/certs/ca.crt"]
```

Useful options of `output.elasticsearch`:

| Option            | Description                                                             |
| ----------------- | ----------------------------------------------------------------------- |
| `hosts`           | List of nodes. FileBeat balances between them                           |
| `worker`          | Workers per host (default `1`)                                          |
| `bulk_max_size`   | Max events per bulk request                                             |
| `compression_level` | `0`–`9`, gzip compression of the requests                             |
| `pipeline`        | Ingest pipeline to apply (can use conditions with `pipelines:`)         |
| `index`           | Custom index / data stream name (needs a matching template, see below) |

## 4. Load the assets: `filebeat setup`

Run it **once** (from one host, with a user with the setup role). It loads the index template, the ILM policy, the ingest pipelines of the enabled modules and the Kibana dashboards:

```bash
sudo filebeat setup -e
# Only some parts:
sudo filebeat setup --index-management
sudo filebeat setup --pipelines --modules nginx,system
sudo filebeat setup --dashboards
```

> [!important] When a new module is enabled, run `filebeat setup --pipelines --modules <module>` again; otherwise the events fail because the ingest pipeline doesn't exist.

## 5. Modules

```bash
sudo filebeat modules enable system nginx
```

```yaml
# /etc/filebeat/modules.d/nginx.yml
- module: nginx
  access:
    enabled: true
    var.paths: ["/var/log/nginx/access.log*"]
  error:
    enabled: true
```

Each module sends its events to its own [[ElasticSearch - Ingest Pipelines|ingest pipeline]] (`filebeat-<version>-<module>-<fileset>-pipeline`), which parses the line and maps it to **ECS** fields (`source.ip`, `http.response.status_code`...). The Kibana dashboards are built on these fields.

## 6. Custom index (optional)

By default the events go to the data stream `filebeat-<version>`. To use your own name you must also define the template (see [[ElasticSearch - Index Management]] for templates, data streams and ILM):

```yaml
output.elasticsearch:
  index: "myapp-%{[agent.version]}"

setup.template.name: "myapp"
setup.template.pattern: "myapp-*"
setup.ilm.enabled: false        # or define your own ILM policy
```

> [!warning] If you change the index, the default Kibana dashboards (which use `filebeat-*`) won't show the data. Prefer keeping the default name and separating data with fields (`service`, `env`) unless you need different retention.

## 7. Test

```bash
filebeat test config
filebeat test output
sudo systemctl enable --now filebeat
```

In Kibana → Dev Tools:

```json
GET _data_stream/filebeat-*
GET filebeat-*/_search?size=1&sort=@timestamp:desc
```

Or in **Kibana → Discover** with the `filebeat-*` data view.

## Troubleshooting

| Problem                                           | Check                                                                         |
| ------------------------------------------------- | ----------------------------------------------------------------------------- |
| `401 Unauthorized`                                | User / password / API key, keystore key name                                  |
| `403 ... action [indices:data/write/bulk]`        | Missing privileges in the writer role (`create_doc`, `auto_configure`)        |
| `pipeline with id [...] does not exist`           | Run `filebeat setup --pipelines --modules <module>`                           |
| x509 / certificate errors                         | CA in `ssl.certificate_authorities`, hostname in the cert SAN                 |
| Version conflict / template errors                | FileBeat version newer than ElasticSearch: keep FileBeat ≤ ElasticSearch version |
| Events rejected with `mapper_parsing_exception`   | Field with different types in different events (e.g. object vs string)       |

## Related notes

- [[FileBeat]]
- [[ElasticSearch]]
- [[ElasticSearch - Ingest Pipelines]]
- [[ElasticSearch - Index Management]]
- [[FileBeat - Configuration]]
- [[FileBeat - Configuration for LogStash]]
