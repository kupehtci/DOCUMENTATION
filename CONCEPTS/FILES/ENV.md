#CONCEPTS #FILES

# .env (Environment files)

An **.env file** is a plain-text file that defines **environment variables** as simple `KEY=VALUE` pairs, one per line. It's the standard way to keep configuration — and especially secrets — out of source code, loaded into the process environment at startup instead of hardcoded.

## Syntax basics

```env
# Comment
DATABASE_URL=postgres://user:pass@localhost:5432/mydb
API_KEY=abcd1234
DEBUG=true
PORT=8080
```

* One variable per line: `KEY=VALUE`.
* No sections, no nesting — just a flat list, even simpler than [[INI]].
* Values are usually left unquoted; quotes are only needed to preserve spaces or special characters.
* Comments start with `#`.

## How it's used

An `.env` file is not parsed by the language/runtime itself — a library (like `dotenv` in Node.js, Python, Ruby, etc.) reads the file and injects each key into the process's environment variables (`process.env` in Node, `os.environ` in Python), so the rest of the application reads configuration the same way it would read any OS-level environment variable.

```js
require('dotenv').config();
console.log(process.env.DATABASE_URL);
```

## Best practices

* **Never commit real `.env` files to version control** — they typically hold secrets (API keys, database passwords, tokens). Commit an `.env.example` with the variable names and dummy/blank values instead.
* Add `.env` to `.gitignore` by default in any new project.
* Different environments (development, staging, production) typically use separate `.env` files or a secrets manager instead of a checked-in file in production.

## Use cases

* Local development configuration, keeping secrets out of the codebase.
* Twelve-Factor App style configuration, where config lives in the environment rather than in code.
* Feeding configuration into containers (`docker run --env-file .env`) without baking secrets into the image.

## Related

* [[INI]] — a similarly flat format, but organized into sections and not tied to the process environment.
* [[File Extensions]] — the `.env` extension entry.
