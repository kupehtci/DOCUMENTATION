#OracleDB 

# OracleDB - Administration


## Check service names

With sqlplus access you can check the service names available: 
```sql
SELECT value FROM v$parameter WHERE name = 'service_names';
```

## Check available users

With sqlplus access you can check the users that exists: 
```sql
SELECT username, account_status FROM dba_users;
```
