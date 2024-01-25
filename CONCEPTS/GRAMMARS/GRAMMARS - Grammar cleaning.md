#CONCEPTS 

A grammar can be cleaned by transforming into a G equivalent with production rules in a formal free of imperfections: 

* Grammar cleaning
	* Unnecesary rules
		* A ::= B 
		* A ::= λ (Except if its the axiom)
	* Innacesible symbols
		* If U ::= x and $U ∈ ∑_N  != S$ so don't appear in any production rule right part.
	* Superflued (Superfluas) rules
		* This rules are not useful in word generation. Contains a non-terminal non-generative symbol. 


`Delete non-generative symbols`
	* Having an A that belongs to a grammar, if constructing a grammar L($G_A$) and its empty imply that A is a non-generative symbol

`Delete non-generative rules`


`Delete no-redenominations rules`

Example if having an empty not terminal only used in one rule:

S ::= aB | bbA | <span style="color:crimson;">R</span> 
A ::= ...
B ::= ....
<span style="color:crimson;">R</span> ::= aaA | baA

Can be replaced with 

S ::= aB | bbA | <span style="color:crimson;">aaA | baA</span>
A ::= ...
B ::= ....

