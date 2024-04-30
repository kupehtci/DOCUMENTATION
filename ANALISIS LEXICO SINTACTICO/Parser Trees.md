#CONCEPTS 

## PARSER TREES

A <span style="color:MediumSlateBlue;">parser tree</span> is a graphical representation of a derivation of a grammar [^1]. 

In order to write a parser tree: 
1. the root of the axiom is the begin $S$ of the grammar. 
2. The leafs of the tree are the terminal tokens or `ε`

#### FIRST 

<span style="color:orange;">First of a production rule</span> is the set of **first** terminal element that can be formed by using that production rule. 

Only contains <span style="color:LightSeaGreen;">terminal tokens</span>.

Having the following grammar $G$: 

```txt
G = ({S, B, C} ; {a, b, c, d, e}; S, P); 
P = {
	S --> aSe
	S --> B
	B --> bBe
	B --> C 
	C --> cCe
	C --> d
}
The firsts of each production rule would be: 

FIRST(S) = {a, b, c, d}
FIRST(B) = {b, c, d}
FIRST(C) = {c, d}
```

Take into account that `ε` is also considered a terminal token, so if a production rule contains it as first terminal elements, this empty token would also be included within the FIRST set: 

```txt
G = ({S, B} ; {a, b, c, d, e}; S, P); 
P = {
	S --> aSe
	S --> B
	B --> b|e|ε

}
The firsts of each production rule would be: 

FIRST(S) = {a, b, e, ε}
FIRST(B) = {a, b, e, ε}
```

Rules to build the FIRST: 

1. If exists a production rule `X --> a` being `a` a terminal token, this imply that FIRST(x) = { a }
2. If exists a production rule `X --> ε`, imply that FIRST(x) = ε
3. If `X --> Y` we search `Y` production rule and follow step 1 or 2. 
4. If a rule `X --> Ya` and `Y --> ε` with `Y` a production rule and `a` a terminal token, FIRST(x) = {a, ε}, including the empty or void token . 
5.  If a rule `X --> Ya` and `Y --> ε | b ` with `Y` a production rule and `a` a terminal token, `FIRST(x) = {a, b}`, with `ε`  included following the rule 4. 

You can take a look into some examples in [[FIRST AND FOLLOW EXAMPLES]]. 

### FOLLOW 

Follow is the following terminal characters of a production rule. 
Follow cannot be an empty symbol (ε), if followed by this terminal symbol, we need to take a look into parent rule of the FOLLOW evaluated rule. 

Rules to build a FOLLOW: 

1. If A is an axiom, FOLLOW(A) = { $ }
2. If `Xy` FOLLOW(X) = { y }
3. When no terminal symbols follow a non-terminal symbol `X --> T` imply that FOLLOW(T) = FOLLOW(X) 
4. If B --> xA where $ε\in FIRST(B)$ so FOLLOW(A) = FIRST(B) + FOLLOW(B)
5. If `A --> Bh` and  `B --> TE` imply that FOLLOW(E) = FOLLOW(B) because one non-terminal symbol imply the other. 
6. If `X --> ABC` and `C --> 0 | 1` imply that FOLLOW(B) = FIRST(C) if C doesn't contain empty (ε). 
7. If $ε\in FIRST(C)$ imply that B cannot have something at its back, so FOLLOW(B) = FIRST(C) + FOLLOW(X). Meaning that need take a look into previous rule in the hierarchy. 

You can take a look into some examples in [[FIRST AND FOLLOW EXAMPLES]]. 

---
[^1]:  Reference to grammars [[GRAMMARS - Introduction]] 