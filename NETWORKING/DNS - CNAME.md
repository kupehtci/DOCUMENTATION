#NETWORKING 

### CNAME

A CNAME registry is a type of resource to link one alias domain name in the domain name system DNS [[DNS - Domain Name System]] to the original one (CNAME). 


This aliases names are stored in the DNS server and has certain restrictions

```
NOMBRE                TIPO      VALOR
--------------------------------------------------
bar.example.com.      CNAME     foo.example.com.
foo.example.com.      A         192.0.2.23
```

When the query search for a A record for *bar.example.com* and finds a CNAME, it would do again the query to *foo.example.com* that would return 192.0.2.23. 

### USE RESTRICTIONS

* CNAME records always need to point to another domain name, not an IP 
* Must not exist another record for that cname of other type. (Except if using DNSSEC)
* CNAME records should not point to another CNAMES, because can cause a loop error: 

```
NOMBRE                TIPO      VALOR
--------------------------------------------------
bar.example.com    CNAME    foo.example.com
foo.example.com    CNAME    bar.example.com
```

But this error would need to be handled by the server. 

* MX or NS records should not point to another CNAME records
* CNAME registers are not DNAME records, they are different. [[DNS - DNAME]]. 
