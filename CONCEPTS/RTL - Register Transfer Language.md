#CONCEPTS 

Its a <span style="color:orange;">three-access code (TAC or 3AC)</span> language that is composed of maximum three operand sentences that are usually a combination of asignation  and binary operator. 

example: 
```RTL
	t1 := 0
L1: if t1 >= 10 goto L2
	t2 := t1 * t1
	t3 := t1 * 4
	goto L1
L2: ...
```

This language is based on <span style="color:coral;">virtual registers</span> instead of using the real registers to make it compatible with all kind of devices. This is meant because is primarily used as an intermediate language between Front End and Back End in a [[Compiler]]. 

Syntax is primary based on: 

> <op> <op_mode> <v_register1> <v_register2>

