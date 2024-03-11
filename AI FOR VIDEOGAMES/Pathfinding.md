
### Pathfinding

In order to find the best path , the intention is to visit all nodes following a certain algorithm and to find the best nodes to reach the `target` the best way is to calculate the : 

* g cost: total cost from the initial node to the node evaluated
* heuristic cost: an absolute minimum <span style="color:orange;">estimated distance</span> cost to reach the target from the evaluated target. 

And using this cost and tending to minimize $f(n) = g(n) + h(n)$ to search the best path. 

### Cost Calculation

There are two costs in A*,  the G cost and the H cost (Heuristic)

For calculating the cost of B node: 

![[./IMAGES/pathfinding-grid-cost-parent.png|250]]

For calculating costs in each node that is visited during the pathfinding algorithm: 

* Calculating `g` cost is: `P.g_cost = A.g_cost + D()`
* Calculating `h` cost is