#CS 

## Enum to string

For some debug or also application features, we may desire that an enumerator name can be converted to text to be debuged or printed. 

In this case by the use of `ToString` dotnet function, we can automatically print the enum value as string, printing the same name as the enum tag name: 

Example: 
```csharp
public class Program
{
	public enum HttpMethod{
		GET = 0, 
		POST, 
		HEAD, 
		PUT, 
		DELETE
	}
	public static void Main()
	{
		Console.WriteLine("Method: " + HttpMethod.GET.ToString()); 
		// |------CONSOLE------|
		// |    Method: GET    |
		// |-------------------|
	}
}
```