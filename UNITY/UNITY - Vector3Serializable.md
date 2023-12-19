### VECTOR 3 SERIALIZABLE CLASS 

#### SERIALIZABLE 

For being able to save or store an object inside a JSON, XML or other plain text storage or bynary format, the object needs to be seriable. 

This class let you save it, Serialize and Deserialize by Json or BinaryFormatter by C#

Since unity doesn't flag the Vector3 as serializable, we
 need to create our own version. This one will automatically convert between Vector3 and SerializableVector3. 
 
[System.Serializable]

```CSHARP
public struct SerializableVector3
{
	public float x;
	public float y;
	public float z;

	public SerializableVector3(float rX, float rY, float rZ)
	{
		x = rX;
		y = rY;
		z = rZ;
	}
	
	public override string ToString()
	{
		return String.Format("[{0}, {1}, {2}]", x, y, z);
	}
	
	/// <summary>
	/// Automatic conversion from SerializableVector3 to Vector3
	/// </summary>
	/// <param name="rValue"></param>
	/// <returns></returns>
	public static implicit operator Vector3(SerializableVector3 rValue)
	{
		return new Vector3(rValue.x, rValue.y, rValue.z);
	}
	
	/// <summary>
	/// Automatic conversion from Vector3 to SerializableVector3
	/// </summary>
	/// <param name="rValue"></param>
	/// <returns></returns>
	public static implicit operator SerializableVector3(Vector3 rValue)
	{
		return new SerializableVector3(rValue.x, rValue.y, rValue.z);
	}
}
```
