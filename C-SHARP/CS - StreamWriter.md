#CS #NET #FILE
## Write to a text file in C# using StreamWriter

C# StreamWriter class is one of the common ways to create and write a file. The StreamWriter constructor takes a full file name and creates the file if it does not exist. The following code example uses a StreamWriter to create and write to a file. The WriteLine method of the StreamWriter writes the next line in the file. 

```csharp
// Write file using StreamWriter
using (StreamWriter writer = new StreamWriter(fullPath))
{
   writer.WriteLine("Monica Rathbun");
   writer.WriteLine("Vidya Agarwal");
   writer.WriteLine("Mahesh Chand");
   writer.WriteLine("Vijay Anand");
   writer.WriteLine("Jignesh Trivedi");
}
// Read a file
string readText = File.ReadAllText(fullPath);
Console.WriteLine(readText);
```

Learn more here, [C# StreamWriter Example (c-sharpcorner.com)](https://www.c-sharpcorner.com/article/csharp-streamwriter-example/)
## EXAMPLE



