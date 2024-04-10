
## DEFECT CAUSAL ANALYSIS 

Even a step before then reviews [^1] and refactoring the code [^2] , some actions can be done in order to <span style="color:MediumSlateBlue;">prevent</span> defects. 

This <span style="color:MediumSlateBlue;">prevention</span> are actions intended to minimize the number of defect that are injected into the code by developers. 


The most important steps in defect prevention are: 

* Identify the causes of defects 
* Take actions to prevent this causes by improving the process. 

### PROCESS

The process of this defect causal analysis and prevention can be splitted into different phases: 

| Phase                 | Description                                                                                                                                                                                                                             |
| --------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| DEFECT IDENTIFICATION | Defects are found by QA activities such as Design review, code inspection, function and unit testing                                                                                                                                    |
| DEFECT CLASSIFICATION | Defects are classified by requirements, design, logical and documentation. Also this categories can de divided into different levels depending of the complexity.                                                                       |
| DEFECT ANALYSIS       | Review and analyze the different defect using Root Cause Analysis (RCA) techniques                                                                                                                                                      |
| DEFECT PREVENTION     | With the causes of defects identified, determine the actions to cut down the causes. This can be done with a <span style="color:LightSeaGreen;">cause-and-effect</span> diagram and rate the solutions and agree among all team members |
| PROCESS IMPROVEMENT   | Put the <span style="color:MediumSlateBlue;">preventive actions</span> in place and verify their effectiveness                                                                                                                          |

As summary:

<span style="font-size: 0.9rem; 
	  padding: 0.3rem;
	   border: 1px solid black;
	   border-radius: 0.2rem;">
	Identify defects --> Classify defects --> Identify causes --> Determine actions ---> Execute actions
</span>

##### RCA -> Root Cause Analysis 

Is the process of finding the activity or process which causes the defects and find ways of eliminating or reduce effect. 

Analyze the defects in order to determine its origin. 

Having a collection of possible causes will be useful when doing the root cause analysis. 

##### PARETO CHART

One tool to find causes and rate them is grouping them in a <span style="color:MediumSlateBlue;">Pareto Chart</span> [^3], ordering in X-Axis the possible causes of defects from left to right in order of frequency or possibility and in the Y-Axis the number of occurrences in an acummulative form. (Each item occurence is its own occurence plus the left item). 

![[Pareto-Chart.png]]
This accumulative quantity is done in order to check the percentage of solved issues if we focus in the left problems. 

##### FISHBONE DIAGRAM

Once with the pareto chart we get the type of defects to focus in, we can understand how those type of defects happens by using a <span style="color:MediumSlateBlue;">FIshbone Diagram</span>. 

A <span style="color:MediumSlateBlue;">Fishbone Diagram</span> is a graphical representation that sorts and relate factors that contribute to a given situation. 

It details the factors and the involved elements that are involved in a defect. 

![[fishbone-diagram.jpg]]
##### 5 WHYS TECHNIQUE

Its a simple technique in order to understand the root cause of something (RCA), that works by asking at least 5 times, why the problem occurred and focusing in the answer of each of the why's question. 

![[5-Whys-Analysis.png|600]]



[^1]: [[SQ - Code Reviews]]
[^2]:  [[SQ - Refactoring]] Refactoring techniques and definitions
[^3]: [[Pareto diagram]] Definition of pareto diagram and use case. 



