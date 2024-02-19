#JAVA


### JavaCC

JavaCC is a parser generator for Java applications. 

A parser generator is a tool that reads a grammar specification and converts it to a Java program that can recognize matches to the grammar.


### USAGE


First we need to define the tokens using Regular Expressions for the parser to be able to detect the expected strings or letters input to transform them as tokens. 

This tokens need to be defined at the end of the document using this syntax language: 


```JAVA
TOKEN:  
{  
    < NUMERO: (["0"-"9"]) >  
|   < LETRAS: (["a"-"z"]) >  
|   < MAYUSCULAS: (["A"-"Z"]) >  
|   < MINOMBRE: ("Daniel") > {1} 
}
```

The different token declarations need to be separated with a $|$ operator.  