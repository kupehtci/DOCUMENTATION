#SoftwareQuality #CONCEPTS 

There are various metrics and different aspects that can be used to quantify and keep track of the project development and life over the time. 

Depending on the aspect evaluated: 
## INTRINSIC

#### Reliability

Reliability is the quality of a product of doing what is expected over the time. 
In this case, this are the metrics of <span style="color:fuchsia;">intrinsic</span> because don't take into account the customer. 
It can be measured as: 

* $R(n)$ = Probability of not failing during $n$ time
* $F(n) = 1 - R(n)$ Probability of failing during $n$ time. 

* $Error\ Rate = 1 / MTTF$
	* <span style="color:CornflowerBlue;">MTTF</span>: Mean time to failure is the average time that occurs between two failures in the system. 
	* <span style="color:CornflowerBlue;">ER</span>: Error rate is the average number of failures suffered by the system during a given amount of time. 

Systems modules can be in two different distributions: 

* Parallel: all the modules work in parallel and are not dependan between them. A fail means that all of the fail at the same time. 
* Serial: all the modules are dependan of another one. If one of them fails, all system fails. 


<span style="color:CornflowerBlue;">SERIAL</span>

If a system follows an exponential distribution of failure: 

$R(t) = 1 - F(t) = 1 - (1 - e^{-𝛌t}) = e^{-𝛌t}$ 
𝛌 :  constant rate error in failures per unit of measurement (fails per hour, per cicle, etc). 

In order to get the entire system failure probability is the multiplication of all module reliability: 

$RS(t)=ΠR_n(t) = R_1(t)*R_2(t) *\ ...\ *R_m(t)$

<span style="color:CornflowerBlue;">PARALLEL</span>

If a system follows an exponential distribution of failure, its reliability function follows a Weibull distribution: 

$R(t) = e^{-[(t/α)^β]}$             with $α$ = scale and $β$ = shape. 

The entire system failure probability is the probability of all nodes fail at the same time, so we need to multiply all node fail probabilities: 

$RS(t)= 1 - ΠF_n(t) = 1 - (F_1(t)*F_2(t) *\ ...\ *F_m(t))$

#### Defect density

The defect density is the relation of defect per the size of the software.

$Defect\ Density = \frac{Amount\ of\ Defects}{Software\ Size}$

* <span style="color:DodgerBlue;">Amount of defects</span>: different types of densities can be calculated depending on the type of defects: 
	* Total number of defects remaining in the product
	* Total number of defects reported by end-users
	* Total number of critical/major/minor defects
	* Total number of new defects
* <span style="color:MediumSlateBlue;">Software size</span>: a good way to measure the size of a software product is by counting the <span style="color:IndianRed;">lines of code (<i>LOC</i>)</span>: 
	* Executable Lines
	* Executable lines + Data definitions
	* Executable lines + Data definitions + Comments
	* Executable lines + Data definitions + Control Lines
	* Physical lunes in an input screen
	* Lines by logical delimiters


## CUSTOMER METRICS

#### Problems (PUM)

Defect density evaluated by bugs is not the best metric in this case because bugs are mistakes made by developers and uses can have problems not related with bugs like lack of clarity, documentation, etc. Also $LOC$ is not a good indication of size from a user point of view. 

A good equivalency is: 

$PUM = \frac{Amount\ of\ Defects}{Usage\ of\ product}$

* <span style="color:DodgerBlue;">Problems reported</span>: Everything that users believe is a problem, can be related with usability, documentation, duplicates, users errors, etc. 
* <span style="color:MediumSlateBlue;">Usage of the product</span>: We need to count the amount of users and how long has been using the product. This can be measured as <span style="color:IndianRed;">Users-Month of usage</span>. 

PUM is an indicator of <span style="color:LightSeaGreen;">Functionality</span> and <span style="color:SkyBlue;">Usability</span>. 


#### Customer Satisfaction

This type of metrics measure the level of satisfaction users have for a software product. 
They are calculated with user feedback. 

The 3 most important metrics are:
* <span style="color:DeepSkyBlue;">CSAT (Customer Satisfaction)</span>:  indication of user happiness.
* <span style="color:SkyBlue;">NP (Net Promoter Score)</span>: that is an indicator of User Loyalty, and it’s calculated asking users “How likely is it you would recommend us to a friend”. Remember that the target NPS depends a lot on the type of product and culture/country.
* <span style="color:DodgerBlue;">CES (Customer Effort Score)</span>: how easy is to use a product.

