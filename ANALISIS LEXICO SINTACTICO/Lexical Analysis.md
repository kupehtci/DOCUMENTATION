#CONCEPTS 

### LEXICAL ANALYSIS

Its the first part of a compiler and its works by translating the input code using a Scanner and Tokenizer into a set of tokens with certain meaning. 

$Lexer = Scanner + Tokenizer$

The scanner reads sequentially the input characters until it recognizes a token.


![[example-translation-scanner-and-tokenizer.png|400]]


In the compilation process, some modules works together in order to build the <span style="color:LightSeaGreen;">tokens</span>. 

The steps in this process are directed by the parser or syntactic analyzer: 

* When the parser need a new token, it make a request to the lexer [[Lexer]]
* The Scanner takes as much characters as needed to build a token. 
* When the token is built, Scanner stops and send the token. 
* Then keeps reading until all tokens are built. 

All this process is done by the <a href="./Lexer.md">Lexer</a> [[Lexer]]. 




### Token, pattern and lexeme

This three concepts can look similar in lexical analysis but are not the same: 

* TOKEN, its the name or identifier associated to a set of strings that follows a declared pattern
* PATTERN, rule or expression that describe the set of string associated with a token
* LEXEME, input string that meets a certain pattern so is labeled with as a certain token. 

The most of **tokens** can be defined by using Regular Expressions [[Regular Expressions]] like are defined in [[JavaCC Basic Parser]]. 