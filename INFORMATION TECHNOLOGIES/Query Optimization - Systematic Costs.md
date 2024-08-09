
### SYSTEMATIC (COST BASED)

In order to calculate the estimated costs, can be estimated using different measures: 

This are the relevant values that need to be defined or calculated in order to calculate the final costs. 

| Variable                                                                                                       | Elmasri / Navathe          |
| -------------------------------------------------------------------------------------------------------------- | -------------------------- |
| Number of records (tuples) in a table (relation)                                                               | r                          |
| Blocking factor (records per block)                                                                            | bfr                        |
| Number of blocks required to store the table                                                                   | b = r / bfr                |
| Number of levels of an index                                                                                   | x                          |
| Number of distinct values of an attribute                                                                      | d (if key attribute d = r) |
| Selectivity (% records satisfying an = condition)                                                              | sI = 1 / d                 |
| Selection cardinality (avg. number of records satisfied on equiality assuming distribution of distinct values) | a = sI * r                 |

Example of the cost measures: 

`SELECT name FROM Professors WHERE id = 111; `

![[systematic_diagram_cost_based.png|350]]

Cost calculations for SELECTION: 

| Selection conditions                                                                                                                                        | Elmasri / navathe |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------- |
| Non-equality condition or equality on a non-key: Full table scan or brute force                                                                             | b                 |
| Equality condition on a key in unordered data: Linear search                                                                                                | b / 2             |
| Equality condition on a key in ordered data: Binary Search                                                                                                  | Log^2(b)          |
| Equality condition on a key in ordered data using primary index                                                                                             | x + 1             |
| Equality condition on a non-key or non-equality condition or a primary key. Retrieve multiple records using an index (asume 1/2 records meet the condition) | x + (b/2)         |
| Equality condition on a non-key using a clustering index:                                                                                                   | x + (s/bfr)       |
| Equality condition on a non-key using secondary index:  <br>because in the worst case, each record may reside on a different block.                         | x + s             |

Cost calculations for JOIN: 

| Type                                       | Formula                      |
| ------------------------------------------ | ---------------------------- |
| Nested loop (Records)                      | $b^r + (r^R * b^s)$          |
| Nested loop (Blocks) (M number of buffers) | $b^R +(b^R / (M-2)) * b^s$   |
| Sort merge                                 | $b^R + b^S + Cost\ to\ sort$ |
| Cost to sort                               | $b^R * [log^2(b^R)]$         |
|                                            |                              |

### SIZE COSTS

Considering a basic joint of a relation R with relation S where R.A = S.B:  $R  ⋈  S$

You need to consider the following variables: 

| Variable                      | Elmasri / Navathe |
| ----------------------------- | ----------------- |
| Size of cartesian product (x) | $b_R * b_S$       |



Example: 

`SELECT name, title FROM Professors NATURAL JOIN grants WHERE id = 111; `


---

#### REFERENCES

Take a look into: https://holowczak.com/database-query-processing-optimization/3/  for information and query sistematic cost calculation. 