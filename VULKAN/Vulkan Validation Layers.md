#VULKAN 


### Vulkan Validation Layers

Because the minimalism of the Vulkan API by itself, its also minimalist in the debugging and error checking option. 

In other hand, this error checks can be added manually to the API, by a elegant system called <span style="color:LightSeaGreen;">validation layers</span>. 

Common operations are: 

* Checking the values of parameters against the specification to detect misuse
- Tracking creation and destruction of objects to find resource leaks
- Checking thread safety by tracking the threads that calls originate from
- Logging every call and its parameters to the standard output
- Tracing Vulkan calls for profiling and replaying

This layers can be freely stacked to implement all the debugging functionality.

It implements a layer of false functions: 

```CPP
VkResult vkCreateInstance( const VkInstanceCreateInfo* pCreateInfo, const VkAllocationCallbacks* pAllocator, VkInstance* instance) 
{ 
if (pCreateInfo == nullptr || instance == nullptr)
{ 
	log("Null pointer passed to required parameter!"); 
	return VK_ERROR_INITIALIZATION_FAILED; 
} 
return real_vkCreateInstance(pCreateInfo, pAllocator, instance); 
}
```

### Implementation


The most complete and useful validation is bundled into the `VK_LAYER_KHRONOS_validation` layer. 

```CPP
const std::vector<const char*> validationLayers = { "VK_LAYER_KHRONOS_validation" };
```

---
Take a look into vulkan tutorial: 
https://vulkan-tutorial.com/en/Drawing_a_triangle/Setup/Validation_layers