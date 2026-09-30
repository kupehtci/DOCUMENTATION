#CONCEPTS #FILES

# TOML

**TOML** ("Tom's Obvious, Minimal Language") is a configuration file format designed to be **easy to read** and to **map unambiguously** to a hash table (key-value structure), avoiding some of the ambiguity and whitespace-sensitivity of [[YAML]].

It's the standard configuration format for tools like Cargo (Rust), Poetry/`pyproject.toml` (Python), and Hugo.

## Syntax basics

```toml
name = "my-project"
version = "1.0.0"
active = true
port = 8080
tags = ["cli", "tool"]

[server]
host = "0.0.0.0"
port = 9090

[database]
url = "postgres://localhost/mydb"
pool_size = 10
```

* **Key-value pairs**: `key = value`, always on a single line.
* **Tables** (`[section]`): group related keys, similar to a section in [[INI]] or a nested object in [[YAML]]/JSON.
* **Arrays**: `[value1, value2]`.
* **Comments**: start with `#`.

## Nested tables

```toml
[server.logging]
level = "debug"
path = "/var/log/app.log"
```

This is equivalent to a nested object `server.logging = { level: "debug", path: "/var/log/app.log" }`.

## Array of tables

Repeated blocks of the same shape use `[[table]]`:

```toml
[[user]]
name = "Daniel"
role = "admin"

[[user]]
name = "Marta"
role = "editor"
```

## TOML vs YAML

| | TOML | [[YAML]] |
| --- | --- | --- |
| Syntax sensitivity | Low — explicit `=` and quotes | High — relies on indentation |
| Readability for deep nesting | Gets verbose with dotted table names | Reads naturally, indentation shows nesting |
| Ambiguity | Very low, strict types | Higher — `yes`/`no`/`on`/`off` can be misparsed |
| Common use | Application/tool configuration | DevOps configs, CI/CD, Kubernetes |

TOML favors strictness and predictability over YAML's flexibility, which is why it's popular for tool configuration where a subtle parsing surprise would be costly.

## Use cases

* Project/tool configuration files (`Cargo.toml`, `pyproject.toml`).
* Application settings where explicit typing and low ambiguity matter more than deep nesting.

## Related

* [[YAML]] — the more flexible, indentation-based alternative.
* [[INI]] — a simpler, older section/key-value format TOML modernizes.
* [[File Extensions]] — the `.toml` extension entry.
