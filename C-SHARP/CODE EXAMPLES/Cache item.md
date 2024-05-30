You can build a basic expirable cache item that holds `Generic` data with this class: 

It also contains useful DateTime methods[^1] that can help to check if the item has expired: 

```csharp 

namespace HTTP_NET_Project;  
  
public class CacheItem<T>  
{  
    public uint Id;   
private static uint _avaliableId= 0;  
    private DateTime _creationTime;  
    private DateTime _expirationTime;  
    private T _data;  
  
    public CacheItem()  
    {        Id = _avaliableId;  
        _avaliableId++;  
  
        _data = default(T);   
          
_creationTime = DateTime.Now;  
        _expirationTime = DateTime.MaxValue;  
    }  
    public CacheItem(T data)  
    {        Id = _avaliableId;  
        _avaliableId++;  
  
        _data = data;   
          
_creationTime = DateTime.Now;  
        _expirationTime = DateTime.MaxValue;  
    }    // --------------- GETTERS AND SETTERS ---------------  
    public T GetData()  
    {        return _data;   
    }  
  
    public static CacheItem<T> NonExpirableCacheItem(T data)  
    {        CacheItem<T> newCacheItem = new CacheItem<T>();  
        newCacheItem._data = data;  
        return newCacheItem;   
    }  
  
    public static CacheItem<T> ExpirableCacheItem(T data, int timeSpanInSeconds)  
    {        CacheItem<T> newCacheItem = new CacheItem<T>();  
        newCacheItem._data = data;  
        newCacheItem._creationTime = DateTime.Now;  
        newCacheItem._expirationTime = DateTime.Now.AddSeconds(timeSpanInSeconds);   
return newCacheItem;   
    }  
  
    public bool HasExpired()  
    {        return DateTime.Compare(DateTime.Now, _expirationTime) > 0;   
    }  
}
```

---
[^1]: Date time class and methods explanation[[CS - DateTime]]