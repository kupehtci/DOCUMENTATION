
#### Directory files in c\# using `Directory.GetFiles()`

The simplest way to search directories and list files in C# is by using the `Directory.GetFiles()`  method. This method returns an array of strings that represents the paths of all files in a specified directory that match a specified search pattern.

Here's how we can use the Directory.GetFiles() method to list all the files in a directory −

```CSHARP 
using System.IO; 
using System; 

class Program { 
	static void Main() { 
	
		string path = @"C:\Users\JohnDoe\Documents"; 
		string[] files = Directory.GetFiles(path); 
		foreach (string file in files) {
		 Console.WriteLine(file); 
		 } 
	}
}
```

Take into account that `path` can be absolute or relative to the <span style="color:cyan; text-decoration:underline;">.sln</span> of the project. 

#### Directory files in c\# using `Directory.EnumerateFiles()`

Another way to search directories and list files in C# is by using the Directory.EnumerateFiles() method. This method returns an <span style="color:#f5a5f5">enumerable collection</span> of strings that represents the paths of all files in a specified directory that match a specified search pattern.

Here's how we can use the `Directory.EnumerateFiles()` method to list all the files in a directory: 

```CSHARP
using System.IO;
using System;

class Program {
   static void Main(string[] args) {
      string path = @"C:\Users\JohnDoe\Documents";
   
      foreach (string file in Directory.EnumerateFiles(path)) {
         Console.WriteLine(file);
      }
   }
}
```
In this code, we start by specifying the directory path that we want to search in a string variable named path. We then use the Directory.EnumerateFiles() method to get an enumerable collection of file paths.

Finally, we use a foreach loop to iterate through the collection of file paths and print each path to the console.

--- 
Because its an iterator, acts like getting a file in each <span style="color:#f5a5f5">iterator iteraction</span>. 