#CS #NET 

## IDisposable

Its a utility to free resources that are not administer by Garbage collector.


### Using an object that implements IDisposable

If your app simply uses an object that implements the [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-8.0) interface, you should call the object's [IDisposable.Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose?view=net-8.0) implementation when you are finished using it. Depending on your programming language, you can do this in one of two ways:

- By using a language construct such as the `using` statement in C# and Visual Basic, and the `use` statement or `using` function in F#.
		An example of this can be seen in: [[CS - StreamReader]]
   
- By wrapping the call to the [IDisposable.Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose?view=net-8.0) implementation in a `try`/`finally` block.