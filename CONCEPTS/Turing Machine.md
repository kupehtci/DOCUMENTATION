#CONCEPTS 

### TURING MACHINE

Is a <span style="color:#ababf5;">mathematical model of computation</span> based in an abstract machine that manipulates symbols on a strip according to a table of rules. 

Despite its simple behaviour, is capable of implement any kind of computer algorithm. 

The original machine strip could only contain 0, 1 or blank, so was known as a 3 symbols machine. 

### OVERVIEW

The machine has basic functions: 
* Read the value on the slot
* Edit the value of the slot to a new value
* Move the strip left or right
* Edit the adjacent slot. 

By using the <span style="color:orange;">state tables</span>, you associate each value with an action of the previous. 
For example you can define that a 0 value mean to move the strip to the left and place a new value of 1. 

![[TuringMachineDiagram.webp]]

### State of the machine

The Turing machine will continue reading values until a certain state acts as a ending point. 

Each symbol is translated to an action, an <span style="color:MediumSlateBlue;">action</span> is a set of instructions defined for each symbol that can be found in the strip. 

For each symbol, the machine: 
* Read the value
* Executes the write function
* Execute the movement function 
* Change into next state defined by current state. 

### State table

A program in a Turing machine is a set of instructions for reading the strip values. 
This instructions are known as <span style="color:orange;">instruction table</span> or <span style="color:orange;">state table</span>. 

In each state also needs to define an action for the empty symbol B (blank), also represented as □. 

| f | 0 | 1 | □ |
| ---- | ---- | ---- | ---- |
| State0 | (Next State, Symbol, Movement) | (Next State, Symbol, Movement) | ((Next State, Symbol, Movement) |
| State1 | (State0, 1, R) | (State1, 0, L) | (State0, 1, S) |

Also each movement is defined in the representation as {L: Left, R: Right, S: Stop}

### Mathematical Definition

A Turing machine is mathematically defined as a 7-tuple: MT=(Γ, Σ, B, Q, s, F, f)

Where: 

- –  Γ: Symbol alphabet of the strip
- –  Σ ⊂ Γ: Input alphabet 
- –  B ∈ Γ: Special symbol for a blank space (B ∉ Σ). Can be also represented as: □
- –  Q: A finite set of states
- –  s ∈ Q: Initial State
- –  F ⊆ Q: Set of end states or accept states
- –  f: function.  Q,Γ→Q,Γ,{I,D,P}(where l : left, R: right, S: Stop)
			(State, Symbol) → (State, Symbol, Movement)


The states tables is defined similar as a <span style="color:MediumSlateBlue;">transition table</span>: 

| f   | 0          | 1          | B          |
| --- | ---------- | ---------- | ---------- |
| q0  | (qF, 0, D) | (q1, 0, D) | (q0, 0, I) |
| q1  | (q0, 1, P) | (q1, 1, P) | (q0, 1, P) |
With each state representing a function with: 

> (next state, symbol to write in strip, strip movement)


### Implementation and usage

For a Turing Machine implementation, each state need to be defined and an action for each value that can be found in the strip need to be stablished in the state machine. 

Starting from the beginning of the strip, start reading the values of each strip place. 
For each one of this values: 
* Read the value
* Execute the <span style="color:#ababf5;">current action</span> defined by the <span style="color:orange;">State Table</span>
* Replace with the symbol stablished in the state
* Move the specified positions
* Change into next state defined in the executed state

### Types of Turing Machine

A Turing machine can act in two different ways: 

`TRANSDUCER`

Modifies the content of the strip performing certain actions
If strip input is correct, needs to end in a final state, otherwise don't. 

Example:
* Turing Machine for deleting 0s
* Turing Machine that duplicate the number of 1s

`RECOGNIZER

Its able to recognize a certain language and accept it. 

The Turing Machine <span style="color:#ababf5;">recognizes</span> a language $L$ if given an $w$ entry in the strip, the Turing Machine always stop and do that in an final state only if $w \in L$. 

The Turing machine <span style="color:#ababf5;">accepts</span> a language $L$ if given an $w$ entry in the strip, the Turing Machine stops in a final state 

### Turing Machines Equivalency 

Two Turing Machines are equivalent if both perform the <span style="color:#ababf5;">same actions</span> over ALL of its entries. 

* If both act as `transducer`, for each entry, the contents of the strip at the end need to be the same
* If both acs as `recognizer`, both need to accept and / or recognize the same words. 

### Turing Universal Machine (MTU or TUM)

Its a Turing Machine capable of <span style="color:#ababf5;">simulate the behavior</span> of every Turing Machine. 

A Turing Universal Machine contains in the strip: 

* The <span style="color:orange ;">description</span> of another Turing Machine
* The <span style="color:orange;">strip content</span> of this other Turing Machine

And its execution produces the same result as the other Turing Machine over the strip. 

Its like reprogramming this machine using the strip input. 
