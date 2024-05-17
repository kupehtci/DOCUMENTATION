#CSHARP #NET 

#### What is nullable propagation 


#### Declaration of nullable types

As a value type is implicitly converted to its <span style="color:#957dad;">nullable value type</span>, you can assign a value to a variable of a nullable value type as you would do that for its underlying value type. You can also assign the `null` value. For example:


Also an array can be null and have nullable types: 
```CSHARP
int?[] array = new int?[10];
```

#### How to check before use the variable

```CSHARP 
int? a = 42; 
if (a is int valueOfA) 
{ 
	Console.WriteLine($"a is {valueOfA}"); 
} 
else 
{ 
	Console.WriteLine("a does not have a value"); 
}

// Output would be: a is 42
```

Also can be check if there is a value instead of null by using: 

You always can use the following read-only properties to examine and get a value of a nullable value type variable:
- Nullable\<T\>.Value is `true`. If [HasValue](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1.hasvalue) is `false`, the [Value](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1.value)property throws an [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception).

With this property would be: 

```CSHARP 
int? a = null; 
if (a.HasValue) 
{ 
	Console.WriteLine($"a is {valueOfA}"); 
} 
else 
{ 
	Console.WriteLine("a does not have a value"); 
}

// Output would be: a does not have a value
```

Also can be compared with a null with an `==` or `!=` operator: 

```CSHARP 
int? a = 31; 
if (a != null) 
{ 
	Console.WriteLine($"a is {valueOfA}"); 
} 
else 
{ 
	Console.WriteLine("a does not have a value"); 
}

// Output would be: a is 31
```

#### NULL Checks

You can check if an item is null in <span style="color:#957dad;">csharp</span> and other languages: 

```CSHARP 
int i = a != null ? a : 0; 
```

With C# 6.0 and superior you can use null checks `?`

```CSHARP 
int i = a?; 
```

With a <span style="color:MediumSlateBlue; "> question mark [?]</span> you can tell the compiler that a variable can be null: 

```CSHARP 
GameObject? new_go = null; 
```



More information in [Learn.Microsoft](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types)
