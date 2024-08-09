#CONCEPTS 

## Grammar LL

A <span style="color:DodgerBlue;">grammar LL</span> is a context-free grammar [^1] that can be parsed in a LL parser. 
This means that: 

* The input is read from left to right (L)
* The parser constructs a left-most derivation. 


```txt
S --> (if E)  S1
S --> s
S1 --> do S
S1 --> then S else S
```

---

[^1]: Context free grammar [[CFG - Context Free grammars]]