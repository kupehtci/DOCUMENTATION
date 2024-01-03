## EDITOR WINDOW MANUAL 



## Unavaliable methods

There are some methods that cannot be used while being in <span style="color:orange;">Edit Mode</span> and need to replace them with others: 

* <span style="color:#ababf5;">Destroy(Gameobject go)</span> needs to be replaced with <span style="color:#ababf5;">DestroyInmediate(GameObject go)</span>
	Can be solved by using: 
	
	```CSHARP 
	if (Application.isPlaying == false) {  
	    Object.DestroyImmediate(_combine);  
	}
	else {  
	    Object.Destroy(_combine);  
	}
	```

#### CODE EXAMPLE 

```CSHARP 
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/MyEditorWindow")]
    public static void ShowExample()
    {
        MyEditorWindow wnd = GetWindow<MyEditorWindow>();
        wnd.titleContent = new GUIContent("MyEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy
        Label label = new Label("Hello World!");
        root.Add(label);

        // Create button
        Button button = new Button();
        button.name = "button";
        button.text = "Button";
        root.Add(button);

        // Create toggle
        Toggle toggle = new Toggle();
        toggle.name = "toggle";
        toggle.label = "Toggle";
        root.Add(toggle);

    }
}```

## Selection.gameObjects

If you want to access the scene objects from the scripts of the editor window, one option is to acess `Selection.gameObjects` . 
This access the gameobjects that are selected in the editor. 
Is an array with all the gameobjects. 
