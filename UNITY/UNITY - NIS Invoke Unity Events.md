#UNITY 

Once you have the New input system configured, the best way to use the inputs captures is to link them to Unity Methods. 

### PLAYER INPUT

You need to link the Action that is called through its bindings with the <span style="color:cyan;">Unity Method</span>. This linking of the callback with the Event can be done with the <span style="color:#a9fcc5;">Player Input Component</span>. 

In the events -> player section you can find the different InputAction Map Actions defined. This actions needs to be assigned with a GameObject and one function that is inside this gameObject. 

![[Player_Input_Component.png]]
### INVOKE UNITY METHODS

To trigger methods or get data from controls when using this method, you’ll need to configure the functions in your script to accept a different data type, **the Callback Context**. 

<span style="color:cyan;">Callback context</span> is a data type that provides information that can be passes through a <span style="color:orange;">callback</span> and in this case is passed what triggered an Action.

```CS
public void Move(InputAction.CallbackContext value)
{
	moveVal = value.ReadValue<Vector2>();
	transform.Translate(new Vector3(moveVal.x, moveVal.y, 0));
}
```

With the <span style="color:cyan;">Callback context</span> you can retrieve bindings information by using `callback_context.ReadValue\<ValueType\>();`
