#UNITY 

# How to detect device in New Input System

```CS
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.InputSystem; 
using UnityEngine.InputSystem.LowLevel; 
using UnityEngine.UIElements; 
public class InputDetector : MonoBehaviour 
{ 
	InputDevice m_LastInputDevice; 
	public GameObject m_ControlIndicator; 
	public Texture m_KeyboardTex; 
	public Texture m_GamepadTex; 
	private void OnEnable() 
	{ 
		InputSystem.onEvent += DetectInput; 
	} 
	private void OnDisable() 
	{ 
		InputSystem.onEvent -= DetectInput; 
	} 
	private void DetectInput(InputEventPtr eventPtr, InputDevice device) 
	{ 
		if (m_LastInputDevice == device) return; 
		if (eventPtr.type != StateEvent.Type) return; 
		
		bool validInput = false; 
		
		foreach(InputControl control in eventPtr.EnumerateChangedControls(device, 0.1f)) 
		{ 
			validInput = true; 
			break; 
		} 
		
		if(!validInput) { return; } 
		
		string deviceData = device.name + " " + device.displayName; 
		m_LastInputDevice = device; 
		
		if(device is Gamepad) 
		{ 
			Debug.Log("Gamepad: " + deviceData); 
			SetIndicatorTex(m_GamepadTex); 
		} 
		else if ( device is Mouse || device is Keyboard) 
		{ 
			Debug.Log("K&M: " + deviceData); 
			SetIndicatorTex(m_KeyboardTex); 
		} 
		else 
		{ 
			Debug.Log("Unknown: " + deviceData); 
		} 
	} 
	private void SetIndicatorTex(Texture tex) 
	{ 
		Renderer renderer = m_ControlIndicator.GetComponent<Renderer>(); 
		renderer.material.mainTexture = tex; 
	} 
}
```