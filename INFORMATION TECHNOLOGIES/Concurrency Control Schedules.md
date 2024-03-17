#DATABASES 


### SCHEDULES

One way to prevent concurrency problems [[Concurrency Control Problems]] is `schedules`. 

Schedules are logical sequences that indicate the chronological order in which operations of concurrent transactions are executed. 

There are two types: 

* Serial Schedule
* Non-Serial Schedule

| T1       | T2       | VALUES |
| -------- | -------- | ------ |
| read(A)  |          | A = 10 |
| read(B)  |          | B = 5  |
| A=A+1    |          |        |
| write(A) |          | A=11   |
|          | read(A)  |        |
|          | A=A-3    |        |
| B=B+1    |          | B=4    |
| write(B) |          |        |
|          | write(A) | A=8    |

A non-serial schedule can be considered serializable, needs to be have two considerations: 

* **Serial**: operations need to be interspersed between the different transaction in a logical way. 
* **Not have concurrency problems**

##### Exercise example: 

Find a serializable schedule that is equivalent to the following serial schedule. 

| T1                      | T2                      | T3                            | VALUES                 |
| ----------------------- | ----------------------- | ----------------------------- | ---------------------- |
|                         |                         |                               | Seats flight A11 = 100 |
|                         |                         |                               | Seats flight B22 = 50  |
| read(seats flight A11)  |                         |                               |                        |
| seats=seats-5           |                         |                               |                        |
| write(seats flight A11) |                         |                               | Seats Flight A11 = 95  |
|                         | read(seats Flight B22)  |                               |                        |
|                         | seats=seats+2           |                               |                        |
|                         | write(seats Flight B22) |                               | Seats Flight A22       |
|                         |                         | read(seats Flight A11)        |                        |
|                         |                         | read(seats Flight B22)        |                        |
|                         |                         | Total = seats A11 + seats B22 |                        |
|                         |                         | write(Total)                  | Total = 147            |

Solution making the different operations in the transactions interspersed and not having concurrency problems: 



| T1                      | T2                      | T3                            | VALUES                 |
| ----------------------- | ----------------------- | ----------------------------- | ---------------------- |
|                         |                         |                               | Seats flight A11 = 100 |
|                         |                         |                               | Seats flight B22 = 50  |
| read(seats flight A11)  |                         |                               |                        |
| seats=seats-5           | read(seats Flight B22)  |                               |                        |
| write(seats flight A11) | seats=seats+2           |                               | Seats Flight A11 = 95  |
|                         |                         | read(seats Flight A11)        |                        |
|                         | write(seats Flight B22) |                               | Seats Flight A22 = 52  |
|                         |                         | read(seats Flight B22)        |                        |
|                         |                         | Total = seats A11 + seats B22 |                        |
|                         |                         | write(Total)                  | Total = 147            |



In the moment the data is returned to the database updated by the T1 and T2 transactions, the two variables gets released and T3 can read its values. 

Taking into account that incrementing or decrementing values (E.g seats=seats-5) is an operation done internally in the device and not affecting the database, can be done at the same time when other Transaction is making a read() (`SELECT FROM <table>`) or write (`UPDATE <table>`) operation. [[SQL - MAIN COMMANDS]]


