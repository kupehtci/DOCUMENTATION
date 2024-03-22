#CSHARP #NET 

## Garbage collector

The garbage collector automatically releases the memory allocated to a managed object when that object is no longer used.

However, it is not possible to predict when garbage collection will occur. 





### <span style="color:orange;">GC Limitations</span>

Furthermore, the garbage collector has no knowledge of <span style="color:#ababf5;">unmanaged resources</span> such as window handles, or open files and streams.

For handling this kind of resources, IDisposable interface can be used: [[CS - IDisposable Interface]]
