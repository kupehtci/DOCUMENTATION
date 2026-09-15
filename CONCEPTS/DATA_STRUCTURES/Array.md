#DATA_STRUCTURE #CONCEPTS 

## ARRAY

An **array** is a collection of elements, each identified by an **index**, stored in <span style="color:#ababf5;">contiguous memory</span>. Because elements sit next to each other in memory, the position of any element can be calculated directly from its index, which makes access extremely fast.

### Characteristics

* Fixed or dynamic **size**, depending on the language/implementation.
* Elements are typically of the **same type** (in statically typed languages).
* Accessed by a numeric **index**, usually zero-based.
* Contiguous memory layout gives excellent **cache locality**.

### Static vs Dynamic arrays

* **Static array**: fixed size, defined at creation time (e.g. `int[10]` in C/Java).
* **Dynamic array**: resizes automatically as elements are added (e.g. `ArrayList` in Java, `list` in Python, `Array` in JS). Internally, when capacity is exceeded, a new larger array is allocated (commonly double the size) and existing elements are copied over — an O(n) operation that happens infrequently, giving **amortized O(1)** appends.

### Complexity

| Operation                     | Complexity | Notes                                  |
| -------------------------------- | ------------ | ------------------------------------------ |
| Access by index                | O(1)       | Direct memory offset calculation       |
| Search (unsorted)              | O(n)       | Must scan linearly                     |
| Search (sorted, binary search) | O(log n)   | Requires the array to be sorted        |
| Insert / delete at the end     | O(1)*      | Amortized for dynamic arrays           |
| Insert / delete at start/middle| O(n)       | Requires shifting subsequent elements  |

### Multi-dimensional arrays

Arrays can have more than one dimension (matrices, grids, cubes), where an element is addressed by multiple indices: `matrix[row][col]`. See [[CS - Multi-dimensional Arrays]] for a C# example.

### Use cases

* Storing fixed collections of known size (lookup tables, buffers).
* Implementing other data structures ([[Stack]], [[Queue]], [[Hash Table]] buckets, binary [[Heap]]).
* Cases where random access by position is the dominant operation.

### Related

* [[Linked List]] — the usual alternative when frequent insertions/deletions are needed.
