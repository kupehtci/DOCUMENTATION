#VULKAN 

### Vulkan queue families

Every operation commands in Vulkan, from drawing up to upload textures, requires the commands to be submitted into a <span style="color:orange;">queue</span>. 
There are different types of queues and each type allows only a subset of commands


Firstly we need to check which family queues are allowed by the device [[Vulkan physical device]] used. 
