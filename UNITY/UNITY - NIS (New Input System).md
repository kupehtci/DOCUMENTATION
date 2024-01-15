#UNITY 

### NEW INPUT SYSTEM

The new input system for Unity let you handle the input from various devices through a map that captures each key / button / joystick interaction and transform into a callback that can be captured via script. 

![[InputActionsNSI.png]]

Typically, there are six main parts to the new Input System:

- [**Input Actions Assets**](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#input_action_assets) – which store sets of Control Schemes, Action Maps, Actions and their Bindings.
- [**Control Schemes**](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#control_schemes) – which define device combinations that the player can use (e.g. keyboard and mouse, gamepad etc.).
- [**Action Maps**](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#action_maps) – which separate different types of activity  (e.g. Menu Controls, Gameplay, Driving).
- [**Actions**](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#actions) – single events that will trigger functions in the scene (e.g. Jump, Fire, Move)
- [**Bindings**](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#bindings) – the physical controls, specific to a Control Scheme, that will trigger Actions (e.g. spacebar, left stick etc.).
- [**Player Input Component**](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#player_input_component) – which can be used to connect all of the above to a player object

### INPUT ACTION ASSET

You cannot modify Input action system directly from project settings, needs to be done by <span style="color:orange;">creating an asset</span>

Instead, **Input Action Assets**, which can contain an entire set of inputs and controls, sit in your project as an asset.

So, before you can get started you’ll need to create one.

To do that, right-click in the Project window and click **Create > Input Actions**, or select **Assets > Create > Input Actions** from the menu.

Mark <span style="color:cyan;">auto-save</span> to don't need to save each time you make a change to input action. 

![[auto_save_input_actions 1.png]]
### ACTIONS

For each Input Action map you need to define some <span style="color:#db7093;">Actions</span> that define certain actions and in them needs to be defined how this action is captured. 

Each action is defined by its type: 

* <span style="color:#ababf5;">Value</span> default action type used for actions that need to track continuous changes in the stream. This type monitor the controls associated to the input. 
* <span style="color:#ababf5;">Button</span> similar to Value but can only have assigned <span style="text-decoration:underline;">ButtonControl</span> values and don't perform an initial check. Used for inputs that trigger an action when they are pressed like shooting. 
* <span style="color:#ababf5;">Pass-through</span> Same as value but don't trigger the <span style="color:orange;">Conflict resolution</span>. This means that any change to any bounded Controller would trigger the callback associated. This is useful if you want to process all input from a set of Controls.

 If a different bound Control actuated more, then that Control becomes the Control driving the Action, and the Action starts reporting values from that Control. This process is called conflict resolution