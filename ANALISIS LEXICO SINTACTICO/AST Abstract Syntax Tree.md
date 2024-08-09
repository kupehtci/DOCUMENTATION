#CONCEPTS 

### Abstract Syntax Tree or AST

Its a representation of the Syntax structure of a source code into a tree graph. 

This graph is built in the Syntax analysis phase of a compiler [[Compiler]] and works as an analysis tree for giving meaning to the tokens generated in the previous phase(Lexical Analysis). 

For example, this is the <span style="color:orange;">AST</span> for the following code once the tokens of the code are identified: 

```PYTHON
while b ≠ 0: 
	if a > b: 
		a := a − b
	else: 
		b := b − a
return a
```

![[AST1.png]]

#### Noted AST

Once the next phase in the compilation, Semantic Analysis, check that doesn't exists semantic errors and the compliments its construction and so on, it generates a new AST with annotations. 

This AST contains per each item: 

* Declare its names in symbol table
* Search another references to it
* Assign types to expression
* Check types validity in the context surrounding