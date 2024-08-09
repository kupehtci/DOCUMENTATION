#Vulkan 

# Including the Vulkan and GLFW header files

To include the Vulkan header, define [GLFW_INCLUDE_VULKAN](https://www.glfw.org/docs/3.3/build_guide.html#GLFW_INCLUDE_VULKAN) before including the GLFW header.

```
#define GLFW_INCLUDE_VULKAN
#include <GLFW/glfw3.h>
```
If you instead want to include the Vulkan header from a custom location or use your own custom Vulkan header then do this before the GLFW header.
```
#include <path/to/vulkan.h>

#include <GLFW/glfw3.h>
```
Unless a Vulkan header is included, either by the GLFW header or above it, any GLFW functions that take or return Vulkan types will not be declared.

The `VK_USE_PLATFORM_*_KHR` macros do not need to be defined for the Vulkan part of GLFW to work. Define them only if you are using these extensions directly.

# Querying for Vulkan support

If you are linking directly against the Vulkan loader then you can skip this section. The canonical desktop loader library exports all Vulkan core and Khronos extension functions, allowing them to be called directly.

If you are loading the Vulkan loader dynamically instead of linking directly against it, you can check for the availability of a loader and ICD with [glfwVulkanSupported](https://www.glfw.org/docs/3.3/group__vulkan.html#ga2e7f30931e02464b5bc8d0d4b6f9fe2b).
```CPP
if (glfwVulkanSupported
{
	// Vulkan is available, at least for compute
}
```

This function returns `GLFW_TRUE` if the Vulkan loader and any minimally functional ICD was found.

If one or both were not found, calling any other Vulkan related GLFW function will generate a [GLFW_API_UNAVAILABLE](https://www.glfw.org/docs/3.3/group__errors.html#ga56882b290db23261cc6c053c40c2d08e) error.

---

For importing GLFW and link it using <span style="color:cyan;">Cmake</span>: 

* Download include folder with the following files: 
	* `glfw3.h`
	* `glfw3native.h` 
* Once this files are in the lib directory, in the root CMakeLists.txt: 

```LUA
set()
```
---
Gottem from: 
[GLFW Documentation](https://www.glfw.org/docs/3.3/vulkan_guide.html)

