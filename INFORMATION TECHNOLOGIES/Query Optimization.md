#DATABASES 

### QUERY PROCESSING

A query expressed in a high-level

Identify language tokens (SQL Keywords, attribute names and relation names)

```PostgreSQL
SELECT professors.name, emails.email 
FROM professors NATURAL JOIN emails
WHERE professors.name = "Andrea Martinez"; 
```

Language tokens extracted from this query: 

* SQL Keywords: SELECT, FROM, NATURAL JOIN and WHERE
* Attribute names: 

Checks syntax: 

``` PostgreSQL
SELECT [ALL | DISTINCT[ON (expression[, ...])]]
	[ * | _`expression`_ [ [ AS ] _`output_name`_ ] [, ...] ]
    [ FROM _`from_item`_ [, ...] ]
    [ WHERE _`condition`_ ]
    [ GROUP BY [ ALL | DISTINCT ] _`grouping_element`_ [, ...] ]
    [ HAVING _`condition`_ ]
    [ WINDOW _`window_name`_ AS ( _`window_definition`_ ) [, ...] ]
    [ { UNION | INTERSECT | EXCEPT } [ ALL | DISTINCT ] _`select`_ ]
    [ ORDER BY _`expression`_ [ ASC | DESC | USING _`operator`_ ]
```


If all attributes and relation names are valid and is semantically correct, query is represented as a tree-data source called <span style="color:orange;">query tree</span>. 

With this query tree that follows relational algebra, search how to optimize this tuple search. 
In this step, all comprobations about attributes, values and keywords are made, so cannot fail unless is ID unique error. 


There are two main techniques to implement this Query optimization: 

* Heuristic rules: order the operations in the query tree
* Systemic (Cost based): estimating the cost of the different strategies and <span style="color:MediumSlateBlue;">select best cost query tree</span> to perform the operation

#### HEURISTIC RULES

Query tree is transformed into another tree that is equivalent to first one, but the execution is more efficient based on query tables characteristics. 

Rules like: 

* Executing a table with two conditions or evaluating one condition and them with the resulting table evaluate the other condition.

	$$C_c1(C_c2(C_c3(...(Table)...))) === C_c1 and c2 and c3....and c(Table)$$
	
* Merge conjuntive tables with conditions, to perform the condition previously than the join to optimize the join. 
* Using commutativity rules, move the selection operations as fas down the tree as possible.

$$T_1 JOIN_c1 T_2 === C_1(T_1 JOIN T_2)$$

![[query-optimization-1.png]]


Take a look into relatioal algebra symbols applied to **query trees**: [[Relational Algebra - Symbols]]. 


You can force this equivalences in some ways: 

![[query-optimization-equivalence.png]]![[class-exercise-3.png]]