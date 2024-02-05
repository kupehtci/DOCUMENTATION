#CONCEPTS 

## DERIVATION TREE

For all grammars of type 1, 2 and 3, are corresponded with a derivation tree also called as: 
* Syntactic tree
* Parse tree

Its a <span style="color:#ababf5;">ordered</span> and <span style="color:#ababf5;">labeled</span> tree that is constructed by: 

* Root denoted by the axiom of G --> G=($∑_T$ ,$∑_N$ , S,P)
* Ad direct derivation is denoted as a set of branches from a given node 
* When applying a rule, a left symbol is exchanged with u word in right side. For each symbol of u, a branch gets out of $N_T$ to that symbol. 


The <span style="color:#ababf5;">set of tree leafs</span> is composed of terminal nodes or ε and its the <span style="color:#ababf5;">sentence generated from the deviation</span>.
* <span style="color:#ababf5;">Sentencial form</span> String composed of terminal and non-terminal symbols. 
* <span style="color:#ababf5;">Sentence</span> string only containing the result of the derivation tree, a string formed only with terminal symbols. 

### Example of a derivation tree

Given the grammar G = ({a, b}, {A, S}, S, {S ::= aAS|a, A ::= SbA|SS|ba}): 

![[derivation-tree-example-1.png|200]]

This derivation tree can be generated for a possible output of the grammar. 
