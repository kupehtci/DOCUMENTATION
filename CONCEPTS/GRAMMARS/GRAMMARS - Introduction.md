#CONCEPTS 

### What is grammar? 

Grammar are syntactical rules for conversation in natural languages. 
This can be applied in the <span style="color:#ababf5;">theory of formal languages</span>. Noam Chomsky gave a mathematical model to represent and write computer languages. 


## Grammar mathematical model

Grammar can be defined as a 4-tuple G = (N, T, S, P) where: 

- **N** or $∑_N$ is a set of variables or non-terminal symbols.
- **T** or $∑_T$ is a set of Terminal symbols.
- **S** is a special variable called the Start symbol, S ∈ N
- **P** is <span style="color:orange;">Production rules</span> for Terminals and Non-terminals. A production rule has the form α → β, where α and β are strings on V_N_ ∪ ∑ and least one symbol of α belongs to VN.

The grammar needs to be defined by this tuple with the N, T and S starting symbol defined in the G and P defined externally with the production rule that define the language. 

An example is: 

G = ({S, X, Y, Z} ; {a, b, c}; S, P)
with P = { 
		S ⇒ aS | bcX 
		X ⇒ cX | aYZ 
		Y ⇒ ab 
		Z ⇒ c
	}



## Derivations from a Grammar

Strings need to be derived from a certain grammar using its production rules. 

If a grammar <span style="color:orange;">G</span> has a production rule <span style="color:orange;">a ::= b</span>, we can say that <span style="color:orange;">xay ::= xby</span> or that xay derived in xby or can be replaced with. 

If we consider the next grammar: 

G2 = ({S, A}, {a, b}, S, {S → aAb, aA → aaAb, A → ε } )

S ⇒ aAb using production S → aAb
⇒ aaAbb using production aA → aAb
⇒ aaaAbbb using production aA → aaAb
⇒ aaabbb using production A → ε