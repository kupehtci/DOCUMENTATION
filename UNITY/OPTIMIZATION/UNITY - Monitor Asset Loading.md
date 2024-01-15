#UNITY 

# MONITOR ASSET LOADING 

Use the [AsyncReadManagerMetrics](https://docs.unity3d.com/ScriptReference/Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics.html) class to monitor runtime asset loading and file reading performance. This class records data about all the file read operations managed by the [AsyncReadManager](https://docs.unity3d.com/ScriptReference/Unity.IO.LowLevel.Unsafe.AsyncReadManager.html). 

The Unity Engine uses the [AsyncReadManager](https://docs.unity3d.com/ScriptReference/Unity.IO.LowLevel.Unsafe.AsyncReadManager.html) to read most files at runtime. The files loaded with the AsyncReadManager include AssetBundles, Addressables and Resources. In addition, you can load files from scripts using [AsyncReadManager.Read](https://docs.unity3d.com/ScriptReference/Unity.IO.LowLevel.Unsafe.AsyncReadManager.Read.html).

Enabling the record of the metrics, needs to start the monitor: 

```csharp 
	#if ENABLE_PROFILER && UNITY_2020_2_OR_NEWER
		AsyncReadManagerMetrics.StartCollectingMetrics(); 
	#endif
```

Once you have record the desired data, can be read from the monitor: 

```csharp
	#if ENABLE_PROFILER && UNITY_2020_2_OR_NEWER 
		AsyncReadManagerRequestMetric[] metrics = AsyncReadManagerMetrics.GetMetrics(AsyncReadManagerMetrics.Flags.ClearOnRead); 
	#endif
```

You can collect this data from the `AsyncReadManagerRequestMetric` class: 
- Average bandwidth
- Average read size
- Asset type with longest load time
- Number of reads
- Number of requests
- Total bytes read*

## AsyncReadManagerMetrics

This class let you gather the metrics from the reading and loading resources by calling `GetMetric` method. 


