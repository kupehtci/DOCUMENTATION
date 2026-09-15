#DATA_STRUCTURE #CONCEPTS 

## HEAP

A **heap** is a specialized complete <span style="color:#ababf5;">binary [[Tree]]</span> that satisfies the **heap property**, used to always give fast access to the smallest or largest element.

* **Min-Heap**: every parent node is **≤** its children → the smallest element is always at the root.
* **Max-Heap**: every parent node is **≥** its children → the largest element is always at the root.

```
        Min-Heap
           1
         /   \
        3     2
       / \   /
      5   4 6
```

Unlike a [[Tree|Binary Search Tree]], a heap is only ordered **vertically** (parent vs children) — there is no ordering guarantee between siblings.

### Representation

Because a heap is a **complete** binary tree (filled left to right, level by level), it can be stored efficiently in a plain [[Array]] without needing pointers:

* Parent of index `i` → `(i - 1) / 2`
* Left child of index `i` → `2i + 1`
* Right child of index `i` → `2i + 2`

### Operations

| Operation         | Description                                                  | Complexity |
| -------------------- | ------------------------------------------------------------- | ------------ |
| `peek()`           | Return the min/max element (the root)                       | O(1)       |
| `insert(x)`        | Add an element at the end, then "bubble up" to restore order | O(log n)   |
| `extractMin/Max()` | Remove the root, move the last element to the root, "bubble down" | O(log n)   |
| `heapify(array)`   | Build a heap from an unordered array                        | O(n)       |

### Use cases

* Implementing a **Priority Queue** (see [[Queue]]).
* **Heap Sort**: repeatedly extract the min/max to produce a sorted sequence, O(n log n).
* Graph algorithms like **Dijkstra's shortest path** and **Prim's minimum spanning tree**, where the next node to process is always the closest/cheapest one.
* Finding the k-th smallest/largest element efficiently.

### Related

* [[Tree]] — a heap is a constrained form of binary tree.
* [[Queue]] — a heap is the typical implementation of a priority queue.
