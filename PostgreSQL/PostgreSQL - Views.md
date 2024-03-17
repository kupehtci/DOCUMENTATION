#PostgreSQL 




#### CHANGE OWNER

You can change the owner of a view via SQL `ALTER` command: 

```PostgreSQL
ALTER TABLE public.registered_user_view OWNER TO registered_user;
```

Take into account that once the view is created, is considered as a "virtual table" [[Views]], so interacting with them is done as with a table. 
#### EXAMPLE

This is an example of a view creation with grating of role permissions: 

```PostgreSQL
CREATE VIEW public.registered_user_view
 AS
	SELECT Users.id, Users.name, Users.street, Users.zipcode, Users.City, Users.Country, Videogames.name, Videogames.platform_name, Videogames.image
	FROM Users 
	JOIN UsersBuyVideogames ON Users.id = UsersBuyVideogames.userid
	JOIN Videogames ON UsersBuyVideogames.videogame_name = Videogames.name AND UsersBuyVideogames.videogame_platform = Videogames.platform_name;

ALTER TABLE public.registered_user_view
    OWNER TO registered_user;

GRANT ALL ON TABLE public.registered_user_view TO postgres WITH GRANT OPTION;
```
