

### HEURISTIC FUNCTION

In search algorithms like <span style="color:MediumSlateBlue;">A*</span> we need a way to calculate or estimate best path for searching the target in order to improve the algorithm performance.

The heuristic helps to estimate the remaining distance to target to follow the the most optimal path during the search. 

The <span style="color:LightSeaGreen;">goal</span> is to find or approximate a better solution than a common algorithm without heuristic like Dijkstra. 

### WHY USE HEURISTICS? 

The primary drawback of not using heuristics is that the algorithm will search the entire graph or search space, which can become computationally expensive and slow for larger maps or grids. 

Without a <span style="color:#FF7518;">heuristic</span>, the algorithm must consider every possible node in the search space, even those that are unlikely to lead to the goal. This can make the algorithm take longer and consume more resources than necessary, ultimately reducing the overall efficiency of the pathfinding system.

By using a heuristic, such as the Manhattan or Euclidean distance, the algorithm can intelligently focus its search on nodes that are more likely to lead to the goal, effectively reducing the search space and improving the efficiency of the algorithm. This can result in faster processing times and improved performance, making pathfinding more practical and effective for use in real-time games and applications.


#### ADMISIBLE HEURISTIC

Heuristic not always lead to a lower cost or are able to find the best path. 

When the heuristic function don't overestimate the truth or find the lowest cost search solution are called <span style="color:#ff7518;">admisible heuristic</span>. 

#### HEURISTIC FUNCTION IN <span style="color:LightSeaGreen;">A*</span>

A* pathfinding algorithm uses a heuristic to find the shortest path in a graph. Each node n has a cost f(n) which is calculated as $f(n) = g(n) + h(n)$ where: 
* g(n) is the actual cost of the node from the beginning of the path. 
* h(n) is its heuristic cost to reach the goal. 

This calculation would help to determine the next nodes to visit, instead of only $g(n)$. 

A* is admissible, meaning that it always finds the solution with optimal f(n).