#PostgreSQL 

### PostgreSQL sequences 

A sequence is a database object that holds a sequence of integers and is usually used as the <span style="color:orange;">primary key</span>. 

The <span style="color:coral;">sequence</span> equivalent: 

```PostgreSQL
CREATE SEQUENCE table_name_id_seq; 

CREATE TABLE table_name (     
	id integer NOT NULL DEFAULT nextval('table_name_id_seq') 
	-- ...
); 

ALTER SEQUENCE table_name_id_seq OWNED BY table_name.id;
```

To ease this usage as primary key, in newer versions of PostgreSQL there exists `serial` pseudo-type [[PostgreSQL - SERIAL]]. 