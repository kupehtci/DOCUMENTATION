#CONCEPTS 

# URI - Uniform Resource Identifier

A **URI** (Uniform Resource Identifier) is a string of characters that identifies a resource, either by **location**, **name**, or **both**. A resource can be anything with an identity: a web page, an image, a file, an email address, a book (ISBN), etc.

URI is the umbrella concept. It has two specializations:

* **URL** (Uniform Resource **Locator**): identifies a resource **and** tells you how/where to find it (protocol + location). Example: `https://example.com/index.html`
* **URN** (Uniform Resource **Name**): identifies a resource by a unique, persistent **name**, without saying where or how to get it. Example: `urn:isbn:0451450523`

So every URL and every URN is a URI, but not every URI is a URL or a URN.

```
                URI
                 |
        ┌────────┴────────┐
       URL                URN
  (locates it)         (names it)
```

## Syntax / Format

A URI follows this general structure, defined in [RFC 3986](https://www.rfc-editor.org/rfc/rfc3986):

```
scheme:[//authority]path[?query][#fragment]
```

Example:

```
https://user:pass@www.example.com:8080/path/to/page?search=hello&lang=en#section2
\___/   \_______/ \_____________/ \__/ \____________/ \_________________/ \______/
scheme  userinfo     host         port      path             query        fragment
        \_________________________________/
                    authority
```

| Component     | Description                                                              |
| ------------- | ------------------------------------------------------------------------ |
| **scheme**    | Protocol or namespace (`http`, `https`, `ftp`, `mailto`, `urn`, `file`). |
| **authority** | `[userinfo@]host[:port]`. Only present when the scheme uses one.         |
| **userinfo**  | Optional credentials (`user:pass`), deprecated for security reasons.     |
| **host**      | Domain name or IP address of the server.                                 |
| **port**      | Optional TCP port. Defaults depend on the scheme (80 for http, 443 for https). |
| **path**      | Hierarchical path to the resource, similar to a file system path.        |
| **query**     | Optional key-value pairs, prefixed by `?`, separated by `&`.             |
| **fragment**  | Optional pointer to a sub-part of the resource, prefixed by `#`. Resolved client-side, never sent to the server. |

## URI vs URL vs URN examples

| Type | Example | Notes |
| ---- | ------- | ----- |
| URL  | `https://example.com/docs/uri.md` | Tells you the protocol and the exact location. |
| URL  | `ftp://files.example.com/report.pdf` | Also a URL, different scheme. |
| URN  | `urn:isbn:9780134685991` | Names a book uniquely, no location involved. |
| URN  | `urn:uuid:6e8bc430-9c3a-11d9-9669-0800200c9a66` | Names a resource by UUID. |
| URI (non-locator, non-URN) | `mailto:john@company.com` | Identifies an email address/action, not a retrievable "location" in the HTTP sense. |

## Relative vs Absolute URIs

* **Absolute URI**: includes the scheme, fully self-contained (`https://example.com/page`).
* **Relative URI (reference)**: resolved against a base URI, commonly used in HTML/CSS (`../images/logo.png`, `/api/users`).

## Percent-encoding

Characters that are not allowed or that have special meaning in a URI (spaces, `?`, `#`, `&`, non-ASCII characters, etc.) must be **percent-encoded** as `%HH`, where `HH` is the hexadecimal value of the byte.

```
"hello world/año" → "hello%20world%2Fa%C3%B1o"
```

Reserved characters (`: / ? # [ ] @ ! $ & ' ( ) * + , ; =`) have structural meaning and are only percent-encoded when they must be used literally inside a component (e.g. a `/` inside a path segment).

## Related concepts

* [[SAML - Security Assertion Markup Language]] — SAML uses URIs as identifiers for namespaces, bindings, and NameID formats.
