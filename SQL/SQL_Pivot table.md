## INTRODUCTION 

A `pivot table` or `junqtion table` is the one created to deal with a many to many relation ship between 2 entities in a database. 

## HANDS IN WORK 

In this example `ProductCategory` acts as a join table, linking each product with its more than one categories and each Category with all of its products related to it. 

![[pivot_table.png]]

This pivot tables needs to link two or more items from different tables. 
For this purpose, they need to have a item1_id value and item2_value, in this case `product id` that points to the product and `category_id` that links to category. 


To link the tables correctly and take into account each change between them you can establish Foreigns keys. [[SQL-FOREIGN KEYS]]

