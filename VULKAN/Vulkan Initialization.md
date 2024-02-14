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