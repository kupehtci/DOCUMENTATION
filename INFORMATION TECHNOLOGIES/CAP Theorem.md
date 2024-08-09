#CONCEPTS #DATABASES #INFORMATION_TECHNOLOGIES

## CAP THEOREM

CAP stand for Consistency, Availability and partition tolerance (Shard tolerance)

This theorem says that a database can only guarantee two of this aspects. 

* <span style="color:#795fad;">Consistency</span>: All clients see the same data at the same time
* <span style="color:#795fad;">Availability</span>: System continues to operate even in in the presence of node failures
* <span style="color:#795fad;">Partition-Tolerance</span>: The system continues to operate despite of network failures

![[cap_theorem_distribution.png]]

##### CONSISTENCY

The same data needs to be populated and retrieved between all nodes at any point and any time. 

When write, needs to be placed in all the nodes and when querying, all nodes should return the same value. 

##### AVALIABILITY

Availability imply that each request gets a return at any time. 

##### PARTITION TOLERANCE (SHARD)

Partition tolerance refers to the potential of a node to respond if even there is a breakdown between the nodes within the system. 

### CAN ONLY MEET 2?

Only two of them can be meet by a technology, because of the nature of this properties. 

Example is that if for example we have a partition in nodes, we lose the consistency because when writing we are only going for a single node, while node 2 preserves the last values. 

### POSSIBLE COMBINATIONS

There are the following possible pairs of features: 

* CA - Highly consistent and available system. 

Ensure this and sacrifice partition tolerance in order to keep same data between all users, but if a network error occurs, the system will become unavailable or limited. 

<span style="color:orange;"><i>Example: control stock of shopping or banking.</i></span>

* CP - Highly consistent and Partition tolerance

You get a fresh read each time, but can result into some nodes may not be avaliable during partition sharding. 

<span style="color:orange;"><i>Example: a consistent key-value that synchronizes the data constantly, ensuring consistency but becomes unavaliable while the partition. An example can be a Healthcare system with patients records. The consistency and sharing are the priority</i></span>

* AP - Highly available system while during partition tolerance. 

The drawback is that data may not remain same between all the distributed nodes. 

<span style="color:orange;"><i>Example: a social media. Needs to be constantly available for the users and easily accessed through various nodes but the changes may not remain same between nodes its not as important.</i></span>