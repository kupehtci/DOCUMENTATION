#DATA_WAREHOUSING #CONCEPTS 

In a <span style="color:IndianRed;">data warehouse</span> its common to store the data using relational models. 
But relational models in this area follow different design rules. 

The logical schemas of a Data warehouse are composed of: 

* <span style="color:DodgerBlue;">Fact table</span>: is the primary table in a dimensional model where main performance measurement are stored. 
* <span style="color:DodgerBlue;">List of Dimensions</span>: define the grain or scope of a fact table. 
* <span style="color:DodgerBlue;">Dimension table</span>: integral companions to the fact table that contains the verbose information of the fact. 


![[logical_schema.png | 350]]

This schemas are designed to address very larger databases for analytical purpose (OLAP)

#### TYPES

There are three main types of multidimensional schemas: 

* Star schema
One fact table and several associated dimension tables. 
The fat table contains specific measurable primary data. 

* Snowflake schema
Extension of <span style="color:DeepSkyBlue;">star schema</span> adding additional dimensions.
Dimension tables are normalized with data splitted into additional tables.

* Fact Constellation schema or Galaxy Schema
Two fact table that share dimension tables. 

