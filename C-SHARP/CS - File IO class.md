#CS #NET 

## System.IO File class

This class is used for dealing with file creation and writing. 


### File.Write() 

This function creates a new file if the specified file path dont exists. 


### Exceptions

This class throws IOException, that is the exception for I/O errors. As other exceptions, inherit from `exception` class. 

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

Take a look about exceptions in:  [[CS - Exceptions]]