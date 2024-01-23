#ML 

The point of <span style="color:SlateBlue;">fuzzy logic</span> is to map an input space classified into <span style="color:orange;">fuzzy sets</span> to an output space and the mechanism for doing that is a list of <span style="color:orange;">if-then statements</span> called rules.

### FUZZY SET 

Is a set without a crisp, that contains elements with a partial membership. 
Reasoning in fuzzy logic don't consist only in boolean values, a membership can also be defined as a value between \[0, 1\]. 

Imagine defining the days of the week like this: 

| Q: Is Saturday a weekend day? |
| ---- |
| A: 1 (yes, or true) |
| Q: Is Tuesday a weekend day? |
| A: 0 (no, or false) |
| Q: Is Friday a weekend day? |
| A: 0.8 (for the most part yes, but not completely) |
| Q: Is Sunday a weekend day? |
| A: 0.95 (yes, but not quite as much as Saturday). |
The left side is a chart of how it will be with two-valued and the right one with fuzzy logic set multivalue. 

![[fuzzy_logic_multivalues.png|500]]

### MEMBERSHIP FUNCTION (MF)

A <span style="color:SlateBlue;">Membership function</span> is a function that defined how each point in the input space is mapped to a membership value between 0 to 1. 

For example, if considering a fuzzy set with a set of tall people we can define that you need to be more than 1.80 metres to be considered as tall, so the function will look like this: 

![[../IMAGES/tall_people_membershgip_functions.png|400]]

The most common Membership functions are built from sevaral basic functions: 

* Piecewise linear functions
* Gaussian distrubution function
* Sigmoid curve
* Quadratic and cubic polynomial curves

`STRAIGHT LINES FUNCTIONS`

* `trimf` — Triangular membership function
* `trapmf` — Trapezoidal membership function
* `linzmf` — Linear z-shaped membership function open to the left (since R2022a)
* `linsmf` — Linear s-shaped membership function open to the right (since R2022a)

![[../IMAGES/linear_memberships.png]]

`GAUSSIAN DISTRIBUTION FUNCTIONS`

* `gaussmf` - simple gausian curve
* `gauss2mf` - two sided composite of gaussian curve
* `gbellmf` - similar smooth transition between 0 and 1 but has a third parameter that can be use to modify the steepness of the curve. 

![[../IMAGES/gaussian_curve_membership.png|500]]

`SIGMOIDS`

Similar in terms of smoothness to gaussian curves but asymmetric. 

* `sigmf` - basic sigmoidal, can be opened from right or left
* `dsigmf` - difference of two asymmetrical sigmoidal function
* `psigmf` - product of two different sigmoidal functions

![[../../CONCEPTS/IMAGES/sigmoid_membership_functions.png]]

`POLYNOMICAL BASE`

- `zmf` - Z-shaped membership function open to the left. 
- `smf` - S-shaped membership function open to the right. 
- `pimf` - Pi-shaped membership function, which is the product of an s-shaped and z-shaped membership function. 


![[zmf-pimf-smf-membership-functions.png|400]]

![[../IMAGES/membership_functions.png]]
[Foundations of fuzzy logic](https://in.mathworks.com/help/fuzzy/foundations-of-fuzzy-logic.html)

Can be defined using code in python in library skfuzzy [[Fuzzy Logic - skfuzzy]]. 
#### How to choose membership functions?

Gaussian functions are mostly used due to its natural form relative to the world. 
