#### IDragHandler threshold 

By default the Handler for dragging UI Items makes a threshold, making that if you click the object by the corner, it will be grabbed from that pixel and do not snap to the center of the position. 

To deactivate this: 
```CSHARP
	void OnInitializePotentialDrag(EventData eventData){
		eventData.useDragThreshold = false; 
	}
```

This function is called when a potential drag is expected. 
OnInitializePotentialDrag set eventData.useDragThreshold = false
