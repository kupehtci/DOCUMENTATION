#CONCEPTS 

### FIRST EXAMPLES

To calculate the FIRST(X) with X being a grammar with its production rules, we can follow three main rules: 

```txt
1. X --> t              :      FIRST(X) = {t}
2. X --> ε              :      FIRST(X) = {ε} 

3. X --> To             :      FIRST(X) = { a | b}  
   T --> a | b 
"o" cannot be a first symbol, because always T would be replaced with "a" or "b"
If T also impplied an empty symbol (ε), "o" could be a first symbol: 

4. X --> To             :      FIRST (X) = {a, b, ε, o}
   T --> a | b | ε      :      FIRST (T) = {a, b, ε}
```

Some examples: 

```txt
----------------------------------------------------------------------------
A more complex one: 
A --> Aa | BCD          :     FIRST(A) = {b, }
B --> b | ε             :     FIRST(B) = {b, ε}
C --> c | ε             :     FIRST(C) = {c , ε}
D --> d | Ce            :     FIRST(D) = {d, c, ε, e }
----------------------------------------------------------------------------
Also more complex: 
A --> Aa | BCD          :     FIRST(A) = {b, }
B --> Cb | ε            :     FIRST(B) = {b, ε}
C --> AcA | ε           :     FIRST(C) = {c , ε}
D --> Bd | Ce           :     FIRST(D) = {d, b, e, ε}     
```

Take into account that a <span style="color:MediumSlateBlue;">loop</span> imply not first symbol following that path. 


### FOLLOW EXAMPLES

Rules: 

```txt
1. S --> aX             :      FOLLOW(S) = $    // Because S = Axiom
   P --> mO

2. S --> Xa             :      FOLLOW(X) = {a}
3. S --> TA
   A --> 1 | 0          :      FOLLOW(T) = FIRST(A) = {1, 0}

4. X --> Ah
   A --> TE             :      FOLLOW(E) = FOLLOW(X) = {h}
```

Take a look into the right part, and not first elements that belong to the production rules: 

```txt
E  --> TE'        :  FOLOW(E    = { ) ,$ }
E' --> +TE' | ε   :  FOLLOW(E') = { FOLLOW(E) } 
T  --> FT'        :  FOLLOW(T)  = { FIRST(E') = +, FOLLOW(E') = { ), $} }
T' --> *T'| ε     :  FOLLOW(T') = { FOLLOW(T) }
F --> (E) | i     :  FOLLOW(F)  = { FIRST(T') = { * }, FOLLOW(T) = {+, +, ), $} }
```