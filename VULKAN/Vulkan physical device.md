#VULKAN 


Once we have the initialization and validation layers, we  need to get if the physical device or GPU of the device is actually suitable for Vulkan usage. 

For doing this, the basic structure of the code is: 

```pseudocode
Enumerate devices

for each device: 
	Get device properfies
	Evaluate if device is suitable
```



The properties can be retreived with `vkGetPhysicalDeviceProperties(device, &deviceProperties)` but for extra features avaliable like 64 bits compression, to check tha textra features ``


`VkPhysicalDeviceFeatures deviceFeatures` and `VkBool32 geometryshader` is true if GPU can render geometry shader in Vulkan API. 

