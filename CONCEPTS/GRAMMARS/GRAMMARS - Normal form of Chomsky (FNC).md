#CONCEPTS 

A grammar is in <span style="color:#ababf5;">Normal form of Chomsky</span> when the right parts have 2 symbols or less and if two symbols, they are non-terminal. 

So right part need to be: 
* 2 non-terminal symbols
* 1 terminal symbol
And left part only a non-terminal symbol. 

Example: 
$G_a = (\{a, b\}, \{S, N, A, B\}, S, P)$
P = {
	S::=λ|a|NN, 
	N::=AB , 
	A::=a , 
	B::=b
}

For transforming a grammar into a <span style="color:orange;">Normal form of Chomsky</span>, just replace symbols before cleaning the grammar [[GRAMMARS - Grammar cleaning]]: 

![[grammar-no-fnc-to-fnc.png|500]]

Resulting into: 

G = ($∑_T =${a,b,c}, $∑_N=${A,B,C,D,E,F,G,H},A,P) 
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