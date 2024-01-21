#ML 

Once the <span style="color:MediumSpringGreen;">knowledge</span> is represented, needs to be interpreted for giving a certain reasoning about it. 

People know things and perform reasoning automatically. 

<span style="color:MediumSpringGreen;">Knowledge Based Systems(KBS)</span> are systems that combine knowledge and reasoning. through declarative languages, that are closest to human languages. 



### Knowledge in an Expert System

<span style="color:orange;">Knowledge Engineering</span> through knowledge representation, defines the keystone of the power of an <span style="color:DarkSeaGreen;">Expert System(ER)</span>. 

The way that ER represents knowledge affect the development, efficiency, speed and system maintenance. 

Conventional programming: 

* $algorithms + Data structures = programs$

Knowledge-based Systems: 

* $Knowledge + Inference = ExpertSystem$

Expert system Structure is defined by: 
* `Facts Base`: Describes the specific problem
* `Rule Base`: Describing the reasoning mechanisms that solve problems
* `Inference Engine`: running rules and gets a chain of reasonin that resolves the problem

#### TYPES OF REASONING

* Deductive, progressive, forward chaining, led by facts
	* Evidences, findings data => conclusions. 
* Inductive, regressive, backward chaining, goal-directed
	* Conclusions => data findings, evidence
* Mixed or hybrid chain

<span style="color:MediumSlateBlue;">Forward Chaining:</span> working from the facts to a conclusion. Match data in working memory agains conditions and if someone fires, this produces more data. 
Example: 

<span style="color:#8ba1f0;">If corn is grown on poor soil, then it will get blackfly</span>
<span style="color:#8ba1f0;">If soil has not enough nitrogen, then it is poor soil</span>
So -> <span style="color:#8ba1f0;"> If soil has not enough nitrogen, corn will get blackfly</span>

<span style="color:MediumSlateBlue;">Backward chaining:</span> works from conclusion to the facts. 

<span style="color:#8ba1f0;">If corn is grown on poor soil, then it will get blackfly</span>
<span style="color:#8ba1f0;">If soil has not enough nitrogen, then it is poor soil</span>
So -> <span style="color:#8ba1f0;">If corn has blackfly, therefore it mush have been grown in poor soil, therefore the soil must be low in nitrogen</span>. 

#### INFERENCE ENGINE

The <span style="color:MediumSlateBlue;">inference engine</span> or control mechanism is a knowledge automatic reasoning form composed of two elements: 
+ `interpreted rules and inference mechanish`: reasoning mechanism that determined which rules KS can be applied to solve the problem and applies: 
+ `Control strategy` or `conflict resolution`strategy. 

Performs actions to solve the problem from an initial set of facts and eventually through an interaction with the user. 
The implementation can lead into deduction of **new facts**. 

Phases: 
1. `Detection` relevant tules getted from the KB, set of rules applicable to a particular situation (state) of the fact base array forming conflict.
2. `Select the rule`: Control strategy and select wich rule to apply to new facts. 
3. `Application`: aplicate the rule on an instantiation of variables are the modification of working memory. 
4. Repeat or stop if problem is solved. 
