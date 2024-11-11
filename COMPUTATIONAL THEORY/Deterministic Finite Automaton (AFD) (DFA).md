Finite Automaton can be classified into two types: 

> - Deterministic Finite Automaton (DFA)
> - Non-deterministic Finite Automaton (NDFA / NFA)

## Deterministic Finite Automaton (DFA)

In DFA, for each input symbol, one can determine the state to which the machine will move. Hence, it is called **Deterministic Automaton**. As it has a finite number of states, the machine is called **Deterministic Finite Machine** or **Deterministic Finite Automaton.**

## Formal Definition of a DFA

A DFA can be represented by a 5-tuple (Q, ∑, δ, q0, F) where −

- **Q** is a finite set of states.
    
- **∑** is a finite set of symbols called the alphabet.
	* Σ3= {x | x es un símbolo de la tabla ASCII}.      \[Intensional format\]
	 * Σ4= {1,A,2,3}   \[extensional format\]
	
- **δ** is the transition function where δ: Q × ∑ → Q 
    
- **q0** is the initial state from where any input is processed (q0 ∈ Q).
    
- **F** is a set of final state/states of Q (F ⊆ Q).


## Graphical Representation of a DFA

A DFA is represented by digraphs called **state diagram** or <span style="color: red; font-weight: bold; ">Moore Diagram</span>

- The vertices represent the states.
- The arcs labeled with an input alphabet show the transitions.
- The initial state is denoted by an empty single incoming arc.
- The final state is indicated by double circles.

Also a DFA can be represented with a<span style="color:red;"> transition table</span>, that represente via a table ,  same rows as states and each column as symbols in the language and in each cell represents the transition for each state to another state depending on the symbol. 
An example of a _**transition table**_ : 

|STATE|0|1|
|---|---|---|
| Q0| Q2 | Q1 |
|Q1 | Q0 | Q1 |
| Q2 | Q1 | Q1|

### Example

Let a deterministic finite automaton be →

- Q = {a, b, c},
- ∑ = {0, 1},
- q0 = {a},
- F = {c}, and

Transition function δ as shown by the following table −

|Present State|Next State for Input 0|Next State for Input 1|
|---|---|---|
|**a**|a|b|
|**b**|c|a|
|**c**|b|c|

Its graphical representation would be as follows −

![DFA Graphical Representation](https://www.tutorialspoint.com/automata_theory/images/dfa_graphical_representation.jpg)