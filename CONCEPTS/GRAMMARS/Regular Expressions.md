#CONCEPTS 

## REGULAR EXPRESSIONS

Given a certain <span style="color:#db7093;">alphabet ∑</span> any finite sequence of symbols that belongs to itself is considered as a <span style="color:orange;">chain or word</span>

The regular expressions are used to specify wich of this strings or words belong to that language. 

Consist of a set of cuantifiers applied to the alphabet symbols to determine how a single symbol affects the string or word. 

A <span style="color:#db7093;">Regular expression</span> can be defined as: 

* **ε** is a regular expression indicating that the language contains an empty string: **L(ε) = {ε}**
	* Empty string can also be denoted with λ ∈ $Σ^∗$
*  **φ** is a Regular Expression denoting an empty language. **(L (φ) = { })**
* **x** is a regular expression where **L(x) = {x}**
* If **X** is a Regular Expression denoting the language **L(X)** and **Y** is a Regular Expression denoting the language **L(Y)**, then
    
    - **X + Y** is a Regular Expression corresponding to the language **L(X) ∪ L(Y)** where **L(X+Y) = L(X) ∪ L(Y)**.
        
    - **X . Y** is a Regular Expression corresponding to the language **L(X) . L(Y)** where **L(X.Y) = L(X) . L(Y)**
        
    - **R*** is a Regular Expression corresponding to the language **L(R*)**where **L(R*) = (L(R))***

## Construct a regular expression 

As regular expressions is a set of symbols with quantifiers that define how the symbol is in the string or word, there are 3 types of quantifers symbols: 
* Simetric close "+"   ->.  Symbol appears >= 1
* Transitive close "*"  ->  Symbol appears >= 0
* Alternative "|"        ->.   Choose between left or right symbol. 