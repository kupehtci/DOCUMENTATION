## INTRODUCTION 

Notes about how to use UI Dropdown with <span style="color:red"> Text Mesh Pro</span>. 

This dropdown lets you select between an option. 
To **handle** this selector dropdown with code, can be done though its variables.

The class can be referenced in code as: 

```CSHARP 
TMP_Dropdown _dropdown = null;
```


#### ASIGN DINAMICALLY LABELS

Labels can be statically created by hand in the editor in the <span style="color:red">Dropdown - TextMeshPro Component</span>. 
Other way to add the `Options` is adding by code. The dropdown object has a list with all the
<span style="color:#b042ff"> labels </span>

```CSHARP 
[SerializeField]
    private MetricsController _metricsController = null;

    [SerializeField]
    private TMP_Dropdown _dropdownSelector = null;


    private void Start()
    {
        if (_dropdownSelector == null) { Debug.Log("_dropdown selectot not assigned in go: " + this.name); return; }
        _dropdownSelector.options.Clear();

        _metricsController = MetricsController.instance;


        foreach (DislexiaMetrics dm in _metricsController._dislexiaMetrics)
        {
            _dropdownSelector.options.Add(new TMP_Dropdown.OptionData(dm._playerName));
        }

    }
```

Each label is a `TMP_Dropdown.OptionData` and can be declared with a string as label text: 

```CSHARP 
// Declare with label text 
TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData("Option A"); 

// Declare with name and sprite
[SerializeField]
private Sprite spr1; 
TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData("Option A", spr1); 
```

### EXAMPLE

Because `options` is a list, items can be appended or added dynamically in <span style="color:#e1affd">runtime</span>. 

```CSHARP
TMP_Dropdown _dropdown = ...;
_dropdown.options.Add(new TMP_Dropdown.OptionData("Daniel")); 
_dropdown.options.Add(new TMP_Dropdown.OptionData("Marta")); 
```

The dropdown now has two more options inserted as labels. 

![[Unity dropdown example.png]]


To clear this labels, taking into account that is a list, can be cleared like that using: 
```CSHARP 
_dropdown.options.Clear();
```

With the labels inserted, take into account the order of insertion and the value assigned to them is following this order. 

In this case, due to that inserted items in that order

<div style="border: 1px solid white; padding: 0.5rem; margin 1rem 0rem 0rem 1rem; "> 
<ol>
	<li>OptionA -> index 0</li>
	<li>Daniel    -> index 1</li> 
	<li>Marta     -> index 2</li> 
</ol>
</div>

Marta follow that order and when that <span style="color:#e1affd">label</span> is selected, `_dropdown.value = 2`

![[dropdown_value_example.png]]

#### LABEL SELECTED 

When clicked in the dropdown, a menu with many labels get displayed and you can select between each other. 
To detect with label is currently selected, can be access via `value`attribute. 

```CSHARP 
int valueSelected = _dropdownSelector.value; 
```


