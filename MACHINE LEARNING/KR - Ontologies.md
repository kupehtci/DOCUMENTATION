#ML #DATA 

### ONTOLOGIES

An ontology is a formal explicit representation of <span style="color:cyan;">shared understanding</span> of the important concepts in some domain of interest. 

Ontologies are formal and can be readable by computers: 
* `highly informal`: natural language
* `rigorously formal` : terms with formal semantics and axioms

mature ontologies requires descriptions for users to be <span style="color:orange;">consistent with a set of axioms</span> limiting their use. 

Also requires an explicit definition of types of concepts and this use restrictions. 
* Accessibility. 
* Transparency.
* Consensual knowledge : accepted by a group of people

Are an <span style="color:cyan;">abstract model</span> of an existing domain of the world
* Commitment
	* make as few claims as possible about domain
	* give reusers freedom to specialize and instantiate as needed
* Sharing: 
	* among people with different needs and viewpoints due to their different contexts
	* <span style="color:cyan;">inter-operability</span> among systems by translating between modeling tools and languages

Are useful for: 

* re-usability
	* Use of standars
	* COnfigurable ontologies and libraries of ontologies
* reliability
	* Formal ontologies enable the use of consistency checking resulting in more reliable systems
* In toy domains, representation is not important but in complex ones, a more flexible representation is needed


### ONTOLOGICAL ENGINEERING

Consist of representing the abstract concepts that occur in many different domains: 
* Actions
* Time
* Physical Objects
* Belief

Certain aspects of the real world are difficult to capture in FOL, because all <span style="color:cyan;">generalizations</span> have exceptions. 
> Example: "Tomatoes are red" but also are green, yellow and orange. 

So the ability to handle exceptions and <span style="color:MediumSpringGreen;">uncertainty</span> is extremely important. 

Similar to <span style="color:cyan;">Knowledge engineering</span>

### ONTOLOGIES LEVELS OF ABSTRACTION

The general framework of concepts is called an upper ontology. 
* The general concepts at the top 
* The more specific concepts bellow them

![[ontologies-abstraction.png]]

All special-purporse ontology its connected into a more <span style="color:#ababf5;">general purpose</span> ontology. 

A <span style="color:#ababf5;">general purpose</span> ontology is one that should be applicable in any special-purpose domain. 


### ONTOLOGIES ELEMENTS

`Concepts`: 

Organized in taxonomies, linked by relations and conforms axioms

`Axioms`: 

Truly statements that helps to make assumptions or inferences from the data. 
Can be very general from "a fox is not a shift deceptive person" or "Firefox is not a person". 

`Categories`: 

Organization using groups of objects. 
Serve to make predictions about objects
* `perceptual input`: inferring the presence of certain objects. 
	* Example: for being a watermelon, its inferred that it would be. in the fruits group
* `perciever properties`: inferring category membership from its properties of the object
	* Example: for being a watermelon, it can be inferred that would be perfect for a fruit salad. 

`Interaction`:  

The interaction with the world takes place at individual objects level but much reasoning takes place at categories level. 

Example:
> A shopper might have the goal of buying a mouse, rather than a particular mouse such as a V470 Cordless Laser Mouse.

Items: 

* Concepts or classes: Represent an abstract generalization of objects.
* Relationships: define how two concepts or classes or even individuals are related each other.
* Attributes or properties: specify values or parameters of an individual or a class
* Axioms / constrains: Helps to make assumptions from the data or inferences.
### ONTOLOGY SPECTRUM


The term ontology has been used to describe models with different degrees of structure (Ontology Spectrum)

* Less structure: Taxonomies (Semio/Convera taxonomies, Yahoo hierarchy, biological taxonomy, UNSPSC), Database Schemas (many) and metadata schemes (ICML, ebXML, WSDL)

* More Structure: Thesauri (WordNet, CALL, DTIC), Conceptual Models (OO models, UML)

* Most Structure: Logical Theories (Ontolingua, TOVE, CYC, Semantic Web)

Have the next properties: 
* Ontologies are expressed in a logic-based language
* Makes a spectrum for making intelligent apps
* Developed by a teams of two types:
	* Domain experts: have the knowledge
	* Modeler (Ontologist): know how to formally model domains
