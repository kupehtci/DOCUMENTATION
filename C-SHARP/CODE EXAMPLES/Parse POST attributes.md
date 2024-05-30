
### Parse POST attributes

This is a method to parse into Dictionary\<string, string\> an string containing various attributes or variables in post format `param1=value1&param2=value2`. 

It checks if its only a single value or more in order to treat it different. 

```csharp
public static Dictionary<string, string> ParsePostAttributes(string postAtts)  
{  
    if (postAtts.Length <= 1)  
    {        Console.WriteLine(" length less than 1");  
        return null;  
    }  
    Dictionary<string, string> dic = new Dictionary<string, string>();   
      
// Check if single attribute  
    if (postAtts.IndexOf("&") <= -1)  
	{        
		if (postAtts.IndexOf("=") <= -1) {  
			Console.WriteLine("Error siungle attrr");  
			return null;   
		}  
  
        string[] attribute = postAtts.Split("=", StringSplitOptions.RemoveEmptyEntries);  
        dic.Add(attribute[0], attribute[1]);  
        return dic;   
    }  
	// Get in multiple attributes
    string[] attributes = postAtts.Split("&");  
  
    foreach (string att in attributes)  
    {        
	    string[] split = att.Split("=", StringSplitOptions.RemoveEmptyEntries);  
        if (split.Length != 2)  
        {            
	        Console.WriteLine("Error double attrr: " + att + " current ");  
			return null; 
		}  
		dic.Add(split[0], split[1]);  
    }  
    return dic; 
    }
```