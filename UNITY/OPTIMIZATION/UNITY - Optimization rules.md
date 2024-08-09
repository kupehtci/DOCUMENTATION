#UNITY 
# MULTIPLATFORM LAB -  RULES OF THUMB 

A **rule of thumb** is a rule, principe or guideline that is based on practical experience rather than strict or precise calculation. 

#### MIPMAPS 

For objects that have an invariant Z-depth relative to the [Camera](https://docs.unity3d.com/Manual/CamerasOverview.html)  
[__](https://docs.unity3d.com/Manual/Glossary.html#Camera), it is possible to disable mipmaps to save about a third of the memory required to load the Texture.
If an object changes Z-depth, disabling mipmaps can lead to worse Texture sampling performance on the GPU.

In general, this is useful for [UI](https://docs.unity3d.com/Manual/UI-system-compare.html)  Textures and other Textures that are displayed at a constant size on screen.

#### ROF - AUDIO

Audio extension files:
> .mp3 
> .ogg 
> .wav    -    discard it for videogames

Take into account that for smartphone development, use mono audio is recommendable because the stereo use in videogames is not as relevant as it can be 

#### ROF - STRING AND TEXT

One of the core performance problems often found in string-related code is the unintended use of the slow, default string APIs.
These APIs were built for business applications, and attempt to deal with handling strings from many different cultural and linguistic rules with regards to the characters found in text. 

Example of string use in an API: 
```csharp
	String.Equals("encyclopedia", “encyclopædia”);
```

Benchmark in string use: 

| Method |  Time in ms |
|---------|------------|
| String.StartsWith() | 137|
| String.EndsWith() | 542|
| Custom StartsWith() and EndsWith() | 4.5|


The custom methods can be created as: 

```csharp
	public static bool CustomEndsWith(this string a, string b) 
	{ 
		int ap = a.Length - 1; 
		int bp = b.Length - 1; 
		while (ap >= 0 && bp >= 0 && a [ap] == b [bp]) 
		{ 
			ap--; 
			bp--; 
		} 
		return (bp < 0); 
	} 
		
	public static bool CustomStartsWith(this string a, string b) 
	{ 
		int aLen = a.Length; 
		int bLen = b.Length;
		int ap = 0; 
		int bp = 0; 
		
		while (ap < aLen && bp < bLen && a [ap] == b [bp]) 
		{ 
			ap++; 
			bp++; 
		} 
		
		return (bp == bLen); 
	}
```
 

#### XML, JSON and other long-form text parsing

Parsing is a heavy operation. 

#### CREATE YOUR OWN MEMORY 

The usage of non allocated physics methods, have a main difference: 
> They don't allocate their own memory, you need to pass them by reference the memory that they are going to use. 
> This is made to avoid that if the method is called 100 times consequently, allocates 100 times another similar space of memory

```csharp
	void foo(void){int[] new_array = new int[10]; /*...*/}
	void foo(int[] allocated_mem){/*...*/}

	int[] int_array = new int[10];
	
	for(x = 0; x < 100; x++){
		foo();                     // Creates 100 arrays of int
		foo(int_array);            // Uses the created one and only created 1 
	}
```

Replace [RaycastAll](https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html) calls with [RaycastNonAlloc](https://docs.unity3d.com/ScriptReference/Physics.RaycastNonAlloc.html), [SphereCastAll](https://docs.unity3d.com/ScriptReference/Physics.SphereCastAll.html) calls with [SphereCastNonAlloc](https://docs.unity3d.com/ScriptReference/Physics.SphereCastNonAlloc.html), and so on. For 2D applications, there are also non-allocating versions of all Physics2D query APIs.
#### FIND 

Dont use [GameObjetct.Find()](https://docs.unity3d.com/ScriptReference/GameObject.Find.html) and [Object.FindObjectOfType()](https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html) in production code, as these functions require to iterate over all gameobjects and components stored in memory. 

#### DEBUG CODE & THE <span style="color:#c175ff;">CONDITIONAL</span> ATTRIBUTE


If a function is called, the local variables that are being used are stored in the **call stack** for posterior use. 
Is inside the function there are no code due to `debug`is not defined, these movement of parameters into the call stack is made for nothing. 

```csharp 
public void Log(string msg){
	#if DEBUG 
		Debug.Log(msg); 
	#endif 
}

// Call stack is called
Log("Error"); 
// Call stack is restored
```

```csharp 
	public static class Logger{
		[Conditional("ENABLE_LOGS")]
	
		public static void Debug(string log_msg){
			UnityEngine.Debug.Log(log_msg);
		}
	}
```
By decorating these methods with the [Conditional] attribute, the define or defines used by the Conditional attribute determine whether the decorated method is included in the compiled source.

If none of the defines passed to the Conditional attribute are defined, then the decorated method _and_ all calls to the decorated method are compiled out. The effect is identical to what would happen if the method and all calls to the method were wrapped in `#if … #endif` preprocessor blocks.

For more information on the `Conditional` attribute, see the MSDN website: [msdn.microsoft.com](https://msdn.microsoft.com/en-us/library/4xssyw96(v=vs.90).aspx).


#### INSTANTIATE 

Instantiate is expensive in `Unity`: 
* Garbage collector -> Allocate memory and gets empty and then the `garbage collector` needs to check and delete 
* Memory Fragmentation -> 
* Access to disk -> need to bring the object from disk to RAM and cache to be able to instantiate it. 
Rendering new objects
Initialization -> each of the functions in the object as `Start()`, `Awake()`, `OnEnable()`...
Added into physics. 
Native vs Managed code. 

Call a method outside my class and maybe will result into cache location error that derive into memory drive to be accessed. 

