#CONCEPTS 

### What is grammar? 

Grammar are syntactical rules for conversation in natural languages. 
This can be applied in the <span style="color:#ababf5;">theory of formal languages</span>. Noam Chomsky gave a mathematical model to represent and write computer languages. 

The grammar is defined by a set of production rules with an axiom that can form a set of symbols that belong to its language. 

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

### Grammar analysis

A grammar can have different characteristics: 

* Maximum length of a grammar accepted word can be: 
	* `infinite` if some of the Production rules is recursive
	* `certain length` if no production rule is recursive and its length can be measured. 
	* `0` if the axiom can only be replaced with λ (S::=λ)
* Minimum length


## Derivations from a Grammar

Strings need to be derived[^1] from a certain grammar using its production rules. 

If a grammar <span style="color:orange;">G</span> has a production rule <span style="color:orange;">a ::= b</span>, we can say that <span style="color:orange;">xay ::= xby</span> or that xay derived in xby or can be replaced with. 

If we consider the next grammar: 

G2 = ({S, A}, {a, b}, S, {S → aAb, aA → aaAb, A → ε } )

S ⇒ aAb using production S → aAb
⇒ aaAbb using production aA → aAb
⇒ aaaAbbb using production aA → aaAb
⇒ aaabbb using production A → ε


[^1]: Derivation of a grammar [[Derivation]]