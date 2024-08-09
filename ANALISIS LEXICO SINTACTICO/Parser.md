#CONCEPTS 

## PARSER

A parser interprets the tokens from a structured program following a Formal Grammar rules that define the syntax of the language. 

It detects the main syntax errors and check is syntactically correct. 

Receives the tokens and outputs an analysis tree [[AST Abstract Syntax Tree]]. 

### GRAMMARS

The grammars to define a Parser interpretation are the CFG or Context Free Grammar [[GRAMMARS - Introduction]] or also Type 2 of Chomsky hierarchy[^3].

### TYPES OF PARSERS

A <span style="color:MediumSlateBlue;">parser LL</span> is a Top-Down parser for a set of CFG [^4]. 
* L : Indicated read from left to right.
* L : Generates a <span style="color:IndianRed;">leftmost derivation</span>. 
* Top-Down parser try to find a leftmost derivation from an input. 

A <span style="color:fuchsia;">parser LR</span> is a Bottom-Up for a set of CFG[^5]. 
* L : Indicated read from left to right 
* R : Generates a <span style="color:IndianRed;">rightmost derivation</span>. 
* Bottom-Up parsers analyzes data relationships in order to infer the production rules. From node leafs to axiom. 

### Parser LL

Needs to meet two conditions to check is a grammar is LL: 

If X --> a1 | a2 | ... | an also for each m, n different, FIRST(an) ∩ FIRST (am) = ∅
	This means that a production rule that has more than 1 "sub-production rules", this production rules don't share any first terminal element

If A ∈ VNT and {𝜀} ∈ FIRST(A) so FIRST(A) ∩ FOLLOW(A) = ∅
	First and Follow must not share any terminal elements

---

[^3]: Take a look into chomsky grammar classification [[GRAMMARS - Chomsky classification]]
[^4]: Context Free Grammar [[CFG - Context Free grammars]]. 



