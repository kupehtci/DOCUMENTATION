#VULKAN 


GLFW will instantly initialize OpenGL as required. 
To void we need to tell it, after we initialize it to don't create it by the following call: 
```CPP
glfwWindowHint(GLFW_CLIENT_API, GLFW_NO_API);
```

If we want the window to be resizeable, this need to be taken into special consideration. We also need to tell Vulkan that the window size won't be constant: 

```CPP
glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);
```

After the configuration is done, window can be created and store a reference to it using `GLFWwindow` pointer: 

```cpp
//GLFWwindow window = glfwCreateWindow(width: 800, height: 600, title:"Vulkan", monitor: nullptr, share: nullptr);

GLFWwindow window = glfwCreateWindow(800, 600, "Vulkan", nullptr, nullptr);

//share parameter is only useful for OpenGL and monitor is to open the window using a monitor reference
```

To keep the application running until either an error occurs or the window is closed, we need to add an event loop to the `mainLoop` function as follows.  

This functions keeps updating during the `while()` until close button is pressed or an error occur: 

```cpp
while (!glfwWindowShouldClose(window)) 
{ 
	glfwPollEvents(); 
}
```

Once you have the window, the following is to create an instance to be able to use the Vulkan Library: 

[[Vulkan instance]]