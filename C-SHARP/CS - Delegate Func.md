#CSHARP #NET 
## FUNC\<\> Introduction

Encapsulates a method that has one parameter and returns a value of the type specified by the <span style="color:#9EE192">TResult</span> parameter.
``` CSHARP 
public delegate TResult Func<in T,out TResult>(T arg);
```
---
#### PARAMETERS 

<div style="border: 1px solid white; border-radius: 0.5rem; padding: 1rem;">

<span style="color:#f5a5f5; ">T</span>
The type of the parameter of the method that this delegate encapsulates.
This type parameter is contravariant. That is, you can use either the type you specified or any type that is less derived. For more information about covariance and contravariance, see Covariance and Contravariance in Generics.
<br><br>
<span style="color:#f5a5f5; ">TResult</span>
The type of the return value of the method that this delegate encapsulates.
This type parameter is covariant. That is, you can use either the type you specified or any type that is more derived. For more information about covariance and contravariance, see Covariance and Contravariance in Generics.
<br><br>
<span style="color:#f5a5f5; ">T</span>
The parameter of the method that this delegate encapsulates.
<br><br>
<span style="color:#f5a5f5; ">TResult</span>
The return value of the method that this delegate encapsulates.
Return Value
</div>

### Execute a Func\<\>

Once you have the Func\<\> defined using lamba expression you can execute it and dont use as a common lambda. 
For executing the method you need to call to ```Func<>.Invoke()```


##### Can be nullable: 

Invoke works well with new C# 6 null propagation operator, now you can do

```csharp
T result = method?.Invoke();
```

instead of : 

```csharp
T result = method != null ? method() : null;
```

More detailed in:  [[CS - Nullable propagation]]


#### USAGE WITH LAMBDA

The following example demonstrates how to declare and use a Func\<T,TResult\> delegate. This example declares a Func\<T,TResult\> variable and assigns it a <span style="color:cyan; text-decoration:underline; ">lambda expression</span> that converts the characters in a string to uppercase. 

The delegate that encapsulates this method is then passed to the Enumerable.Select method to change the strings in an array of strings to uppercase.

```CSHARP 
// Declare a Func variable and assign a lambda expression to the
// variable. The method takes a string and converts it to uppercase.
Func<string, string> selector = str => str.ToUpper();


string[] words = { "orange", "apple", "Article", "elephant" };
IEnumerable<String> aWords = words.Select(selector);

foreach (String word in aWords)
    Console.WriteLine(word);

/*
This code example produces the following output:

ORANGE
APPLE
ARTICLE
ELEPHANT
*/
```

#### USAGE WITH DELEGATE METHOD

When you use the Func\<T,TResult\> delegate, you do not have to explicitly define a delegate that encapsulates a method with a single parameter. For example, the following code explicitly declares a delegate named `ConvertMethod` and assigns a reference to the `UppercaseString` method to its delegate instance.

```CSHARP 
using System;

delegate string ConvertMethod(string inString);

public class DelegateExample
{
   public static void Main()
   {
      // Instantiate delegate to reference UppercaseString method
      ConvertMethod convertMeth = UppercaseString;
      string name = "Dakota";
      // Use delegate instance to call UppercaseString method
      Console.WriteLine(convertMeth(name));
   }

   private static string UppercaseString(string inputString)
   {
      return inputString.ToUpper();
   }
}
```

The following example simplifies this code by instantiating the Func\<T, TResult\> delegate instead of explicitly defining a new delegate and assigning a named method to it.

```CSHARP 
// Instantiate delegate to reference UppercaseString method
Func<string, string> convertMethod = UppercaseString;
string name = "Dakota";
// Use delegate instance to call UppercaseString method
Console.WriteLine(convertMethod(name));

string UppercaseString(string inputString)
{
   return inputString.ToUpper();
}

// This code example produces the following output:
//
//    DAKOTA
```

#### USAGE WITH ANONYMOUS METHODS

You can also use the Func\<T, TResult\> delegate with anonymous methods in C#, as the following example: 
(For [Anonymous Methods](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-methods) take a look into [[CS - ANONYMOUS METHODS]].)

```CSHARP 
 Func<string, string> convert = delegate(string s)
    { return s.ToUpper();};

 string name = "Dakota";
 Console.WriteLine(convert(name));

// Output: DAKOTA
```

You can also assign a lambda expression to a [Func<T,TResult>](https://learn.microsoft.com/en-us/dotnet/api/system.func-2?view=net-8.0) delegate, as the following example illustrates. (For an introduction to lambda expressions, see [Lambda Expressions (VB)](https://learn.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/procedures/lambda-expressions), [Lambda Expressions (C#)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions) and [Lambda Expressions (F#)](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/lambda-expressions-the-fun-keyword).)
```CSHARP 
Func<string, string> convert = s => s.ToUpper();

string name = "Dakota";
Console.WriteLine(convert(name));

// This code example produces the following output:
//
//    DAKOTA
```

The underlying type of a lambda expression is one of the generic `Func` delegates. This makes it possible to pass a lambda expression as a parameter without explicitly assigning it to a delegate. In particular, because many methods of types in the [System.Linq](https://learn.microsoft.com/en-us/dotnet/api/system.linq?view=net-8.0) namespace have [Func<T,TResult>](https://learn.microsoft.com/en-us/dotnet/api/system.func-2?view=net-8.0) parameters, you can pass these methods a lambda expression without explicitly instantiating a [Func<T,TResult>](https://learn.microsoft.com/en-us/dotnet/api/system.func-2?view=net-8.0) delegate.

#### USAGE WITHOUT DELEGATES

You can use Func\<\> similar to System.Action\<\> just by assigning a method name to it and call it with invoke. 

```CSHARP 
static Func<bool> test = Test;

    static void Main()
    {
        test.Invoke();
    }

    public static bool Test()
    {
        Console.WriteLine("Hello world");
        return false; 
    }

// Output: Hello world
```

### METHOD CALL - () or .Invoke() 

Both compile the same way. In this terms, use <span style="color:#ababf5;">method()</span> is a shorter-way for <span style="color:#ababf5;">method.Invoke()</span>. 

```csharp
public T Execute<T>(Func<T> method)
{
    return (T)method.Invoke();
}
```

or: 

```csharp
public T Execute<T>(Func<T> method)
{
    return (T)method();
}
```

---
### NAMESPACE

| TYPE | ALOCATION |
|---|---|
| Namespace: | System |
| Assembly: | System.Runtime.dll | 
