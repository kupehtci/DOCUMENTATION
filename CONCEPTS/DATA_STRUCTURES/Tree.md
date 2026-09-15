#DATA_STRUCTURE #CONCEPTS 

## TREE

A **tree** is a hierarchical data structure made of <span style="color:#ababf5;">nodes</span> connected by edges, with a single **root** node and no cycles. Every node except the root has exactly one **parent**, and can have zero or more **children**.

```
        root
       /    \
     A        B
    / \        \
   C   D        E
```

> For a deeper dive into tree fundamentals, binary trees and search trees, see [[Data Tree - Basics]] and [[Data Tree - Search]].

### Terminology

* **Root**: the top node, with no parent.
* **Leaf**: a node with no children.
* **Height**: the number of edges on the longest path from the root to a leaf.
* **Depth**: the number of edges from the root to a given node.

### Common types

| Type                      | Description                                                                 |
| ---------------------------- | -------------------------------------------------------------------------------- |
| **Binary Tree**             | Each node has at most two children (left/right).                              |
| **Binary Search Tree (BST)**| A binary tree where left subtree keys < node < right subtree keys.            |
| **Balanced Tree** (AVL, Red-Black) | Self-balancing BST, keeps height at O(log n) to guarantee fast operations. |
| **Heap**                    | A complete binary tree ordered by priority, see [[Heap]].                     |
| **Trie** (prefix tree)      | Each path from the root represents a string prefix, used for autocomplete.    |
| **N-ary Tree**              | Each node can have any number of children.                                    |

### Complexity (balanced BST)

| Operation | Complexity |
| ----------- | ------------ |
| Search    | O(log n)   |
| Insert    | O(log n)   |
| Delete    | O(log n)   |

An **unbalanced** tree can degrade to a [[Linked List]] shape, with O(n) operations.

### Traversal

* **Depth-First**: pre-order, in-order, post-order — usually implemented with recursion or an explicit [[Stack]].
* **Breadth-First** (level order): visits nodes level by level, implemented with a [[Queue]].

### Use cases

* Representing hierarchical data (file systems, DOM, org charts).
* Implementing sorted [[Map]]s and [[Set]]s (tree map/tree set).
* Parsing: [[AST Abstract Syntax Tree]] and [[GRAMMARS - Derivation tree]].
* Spatial partitioning: [[BVH Bounding Volume Hierarchy]].

### Related

* [[Graph]] — a tree is a special case of a graph with no cycles and a single root.
