#CSHARP #NET 
## ARRAYS 


When having a string array, some considerations need to be taken: [[CS - Array of strings]]

#### RESIZE ARRAY

An array can be resize to get more capacity. 
Can be resized by using: 

```CSHARP
int[] arr = new int[]{1, 2, 3}; 
Array.Resize(ref arr, arr.Length + 1); 
```

#### COMBINE ARRAYS 

There is not a method to combine two arrays. 

To concatenate two arrays, you can create a new array of the combined size and use the `Array.Copy()` method to copy elements from both arrays into the new one.

```CSHARP
void CombineArrays(int[] a, int[] b){
	
}
```