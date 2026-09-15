#DATA_STRUCTURE #CONCEPTS 

## QUEUE

A **queue** is a linear data structure that follows the <span style="color:#ababf5;">FIFO</span> principle: **First In, First Out**. The first element added is the first one to be removed, like a line of people waiting.

```
enqueue →  [ 1 ][ 2 ][ 3 ]  → dequeue
           front       back
```

### Operations

| Operation             | Description                                  | Complexity |
| ------------------------ | ----------------------------------------------- | ------------ |
| `enqueue(x)`           | Add an element to the back                    | O(1)       |
| `dequeue()`            | Remove and return the front element           | O(1)       |
| `peek()` / `front()`   | Return the front element without removing it  | O(1)       |
| `isEmpty()`            | Check whether the queue has any elements      | O(1)       |

### Implementation

A queue can be implemented on top of:

* A [[Linked List]]: O(1) enqueue/dequeue with head and tail pointers.
* A **circular buffer** over an [[Array]]: avoids shifting elements by wrapping the index around.

### Variants

* **Deque** (double-ended queue): allows insertion and removal from **both** ends.
* **Priority Queue**: elements are dequeued by priority instead of arrival order, typically implemented with a [[Heap]].
* **Circular Queue**: the array-backed variant that wraps around to reuse freed space.

### Use cases

* **Breadth-First Search (BFS)** on a [[Tree]] or [[Graph]].
* **Task scheduling**: processing jobs in the order they arrive (print queues, CPU scheduling).
* **Message queues** and buffering between producers and consumers, e.g. [[AWS - SQS Simple Queue Service]].
* **Rate limiting / throttling** and request buffering.

### Related

* [[Stack]] — the LIFO counterpart of a queue.
* [[Heap]] — commonly used to implement a priority queue.
