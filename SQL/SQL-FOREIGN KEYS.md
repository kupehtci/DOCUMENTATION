## FOREIGNS KEYS 

A foreign key is the method used in SQL for dealing with relation ships between tables when one item depend of other table item or viceversa. 

If you want when an item value is update or the entire item gets deleted, have an affect in other table, establish a foreign key in the affected one is the method to make it. 

```SQL
ALTER TABLE Orders
	ADD CONSTRAINT fk_order_user
	FOREIGN KEY (user_id)
	REFERENCES Users(id)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
```

This example links by a foreign key the <span style="color:orange;">Users.id</span>. 