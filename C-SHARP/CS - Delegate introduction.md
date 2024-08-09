#CSHARP #NET 

## Introduction to delegates

A delegate is an anonymous method that can be converted into a <span style="color:orange;">delegate type</span> that can be converted into System.Func\<TResult\> ([[CS - Delegate Func]]) or System.Action; 

```CSHARP 
Func<int, int, int> sum = delegate (int a, int b) { return a + b; }; Console.WriteLine(sum(3, 4)); // output: 7
```


Simply a “Delegate” is a type-safe method pointer.