## INTRODUCTION 

How to get a reference to a lot of objects by only having the reference to the father  `gameObject` 

```CSHARP 
public GameObject _buttonGroup;
    public GameObject[] _buttons; 

    private void Start()
    {
        if (_buttonGroup == null) { Debug.Log("buttonGroup dont assigned"); return; }

        _buttons = new GameObject[_buttonGroup.transform.childCount]; 

        for(int i = 0; i < _buttonGroup.transform.childCount; i++)
        {
            _buttons[i] = _buttonGroup.transform.GetChild(i).gameObject;   
        }
    }
```