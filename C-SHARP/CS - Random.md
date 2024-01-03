#### RANDOM

The `Random`Class in csharp let you gerate a random value


##### RANDOM INT 

To generate a random int: 

```CSHARP
	Random random = new Random(); 
	int newRandomInt = random.Next(0,255); 
```

If going to use it in Unity take into account the two different classes: 

[[UNITY - Random]]

If you write Random and have also `using UnityEngine` and `using System` its going to have an _ambiguous conflict_. 
To avoid this, tell the compiler with Random are you specifiying with that word: 

```CSHARP
using Random = System.Random; 
```

This <span style="color:orange;">directive</span> tells the compiler that when you write <span style="color:ababf5;">Random</span> you are refering to <span style="color:ababf5;">System.Random</span> 