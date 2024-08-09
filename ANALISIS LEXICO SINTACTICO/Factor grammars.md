#CONCEPTS 

To factor a grammar you need to check the alternatives of productions (those separated by `|`) whether they have some common symbols in sequence. For example, whether they have a common prefix (that is, whether they start with the same symbol). Join together as many subsequent common symbols (common factors) as you can, and put the rest into parentheses. For example, look at the productions for `item`:

```
item --> NAME price | NAME quantity price
```

You can rewrite all alternatives one below the other to better see the common prefix:

```
item --> NAME price
item --> NAME quantity price
```


Factorization is done in order to remove recursivity in grammars. 

You can follow the next rules: 

```
Y --> Ya
Y --> b

Transform into: 

Y --> bY'
Y'--> aY'
Y'--> ε
```

And in order to apply it, we need to identify the pattern, identify the `a` and `b` symbols within the production rules and transform it by following the rule. 

Example: 

```
non-terminal = {+, *, (, ), id}
terminal     = {E, T, F}
E --> E+T
E --> T
T --> T*F
T --> F
F --> (E) | id

Factorization: 
E --> TE'
E'--> +TE'
E'--> ε
T --> FT'
T'--> *FT'
T'--> ε
F --> (E) | id
```

Also to avoid ambiguity : 

```txt
Y -> aB | aC

More clear as: 

Y -> aB
Y -> aC

Factorize into: 

Y -> aY'
Y'-> B
Y'-> C
```

