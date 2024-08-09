#DATABASES #DATA_WAREHOUSING

## LOGICAL SCHEMA


In order to define a logical schema for a data warehouse, there are four main steps to follow to define its logical schema[^1]. 

### Four-steps Dimensional Design Process

Follow the next steps in order to build a logical schema[^1] for a data warehouse: 

* Select the business process to model

Define the purpose of the logical schema. 

```
Understand better customer purchases as captured in the system. 
```

* Declare the grain of the business process

The grain in a logical schema is an individual unit to be analyzed in the schema. Will be the fact table main unit. 

```
The grain here is the individual product purchased on a transaction
```

* Choose the dimensions that apply to each fact table row.

Choose the data that surround the fact table. This data is going to be extracted as dimension tables and its important to analyze the business model. 

```
The following dimensions that are around the main fact table: 
* product
* store
* state
* date
* promotion
* cashier
* method payment
```

* Identify the numerical facts that fill populate the fact table. 

If there is a numerical value, get extracted from the dimensions to numerical values within the fact table. 
If a value within the system is not numerical such as locations, states or something similar, take out as <span style="color:CornflowerBlue;">dimension tables</span>. 



[^1]: Logical schema of a data warehouse [[Logical Schemas in DW]]. 