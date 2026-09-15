#DATA_STRUCTURE #CONCEPTS 

## MAP

Also known as <span style="color:#d291bc;">associative array</span> or **dictionary**.

The map data structure is used to store a collection of **key-value pairs**, where each key is unique and maps to exactly one value. It is an essential data structure in computer science because it allows for efficient and fast lookups, inserts, and deletes.

### Characteristics

* Keys are **unique**: inserting with an existing key overwrites its value.
* Values can be duplicated across different keys.
* No guaranteed ordering, unless using an ordered implementation (see below).
* Lookup, insert and delete are performed **by key**, not by position.

### Implementations

A map is an abstract concept. It is usually implemented on top of one of these underlying structures:

| Implementation                     | Ordering                   | Average complexity | Notes                                                                 |
| ----------------------------------- | --------------------------- | -------------------- | ------------------------------------------------------------------------ |
| [[Hash Table]] (Hash Map)          | Unordered                  | O(1)                | Fastest general-purpose map, relies on a good hash function          |
| Balanced [[Tree]] (Tree Map)       | Sorted by key               | O(log n)            | Keeps keys sorted, useful for range queries (`floor`, `ceiling`, etc.) |
| [[Array]] / Linked List of pairs   | Insertion order (or none)  | O(n)                | Only practical for very small maps                                    |

### Common operations

| Operation          | Hash Map (avg) | Tree Map (avg) |
| -------------------- | ---------------- | ----------------- |
| `get(key)`          | O(1)            | O(log n)         |
| `put(key, value)`   | O(1)            | O(log n)         |
| `remove(key)`       | O(1)            | O(log n)         |
| `containsKey(key)`  | O(1)            | O(log n)         |

### Example

```js
const map = new Map();
map.set("es", "Spain");
map.set("fr", "France");

map.get("es");        // "Spain"
map.has("de");         // false
map.delete("fr");
```

### Related

* [[Hash Table]] — the mechanism behind most map implementations.
* [[Set]] — a map that only stores keys, no values.
