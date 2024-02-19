#DATABASES 

## DCL - Data Control Language

This SQL Language DCL is used for defining SQL roles and manage a database access


```PostgreSQL
GRANT privilege_list | ALL ON table_name TO role_name
```

* `privilege_list`can be: `SELECT`, `INSERT`, `UPDATE`, `DELETE`, `TRUNCATE`, ...
* `table_name` is the table that privilege is given. It gives permission to all table. To add to a certain attribute of a SQL table, 
* `role_name` is a predefined role, example: student, professor


Example: 

```PostgreSQL
GRANT SELECT ON TABLE grants.professors TO "Student"
```

In postgreSQL: 

* Create a new SQL connection with Student username. This connection done by: Add++ Server, is adding a connection. This connection needs to be pointing to the localhost
* Create a new Role in SQL, with student name. Activate the CanLogin? property and save

If user role is aready created and have a wrong icon, is because is an internal role and cannot externally login: 

To alter the property: 
```PostgreSQL
ALTER ROLE "Student"
	LOGIN;
```

#### Create a View

We need to create a view that virtually make a closer scope to the tables that a certain role can view: 

* Go to views in PostgreSQL master user. And right click --> Create a View. 
* give a name: `view_grants_for_students` and in code section assign a code that limits the view: `SELECT idGrant, title FROM grants` and in Security section give permision to Student role to be able to use this view.

In code format: 

```PostgreSQL
CREATE VIEW public.view_grants_for_students
 AS
SELECT idGrant, title FROM grants;

ALTER TABLE public.view_grants_for_students
    OWNER TO postgres;

GRANT ALL ON TABLE public.view_grants_for_students TO "Student";
```

```PostgreSQL
-- Once the view is created, you can view data by: 
SELECT * FROM view_grant_for_students
```
