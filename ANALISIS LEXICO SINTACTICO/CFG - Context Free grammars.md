#CONCEPTS 

Context free grammars can be classified on two groups: 

* Non-recursive: if a grammar generates a finite number of strings
* Recursive: if one of the production rules can be replaced with itself, we have a loop that result in a infinite number of strings. Example: 
```txt
S->SaS    
S->b
language(S) = {bab, babaa, ...} is infinite so is recursive
```

Depending on the result: 

* Ambiguous: if there are more than one left most derivation tree or right most derivation tree or parser tree. 
* Unambiguous: if there is only one derivation tree. 


Basing on the type of resursion:

nature of the recursion in a recursive grammar, a recursive CFG can be again divided into the following:

- Left Recursive Grammar (having left Recursion)
- Right Recursive Grammar (having right Recursion)