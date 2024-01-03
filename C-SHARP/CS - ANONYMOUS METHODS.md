
### INTRODUCTION - What are anonymous methods

The `delegate` operator creates an anonymous method that can be converted to a delegate type. An anonymous method can be converted to types such as [System.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action) and System.Func\<TResult\>types used as arguments to many methods.

As the name suggests, an <span style="color:orange;">anonymous method</span> is a method without a name. 
Anonymous methods in C# can be defined using the delegate keyword and can be assigned to a variable of delegate type. 

```CSHARP 
Func<int, int, int> sum = delegate (int a, int b) { return a + b; }; Console.WriteLine(sum(3, 4)); // output: 7
```

Lambda expressions provide a more concise and expressive way to create an anonymous function. Use the [=> operator](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator) to construct a lambda expression:

``` CSHARP 
Func<int, int, int> sum = (a, b) => a + b;
Console.WriteLine(sum(3, 4));  // output: 7
```

For more information about features of lambda expressions, for example, capturing outer variables, see [Lambda expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions).

#### ANONYMOUS METHODS AS PARAMETERS

Anonymous methods can also be passed to a method that accepts the delegate as a parameter.

In the following example, PrintHelperMethod() takes the first parameters of the Print delegate:

```CSHARP 
public delegate void Print(int value);

class Program
{
    public static void PrintHelperMethod(Print printDel,int val)
    { 
        val += 10;
        printDel(val);
    }

    static void Main(string[] args)
    {
        PrintHelperMethod(delegate(int val) { Console.WriteLine("Anonymous method: {0}", val); }, 100);
    }
}
```

Take a look into <span style="color:orange;">delegates</span> in [[CS - Delegate introduction]], [[CS - Delegate Func<>]], 

---
See: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/delegate-operator