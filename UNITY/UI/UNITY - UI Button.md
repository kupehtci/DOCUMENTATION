#UNITY #CSHARP 

## Button UI Component




## Add OnClick Listener

Also the function that is executed when clicking in the button element can be set to a delegate using a <span style="color:#ababf5;">listener</span>. 

```CSHARP 
GameObject go; 

Button button = GetComponent<Button>(); 
go.GetComponent<Button>().onClick.AddListener(delegate { ButtonFunction(); });

public void ButtonFunction(){
	// Execute something...
}
```

This function would not be reflected in the Editor, as .OnClick() box would continue empty, but if we put some code in the function and click the button, we can make sure that the code is being executed. 