
The difference between IEndDragHandler and IDropHandler is that: 
* IEndDragHandler is called in the draggable object when the drag ends
* IDropHandler is called in the object in the position where the drag ends

For not blocking the detection of the drop obejct, raycasting in the draggable one needs to be deactivated. 

For doing this you need to add a CanvasGroup component. This component let you assign certain properties to an UI Element and its children, like the alpha 

![[canvas_group_component.png]]

With this component you need to disable the blockRaycasts to let the raycast pass through it to the slot object. 
Using `_canvasGroup.blocksRaycasts = false; ` and reactivate it when ends the drag. 

How to implement it: 

```CSHARP
	private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>(); 
    }
	public void OnBeginDrag(PointerEventData eventData)
    {
        _dragging = true;
        _canvasGroup.alpha = 0.6f; 
        _canvasGroup.blocksRaycasts = false; 
        Debug.Log("Begin drag"); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Is dragging ");
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragging = false;
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true; 
        Debug.Log("End dragging"); 
    }
```



The functions are implementation of the [[UNITY - Event system interfaces]]

