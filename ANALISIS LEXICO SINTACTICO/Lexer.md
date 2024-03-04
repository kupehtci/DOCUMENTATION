#CONCEPTS 
### Lexer


The lexer reads with an Scanner and convert characters into tokens in the Lexical Analysis phase of a compiler. 

It recognizes: 
* reserved keywords of the language 
* Special characters like '\=\=' or '\!\=' .
* Identifiers, integers ,real numbers ,floats , strings, etc
* Ignore blank spaces. 
* Recognized special directives like preprocessor directives `#include file.cpp` and macros `#define PI 3.1418` 

These patterns that the input need to meet to be recognized each part with a token needs to be defined usually by Regular Expressions [[Regular Expressions]]. 

### BEHAVIOUR

Parts of the Lexer: 

* `Token`: Name that groups a set of input that has a similar structure. 
* `Pattern`: Rule or expression that define the set of strings associated with a token. 
* `Lexeme`: input string that meets a pattern. 

Example: 

```CPP
x = x * (acc+123)
```

| Token       | Lexeme or value |
| ----------- | --------------- |
| Identifier  | x               |
| equal       | \=              |
| identifier  | x               |
| asterisc    | \*              |
| parenthesis | \(              |
| identifier  | acc             |
| plus        | \+              |
| integer     | 123             |
| parenthesis | \)              |
Another example: 


![[./IMAGES/lexer-example.png|350]]

Most of the tokens can be described with a Regular Expression [[Regular Expressions]]. 
### TOKENS DEFINITION

In order to define this tokens and the pattern needs the input to follow to be indetified each part as its correspondent token, we need to declare them using <span style="color:orange;">Regular Expressions</span>. [[Regular Expressions]]. 
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

Example: [[JavaCC Token definition]]. 

Also this Regular Expressions can be treated as Finite automatons. [[Deterministic Finite Automaton (AFD) (DFA)]], that define the certain states the input need to have to end in a certain end state or token recognized or even error if doesn't follow the pattern of the token. 

### IMPLEMENTATION OF A LEXICAL ANALYSIS

To implement the lexical analysis in a compiler, can be done in multiples ways. 

* Using a scanner generator as Lex, Flex ore JavaCC plugin [[JavaCC Basic Parser]]. This tokens can be defined in this programs as a high-level description similar to regular expressions. 
* Rough Programming in C or Java using E/S facilities of this languages. 
* Written in assembler and administer explicitly the input. 

### TOKEN PRIORIZATION 

When a certain pattern can be identified as more than one token, how the resultant token is determined?. 

Disambiguation rules: 

* Rule 1: Longest one
	From all tokens that can be assigned to the input, chose the one with the lexema more long. 
* Rule 2: Priorization rule
	If more than one token can be assigned, token selection is made by the declaration order (First declared is the first). 


### LOOKAHEAD RULE

Not always is posible to determine a token without looking if its ended. 

For example: 

With a JavaCC token declaration of: 

```Java
TOKENS:
{
	<NUMBER: (["0"-"9"])>
	| <LETTER: (["a"-"z", "A"-"Z", " "])>
	| <BLANK: (" ")*>
	| <IF: "if(" (<LETTER>)* ")">
}
```

If Scanner reads an "i", could be tokenized as a `<LETTER>` but if its followed by an "f, wouldn't be a letter token, would be a `<IF>`.  


