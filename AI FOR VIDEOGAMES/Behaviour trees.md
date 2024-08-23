#CONCEPTS 


A behaviour tree is a mathematical graph model that can define a plan execution in computer science, robotics and also in IA for Videogames. 

Unlike state machines, its more focused in the execution and success / fail of the actions instead of the transition. 

This transitions between nodes depending on the result of each of them is defined by a <span style="color:#ff7518;">set of special nodes (composite and decorators)</span>, and with them, the transitions can be easily defined: 

* `composite`: has *one or more children* and can pass success or failure to the parent determined by the success or failure of child nodes. 
* `decorator`: has *only one child* and transform the result received from the children node status. 
* `leaf`: has no children and represent an specific action. 

![[behaviour_tree_components.png]]

##### Types of composite nodes

`SEQUENCE`

Visit each child in order and when one success, continue with the next one until end or fail of one of them, failure that its propagated to the parent. 

Similar to an <span style="color:LightBlue;">AND gate</span>. 

Can have conditional decorator children that act as `if` statements


`SELECTOR`

Executes the children in order until one returns a success and don't process any further children. 

If all children fails, it will fail. 

Similar to an <span style="color:LightBlue;">OR gate</span>. 


`