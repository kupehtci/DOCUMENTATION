## INTRODUCTION 


### ENUMERATORS <span style="color:#e1affd">enum</span>

An _enumeration type_ (or _enum type_) is a [value type](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types) defined by a set of named constants of the underlying [integral numeric](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types) type. To define an enumeration type, use the `enum` keyword and specify the names of _enum members_:

Example of enumerators: 
```CSHARP
enum Season { 
	Spring, 
	Summer, 
	Autumn, 
	Winter 
}
```

In this case, values to each constant are given by the compiler, but Its values can be predefined

```CSHARP 
enum ErrorCode : ushort { 
	None = 0,
	Unknown = 1, 
	ConnectionLost = 100, 
	OutlierReading = 200 
}
```
### ENUM TO <span style="color:#e1affd">INT</span>

 if you want to get the `int` value from `System.Enum`, then given `e` here:

 ```csharp
System.Enum e = Question.Role;
```

You can use:

```csharp
int i = Convert.ToInt32(e);
int i = (int)(object)e;
int i = (int)Enum.Parse(e.GetType(), e.ToString());
int i = (int)Enum.ToObject(e.GetType(), e);
```

The last two are plain ugly. I prefer the first one.


