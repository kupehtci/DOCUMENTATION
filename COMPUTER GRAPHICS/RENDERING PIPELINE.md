#shaders 

The pipeline of shaders is the path that the data goes through from data into the rendererization into the screen when performing a <span style="color:orange;">rendering operation</span>. 


The next diagram shows the path of the render data. 
![[RenderingPipeline.png]] 
Each step in blue is programmable via shaders language. 


Once initiated, the pipeline operates in the following order:

## Vertex Processing

 Each vertex retrieved from the vertex arrays (as defined by the VAO) is acted upon by a [Vertex Shader](https://www.khronos.org/opengl/wiki/Vertex_Shader "Vertex Shader"). Each vertex in the stream is processed in turn into an output vertex.

##  Tesellation

Each vertex is subdivided into smaller primitives. 

##  Geometry

Controls the processing of Primitives. 
The output is a sequence of primitives.

## Vertex Post-Processing

he outputs of the last stage are adjusted or shipped to different locations.
    1. [Transform Feedback](https://www.khronos.org/opengl/wiki/Transform_Feedback "Transform Feedback") happens here.
    2. [Primitive Assembly](https://www.khronos.org/opengl/wiki/Primitive_Assembly "Primitive Assembly")
    3. Primitive [Clipping](https://www.khronos.org/opengl/wiki/Clipping "Clipping"), the [perspective divide](https://www.khronos.org/opengl/wiki/Perspective_Divide "Perspective Divide"), and the [viewport transform](https://www.khronos.org/opengl/wiki/Viewport_Transform "Viewport Transform") to window space.
6. [Scan conversion and primitive parameter interpolation](https://www.khronos.org/opengl/wiki/Rasterization "Rasterization"), which generates a number of [Fragments](https://www.khronos.org/opengl/wiki/Fragment "Fragment").
7. A [Fragment Shader](https://www.khronos.org/opengl/wiki/Fragment_Shader "Fragment Shader") processes each fragment. Each fragment generates a number of outputs.
8. [Per-Sample_Processing](https://www.khronos.org/opengl/wiki/Per-Sample_Processing "Per-Sample Processing"), including but not limited to:
    1. [Scissor Test](https://www.khronos.org/opengl/wiki/Scissor_Test "Scissor Test")
    2. [Stencil Test](https://www.khronos.org/opengl/wiki/Stencil_Test "Stencil Test")
    3. [Depth Test](https://www.khronos.org/opengl/wiki/Depth_Test "Depth Test")
    4. [Blending](https://www.khronos.org/opengl/wiki/Blending "Blending")
    5. [Logical Operation](https://www.khronos.org/opengl/wiki/Logical_Operation "Logical Operation")
    6. [Write Mask](https://www.khronos.org/opengl/wiki/Write_Mask "Write Mask")


## Rasterization 

In this stage of the graphics pipeline, the grid points are also called fragments, for the sake of greater distintiveness. Each fragment corresponds to one pixel in the frame buffer and this corresponds to one pixel of the screen.