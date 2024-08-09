#CSHARP 
## INTRODUCTION 

Structs are light versions of classes. Structs are value types and can be used to create objects that behave like built-in types.

Structs share many features with classes but with the following limitations as compared to classes.

- Struct cannot have a default constructor (a constructor without parameters) or a destructor.
- Structs are value types and are copied on assignments.
- Structs are value types, while classes are reference types.
- Structs can be instantiated without using a new operator.
- A struct cannot inherit from another struct or class, and it cannot be the base of a class. All structs inherit directly from the System.ValueType, which inherits from System.Object.
- Struct cannot be a base class. So, Struct types cannot abstract and are always implicitly sealed.
- Abstract and sealed modifiers are not allowed, and struct members cannot be protected or protected internals.
- Function members in a struct cannot be abstract or virtual, and the override modifier is allowed only to the override methods inherited from the System.ValueType.
- Struct does not allow the instance field declarations to include variable initializers. However, static fields of a struct are allowed to include variable initializers.
- A struct can implement interfaces.
- A struct can be used as a nullable type and can be assigned a null value.

To answer this question, we should have a good understanding of the differences.

|S.N|Struct|Classes|
|---|---|---|
|1|Structs are value types allocated either on the stack or inline in containing types.|Classes are reference types, allocated on the heap and garbage-collected.|
|2|Allocations and de-allocations of value types are, in general, cheaper than allocations and de-allocations of reference types.|Assignments of large reference types are cheaper than assignments of large value types.|
|3|In structs, each variable contains its own copy of the data (except in the case of the ref and out parameter variables), and an operation on one variable does not affect another variable.|In classes, two variables can contain the reference of the same object, and any operation on one variable can affect another variable.|

In this way, struct should be used only when you are sure that,

- It logically represents a single value, like primitive types (int, double, etc.).
- It is immutable.
- It should not be boxed and un-boxed frequently.

In all other cases, you should define your types as classes.