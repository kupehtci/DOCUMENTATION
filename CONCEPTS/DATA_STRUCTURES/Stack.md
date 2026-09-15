#DATA_STRUCTURE #CONCEPTS 

## STACK

A **stack** is a linear data structure that follows the <span style="color:#ababf5;">LIFO</span> principle: **Last In, First Out**. The last element added is the first one to be removed, like a stack of plates.

```
push →  ┌───────┐
        │   3   │  ← top (pop / peek here)
        ├───────┤
        │   2   │
        ├───────┤
        │   1   │
        └───────┘
```

### Operations

| Operation  | Description                                  | Complexity |
| ------------ | ----------------------------------------------- | ------------ |
| `push(x)`  | Add an element to the top                     | O(1)       |
| `pop()`    | Remove and return the top element             | O(1)       |
| `peek()` / `top()` | Return the top element without removing it | O(1)       |
| `isEmpty()`| Check whether the stack has any elements      | O(1)       |

### Implementation

A stack can be implemented on top of either:

* An [[Array]]: fast, cache-friendly, but may need resizing.
* A [[Linked List]]: push/pop at the head, no resizing needed.

### Use cases

* **Call stack**: every function call is pushed onto the stack; returning pops it off.
* **Undo/redo** functionality in editors.
* **Backtracking algorithms** (maze solving, N-Queens).
* **Expression evaluation** and syntax parsing (matching parentheses, converting infix to postfix). See [[AST Abstract Syntax Tree]].
* **Depth-First Search (DFS)** on a [[Tree]] or [[Graph]], either with an explicit stack or via recursion (which uses the call stack implicitly).

See a language-specific example in [[JAVA - Stack]].

### Related

* [[Queue]] — the FIFO counterpart of a stack.
