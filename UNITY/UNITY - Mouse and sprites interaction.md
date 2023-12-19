#CSHARP #UNITY 

If you are using sprite elements in the game and need to detect whether the mouse click them and drag them you can implement a `draggable item` this way: 

```CSHARP

private Vector2 GetMousePosition()  {    
	return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);  
}    
    
private void Awake()  {    
	_originalPosition = transform.position;    
	Debug.Log("awake");  
}        
    
private void Update()  {    
	if (!_dragging) return;    
	    
	this.transform.position = GetMousePosition();  
}    
    
void OnMouseDown()  {    
	_dragging = true;    
	Debug.Log("Clicked");  
}    
    
void OnMouseUp()  {    
	_dragging = false;    
	    
	this.transform.position = _originalPosition;    
	Debug.Log("Released");  
}
```

By using <span style="color:orange;"> GetMousePosition()</span> the input in terms of screen position, get projected into word position. Because we are interacting with <span style="color:#ababf5;">sprites</span> we want as return a Vector2D. 

