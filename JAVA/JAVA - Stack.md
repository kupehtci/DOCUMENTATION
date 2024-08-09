#JAVA 

### Java Stack

<span style="color:orange;">Stack</span> is a data structure based in the <span style="color:MediumSlateBlue;">Last In First Out (LIFO) principle</span>. 

The basic interactions with this Stack is <span style="color:MediumSlateBlue;">push</span> and <span style="color:MediumSlateBlue;">pop</span>. 

Push inserts an element into the top of the Stack and Pop removes an element from the top. 

Stack can be declared as: 
```JAVA
Stack<dataType> stackName = new Stack<>();
```

## METHODS

* `push()` pushes the element passed as parameter into top of the stack. 
* `pop()` removes and returns the top element of the stack. 
* `peek()` returns the element at the top of the stack but don't remove it. 
* `empty()` returns `true` if the stack if empty, otherwise `false`.  
* `search()` determine the index of the specified item. If found, returns the index from the top of the stack and if not founded returns -1. 


### EXCEPTIONS 

Returns `EmptyStackException` if doing `pop()` or `peek()` over an empty stack. 