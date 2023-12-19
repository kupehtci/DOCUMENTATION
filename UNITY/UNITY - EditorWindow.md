## EDITOR WINDOW MANUAL 


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
