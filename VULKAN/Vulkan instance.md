#VULKAN 

The instance is the connection between your application and the Vulkan library and creating it involves specifying some details about your application to the driver.

Create application info: 
```C++
VkApplicationInfo appInfo{}; 
appInfo.sType = VK_STRUCTURE_TYPE_APPLICATION_INFO; 
appInfo.pApplicationName = "Hello Triangle"; 
appInfo.applicationVersion = VK_MAKE_VERSION(1, 0, 0); 
appInfo.pEngineName = "No Engine"; 
appInfo.engineVersion = VK_MAKE_VERSION(1, 0, 0); 
appInfo.apiVersion = VK_API_VERSION_1_0;
```

A lot of information in Vulkan is passed through structs instead of function parameters and we'll have to fill in one more struct to provide sufficient information for creating an instance: 

`CreateInfo` structure is not optional. 
This tells Vulkan driver which global extensions and validation layers are going to be used.
This structs is returned by Vulkan to tell the program in order to deal with the windowing system, which <span style="color:orange;">global extension its need</span>. 

```C++
VkInstanceCreateInfo createInfo{};
createInfo.sType = VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO; createInfo.pApplicationInfo = &appInfo;


uint32_t glfwExtensionCount = 0; 
const char** glfwExtensions; glfwExtensions = glfwGetRequiredInstanceExtensions(&glfwExtensionCount); createInfo.enabledExtensionCount = glfwExtensionCount; createInfo.ppEnabledExtensionNames = glfwExtensions;
```


By doing `glfwGetRequiredInstanceExtensions($num_instance_extension_required)` we get as result in this `int` passed by reference the number of extensions that are needed. 






