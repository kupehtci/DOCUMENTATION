#OracleDB 

# OracleDB - Service Name

A **Service Name** is a logical database service running in an oracle server used to route connection requests to the appropriate database instance. 

Its defined in the oracle database configuration and may be different from the database name or SID. 

You can check the service name ar `tnsnames.ora` file: 
```bash
MYDB = 
  (DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = hostname)(PORT = 1521))
    (CONNECT_DATA =
      (SERVICE_NAME = myservice.domain.com)  # This is the service name
    )
  )
```

This will grant a connection string like: 
```ini
# Using service name 
dsn = "hostname:1521/ORCLPDB1"

# Older format uses SID 
dsn = "hostname:1521/ORCL"

# Connextion string with domain
dsn = "hostname:1521/myservice.mydomain.com"

# For Autonomous Database (from wallet)
dsn = "dbname_high"  # Requires a config_dir pointing to wallet
```