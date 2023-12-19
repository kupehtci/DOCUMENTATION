#CSHARP 

# string\[\]

An array of strings can have certain complications: 

Initialization of Arrays of Strings: Arrays can be initialized after the declaration. It is not necessary to declare and initialize at the same time using the new keyword. However, Initializing an Array after the declaration, it must be initialized with the new keyword. It can’t be initialized by only assigning values.

Example:
```CSHARP 
// Declaration of the array
string[] str1, str2;

// Initialization of array
str1 = new string[5]{ “Element 1”, “Element 2”, “Element 3”, “Element 4”, “Element 5” };

str2 = new string[]{ “Element 1”, “Element 2”, “Element 3”, “Element 4”, “Element 5” };
```

<span style="color:orange;">Note:</span> Initialization without giving size is not valid in C#. It will give compile time error.
<span style="color:orange;">Example:</span> Wrong Declaration for initializing an array

```CSHARP 
// compile-time error: must give size of an array
String[] str = new String[];

// error : wrong initialization of an array
string[] str1;
str1 = {“Element 1”, “Element 2”, “Element 3”, “Element 4” };

```

<span style="color:pink;">Accessing Arrays of Strings Elements:</span> At the time of initialization, we can assign the value. But, we can also assign the value of array using its index randomly after the declaration and initialization. We can access an array value through indexing, placed index of the element within square brackets with the array name.

Example:
```CSHARP 
// declares & initializes string array
String[] s1 = new String[2];

// assign the value "Geeks" in array on its index 0
s1[0] = 10; 

// assign the value "GFG" in array on its index 1
s1[1] = 30;

// assign the value "Noida" in array on its index 2
s1[2] = 20;


// Accessing array elements using index
s1[0];  // returns Geeks
s1[2];  // returns Noida
```

Declaration and initialization of string array in a single line: String array can also be declared and initialized in a single line. This method is more recommended as it reduces the line of code.

Example:
```CSHARP 
String[] weekDays = new string[3] {"Sun", "Mon", "Tue", "Wed"}; 
``` 