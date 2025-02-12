#CPP 

# CPP Compilation


C++ Code is compiled through a series of steps to transform the code into "machine-readable" code that can be executed. 
This compilation steps involve: 

1. Preprocessing: processor handle pre-processor directives like `#include`, `#define`and during this stage it: 
	* Header files are included
	* Macros are replaced and expanded
	* Conditional compilations are evaluated and code is included
	* Comments are removed from the files
2. Compilation: this preprocessed code is translated into assembly code for the target architecture and it includes: 
	* Syntax analysis
	* Semantic analysis
	* Intermediate code
	* Assembly code generation

3. Assembly: the code generated in assembly is converted into machine code through an assembler. 
	* This results in a `.o` or `.obj`file that is not yet executable until the library references are linked. 

4. Linking: the linker combines one or more object files and resolves references for external symbols and external libraries. 

