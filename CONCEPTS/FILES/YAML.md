#CONCEPTS #FILES

# YAML

**YAML** ("YAML Ain't Markup Language") is a human-readable **data serialization format**, commonly used for configuration files. Unlike [[JSON - BASICS|JSON]] or [[XML - BASICS|XML]], YAML relies on **indentation and whitespace** instead of brackets or closing tags, which makes it easier to read and write by hand — at the cost of being more sensitive to formatting mistakes.

It is the format of choice for most DevOps tooling: Kubernetes manifests, Docker Compose, GitHub Actions/Azure Pipelines, Ansible playbooks, and Helm charts.

## Syntax basics

* **Indentation matters**: nesting is defined by spaces (never tabs), consistently indented.
* **Key-value pairs**: `key: value`.
* **Lists**: items prefixed with `- `.
* **Comments**: start with `#`.
* **Strings**: usually don't need quotes, but can be wrapped in `'single'` or `"double"` quotes, needed when the value could be ambiguous (looks like a number, boolean, or contains special characters).

```yaml
name: Daniel
age: 30
isActive: true
tags:
  - admin
  - developer
address:
  city: Zaragoza
  country: Spain
```

This is equivalent to the following JSON:

```json
{
  "name": "Daniel",
  "age": 30,
  "isActive": true,
  "tags": ["admin", "developer"],
  "address": { "city": "Zaragoza", "country": "Spain" }
}
```

## Data types

| Type      | Example                          |
| ----------- | ----------------------------------- |
| String    | `name: Daniel` or `name: "Daniel"` |
| Number    | `age: 30`                         |
| Boolean   | `isActive: true`                  |
| Null      | `middleName: null` or `middleName: ~` |
| List      | `- item1` `- item2`               |
| Map       | `key: value` (nested)             |

### Inline (flow) style

Lists and maps can also be written in a compact, JSON-like inline form:

```yaml
tags: [admin, developer]
address: { city: Zaragoza, country: Spain }
```

### Multi-line strings

* `|` (literal block): preserves line breaks exactly as written.
* `>` (folded block): folds line breaks into spaces, useful for long wrapped text.

```yaml
description: |
  This is line one.
  This is line two, kept as-is.

summary: >
  This long sentence will be
  folded into a single line.
```

## Anchors and aliases

YAML supports **reusing** a block of content with anchors (`&`) and aliases (`*`), avoiding repetition:

```yaml
default: &default
  retries: 3
  timeout: 30

jobA:
  <<: *default
  name: jobA

jobB:
  <<: *default
  name: jobB
  timeout: 60   # overrides the default
```

`jobA` and `jobB` both inherit `retries: 3` and `timeout: 30` from `default`, and `jobB` overrides `timeout`.

## Multiple documents

A single YAML file can contain several documents, separated by `---` — commonly used in Kubernetes manifests to define multiple resources in one file:

```yaml
apiVersion: v1
kind: Service
metadata:
  name: my-service
---
apiVersion: apps/v1
kind: Deployment
metadata:
  name: my-deployment
```

## Common pitfalls

* **Tabs are not allowed** for indentation — only spaces.
* Unquoted values like `yes`, `no`, `on`, `off`, `null` or version-looking strings (`1.20`) can be silently parsed as booleans, null, or numbers instead of strings — quote them when in doubt.
* Inconsistent indentation between sibling keys breaks the whole document, and the error messages from YAML parsers can be unhelpful about exactly where.

## Use cases

* Kubernetes manifests and Helm charts, e.g. [[HELM - Chart.yaml]].
* CI/CD pipeline definitions (GitHub Actions, Azure Pipelines, GitLab CI).
* Application configuration files, as an alternative to [[INI]] or [[TOML]].
* Infrastructure as Code tools (Ansible playbooks, Docker Compose).

## Related

* [[JSON - BASICS]] and [[JSON vs XML]] — YAML is a superset of JSON's data model with a friendlier, indentation-based syntax.
* [[TOML]] — a config-focused alternative that trades YAML's flexibility for a stricter, less ambiguous syntax.
* [[File Extensions]] — the `.yml`/`.yaml` extension entry.
