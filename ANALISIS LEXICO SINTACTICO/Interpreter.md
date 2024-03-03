
### INTERPRETERS

Interpreter is a program that reads a source code written in high level language, executed it parcially and directly generate the results of the execution of this code without generating the equivalent low-level code like the compiler [[./Compiler]]

The interpreter made a translation of parts when needed and its down to intermediate code. 

Examples of interpreted code are: 

* UNIX Shell languages
* BASIC, Python
* LISP, PERL
* PHP, Javascript
* PostScript


#### COMPILER vs INTERPRETER

|                    | Compiler                                          | Interpreter              |
| ------------------ | ------------------------------------------------- | ------------------------ |
| How x+2 is treated | Generates a low level program that calculates x+2 | Calculates x+2           |
| When do it happen  | Before execution                                  | During execution         |
| What is compiled   | Development of the program                        | Execution of the program |
| Decisions taken in | Compilation time                                  | Execution time           |
 
In terms of <span style="color:orange;">performance</span>, native programs that are compiled, are executed faster than interpreted languages. 
On the other hand, compiled programs are harder to understand at first sight once they are compiled (<span style="color:orange;">secretism</span>). 

