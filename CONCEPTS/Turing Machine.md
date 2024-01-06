#CONCEPTS 

### TURING MACHINE

Is a mathematical model of computation based in an abstract machine that manipulates symbols on a strip according to a table of rules. 

Despite is a simple behaviour, is capable of implement any kind of computer algorithm. 


The original machine strip could only contain 0, 1 or blank, so was known as a 3 symbols machine. 

## OVERVIEW

The machine has basic functions: 
* Read the value on the slot
* Edit the value of the slot to a new value
* Move the strip left or right
* Edit the adjacent slot. 

By using the state tables, you associate each value with an action. For example you can define that a 0 value mean to move the strip to the left and place a new value of 1. 

![[TuringMachineDiagram.webp]]

### State of the machine

This turing machine will continue reading values until a certain state acts as a ending point. 
Each symbol is translated to an action, an <span style="color:MediumSpringGreen;">action</span> is a set of instructions defined for each symbol that can be found in the strip. 

For each symbol, the machine: 
* Read the value
* Executes the write function
* Execute the movement function 
* Change into next state. 

 Cuando se lee cada símbolo, la máquina ejecuta la instrucción de escritura, la instrucción de movimiento, y luego pasa al siguiente estado (que puede tener o no instrucciones similares para cada símbolo).

### Instruction table

A program in a Turing machine is a set of instructions for reading the strip values. 
This instructions are known as <span style="color:orange;">instruction table</span> or <span style="color:orange;">state table</span>. 

## MATHEMATICAL DEFINITION

A Turing machine is mathematically defined as a 7-tuple: MT=(Γ, Σ, B, Q, s, F, f)

Where: 

- –  Γ: Symbol alphabet of the strip
- –  Σ ⊂ Γ: Input alphabet 
- –  B ∈ Γ: Special symbol for a blank space (B ∉ Σ). Can be also represented as: □
- –  Q: A finite set of states
- –  s ∈ Q: Initial State
- –  F ⊆ Q: Set of end states or accept states
- –  f:función.  Q,Γ→Q,Γ,{I,D,P}(dondeI:izda,D:dchayP: parada)
			(Estado, Símbolo) → (Estado, Símbolo, Movimiento)


The states tables is defined as a <span style="color:MediumSpringGreen;">transition table</span>: 

| f | 0 | 1 | B |
| ---- | ---- | ---- | ---- |
| q0 | (qF, 0, D) | (q1, 0, D) | (q0, 0, I) |
| q1  | (q0, 1, P) | (q1, , P) | (q0, 1, P) |
With each state representing a function with: 

> (next state, symbol to write in strip, strip movement)


## IMPLEMENTATION


###