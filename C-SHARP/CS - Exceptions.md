


The following exceptions inherit from `exception` case class. All of them can be catch by using Exception because they inheritance. 

### <span style="color:#ababf5">IOException</span>

Exception for I/O errors. As other exceptions, inherit from `exception` class. 

```CS
public class IOException : SystemException
```


Use: 

```cs
// Catch the IOException generated if the // specified part of the file is locked. 
try{
	//...
}
catch(IOException e) 
{ 
	Console.WriteLine( "{0}: The write operation could not " + "be performed because the specified " + "part of the file is locked.", e.GetType().Name); 
}
``` 

[IOException](https://learn.microsoft.com/es-es/dotnet/api/system.io.ioexception?view=net-8.0)  is the base class for exceptions that happens while having access to data via sequences, files or directories. 
La biblioteca de clases base incluye los siguientes tipos, cada uno de los cuales es una clase derivada de `IOException` :

- [DirectoryNotFoundException](https://learn.microsoft.com/es-es/dotnet/api/system.io.directorynotfoundexception?view=net-8.0)
- [EndOfStreamException](https://learn.microsoft.com/es-es/dotnet/api/system.io.endofstreamexception?view=net-8.0)
- [FileNotFoundException](https://learn.microsoft.com/es-es/dotnet/api/system.io.filenotfoundexception?view=net-8.0)
- [FileLoadException](https://learn.microsoft.com/es-es/dotnet/api/system.io.fileloadexception?view=net-8.0)
- [PathTooLongException](https://learn.microsoft.com/es-es/dotnet/api/system.io.pathtoolongexception?view=net-8.0)

This exceptions can be use instead of <span style="color:#ababf5;">IOException</span> and all of them can be captured with it and the main base class <span style="color:orange;">exception</span> 

[IOException](https://learn.microsoft.com/es-es/dotnet/api/system.io.ioexception?view=net-8.0) usa el COR_E_IO HRESULT que tiene el valor 0x80131620.