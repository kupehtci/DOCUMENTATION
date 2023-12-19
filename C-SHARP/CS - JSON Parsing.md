#NET #CSHARP 

##### WRITING INTO FILE 

Once we have the json string, we need to copy that string into a file `.json` to store the data. 

For that we can use the <span style ="color:#9bcadd">File</span> class API from .Net. It can also be written using <span style="color:#c175ff">StreamWriter</span>. 
[[CSHARP - StreamWriter]]

For using  <span style ="color:#9bcadd">File</span> class, we need to add the library by `using System.IO`. 

```CSHARP 
[Serializable]
struct Vector3S{
	float x; 
	float y; 
	float z; 
	public Vector3S(float x, float y, float z){}
}

string jsonPath = (_sessionsFilePath + _fileName + session.ToString() + ".json");

string json = JsonUtility.ToJson(_dyslexiaMetrics, true);

try
{
	File.WriteAllText(jsonPath, json);
	
}
catch (Exception e)
{
	Debug.Log("Error saving data in pàth: " + jsonPath + " returned exception: " + e.Message);
}
```

If you want to 

#### EXAMPLE


