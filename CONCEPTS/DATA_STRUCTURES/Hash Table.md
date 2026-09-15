#DATA_STRUCTURE #CONCEPTS 

## HASH TABLE

A **hash table** (hash map) is the underlying mechanism used to implement fast [[Map]]s and [[Set]]s. It stores key-value pairs in an [[Array]] of **buckets**, using a <span style="color:#ababf5;">hash function</span> to compute the bucket index directly from the key.

```
key "es" → hash("es") → index 3 → bucket[3] = [("es", "Spain")]
```

### How it works

1. A **hash function** converts the key into a numeric hash code.
2. The hash code is reduced to a valid bucket index, typically `hash(key) % number_of_buckets`.
3. The value is stored in that bucket.
4. Looking up a key repeats the same steps to jump directly to the right bucket.

Because the index is computed instead of searched for, average lookup, insert and delete are **O(1)**.

### Collisions

Two different keys can hash to the same bucket index — a **collision**. Common resolution strategies:

* **Separate chaining**: each bucket holds a small [[Linked List]] (or array) of entries; colliding entries are appended to it.
* **Open addressing**: on collision, probe for the next free slot in the array itself (linear probing, quadratic probing, double hashing).

### Load factor

The **load factor** is `number_of_entries / number_of_buckets`. As it grows, collisions become more frequent and performance degrades. Hash tables automatically **resize** (rehash into a bigger array) once the load factor passes a threshold (commonly ~0.75), similar to how dynamic [[Array]]s grow.

### Complexity

| Operation | Average | Worst case                          |
| ----------- | --------- | -------------------------------------- |
| Access    | O(1)    | O(n) — all keys collide into one bucket |
| Search    | O(1)    | O(n)                                  |
| Insert    | O(1)    | O(n)                                  |
| Delete    | O(1)    | O(n)                                  |

A good hash function that distributes keys evenly keeps performance close to the average case in practice.

### Related

* [[Map]] and [[Set]] — the abstractions most commonly implemented with a hash table.
