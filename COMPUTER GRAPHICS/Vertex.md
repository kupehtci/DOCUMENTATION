#SHADER

# Vertex (geometry)

 In geometry, a vertex is a point where two or more curves, lines, or edges meet. As a consequence of this definition, the point where two lines meet to form an angle and the corners of polygons and polyhedra are verices. ([Vertex (geometry) — Wikipedia](https://en.wikipedia.org/wiki/Vertex_(computer_graphics)))

![](https://miro.medium.com/v2/resize:fit:960/1*pGQbzjDGmB-t6OfZi58hbw.png)

[[Vertex(Geometry)]]
# Vertex (computer graphics)

A vertex in computer graphics is a data structure that describes certain attributes, like the position of a point in 2D or 3D space, or multiple points on a surface.

## **_Application to 3D models_**

3D models are most often represented as triangulated polyhedra forming a triangle mesh. Non-triangular surfaces can be converted to an array of triangles through tessellation. Attributes from the vertices are typically interpolated across mesh surfaces.

## **_Vertex attributes_**

The vertices of triangles are associated not only with spatial position but also with other values used to render the object correctly. Most attributes of a vertex represent vectors in the space to be rendered. These vectors are typically 1(x), 2(x,y), 3(x,y,z) dimensional and can include a fourth homogeneous coordinate (w). These valuse are given meaning by a material description. In realtime rendering these properties are used by a vertex shader or vertex pipeline.

such attributes can include:

<span style="color:orange;">Position</span>: 2D or 3D coordinates representing a position in space

<span style="color:orange;">Color</span>:  Typically diffuse of specular RGB values, either representing surface colour or pre-computed lighting information.

<span style="color:orange;">Texture coordinates</span> Also known as UV coordinates, these control the texture mapping of the surface, possibly for multiple layers.

Also: 
normal vectors, tangent vectors, Blend weights, Blend shapes…