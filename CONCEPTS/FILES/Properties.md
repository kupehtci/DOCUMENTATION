#CONCEPTS #FILES

# Properties (.properties)

A **`.properties` file** is a simple, flat, line-based configuration format used mainly in the **Java ecosystem** (Java itself, Spring Boot, Maven, Log4j). Each line holds a single **key-value pair**, similar in spirit to [[INI]] but without sections.

## Syntax basics

```properties
# Comment
server.port=8080
server.host=0.0.0.0
app.name=My Application
app.debug=true

! Exclamation marks also work as comments
database.url=jdbc:postgresql://localhost:5432/mydb
```

* **Key-value pairs**: `key=value` or `key:value` — both separators are accepted.
* **Comments**: start with `#` or `!`.
* **Everything is a string**: like [[INI]], there is no native typing — the application parses `true`/`8080` as booleans/numbers itself.
* **Dot-separated keys** are a common convention to fake hierarchy (`server.port`, `server.host`), since the format itself has no real nesting.
* A `\` at the end of a line continues the value onto the next line.

## Properties vs YAML in Spring Boot

Spring Boot accepts both `application.properties` and `application.yml` for the same configuration:

```properties
# application.properties
server.port=8080
spring.datasource.url=jdbc:postgresql://localhost/mydb
```

```yaml
# application.yml
server:
  port: 8080
spring:
  datasource:
    url: jdbc:postgresql://localhost/mydb
```

[[YAML]] expresses the same dotted hierarchy more compactly through real nesting, which is why many teams prefer it once the configuration grows large — `.properties` stays popular for its simplicity and because dotted keys are trivial to override individually via environment variables or command-line flags (`--server.port=9090`).

## Use cases

* Java/Spring Boot application configuration.
* Localization/internationalization (i18n) resource bundles (`messages_en.properties`, `messages_es.properties`).
* Build tool configuration (Maven, Ant).

## Related

* [[INI]] — the closest non-Java equivalent, flat key-value pairs but organized into sections.
* [[YAML]] — the common alternative for the same configuration, with real nesting.
* [[File Extensions]] — general file extension reference.
