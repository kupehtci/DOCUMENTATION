#Linux 

# curl command

`curl` (*Client URL*) is a command line tool to transfer data from or to a server using URLs. It is built on top of the `libcurl` library and supports a lot of protocols: `HTTP`, `HTTPS`, `FTP`, `FTPS`, `SFTP`, `SCP`, `SMTP`, `LDAP`, `MQTT`, `WS`/`WSS`, `FILE`...

It is non-interactive, so it is commonly used in scripts, CI/CD pipelines, health checks and for testing / debugging REST APIs. 

The basic syntax is: 
```bash
curl [options] [URL...]
```

By default `curl` performs a `GET` request and prints the response body to the standard output. 

```bash
curl https://example.com
```

## Output flags

* `-o file` / `--output file` writes the output in a file instead of stdout. 
* `-O` / `--remote-name` saves the file with the remote file name. 
* `-J` / `--remote-header-name` uses the name from the `Content-Disposition` header (with `-O`). 
* `--create-dirs` creates the local directories needed by `-o`. 
* `-s` / `--silent` silent mode, no progress bar nor errors. 
* `-S` / `--show-error` shows errors even with `-s`. 
* `-#` / `--progress-bar` shows a simple progress bar. 
* `-i` / `--include` includes the response headers in the output. 
* `-I` / `--head` makes a `HEAD` request, only the headers are fetched. 
* `-D file` / `--dump-header file` writes the response headers into a file (`-` for stdout). 
* `-v` / `--verbose` shows the full request / response exchange (TLS handshake, headers...). 
* `--trace file` / `--trace-ascii file` full dump of all incoming and outgoing data. 
* `-w format` / `--write-out format` prints information after the transfer (see [Write-out variables](#Write-out%20variables)). 

```bash
# Download a file keeping its remote name
curl -O https://example.com/files/archive.tar.gz

# Download into a specific path
curl -o /tmp/app.tar.gz --create-dirs https://example.com/files/archive.tar.gz
```

## Request flags

* `-X METHOD` / `--request METHOD` sets the HTTP method (`GET`, `POST`, `PUT`, `PATCH`, `DELETE`...). 
* `-H "Header: value"` / `--header` adds a custom header. Can be used multiple times. 
* `-A "agent"` / `--user-agent` sets the `User-Agent` header. 
* `-e URL` / `--referer` sets the `Referer` header. 
* `-G` / `--get` sends the `-d` data as URL query string with a `GET`. 
* `--compressed` asks for a compressed response (`gzip`, `br`...) and decompresses it. 
* `-L` / `--location` follows redirects (`3XX` + `Location` header). 
* `--max-redirs n` limits the number of redirects followed. 

> [!info] 
> Using `-d` implies `POST` and `-I` implies `HEAD`, so `-X` is usually only required for `PUT`, `PATCH` or `DELETE`. Using `-X POST` with `-L` can lead to unexpected behaviour because the method is forced also in the redirected requests. 

## Sending data

* `-d data` / `--data data` sends data in a `POST` with `Content-Type: application/x-www-form-urlencoded`. 
* `-d @file` reads the data from a file (`@-` for stdin). 
* `--data-raw data` like `-d` but the `@` character is not interpreted. 
* `--data-binary @file` sends the file exactly as it is (no newline stripping). 
* `--data-urlencode "key=value"` URL-encodes the value. 
* `--json data` (curl >= 7.82) sends JSON and sets both `Content-Type` and `Accept` to `application/json`. 
* `-F "key=value"` / `--form` sends `multipart/form-data`. Use `-F "file=@path"` to upload a file. 
* `-T file` / `--upload-file file` uploads a file with `PUT` (or to FTP / SFTP). 

```bash
# Form data
curl -d "user=admin&role=dev" https://api.example.com/users

# JSON body
curl -X POST https://api.example.com/users \
  -H "Content-Type: application/json" \
  -d '{"name": "Daniel", "role": "dev"}'

# The same with --json
curl --json '{"name": "Daniel", "role": "dev"}' https://api.example.com/users

# JSON body from a file
curl --json @user.json https://api.example.com/users

# Multipart file upload
curl -F "file=@./report.pdf" -F "description=Monthly report" https://api.example.com/upload

# Query string with GET
curl -G --data-urlencode "q=linux commands" -d "page=2" https://api.example.com/search
```

## Authentication

* `-u user:password` / `--user` basic authentication. If only `user` is given, `curl` asks the password interactively. 
* `--basic`, `--digest`, `--ntlm`, `--negotiate` select the authentication method. 
* `--oauth2-bearer token` sends a `Authorization: Bearer` header. 
* `-n` / `--netrc` reads the credentials from `~/.netrc`. 
* `--netrc-file file` uses a different `netrc` file. 

```bash
curl -u admin https://api.example.com/private

curl -H "Authorization: Bearer $TOKEN" https://api.example.com/me
```

> [!warning] 
> Passing secrets directly in the command line leaves them in the shell history and visible in `ps`. It is better to use environment variables, a `.netrc` file or reading the header from a file: `-H @headers.txt`. 

## Cookies

* `-b "name=value"` / `--cookie` sends cookies. It can also read them from a file: `-b cookies.txt`. 
* `-c file` / `--cookie-jar file` saves the cookies received in a file. 

```bash
# Login and save the session cookie, then reuse it
curl -c cookies.txt -d "user=admin&pass=$PASS" https://example.com/login
curl -b cookies.txt https://example.com/dashboard
```

## TLS / SSL flags

* `-k` / `--insecure` skips the certificate validation (only for testing!). 
* `--cacert file` uses a specific CA bundle to verify the server. 
* `--capath dir` directory with CA certificates. 
* `--cert file[:password]` client certificate (mTLS). 
* `--key file` private key of the client certificate. 
* `--tlsv1.2`, `--tlsv1.3` minimum TLS version. 
* `--http1.1`, `--http2`, `--http3` forces the HTTP version. 

```bash
# Mutual TLS
curl --cert client.crt --key client.key --cacert ca.crt https://internal.example.com
```

## Network and connection flags

* `-x proxy` / `--proxy` uses a proxy (`http://`, `socks5://`...). Also read from `http_proxy`, `https_proxy` and `no_proxy` env variables. 
* `--noproxy hosts` hosts that bypass the proxy. 
* `--resolve host:port:ip` forces the resolution of a host to an IP, without touching `/etc/hosts`. 
* `--connect-to host1:port1:host2:port2` redirects the connection to another host keeping the original `Host` header and SNI. 
* `-4` / `-6` forces IPv4 / IPv6. 
* `--interface name` uses a specific network interface. 
* `--unix-socket path` connects through a Unix socket. 
* `--connect-timeout seconds` max time for the connection phase. 
* `-m seconds` / `--max-time` max time for the whole operation. 
* `--retry n` retries on transient errors. 
* `--retry-delay seconds`, `--retry-max-time seconds`, `--retry-all-errors` fine tune the retries. 
* `-C -` / `--continue-at -` resumes an interrupted download. 
* `--limit-rate speed` limits the bandwidth (`500K`, `2M`...). 
* `-f` / `--fail` returns an error exit code (22) on HTTP errors `>= 400` and prints nothing. 
* `--fail-with-body` like `-f` but prints the response body. 
* `-Z` / `--parallel` performs the transfers in parallel. 

```bash
# Test a virtual host before changing the DNS
curl --resolve app.example.com:443:10.0.0.15 https://app.example.com/health

# Talk to the Docker daemon through its socket
curl --unix-socket /var/run/docker.sock http://localhost/containers/json

# Resume a big download
curl -C - -O https://example.com/big.iso
```

## Write-out variables

The `-w` flag prints variables after the transfer. Very useful for monitoring and debugging latencies. 

* `%{http_code}` response status code. 
* `%{time_namelookup}` DNS resolution time. 
* `%{time_connect}` TCP connection time. 
* `%{time_appconnect}` TLS handshake time. 
* `%{time_starttransfer}` time to first byte (TTFB). 
* `%{time_total}` total time. 
* `%{size_download}` downloaded bytes. 
* `%{remote_ip}` IP of the server. 
* `%{redirect_url}` URL of the redirect (if any). 
* `%{json}` all the variables in JSON format. 

```bash
# Only the HTTP status code
curl -s -o /dev/null -w "%{http_code}\n" https://example.com

# Timing breakdown
curl -s -o /dev/null -w "dns: %{time_namelookup}s\nconnect: %{time_connect}s\ntls: %{time_appconnect}s\nttfb: %{time_starttransfer}s\ntotal: %{time_total}s\n" https://example.com
```

The format can also be stored in a file and passed with `-w @format.txt`. 

## Configuration file

`curl` reads default options from `~/.curlrc` (or the file given with `-K file` / `--config file`). Use `-q` as first argument to ignore it. 

```text
# ~/.curlrc
silent
show-error
location
connect-timeout = 10
user-agent = "my-scripts/1.0"
```

## Exit codes

`curl` returns `0` on success. Some useful codes for scripting: 

| Code | Meaning                                  |
| ---- | ---------------------------------------- |
| 6    | Couldn't resolve host                    |
| 7    | Failed to connect to host                |
| 22   | HTTP error `>= 400` (only with `-f`)     |
| 28   | Operation timeout                        |
| 35   | SSL/TLS handshake error                  |
| 52   | Empty reply from server                  |
| 56   | Failure receiving network data           |
| 60   | Peer certificate cannot be authenticated |

## Interesting examples

```bash
# Pretty print a JSON response
curl -s https://api.github.com/repos/curl/curl | jq '.stargazers_count'

# Health check in a script / Dockerfile HEALTHCHECK
curl -fsS --max-time 5 http://localhost:8080/health || exit 1

# Wait until a service is up
until curl -fs -o /dev/null http://localhost:8080/health; do sleep 2; done

# Download and pipe to tar without saving the file
curl -fsSL https://example.com/app.tar.gz | tar -xz -C /opt/app

# Inspect the redirects chain
curl -sIL https://github.com | grep -iE "^(HTTP|location)"

# Check the certificate of a server (expiration, issuer...)
curl -vI https://example.com 2>&1 | grep -E "expire date|issuer|subject"

# Upload a file to an S3 pre-signed URL
curl -T ./backup.tar.gz "$PRESIGNED_URL"

# Several URLs at once with globbing
curl -O "https://example.com/logs/app-[1-10].log"
curl -O "https://example.com/{index,about,contact}.html"

# Send a message to a Slack / Teams webhook
curl --json '{"text": "Deploy finished"}' "$WEBHOOK_URL"

# Get your public IP
curl -s https://ifconfig.me

# Weather in the terminal
curl wttr.in/Zaragoza

# Convert a browser request to curl: DevTools > Network > right click > Copy as cURL
```

> [!warning] 
> Avoid `curl ... | bash` with scripts from untrusted sources. Download the script first, read it and then execute it. 

## curl vs wget

| | `curl` | `wget` |
| --- | --- | --- |
| Default output | stdout | file |
| Protocols | Many (HTTP, FTP, SMTP, LDAP, MQTT...) | HTTP, HTTPS, FTP |
| Recursive download | No | Yes (`-r`, mirror websites) |
| Upload / methods | Yes (`-X`, `-d`, `-F`, `-T`) | Limited |
| Library | `libcurl` | No |

Related: [[find]], [[SSH - Secure Shell]], [[HTTP - Header attributes]]
