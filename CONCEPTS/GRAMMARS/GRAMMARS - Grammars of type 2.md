#CONCEPTS 


The grammars of type 2 are the ones defined in this category by Chomsky classification. [[GRAMMARS - Chomsky classification]]
This type of grammars are used in language definitions in coding and the language compilation. 


They are free-context languages and are represented as $L(G_2)$
There are existing algorithms used for recognize if $L(G_2)$ is an empty (∅), finite or infinite

#### Check if empty

The language generated by G2 is empty? . 

Given a $G_2$ that $m = C(∑_N) + C(∑_T)$ the number of nodes, $L(G_2) != ∅$ if exists x sentence that can be generated with the derivation tree in wich all paths has a length <= m


#### Check if infinite

By constructing the graph with x, y, z being terminal symbols: 

* if exists a production rule with the form A ::= xBy and B ::= xAz that imply recursivity, the grammar G would be infinite. 

Can also be seen in the graph constructed: 

![[infinite-graph.png|250]]