#DATABASES #DATA_WAREHOUSING

### Four-steps Dimensional Design Process


* Declare the grain of the business process

The grain here is the individual product purchased on a transaction



* Choose the dimensions that apply to each fact table row.

The following dimensions that are around the main fact table: 

* product
* store
* state
* date
* promotion
* cashier
* method payment

* Identify the numerical facts that fill populate the fact table. 

If there is a numerical value, get extracted from the dimensions to numerical values within the fact table. 