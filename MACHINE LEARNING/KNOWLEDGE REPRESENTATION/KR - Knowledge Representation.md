#ML 

<span style="color:Indigo;">Knowledge Representation or reasoning</span> is the field of IA meant to represent information about the world in a <span style="color:orange;">format that a computer system can use</span> to solve complex tasks like for example having a dialog in natural language. 

KR with <span style="color:orange;">automated reasoning</span> can reason about knowledge, make inferences and assert new knowledge. 

Its used because **conventional procedural code** is not the best formalism for solving complex problems. 

KR representation uses <span style="color:orange;">psychology concepts</span> about how to solve human problems. 
Also incorporated findings from logic to automate kinds of reasoning, such as `application of rules` or the `relations of sets and subsets`. 

Knowledge representations formalisms: 
* Semantic nets
* Frames
* Rules
* Ontologies

Automated reasoning engines: 
* Inference engines
* Theorem provers
* Classifiers

### EXPRESSIVITY AND PRACTICALITY 

Its the main key trade-off when designing a <span style="color:orange;">KR formalism</span> (KR-F). 
The best KR-F for expressive power and compactness is <span style="color:SlateBlue;">First Order Logic (FOL)</span> but has 2 main drawbacks, ease of use and practicality of implementation. Also has IF-THEN rules with statements (quantification over infinite sets) that cause the system to never end if it attempted to verify them. 

### CLASSIFIER

Languages based on Frame model with automatic classification provide a layer of <span style="color:orange;">semantics</span> on top of the existing internet. 
This causes that searching via text string is possible to define logical queries and find webpages. that map those queries. 

The <span style="color:SlateBlue;">Resource Description Framerwork (RDF)</span> provides basic capabilities to define knowledge-based objects on internet with basic features as IAs relations and object properties. 

The <span style="color:SlateBlue;">Web Ontology Language(OWL)</span> adds additional semantics and integrated with automatic classification reasoners. 


### TYPES OF KNOWLEDGE REPRESENTATION

There are 2 types: 

* Formal: 
	* Production Rules
	* Logic
		* Fuzzy
		* Propositional
		* Predicate First Order, nth order
		* Temporal 
		* Multivalued
		* O-A-V o 0+ 
		* etc
* Informal 
	* Semantic Network
	* frames

### PRODUCTION RULES AND APPLICATION

The knowledge is applied to solve certain problems expressed in two vays: 

* `declaratively`: objects, properties and general relationships are specified and the system has to solve problems appliying <span style="color:#abab02;">general reasoning mechanisms</span>
* `procedural manner`: a process specified to solve the problems. 

Depending on the form, varies its naturally of representation or its ease to apply. 


#### PRODUCTION RULES

In the <span style="color:LightSteelBlue;">declarative paradigm</span>, production rules is the most popular form of knowledge. 

Its configuration allows to build systems in chich it if often easy to incorporate new information or modify existing creating or changing the rules individually. 

The representation is based on two elements: 

* `facts`: propositions or predicates. Piece of knowledge that show something about a domain element Static state associated with the object but not with the dynamic activities associated with the object. 
* `rules`: conditional formulas. Parts of knowledge that describe the dynamic actions of the objects. Its a logical statement that relates two or more objects and includes two parts. Each part, <span style="color:orange;">premise</span> and <span style="color:orange;">conclusion</span> is a logical expresion with one or more statement connected with logical operators and, or or not. 

Rules terminology: 
IF (condition) -> THEN (action / consequence)
<span style="color:#db7093;">IF</span> x is a cat <span style="color:#db7093;">then</span> x is a pet. 

Rules are defined in <span style="color:cyan;">Backus-Naum Form (BNF)</span> notation. 
Example of rules definition: 
<div style="border: 1px solid white; padding: 0.3rem;">
<p>IF something is a flight THEN it is also a trip</p>
<p>IF some perton participad in a trip booked by some company</p>
<p>THEN this person is an employee of this company</p>
<p>FACT the person X MrsX participated in a flight booked by company CompanyX</p>
<p>IF trips source and destination are close to each other</p>
<p>THEN the trip is by train</p>
</div>

Also can be denoted by mathematical notation: 

![[mathematical_kb_notation.png]]

Each rule is a **piece of knowledge** or unit of information within a knowledge: 

![[backus-naum-form-notation.png|450]]


#### FUZZY LOGIC

A form of knowledge representation suitable for notions that cannot be define precisely, but wich depend upon their contexts. 

The traditional representation could have a snail that has speed = 0 and dog with speed = 1, so slow is determined when speed is 0. 

Represented in fuzzy sets, can define a certain set of groups of animal with a speed range defined from slowest, slow, fast, fastest and speed goes from. \[0 - 1\]. 

![[Fuzzy logic sets representation.png]]

Example of fuzzy logic: 

> Change the speed of a heater fan based in room temperature and humidity
> A temperature control value can be defined in 4 fuzzy sets: Cold, Cool, Warm and Hot
> Humidity can be grouped in: Low, Medium and high. 

Using this, a fuzzy set can be defined: 

![[fuzzy_set_temp_humidity_example.png|200]]


![[benefits fuzzy logic.png]]


#### STEPS

1. "fuzzification" of the inputs
	* Resolve all sentences according to their degree of membership between 0 to 1
2.  Application of fuzzy operators
	* If there are multiple parties in the antecedent, fuzzy operator are applied and the antecedent is solved as a number between 0 and 1. 
3. Application of involvement
	* Consequent of a fuzzy rule assigns an entire fuzzy set to the output
4. Aggregation
	* Output of each rule is sum 
5. "defuzzification"
	* Outputs a number

![[fuzzy rule system dinner example.png]]

The output aggregation is like this: 
![[output_aggregation_fuzzy_logic.png]]

