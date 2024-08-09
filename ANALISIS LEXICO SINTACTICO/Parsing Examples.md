#CONCEPTS 

### PARSING examples

Given the grammar, which of the following are accepted by the grammar: 
```
S --> aABC
A --> b | c | ε
B --> x | y
C --> x

a) acy          (NO)
b) abxx        (SI)
c) babcx      (NO)
d) axx           (SI)

```
Draw the parser tree: 

![[parser_tree_1.png|350]]

2. Given the following grammar: 

```
S --> abA | bC
A --> CBD
B --> cAb | ε
C --> d | S | ε
D --> ε
```

Build the first and follow tables related to that grammar: 

|     | FIRST | FIRST | FIRST | FIRST | FIRST |
| --- | ----- | ----- | ----- | ----- | ----- |
|     | a     | b     | c     | d     | ε     |
| S   | X     | X     |       |       |       |
| A   | X     | X     | X     | X     | X     |
| B   |       |       | X     |       | X     |
| C   | X     | X     |       | X     | X     |
| D   |       |       |       |       | X     |

|     | FOLLOW | FOLLOW | FOLLOW | FOLLOW | FOLLOW | FOLLOW |
| --- | ------ | ------ | ------ | ------ | ------ | ------ |
|     | a      | b      | c      | d      | ε      | $      |
| S   |        |        |        |        |        | X      |
| A   |        | X      |        |        |        | X      |
| B   |        | X      |        |        |        | X      |
| C   |        |        | X      |        |        | X      |
| D   |        |        |        |        |        |        |
|     |        |        |        |        |        |        |

in order to build the Follow, we need to look for a terminal symbol in the production rules, which non-terminal symbols are preceding the targeted terminal-symbol: 
This table means that: 

```
FIRST(S) = {a}
FIRST(A) = {a, b, c, d, ε}
FIRST(B) = {c, ε}

FOLLOW(B) = [Rule7]
```


---

Calculate the LL parsing table of the following grammar: 
```txt
1) E ::= TE’  
2) E’::= +TE’  
3) E’::= ε  
4) T ::= FT’
5) T’::= *FT’  
6) T’::= ε  
7) F ::= (E)  
8) F ::= id

FIRST(E)  = {(, id}
FIRST(E') = {+, ε}
FIRST(T)  = {(, id}
FIRST(T') = {*, ε}
FIRST(F)  = {(, id}

FOLLOW(E)  = {), $}
FOLLOW(E') = {), $}
FOLLOW(T)  = {+, ), $} = FIRST(E') - {ε} + FOLLOW(E') + FOLLOW(E)
FOLLOW(T') = {+, ), $} = FOLLOW(T)
FOLLOW(F)  = {*, +, ), $} = FIRST(T') + FOLLOW(T') + FOLLOW(T)
```

Parsing table: 

|     | +   | *   | (   | )   | id  | $   |
| --- | --- | --- | --- | --- | --- | --- |
| E   |     |     | 1   |     |     |     |
| E'  | 2   |     |     | 3   |     | 3   |
| T   |     |     | 4   |     | 4   |     |
| T'  | 6   | 5   |     | 6   |     | 6   |
| F   |     |     | 7   |     | 8   |     |


---

Given the following grammar, write the FIRST and FOLLOW of the production rules: 

```txt
S ::= A B 
A::=aAb | ε
B::=bBa | ε

FIRST(S) = {a, b, ε} 
FIRST(A)={a, ε} 
FIRST(B)={b, ε}

FOLLOW(S) = {$} 
FOLLOW(A) = {b,$} 
FOLLOW(B) = {a,$}
```

---

Calculate the FIRST() and  FOLLOW() of the following production rules: 
```txt 
S ::= aSe | B  
B ::= bBCf | C  
C ::= cCg | d | ε

FIRST(S) = {a, b, c, d, ε}
FIRST(B) = {b, c, d, ε}
FIRST(C) = {c, d, ε}

FOLLOW(S) = {e, $}
FOLLOW(B) = {c, d, f, e, $}
FOLLOW(C) = {c, d, e, f, g, $}

r1: if S is the axiom, add $ to FOLLOW(S). 

r3: In this case B and C are the last non-terminal symbols in the production rule. So in case X --> A imply that FOLLOW(A) += FOLLOW(X). 
In this case FOLLOW(B) += FOLLOW(S) and FOLLOW(C) += FOLLOW(B)
```

---

Calculate the FIRST() and FOLLOW() of the following production rules: 

```txt
S --> (A) | ε
A --> TE
E --> &TE | ε
T --> (A) | a | b | c

FIRST(S) = {(, ε}
FIRST(A) = {(, a, b, c}
FIRST(E) = {&, ε}
FIRST(T) = {(, a, b, c}

FOLLOW(S) = {$}
FOLLOW(A) = {)}
FOLLOW(E) = {)}
FOLLOW(T) = {), &} FOLLOW(T) = FIRST(E) and ε in FIRST(E) so also 
					FOLLOW(T) += FOLLOW(E) and FOLlOW(T) += FOLLOW(E)
```

---
[[First and Follow]]
