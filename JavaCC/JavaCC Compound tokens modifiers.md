#JavaCC #JAVA


JavaCC when declaring tokens, this ones can be combined to form other patterns that belong to another token. 

This tokens inside another can also me modified using Regular Expression Modifiers [[Regular Expressions]], like `*` or `+`. 

For example in JavaCC: 

```Java
< NUMBER: (["0"-"9"]) >
| <COMPOUND_NUMBER: (<NUMBER>)*>     //Accept more than 1 number
| <TWO_NUMBER: (<NUMBER){2}>         //Accept only two numbers
```

Take into account that this last example `COMPOUND_NUMBER` and `TWO_NUMBER` won't work together because by the token priorization rules (Longest one or priorization rule), a numerical input won't be identified as `TWO_NUMBER` because compound number is declared first and is the longest one. Take a look into this rules in [[Lexer]]. 

