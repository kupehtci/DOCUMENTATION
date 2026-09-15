#DATA_STRUCTURE #CONCEPTS 

## GRAPH

A **graph** is a data structure made of a set of <span style="color:#ababf5;">nodes (vertices)</span> connected by <span style="color:#ababf5;">edges</span>. Unlike a [[Tree]], a graph has no single root and can contain cycles — any node can connect to any other node.

```
   A --- B
   |     |
   C --- D --- E
```

### Types

* **Undirected**: edges have no direction, `A-B` means `A` connects to `B` and vice versa.
* **Directed** (digraph): edges have a direction, `A → B` doesn't imply `B → A`.
* **Weighted**: edges carry a numeric cost/weight (distance, time, price).
* **Unweighted**: edges just represent a connection.
* **Cyclic / Acyclic**: whether the graph contains cycles. A **DAG** (Directed Acyclic Graph) is used to represent dependencies (task scheduling, build systems).

### Representations

| Representation       | Description                                                        | Space   | Edge lookup |
| ----------------------- | ---------------------------------------------------------------------- | --------- | ------------- |
| **Adjacency Matrix**   | 2D [[Array]] where `matrix[i][j]` indicates an edge between `i` and `j` | O(V²)   | O(1)        |
| **Adjacency List**     | Each node keeps a [[Linked List]]/array of its neighbors             | O(V + E)| O(degree)   |

Adjacency lists are preferred for sparse graphs (few edges); adjacency matrices are simpler for dense graphs or when O(1) edge lookup is critical.

### Traversal

* **Breadth-First Search (BFS)**: explores neighbors level by level, using a [[Queue]]. Finds the shortest path in an unweighted graph.
* **Depth-First Search (DFS)**: explores as far as possible along each branch before backtracking, using a [[Stack]] or recursion.

### Common algorithms

| Algorithm             | Purpose                                             |
| ------------------------ | ------------------------------------------------------ |
| **Dijkstra**            | Shortest path from a source node, non-negative weights (uses a [[Heap]]) |
| **Bellman-Ford**        | Shortest path, supports negative weights            |
| **Kruskal / Prim**      | Minimum Spanning Tree                               |
| **Topological Sort**    | Orders nodes of a DAG respecting dependencies        |
| **Union-Find**          | Tracks connected components, used in Kruskal's algorithm |

### Use cases

* Modeling networks: social graphs, road maps, computer networks.
* Dependency resolution (package managers, build pipelines) via DAGs.
* Pathfinding in games and robotics, e.g. [[Pathfinding]].
* Representing state machines and workflows.

### Related

* [[Tree]] — a graph that is connected, acyclic, and has exactly one root is a tree.
