#CONCEPTS 

### Lexer


The lexer builds and convert characters into tokens for a compiler in the Lexical Analysis step. 

It recognizes: 
* reserved keywords of the language 
* Special characters like '\=\=' or '\!\=' .
* Identifiers, integers ,real numbers ,floats , strings, etc
* Ignore blank spaces. 
* Recognized special directives like preprocessor directives `#include file.cpp` and macros `#define PI 3.1418` 

Also find code errors. 

### BEHAVIOUR

Parts of the Lexer: 

* `Token`: Name that groups a set of input that has a similar structure. 
* `Pattern`: Rule or expression that define the set of strings associated with a token. 
* `Lexeme`: input string that meets a pattern. 

Example: 

```CPP
x = x * (acc+123)
```

| Token | Lexeme or value |
| ---- | ---- |
| Identifier | x |
| equal | \= |
| identifier | x |
| asterisc | \* |
| parenthesis | \( |
| identifier | acc |
| plus | \+ |
| integer | 123 |
| parenthesis | \) |
Another example: 


![[./IMAGES/lexer-example.png|350]]

Most of the tokens can be described with a Regular Expression [[Regular Expressions]]: 

* character --> (a|b|c|...|z|A|B|...|Z) = \[a-zA-Z\]
* digit --> (0|1|2|3|4|5|6|7|8|9)=\[0-9\] 
* id --> char(char|digit)*  
* integer --> (+|-|ε)(0|(1|2|3|...|9)digit*) 
* decimal --> integer ‘.’ (digit)* 
* real --> (integer|decimal) ‘E’ (‘+’|’-’) (dígito)+ 
* complex --> ‘(‘ real ‘,’ real ‘)’

And the main modifiers of the regular expressions: 

- –  Los paréntesis () se usan para definir el ámbito y precedencia de los demás operadores
* Parenthesis $()$ used for define environment and procedence of the rest of the operators.  
* $r^*$ as a transitive close
- $r^+$ as a simetric close
* Alternative $( | )$ choose between the right or left symbols of $|$. 
* r? for defining optionality. 
* 

