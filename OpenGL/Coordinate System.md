
The GPU's coordinates of each vertex that it can handle are between -1.0 and 1.0.  (NDC or Normalized Device Coordinates) 
In order to handle coordinates in an spatial system that we define the most common format to transform to NDC (Normalised Device Coordinates) is to handle this transformation in the vertex shader and then this NDCs are given to the rasterizer to transform it to 2D or pixels on the screen. 

To do so in an optimal transformation that also give us the option to handle intermediate coordinate systems is to use 5 different coordinate systems: 

- Local space (or Object space)
- World space
- View space (or Eye space)
- Clip space
- Screen space

![[coordinate_systems.png]]

1. Local coordinates are the coordinates of your object relative to its local origin; they're the coordinates your object begins in.
2. The next step is to transform the local coordinates to world-space coordinates which are coordinates in respect of a larger world. These coordinates are relative to some global origin of the world, together with many other objects also placed relative to this world's origin.
3. Next we transform the world coordinates to view-space coordinates in such a way that each coordinate is as seen from the camera or viewer's point of view.
4. After the coordinates are in view space we want to project them to clip coordinates. Clip coordinates are processed to the `-1.0` and `1.0` range and determine which vertices will end up on the screen. Projection to clip-space coordinates can add perspective if using perspective projection.
5. And lastly we transform the clip coordinates to screen coordinates in a process we call viewport transform that transforms the coordinates from `-1.0` and `1.0` to the coordinate range defined by glViewport. The resulting coordinates are then sent to the rasterizer to turn them into fragments.

[LearnOpenGL - Coordinate Systems](https://learnopengl.com/Getting-started/Coordinate-Systems)