#CONCEPTS 

### PARSING TABLE

A <span style="color:orange;">parsing table</span> is a table that given a grammar, indicates the rule that needs to be followed in order to get that terminal element (horizontal - columns) by the given non-terminal element (vertical - rows). 

The terminals that cannot be reached by the non-terminal symbol, will leave the cell as empty. 

This table sumarizes for each terminal object and non-terminal symbol, which production rule generates the terminal. 

The table has the following format: 

![[parser_table.png]]

Table is filled with FIRST values except if $ε \in FIRST$ so we will look for the FOLLOW and sign the production rule that imply the `ε` value. 