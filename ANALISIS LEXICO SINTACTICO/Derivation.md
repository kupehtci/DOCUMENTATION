#CONCEPTS 

## Derivation

A derivation of a string for a grammar[^1] is a set of application of it production rules in order to transform the start symbol (Axiom) into the string. 

This derivation proves that the string belongs to the grammar language. [^2]

There are two main types of derivations: 

* left-most derivation: in each iteration, apply a production rule to replace the **non-terminal** at the left. 
* right-most derivation: in each iteration, apply a production rule to replace the **non-terminal** at the right. 

### Example

Consider the following grammar: 

```txt
S → S + S
S → 1
S → a
```

and the following string: 

```1 + 1 + a```

You can start the derivation as left-most: 
```
1. S
2. S + S
3. S + S + S
4. 1 + S + S
5. 1 + 1 + S
6. 1 + 1 + a
```



[^1]: Grammar [[GRAMMARS - Introduction]]
[^2]: A string or set of symbols belongs to a grammar if exists a derivation (unambiguous) or more derivations (ambiguous) using the grammar production rules that creates that string. 