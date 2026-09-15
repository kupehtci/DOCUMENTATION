#DATA_STRUCTURE #CONCEPTS 

## LINKED LIST

A **linked list** is a linear collection of elements, called <span style="color:#ababf5;">nodes</span>, where each node stores a value and a **reference (pointer)** to the next node. Unlike an [[Array]], nodes are not stored in contiguous memory — they can live anywhere, linked together by pointers.

```
[ value | next ] -> [ value | next ] -> [ value | next ] -> null
   Head                                      Tail
```

### Types

* **Singly linked list**: each node points only to the **next** node.
* **Doubly linked list**: each node points to both the **next** and **previous** node, allowing traversal in both directions.
* **Circular linked list**: the last node points back to the first node instead of `null`.

### Complexity

| Operation                          | Complexity | Notes                                            |
| ------------------------------------- | ------------ | ---------------------------------------------------- |
| Access by index                     | O(n)       | Must traverse from the head                     |
| Search                              | O(n)       | Linear traversal                                 |
| Insert / delete at head             | O(1)       | Just re-point the head                           |
| Insert / delete at tail             | O(1)*      | O(1) if a tail pointer is kept, otherwise O(n)   |
| Insert / delete at a known node     | O(1)       | No shifting needed, unlike arrays                |

### Linked List vs Array

| | Array | Linked List |
| --- | --- | --- |
| Memory layout | Contiguous | Scattered, linked by pointers |
| Random access | O(1) | O(n) |
| Insert/delete at start | O(n) | O(1) |
| Memory overhead | Low | Higher (stores pointers per node) |
| Cache locality | Good | Poor |

### Use cases

* Implementing a [[Stack]] or [[Queue]] when frequent insert/delete at the ends is needed.
* Scenarios with frequent insertions/deletions where random access isn't required (e.g. undo history, music playlists).
* Building blocks for more complex structures like adjacency lists in [[Graph]]s.

### Related

* [[Array]] — the main alternative, trading insert/delete speed for random access speed.
