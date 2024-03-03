#JAVA
### JavaCC

JavaCC is a parser generator for Java applications. 

A parser generator is a tool that reads a grammar specification and converts it to a Java program that can recognize matches to the grammar.


For defining the different parameters for the lexical analysis of the code, it need to identify the different tokens that conform the language: 

### Tokens definition

First we need to define the tokens using Regular Expressions [[Regular Expressions]] for the parser to be able to detect the expected strings or letters input to transform them as tokens. 

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


### Complex tokens

For reading this XML structure information:

```XML
<Alumno>
	<nombre>Daniel</nombre>
	<parcial1>9.55</parcial1>
</Alumno>
```

```Java
< NUMERO: (["0"-"9"])>
|< LETRAS: (["a"-"z", "A"-"Z", " "])
|< ABRIR_ALUMNO: ("<Alumno>") >
|< CERRAR_ALUMNO: ("</Alumno>")>
|< ABRIR_NOMBRE: ("<nombre>")>
|< CERRAR_NOMBRE: ("</nombre>")>
|< NOMBRE_ALUMNO: (<ABRIR_NOMBRE> (<LETRAS>)+ <CERRAR_NOMBRE>) //<nombre>Daniel</nombre>
|< PARCIAL1: ("<parcial1>" (<NUMERO>)* "," (<NUMERO>){2} "</parcial1>")> // <parcial1>9.55</parcial1>
```

In this case, we have some complex tokens definition: 
Example, for reading float definitions, we can declare the "," as a literal and `(<NUMBER>)* "," (<NUMBER>){2}`, for expecting 2 numbers after the comma. 

If want to read the token

```Java
LIGA 1 - JORNADA 4
```

Take into account the spaces in the text: 

```Java
TOKEN: 
{
	< NUMERO: (["0"-"9"])>
	| < LETRAS: (["a"-"z", "A"-"Z", " "])
	// LIGA 1 - JORNADA 38
	| < CABECERA: ("LIGA " (<NUMERO>){0, 2} " - JORNADA " (<NUMERO>)+)> 
}
```

### Token modifiers

* We can use `+` or `*` for defining 1 or more appearance or 0 or more like in Regular expressions [[Regular Expressions]]. 
* We can define the minimum and max appearance of a single token by using `(TOKEN){1, 4}` with minimum 1 and maximum 4 tokens. 
* `OPTIONAL` an optional token part can be defined using `?`. By using `(TOK)?` is the same as defining `(TOK){0,1}`. 
* `MORE THAN ONE OPTION` to have more than one predefined option for example domain extensions you can defined as: `EXTENSIONS: (".com" | ".es" | ".net")` or `EXTENSIONS: ([".com", ".es", ".net"])`


### Result


Once this is done, should be able to recognize the tokens in the input with a result of: 
```bash
<Alumno>
	<nombre>Daniel Laplana Gimeno</nombre>
	<parcial1>9,55</parcial1>
	<email>daniel@gmail.com</email>
</Alumno>Leido lexema: <Alumno> -->Token: "<Alumno>"

Leido lexema: <nombre>Daniel Laplana Gimeno</nombre> -->Token: <NOMBRE_ALUMNO>
Leido lexema: <parcial1>9,55</parcial1> -->Token: <PARCIAL1>
Leido lexema: <email>daniel@gmail.com</email> -->Token: <EMAIL>
```