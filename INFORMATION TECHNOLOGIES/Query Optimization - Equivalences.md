#DATABASES #MATHs 


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

