#CONCEPTS 

### Definition

A <span style="color:orange;">compiler</span> is a program that translates from a source code written in a high level language in an equivalent low level code, that can be executed directly by a device. 

They allow to code <span style="color:LightBlue;">independently from the machine</span>. Also generates correct code, that can be reviewed though a list of errors to spell-checking and other features. 

### Compiler phases

The compiler is composed of various phases or components and each one of them realizes a certain sub-tasks of the compilation. 

This decomposition <span style="color:orange;">reduces its complexity</span> and makes easy each tasks <span style="color:orange;">implementation</span>. 

The compiler can be divided in two parts <span style="color:LightBlue;">Front End</span> and <span style="color:LightBlue;">Back End</span>. 

```mermaid
flowchart TD
id4(Source Language)-->id1(Front End)-->id2(IR Intermediate Representation)-->id3(Back End)-->id5(Machine code)
```

Because is splitted into this two parts via the <span style="color:coral;">intermediate language</span>, can be interchanged in order to produce multiple compatibilities. 

Once the front end for Java and backend for Intel i7 has been built, it only need a new back-end to be able to compile in other CPU or even build a C compiler for each i7 only writing the Front End part. 

The steps a compiler does is: 
// TODO Change this with english diagram. 

![[compiler-phases-diagram.png|350]]

##### `FRONT END`

* `Lexical Analysis`:  An scanner recognized the input characters and recognizes and build tokens from it. This pattern that belong to a certain token are defined using Regular Expressions and translated into AFDs.[[Regular Expressions]],  [[Deterministic Finite Automaton (AFD) (DFA)]]. 

* `Syntax Analysis`: (Parser) Takes tokens from the lexical analysis and analyze them using grammars [[GRAMMARS - Introduction]]. Using this grammars, it construct a <span style="color:orange;">AST (Abstract Syntax Tree)</span> [[AST Abstract Syntax Tree]] that define the tokens traverse. In general, group tokens into phrases with meaning. 

* `Semantic Analysis`: This steps receives the <span style="color:orange;">AST</span> from the Syntax Analysis step, check on errors and complements the AST with certain add-ons generating a <span style="color:orange;">Anotted AST</span>. 
	* Declare names in a symbol table
	* Search names between its references to determine types
	* Assign types to expressions
	* Check types validity

 * `Intermediate code generation`: This step generates device independent assembler code that can process the sentences defined in the AST with notes. Generates a Three-access code (three operand sentence code) also called RTL or Register Transfer Language. This assembler language is free of device context like registers or certain operations. (Its based in virtual registers)

![[./IMAGES/lexic-and-syntax-analysis.png]]

##### `BACK END`

* `Optimization`: Optional phase that optimizes the thousands of assembler code generates in the previous step. 

* `Object Code Generation`: Translation of the assembler code model into target's architecture machine code of the device, using an appropriate instruction set, registers and memory allocations. 
  The object code or machine code resultant is not totally executable, because contains calls to OS functions and the <span style="color:orange;">linker</span> completes this call with libraries referenced.  

* `Machine Code`:  Its the lowest level language, capable of being directly understand by a machine. 


### COMPILERS JUST-IN-TIME

Compilers just-in-time are compilers in execution time or dynamic translation. 
Its like an hybrid of static compilation and interpretation and its purpose is to improve execution of certain programs. 


In systems that compile into <span style="color:orange;">bytecode</span> an interpreter is needed to make the program to work, translating this bytecode into executable code. 

<span style="color:LightBlue;">JIT compilers</span>, in certain parts of the code in bytecode that can be executed multiple times constantly, are cached. So when this code is called again, doesn't need to be translated again, and 

### PEEPHOLE OPTIMIZATION

Its an optimization technique executed over a small part of the set of instructions of the generated code. 

This technique works recognizing set of common instructions that can be replaced with shorter or more optimized ones.   

### SYMBOLS TABLE

Its a data structure used by the compilers where each identifier in the source code is linked with information about its declaration or format in the source code. 

This attributes are code-dependant but are like: 

* Name of identifier
* Type of identifier
* Memory address allocated if its a variable
* Maximum size of the array 
* etc

