#DATA_STRUCTURE #CONCEPTS 

## SET

A **set** is a collection that stores <span style="color:#ababf5;">unique elements</span>, with no duplicates and (usually) no guaranteed order. It closely mirrors the mathematical concept of a set.

Conceptually, a set behaves like a [[Map]] that only stores keys, with no associated value.

### Characteristics

* No duplicate elements: adding an existing element has no effect.
* Membership testing (`contains`) is the core operation, and should be fast.
* Ordering depends on the implementation (hash-based sets are unordered, tree-based sets are sorted).

### Implementations

| Implementation      | Ordering      | Average complexity | Notes                                  |
| ---------------------- | --------------- | --------------------- | ------------------------------------------- |
| Hash Set             | Unordered     | O(1)                | Backed by a [[Hash Table]]             |
| Tree Set             | Sorted        | O(log n)            | Backed by a balanced [[Tree]]          |

### Common operations

| Operation        | Description                              | Complexity (hash set) |
| ------------------- | -------------------------------------------- | ------------------------ |
| `add(x)`          | Insert an element                          | O(1)                    |
| `remove(x)`       | Remove an element                          | O(1)                    |
| `contains(x)`     | Check if an element is present             | O(1)                    |

### Set operations

Sets also support mathematical operations between two sets `A` and `B`:

* **Union** (`A ∪ B`): all elements in either set.
* **Intersection** (`A ∩ B`): elements present in both sets.
* **Difference** (`A - B`): elements in `A` that are not in `B`.
* **Subset** (`A ⊆ B`): whether every element of `A` is also in `B`.

### Use cases

* Removing duplicates from a collection.
* Fast membership checks (e.g. "has this user already been processed?").
* Tracking visited nodes in a [[Graph]] traversal (BFS/DFS).

### Related

* [[Map]] — a set is essentially a map without values.
* [[Hash Table]] — the usual mechanism behind fast sets.