The CSAT and NP are indicators for functionality and CES of Usability. 

#### ACTIONABLE METRICS

The analysis of the end-product customers needs to be evaluated by separating by customers groups (Cohort Analysis). 

This metrics evaluate how a product works for a user. 

By defining an hypotesis, we can decide how to measure it. For example we can evaluate a user access and activity within a webpage with tools like Google Analytics. 



Actionable metrics helps to evaluate a product <span style="color:LightSeaGreen;">Functionality</span> and <span style="color:SkyBlue;">Usability</span>. 

## PROCESS METRICS

Process Metrics are the metrics that provide indications of the quality during the process. 
They are calculated during the development and are useful to take actions to improve the process. 

They are based in: 

* The number of defects detected
* When they are detected
* When they are fixed

This process metrics evaluates a product <span style="color:LightSeaGreen;">Functionality</span>. 

#### Defect Density after a phase

Calculate the defect density of the non-final product after a development cycle (iteration, sprint)
Keep tracking of this evolution over the development time. 

We can get a prediction by identifying the patterns over the time. 

![[./IMAGES/defect_density_over_time.png | 320]]
#### Defect Arrival Pattern

This evaluation keeps track of every day defects in a continuous or accumulative manner. 

Is a better metric to evaluate progress that DDAP because its not a discrete function and each iterations doesn't incorporate same LOC size as others or ER (Error Rate). 


#### Defect Removal Pattern

DRP is the delta between defects reported and defects fixed measured along the time. 

This can be evaluated by keeping track of the defects reported and the defects fixed and calculate a delta between the defects reported and defects fixed. 

![[DRP_measure.png]]

#### Defect Removal Effectiveness

DRE evaluates how a phase has been in relation of defect removal. 
Its a ratio of how many defects have been removed and how many defects can have been removed. 

$DRE = \frac{Defects\ removed}{Defects\ can\ be\ removed} * 100$

Defects can be omitted to be removed because lack of time, lack of critically, etc. 

## SOFTWARE METRICS

Software metrics are metrics based of software internals. 

They are more focused in <span style="color:fuchsia;">Efficiency</span>, <span style="color:LightSlateGrey;">Maintainability</span> and <span style="color:purple;">Portability</span>. 
#### Cyclomatic Complexity

The cyclomatic complexity is a measure that counts how difficult and time consuming is to test all program paths and decisions. 

1. Identify modules that has more difficulty to test or maintain. 
2. Quantify the number of linearly independent paths through the programs source code 
3. Quantify the minimal number of test cases to test all this paths. 

Complexity can be calculated as: 

$CYCO = EDGES - NODES + 2$

![[./IMAGES/cyclomatic_complexity_2.png]]

#### LCOM4

This metric is based on calculate what happens inside a module or class. 
This measure helps to identify modules that don't work as intended and misplace functionality. 

This LCOM measure quantify the measure of: 

* Strength of the relationships between methods and data of a class and the class purpose
* Strength of the relationship between class methods and data themselves. 

LCOM4 measures the number of <span style="color:CornflowerBlue;">connected components</span> within a class. 
It quantifies the number of connected groups of methods. The methods are grouped and counted


#### AFC and EFC coupling

Focuses on the relationships between modules. 

Coupling is the degree of interdependence between software modules. 
it increases if: 
* A has an attribute of type B 
* A calls an B instance
* A has a method that refer B
* A is a subclass of class B

A high or thigh coupling makes software difficult to maintain, test, reuse and understand. 

![[coupling_afc_efc.png]]

| Cohesion                                           | Coupling                                                                                            |
| -------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| Indication of relationship within the module       | Indication of relationship between modules                                                          |
| Shows module's relative functional strength        | Shows relative independence among the modules                                                       |
| Degree to which a module focuses in only one thing | Degree to wich a component is connected to others                                                   |
| We should maintain a high cohesion                 | We should maintain a low coupling                                                                   |
| Cohesion is data hiding                            | Coupling is maintaining private fields, private methods and non-public classes for loosing coupling |
| intra-module                                       | inter-module                                                                                        |

