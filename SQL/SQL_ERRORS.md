# SQL ERRORS
#SQL
## 1828 - Cannot drop colum, because a foreign key 

When triying to **drop** a table´s column and you have an error like this: 

```bash 
	mysql> ALTER TABLE `user` DROP COLUMN `region_id`;
	1828 - Cannot drop column 'region_id': needed in a foreign key constraint 'FK_regions'
```

This is because when the table was created, a foreign key was setted for that column. 
A foreign key that look like: 

```SQL 
	-- USER TABLE WITH FOREIGN KEYS 

	--MySQL
	CREATE TABLE `user` (
	  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
	  `region_id` int(11) unsigned DEFAULT NULL,
	  `town_id` int(11) unsigned DEFAULT NULL,
	  `fullname` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
	  `username` varchar(30) COLLATE utf8_unicode_ci DEFAULT NULL,
	  `email` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
	  `password` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
	  `active` tinyint(1) unsigned NOT NULL DEFAULT '0',
	  PRIMARY KEY (`id`),
	  KEY `FK_G38T6P7EKUXYWH1` (`region_id`),
	  KEY `FK_J8VWK0ZN7FD2QX4` (`town_id`),
	  CONSTRAINT `fk_regionid` FOREIGN KEY (`region_id`) REFERENCES `region` (`id`) ON UPDATE NO ACTION,
	  CONSTRAINT `fk_townid` FOREIGN KEY (`town_id`) REFERENCES `town` (`id`) ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci

	-- MariaDB 
	CREATE TABLE Users(
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(128) NOT NULL,
    name VARCHAR(64) NOT NULL, 
    email VARCHAR(128) NOT NULL, 
    password VARCHAR(128) NOT NULL,
    registration_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    is_admin BOOLEAN NOT NULL DEFAULT FALSE, 
    activation_token VARCHAR(32) NOT NULL, 
    actived BOOLEAN NOT NULL DEFAULT 0, 
    category INT NOT NULL
); 

	-- MariaDB Constrain
	ALTER TABLE Users
    ADD CONSTRAINT fk_category
        FOREIGN KEY (order_products_id) 
        REFERENCES Categories(id)
        ON DELETE NO ACTION 
        ON UPDATE CASCADE; 

	ALTER TABLE Users ADD UNIQUE(email);
```

This constrain determines that a key of the table is constrained to other table changes. This means than when added a constrain this table is assigned as a child of the referenced one and if the father one gets updated or deleted a value, this change would make some effects in the children one.

To delete this constrains: 

```SQL 
	ALTER TABLE Users DROP FOREIGN KEY `fk_category`;

	-- After droping the constrain, you should be able to delete the column 

	ALTER TABLE Users DROP COLUMN Users.category; -- Also works using category instead of Users.category
```


---
title: SQL ERRORS
author: Daniel Laplana Gimeno
date: 23-11-2023