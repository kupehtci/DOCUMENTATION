#CONCEPTS 

A grammar is in <span style="color:#ababf5;">Normal form of Chomsky</span> when the right parts have 2 symbols or less and if two symbols, they are non-terminal. 
So right part need to be: 
* 2 non-terminal symbols
* 1 terminal symbol

Example: 
$G_a = (\{a, b\}, \{S, N, A, B\}, S, P)$
P = {
	S::=λ|a|NN, 
	N::=AB , 
	A::=a , 
	B::=b
}

For transforming a grammar into a <span style="color:orange;">FNC</span>, just replace symbols before cleaning the grammar: 

![[grammar-no-fnc-to-fnc.png|500]]

Resulting into: 

G = ({a,b,c},{A,B,C,D,E,F,G,H},A,P) 
P = { 
	A::=DE|AG|FA|a
	B::=BD|FH|a 
	C::=c|CF  
	D::=a  
	E::=BF
	F::=b  
	G::=BC  
	H::=AD
	}