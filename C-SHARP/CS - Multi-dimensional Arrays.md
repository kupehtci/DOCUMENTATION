#CSHARP 

### ARRAYS WITH MORE THAN 1-D


An array with more that one dimension act like an array of arrays.
The most common use is a 2D array that act like a grid. 

```CSHARP 
// Two-dimensional array.
int[,] array2DInitialization =  { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

// Three-dimensional array.
int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4,   5,  6 } },
								{ { 7, 8, 9 }, { 10, 11, 12 } } };
```


#### Traverse a multidimensional array 

The order of <span style="color:orange;">traverse</span> a multidimensional array is by reducing the dimensions, starting by the rightmost dimension, then the next left dimension to the traversed one and at last the leftmost one. 

Example with 2-D and 3-D: 

```CSHARP 
int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

foreach (int i in numbers2D)
{
    System.Console.Write($"{i} ");
}
// Output: 9 99 3 33 5 55

int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4,   5,  6 } },
                        { { 7, 8, 9 }, { 10, 11, 12 } } };
foreach (int i in array3D)
{
    System.Console.Write($"{i} ");
}
// Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
```

One way to traverse the array is using <span style="color:purple">nested loops</span>. 
For this we need to get the length of each dimension and can be done with the method `GetLength(int indexDimension)` and each dimension has an index starting with 0. 

Example: 

```CSHARP 
for (int i = 0; i < array3D.GetLength(0); i++)
{
    for (int j = 0; j < array3D.GetLength(1); j++)
    {
        for (int k = 0; k < array3D.GetLength(2); k++)
        {
            System.Console.Write($"{array3D[i, j, k]} ");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}
```

### Multidimensionals in functions 


They cal also be passed as an argument to a function and even by reference, the same way as a unidimensional array: 

```CSHARP 
static void Print2DArray(int[,] arr) {}
```

### Jagged arrays

A `jagged array` is the one that whose elements are arrays. Works the same as multidimensional arrays. 
Example: 

```CSHARP 
int[][] jaggedArray = new int[3][];

jaggedArray[0] = [1, 3, 5, 7, 9];
jaggedArray[1] = [0, 2, 4, 6];
jaggedArray[2] = [11, 22];

int[][] jaggedArray2 = 
[
    [1, 3, 5, 7, 9],
    [0, 2, 4, 6],
    [11, 22]
];

// Assign 77 to the second element ([1]) of the first array ([0]):
jaggedArray2[0][1] = 77;

// Assign 88 to the second element ([1]) of the third array ([2]):
jaggedArray2[2][1] = 88;
```

The <span style="color:#ababf5;">main difference</span> is that these type of arrays need to be initialized to be able to use them, and the multidimensional arrays are initialized by making the <span style="color:#ababd5;">new</span>. 

