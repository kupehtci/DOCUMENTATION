#DATABASES 

### DATA WAREHOUSES

A <span style="color:MediumSlateBlue;">Data warehouse</span> is a subject oriented, integrated, non-volatile, time-variant collection of data in support of management's decisions. 

* Subject-oriented: discard the information that is not important for that study subject
* Integrated: Board only contains information to solve the questions
* Non-volatile: data is permanent
* Time-variant: as you include more data, you can see the evolution regarding the time. 

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

### ETL - Extract, Transform, Load

Extract, Transform and Load are three simple database functions that are combined into one tool to pull data out from a database and place in another one. 

Is used to build a **Data warehouse**: 

* **Extract**: obtain relevant information from a business point of view
* **Transformation**: transform from different sources into a single format. (Usually relational data , normally used in Data warehouses). 
* **Loading**: once the data has been transformed, it must be stored. 

##### DATA LAKE

A data lake is a **centralized** database that integrates data from multiple sources for corporate reporting and analysis. 

##### DATA MART

A data mart is a single functional data area of an organization. Contains a little and specific piece of data within a more bigger data system. 

Is a logical subdivision of a Data Warehouse. 


### Data warehousing components

| Operational systems                                         | Data staging area                 | Data presentation area                                                        | Data access control                                                                                     |
| ----------------------------------------------------------- | --------------------------------- | ----------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
| Captures the transactions of the bussiness. Common database | Storage area and processes as ETL | Data is organized, stored and made available for users, report data and more. Capabilities provided to business users to  to access presentation area for analytic decision making.  a  |

#### Architectures

There are three main structures for data warehouses: 

- Single Tier Architecture

Minimize the amount of the data stored reducing data redundancy. 
All components of data warehousing are located in the same server. 

This structure can be condensed into different Data Marts that contains subsets of the data stored in the warehouse. 

- Two Tier Architecture

Physically available sources and the data warehouse are separated- 
Data can be accesses through an API like ODBC or JDBC, from the client side program. 

- Three Tier Architecture

There is another layer between the client and the server. The client in order to communicate with the Data warehouses goes through a OLAP server. 

---

[^1]: Differences between operational and informational data systems [[Operational or Informational Systems]]