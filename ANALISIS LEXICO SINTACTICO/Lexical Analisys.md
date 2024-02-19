#CONCEPTS 


### Lexical Analisys


The lexical analysis is done by an Scanner and a Tokenizer: 

* The scanner goes sequentially through the input until recognizes a <span style="color:LightSeaGreen;">token</span> (Lexical indivisible unit). 

Example: 
* *Input*: x3 = y + 3
* *Output*: id(x3), = , id(y), +, num(3)

![[example-translation-scanner-and-tokenizer.png|400]]


In the compilation process, some modules works together in order to build the <span style="color:LightSeaGreen;">tokens</span>. 


The steps in this process are directed by the parser or syntactic analyzer: 

* When the parser need a new token, it make a request to the lexer[[Lexer]]
* The Scanner takes as much characters as needed to build a token. 
* When the token is built, Scanner stops and send the token. 
* Then keeps reading until all tokens are built. 