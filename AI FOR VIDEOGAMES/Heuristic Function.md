

### HEURISTIC FUNCTION

In search algorithms like <span style="color:MediumSlateBlue;">A*</span> we need a way to calculate or estimate best path for searching the target. 

The heuristic helps to estimate the remaining distance to target to follow the the most optimal path during the search. 


The <span style="color:yellow;">goal</span> is to find or approximate a better solution than a common algorithm without heuristic like Dijstra


#### ADMISIBLE HEURISTIC

Heuristic not always lead to a lower cost or are able to find the best path. 

When the heuristic function don't overestimate the truth or find the lowest cost search solution are called <span style="color:orange;">admisible heuristic</span>. 

#### HEURISTIC FUNCTION IN <span style="color:LightBlue;">A*</span>

A* pathfinding algorithm uses a heuristic to find the shortest path in a graph. Each node n has a cost f(n) which is calculated as $f(n) = g(n) + h(n)$.
* g(n) is the actual cost of the node from the beginning of the path. 
* h(n) is its heuristic cost to reach the goal. 

A* is admissible, meaning that it always finds the solution with optimal f(n).