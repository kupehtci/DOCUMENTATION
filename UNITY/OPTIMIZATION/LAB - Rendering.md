#UNITY 

Rendering is expensive. This is because, for a 1920x1080p screen, for each pixel, the fragment shader is executed. 
This means that for a single frame, is executed 2,000,000 times, and this is handled by the GPU 


## Drawcall (BATCHES)

Drawcalls are expensive, and the most effective way to optimize it is to reduce their number and make them in the correct order with optimization purpose. 
The <span style="color:orange;">method</span> of reducing the <span style="color:orange;">drawcalls</span> called batching. [[BATCHING]]
Drawcall is not the same as Pass. 

Drawcall is composed of <span style="color:#db7093;">Mesh + Shader + Material + Others</span>. 
* Mesh  = vertices and indices [[Vertex]]
* Shaders [[Lit Shaders[[UnLit Shaders]]]]
* Materials = Blend, depth, culling, modes, uniforms, textures
* Others = Render targets, transformation, matrices, lightning

This is treated by the render pipeline [[RENDERING PIPELINE]]

---
## Rendering methods

![Rendering methodologies, Forward vs Deferred](https://i.imgur.com/rxTYLGv.png)

### **Forward**
>A cube and a sphere and a directional light. 
  Firstly draw with a pass the cube with the light and then another time with the sun light. And then the same for the sphere. 
  For calculating the shadows of each object into anothers, shadows are calculated first in the shadow map and then is taken into account when rendering the objects light. 
  
num-renders = num_objects * num_lights

### **Deferred**

Same situation, sphere and cube and 2 lights. 
Firstly cube and sphere are calculated and them the lights are calculated. 

>You defer to perform the lighting calculations until after the scene's geometry fragments have been culled or discarded and then with the culled. 
>Calculed in two phases. Firstly the positions, depths, normals and materials are rendered into a framebuffer called **Geometry Buffer** or **G-buffer** 

num_renders = num_object + num_lights; 

### **Ray-Tracing**

