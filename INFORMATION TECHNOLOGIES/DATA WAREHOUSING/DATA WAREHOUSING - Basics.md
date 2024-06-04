#DATABASES 

### DATA WAREHOUSES

A <span style="color:MediumSlateBlue;">Data warehouse</span> is a subject oriented, integrated, non-volatile, time-variant collection of data in support of management's decisions. 
The Data warehouses are then analyzed though BI[^2] techniques

Also is: 
* <span style="color:MediumSlateBlue;">Subject Oriented</span>: related to a subject of interest
* <span style="color:CornflowerBlue;">Integrated</span>: follow common standards and formats
* <span style="color:MediumSlateBlue;">Time-variant</span>: stores time data
* <span style="color:CornflowerBlue;">Non volatile</span>: persistent data, don't gets deleted
* <span style="color:MediumSlateBlue;">Summarized</span>: segmented in order to help future analysis. 

The information stored within the data warehouse helps to make future decisions. 

In terms of data it uses <span style="color:orange;">informational data</span> instead of operational data because it stores data with an historical perspective to make decisions[^1]. 

The main <span style="color:orange;">goals</span> of Data warehousing: 

* Information easily accesible: data is intuitive to the business user, not only the developer. 
* Present the information consistently: data is carefully assembled from different sources, cleaned, quality assured and refined for the final user consumption. 
* Adaptative and resilient to changes: existing data won't be disrupted for the new questions or new data. 
* Protect the information: the data warehouses must effectively control access to the organization confidential information. 
* Foundation the information: a data warehouse must have the right data in order to support the decision making. 
* Accepted by the business community: or easy to understand. 

This data can be taken from **various sources**: 

* Structured data (tabular data)
* Semi-structured data (JSON or XML)
* Unstructured data (plain text, videos, audios, ...)

Data can also be stored in: 
* [[Data Mart]]
* [[Data Lake]]

### ETL - Extract, Transform, Load

Extract, Transform and Load are three simple database functions that are combined into one tool to pull data out from a database and place in another one. 

Is used to build a **Data warehouse**: 

* <span style="color:MediumSlateBlue">Extract</span>: obtain the relevant information from a certain bussines point
* <span style="color:CornflowerBlue">Transform</span>: transform the heterogeneous data into a single format. 
* <span style="color:Orchid">Load</span>: once the data is transformed, it must be stored. 

### Data warehousing components

| Operational systems                                         | Data staging area                 | Data presentation area                                                                                                                                                              | Data access control                                                   |
| ----------------------------------------------------------- | --------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Captures the transactions of the business. Common database. | Storage area and processes as ETL | Data is organized, stored and made available for users, report data and more. Capabilities provided to business users to  to access presentation area for analytic decision making. | Tools provided to business users in order to analitic decision making |

#### Architectures

There are three main structures for data warehouses: 

- Single Tier Architecture

Minimize the amount of the data stored reducing data redundancy. 
All components of data warehousing are located in the same server. 

This structure can be condensed into different Data Marts that contains subsets of the data stored in the warehouse. 

![[dw_single_tier.png]]

- Two Tier Architecture

Physically available sources and the data warehouse are separated- 
Data can be accesses through an API like ODBC or JDBC, from the client side program. 

![[dw_two_tier.png]]

- Three Tier Architecture

There is another layer between the client and the server. The client in order to communicate with the Data warehouses goes through a OLAP server. 

This OLAP server presents an abstract view of the database acting as a mediator between the end-user and the database. 
![[dw_three_tier.png]]

---

[^1]: Differences between operational and informational data systems [[Operational or Informational Systems]]

[^2]: Business intelligence [[BI - Business Intelligence]]