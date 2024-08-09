### EditorWindow class not found

This error happens because unity thinks that this class will need to be imported into the build and because in the buid, unity editor libraried would not be included, throws this exception. 

To solve this, all scrits and assets that would only be used in the editor need to be in a folder called Editor/ so all inside that directory would be ignored in build. 

classes of unity editor are: 

```CSHARP 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 

public class StaticBatcherEditor : EditorWindow
{
    public void OnGUI()
    {
        
    }
}

```


Needs the using directive to include "UnityEditor". 
