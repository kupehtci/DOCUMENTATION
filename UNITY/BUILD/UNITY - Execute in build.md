
### Execute code after build

One method to execute some code and get an output of the execution is using the <span style="color:orange;">interface</span> `IPreprocessBuildWithReport`. 

This class is an interface that needs to implement the method <span style="color:#ababf5;">OnPreprocessBuild(BuildReport report)</span>. 

```CSHARP 
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

class MyCustomBuildProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        Debug.Log("MyCustomBuildProcessor.OnPreprocessBuild for target " 
        + report.summary.platform + " at path " + report.summary.outputPath);
    }
}
```


### Execute code before build

In a similar way, an interface can be implemented to have a method that <span style="color:#ababf5;">receive a callback</span> when the build has been completed. 

```CSHARP
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

class MyCustomBuildProcessor : IPostprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPostprocessBuild(BuildReport report)
    {
        Debug.Log("MyCustomBuildProcessor.OnPostprocessBuild for target " 
        + report.summary.platform + " at path " + report.summary.outputPath);
    }
}
```


### Take into account

When using this <span style="color:orange; ">Interfaces</span>, the implementation of them need to be placed in `Editor/` folder. 
This is made because needs to import: `using UnityEditor;` and this library is only avaliable inside the Editor and not compiled when making a build. 