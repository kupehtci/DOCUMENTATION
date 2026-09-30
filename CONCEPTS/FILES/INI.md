#CONCEPTS #FILES

# INI

An **INI file** is one of the oldest and simplest configuration file formats: plain **key-value pairs**, optionally grouped into **sections**. There is no official standard, so exact syntax details (quoting, comments, nesting) can vary slightly between the tools that read them.

## Syntax basics

```ini
; this is a comment
[server]
host = 0.0.0.0
port = 8080
debug = true

[database]
url = postgres://localhost/mydb
pool_size = 10
```

* **Sections**: `[section]` groups related keys, similar to a table in [[TOML]].
* **Key-value pairs**: `key = value` (or `key: value` depending on the parser).
* **Comments**: usually `;` or `#`, depending on the parser.
* Everything is essentially a **string** — there is no native typing for numbers, booleans or lists; the application reading the file decides how to interpret values like `true` or `8080`.

## Characteristics

* Flat structure: sections cannot usually be nested inside other sections.
* No standard way to represent lists or nested objects, unlike [[YAML]] or [[TOML]].
* Very easy to read and hand-edit, which is why it's still common for simple desktop application settings (`.ini`, `php.ini`, `.gitconfig`-style files, Windows configuration).

## Use cases

* Legacy or simple application configuration (`php.ini`, `.editorconfig`-style tools).
* Situations where a lightweight, flat, human-editable format is enough and nested structures aren't needed.

## Related

* [[TOML]] — a modernized, stricter evolution of the same key-value/section idea.
* [[YAML]] — used instead when nesting and richer data types are needed.
* [[File Extensions]] — the `.ini` extension entry.
