#CONCEPTS 

### DIFFERENCE IN MEMORY

An integer size is <span style="color:orange;">4 bytes</span> because it lives in the stack and doesn't need any reference to it. 


```C
int a = 0; //-> 4 bytes
int a = new int[1]; //-> 12 bytes
a[0] = 0;
```

<span style="color:cyan;">Integer array</span> is <span style="color:orange;">12 bytes</span> because it lives in the heap and it needs a reference in the stack (<span style="color:orange;">Pointer</span>) 8 bytes and 4 bytes for each integer. 


## STACK

It is a LIFO (Last In First Out) data structure. In it, cata can be added to and deleted only from it. 

In c\#, the stack is a 1MB -> 250.000 float variables

All values that goes into the stack: 
• bool
• int, long, short, uint, ulong, ushort, sbyte, byte, char
• double, float
• decimal
• enum, struct

## HEAP

Area of memory where chuncks are allocated to store certain of data objects. In it, can be stores and removed in any order. 

All <span style="color:orange;">reference types</span> go in the heap: 
• array
• class
• interface
• delegate
• object
• string

Using the memory can cause memory fragmentation. 

The heap has “unlimited” memory while being dispersed and slowly accessed. The free of memory is handled by the Garbage Collector
The stack has limited memory, and it is ordered and quickly accessible. The free of memory is handled once the scope is lost.

![[stack and heap.png|500]]

## Garbage Collector

A garbage collector is used to reclaim memory from objects that an application is no longer using. 

When it runs, it examines all objects in the heap