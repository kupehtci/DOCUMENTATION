#UNITY #CSHARP 

This attributes adds as add-ons or modifiers for a function functionality. 

#### AddComponentMenu

The AddComponentMenu attribute allows you to place a script anywhere in the "Component" menu, instead of just the "Component->Scripts" menu.

You use this to organize the Component menu better, this way improving workflow when adding scripts. Important notice: You need to restart.

```CSHARP
AddComponentMenu
public class FollowTransform : MonoBehaviour
{
	//Some Code
}
```