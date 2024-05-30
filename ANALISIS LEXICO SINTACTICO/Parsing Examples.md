#CONCEPTS 

### PARSING examples

Given the grammar: 

`S --> aABC`
`A --> b | c | ε`
`B --> x | y`
`C --> x`

Which of the following are accepted by the grammar: 

a) acy          (NO)
b) abxx        (SI)
c) babcx      (NO)
d) axx           (SI)

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

[[Parser Trees]]
