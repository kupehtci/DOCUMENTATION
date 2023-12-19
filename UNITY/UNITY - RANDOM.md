### UNITY RANDOM CLASS 

There is the static class [`UnityEngine.Random`](https://docs.unity3d.com/ScriptReference/Random.html) and there is [`System.Random`](https://learn.microsoft.com/dotnet/api/system.random).

Since you have the

```csharp
using UnityEngine;
```

in your script but not

```csharp
using System;
```

for the compiler it is clear that you are referring to `UnityEngine.Random`.

---

Now you can either use explicitly

```csharp
var RndB = new System.Random();
var StrB = RndB.Next();
```

Or add a

```csharp
using Random = System.Random;
```

at the top of your script and then use what you have.

```csharp
var RndB = new Random();
var StrB = RndB.Next();
```

###### DIFFERENCES

The `UnityEngine.Random` is specifically made for `float` (`Random.value`). For `int` values you have to go via [`UnityEngine.Random.Range`](https://docs.unity3d.com/ScriptReference/Random.Range.html) and to get the same behavior as the `System.Random.Next` (which only returns positive values) you would have to rather do

```csharp
using UnityEngine;

...

var StrB = Random.Range(0, int.MaxValue);
```

[[CS - Random]]

