#DATABASES #MATHs 

### RULES

The queries in order to maintain the equivalence and being represented as Linear algebra, some equivalency rules can be use in order to transform each query into an equivalent one that is more efficient: 

-  Cascading selections. A list of conjunctive conditions can be broken up into separate individual conditions.
- Commutativity of the selection operation.
- Cascading projections. All but the last projection can be ignored.
- Commuting selection and projection. If a selection condition only involves attributes contained in a projection clause, the two can be commuted.
- Commutativity of Join and Cross Product.
- Commuting selection with Join.
- Commuting projection with Join.
- Commutativity of set operations. Union and Intersection are commutative.
- Associativity of Union, Intersection, Join and Cross Product.
- Commuting selection with set operations.
- Commuting projection with set operations.
- Logical transformation of selection conditions. For example, using DeMorgan’s law, etc.
- Combine Selection and Cartesian product to form Joins.

And can be used following the next steps: 

1. Using rule 1, break up conjunctive selection conditions and chain them together.
2. Using the commutativity rules, move the selection operations as far down the tree as possible.
3. Using the associativity rules, rearrange the leaf nodes so that the most restrictive selection conditions are executed first. For example, an equality condition is likely more restrictive than an inequality condition (range query).
4. Combine cartesian product operations with associated selection conditions to form a single Join operation.
5. Using the commutativity of Projection rules, move the projection operations down the tree to reduce the sizes of intermediate result sets.
6. Finally, identify subtrees that can be executed using a single efficient access method.

Equivalences: 


`CROSS TO JOIN`

Cross product operation is expensive. This is because matches each tuple from the T1 into T2 giving a result of $m*n$ entries. If we have a selection operation from that table, this is equivalent to make a conditional join $⋈_c$. 

$$C_0(T_1 x T_2) \equiv T_1 ⋈_c T_2$$

`ASSOCIATIVE EQUIVALENCES`

$$(T_1 ⋈_1 T_2) ⋈_2 T_3 \equiv T_1 ⋈_1 (T_2 ⋈_2 T_3)$$

Joins are commutative as well as associative so can be executed in different order. Tend to execute joins with less number of entries first and them with the remaining table. 


`SELECTION EQUIVALENCES`

combined selections can be redistributed into tables before a join to optimize the join. 

$$$$


---

Take a look into : [geeksforgeeks](https://www.geeksforgeeks.org/query-optimization-in-relational-algebra/)

