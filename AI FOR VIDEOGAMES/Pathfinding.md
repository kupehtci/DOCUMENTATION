
### Pathfinding

Pathfinding is the technique used in videogames and other areas to find the best path from a point A to a point B. 

Firstly we need to define a group of pieces to calculate the path and the best way to do this is to convert a 3D field into a 2D grid, in order to calculate the pathfinding algorithms calculating distances between two cells within the grid. 

This "celling" algorithms when use irregular or non-polygonal boundaries to fill close regions are known as <span style="color:#ff7518;">"flood-fill"</span> or  <span style="color:#ff7518;">"bushfire"</span> algorithms. 

In order to find the best path , the intention is to visit all nodes following a certain algorithm and to find the best nodes to reach the `target` the best way is to calculate the : 

* g cost: total cost from the initial node to the node evaluated
* heuristic cost: an absolute minimum <span style="color:orange;">estimated distance</span> cost to reach the target from the evaluated target [^1]. 

And using this cost and tending to minimize $f(n) = g(n) + h(n)$ to search the best path. 

## DIJKSTRA ALGORITHM




### A* ALGORITHM

The A* algorithm is a heuristic search algorithm that combines the advantages of both Dijkstra's algorithm and Greedy Best-First Search. It works by searching the graph or grid from the start node to the goal node, using a heuristic function to guide the search towards the goal node. The heuristic function provides an estimate of the remaining cost to the goal node, which allows the algorithm to explore the most promising paths first.

The A* algorithm uses three main variables to calculate the path from the start node to the goal node:

- `g(n)`: the cost of the path from the start node to node n.
- `h(n)`: the heuristic estimate of the remaining cost from node n to the goal node.
- `f(n)`: the total estimated cost of the path from the start node to the goal node that goes through node n.

The pseudocode of visiting the different nodes: 
```pseudocode
Current node is the start and add to not tested list

Loop while if the not tested list contains nodes and is not the end node
     Sort Untested nodes by global goal, so lowest is first
     Pop front all visted nodes and test if listNotTestedNodes not empty
     get the first listNotTestedNodes -> Front
     if listNotTestedNodes is empty then abort
     set current node as the first listNotTestedNodes
     set current node as visited
     loop current node links (neighbours)
         if neighbour is not visited push back to not tested nodes
         calculate the neighbours potential lowest parent distance
         If this node is a lower distance, use this node
             update the neighbour's heuristic
```
### Cost Calculation

There are two costs in A*,  the G cost and the H cost (Heuristic)

For calculating the cost of B node: 

![[./IMAGES/pathfinding-grid-cost-parent.png|250]]

For calculating costs in each node that is visited during the pathfinding algorithm: 

* Calculating `g` cost is: `P.g_cost = A.g_cost + D()`
* Calculating `h` cost is an heuristic chosen for calculating if the cells that is going to be visited, is going closer to the target than others. 


### HEURISTICS

There are different heuristics than can be used to calculate this $h(n)$ cost. 

##### TAXICAB

##### EUCLIDEAN DISTANCE

##### EUCLIDEAN SQUARED DISTANCE

##### DIAGONAL DISTANCE

##### CHEBYSHEV DISTANCE

##### MANHATTAN DISTANCE


---

[^1]: See how the heuristics in Pathfinding work and how they can be calculated in [[Heuristic Function]]. 
