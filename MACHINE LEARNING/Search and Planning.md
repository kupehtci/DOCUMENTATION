#ML 

Search and planning is the approach of Practical reasoning: 
* deliberation: decide the goal state we want to achieve
* means-end-reasoning: decide how to achieve this state.. 
* intentions: the output of the deliberation and states and actions that can be performed. 

This practical reasoning can be applied to Machine learning and intelligent systems by **Search and planning** algorithms. 
##### PROBLEM SOLVING

objetive: solve the problem automatically, arrive to the goal. 
You need: problem representation and define an strategy (algorithm) to get the goal. 

* `initial state`: 
* Set of possible `actions`. 
	* Successor function: state --> set of \<action, state\>
	* Successor function + initial state = state space. 
* `goal`: goal state or goal test function
* `path cost`: allows optimization, and its the sum of step costs. 


Imagine the following scenario:

* initial state:  3 missionaries and 3 cannibals and a boat are on the left bank of a river. 
* actions: 
	* one missionary crossing
	* one cannibal crossing
	* two missionaries crossing
	* two cannibals crossing
	* one missionary and one cannibal crossing
* goal state: all missionaries and cannibals and the boat are on the right side of the bank. 
* path cost: step cost: 1 for each action (number of crossings = length of path)

![[missionaries and cannibals_search and planning.png]]
* 4 optimal solutions with 11 path cost.


### Search Trees

A <span style="color:MediumSlateBlue;">search tree</span> is a tree structure used for traversing easily to locate certain keys within a set. 

In case of search and planning, its composed of certain parts: 
* `search nodes`: nodes within the search tree. Composed of: 
	* state: state space
	* parent node: immediate predecessor
	* action: action that performed in the parent leads into this node
	* path cost: total path cost to reach this node
	* depth: depth of this node in the search tree. 
* `fringe nodes`: nodes that have not been expanded. (Leaf nodes)
* `search or control strategy`: an affective method for scheduling the application of successor function to expand nodes. 
	1. Selects the next node to be expanded from the fringe
	2. Determines the order in which nodes are expanded
	3. the aim: produce a goal state as quickly as possible

### Search

Two types of search: 
* `uninformed search` (blind search): 
	* no additional information about states beyond problem definition 
	* Only goal states and non-goal states can be distinguish
* `informed search` (heuristic search): 
	* additional information about how "promising" a state is available. This can be achieved because the programmer has some knowledge about the problem that is asking the agent and can set a sort of <span style="color:MediumSlateBlue;">heuristics</span> to the algorithm. 


`iterative deepening search` - blind search

Based in depth-limited (depth-first) search. 
Repeat the search with gradually increasing depth limit until a goal state is found.
Prioritize the depth


Repeated states are unavoidable, resulting in infinite search trees. Try to avoid repeating states in the tree. 

`combinatorial explosion` - heuristic search

Using a heuristic function, solve the efficiency of brute-force algorithms. 
* Leads the algorithm toward a goal state
* Pruning off branches that don't lead into an optimal solution. 
* Its relatively accurate estimator of the cost to reach a goal
* Relatively cheap to compute.

### Pure heuristic search (BFS)

The simples algorithm that the heuristic function can use is: 

$f(n) = h(n)$ $-->$ $cost\ function = heuristic\ function$

And this algorithm is called **Pure heuristic search (PHS)** or **Best-First Search(BFS)**. 
PHS will generate the entire graph finding a goal node if one exists. 

Its used to evaluate the shortest path where the goal can be. 


``

