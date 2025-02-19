#OpenGL 

# OpenGL Glossary

vector

A value composed of an ordered sequence of other values. The number of values stored in a vector is its dimensionality. Vectors can have math operations performed on them as a whole.

scalar

A single, non-vector value. A one-dimensional vector can be considered a scalar.

vector position

A vector that represents a position.

vector direction

A vector that represents a direction.

vector component

One of the values within a vector.

component-wise operation

An operation on a vector that applies something to each component of the vector. The results of a component-wise operation is a vector of the same dimension as the input(s) to the operation. Many vector operations are component-wise.

unit vector

A vector who's length is exactly one. These represent purely directional vectors.

vector normalization

The process of converting a vector into a unit vector that points in the same direction as the original vector.

pixel

The smallest division of a digital image. A pixel has a particular color in a particular colorspace.

image

A two-dimensional array of pixels.

rendering

The process of taking the source 3D world and converting it into a 2D image that represents a view of that world from a particular angle.

rasterization

A particular rendering method, used to convert a series of 3D triangles into a 2D image.

geometry, model, mesh

A single object in 3D space made of triangles.

vertex

One of the 3 elements that make up a triangle. Vertices can contain arbitrary of data, but among that data is a 3-dimensional position representing the location of the vertex in 3D space.

clip space, clip coordinates

A region of three-dimensional space into which vertex positions are transformed. These vertex positions are 4 dimensional quantities. The fourth component (W) of clip coordinates represents the visible range of clip space for that vertex. So the X, Y, and Z component of clip coordinates must be between [-W, W] to be a visible part of the world.

In clip space, positive X goes right, positive Y up, and positive Z away.

Clip-space vertices are output by the vertex processing stage of the rendering pipeline.

clipping

The process of taking a triangle in clip coordinates and splitting it if one or more of its vertices is outside of clip space.

normalized device coordinates

These are clip coordinates that have been divided by their fourth component. This makes this range of space the same for all components. Vertices with positions on the range [-1, 1] are visible, and other vertices are not.

window space, window coordinates

A region of three-dimensional space that normalized device coordinates are mapped to. The X and Y positions of vertices in this space are relative to the destination image. The origin is in the bottom-left, with positive X going right and positive Y going up. The Z value is a number on the range [0, 1], where 0 is the closest value and 1 is the farthest. Vertex positions outside of this range are not visible.

scan conversion

The process of taking a triangle in window space and converting it into a number of fragments based on projecting it onto the pixels of the output image.

sample

A discrete location within the bounds of a pixel that determines whether to generate a fragment from scan converting the triangle. The area of a single pixel can have multiple samples, which can generate multiple fragments.

fragment

A single element of a scan converted triangle. A fragment can contain arbitrary data, but among that data is a 3-dimensional position, identifying the location on the triangle in window space where this fragment originates from.

invariance guarantee

A guarantee provided by OpenGL, such that if you provide binary-identical inputs to the vertex processing, while all other state remains exactly identical, then the exact same vertex in clip-space will be output.

colorspace

The set of reference colors that define a way of representing a color in computer graphics, and the function mapping between those reference colors and the actual colors. All colors are defined relative to a particular colorspace.

shader

A program designed to be executed by a renderer, in order to perform some user-defined operations.

shader stage

A particular place in a rendering pipeline where a shader can be executed to perform a computation. The results of this computation will be fed to the next stage in the rendering pipeline.

OpenGL

A specification that defines the effective behavior of a rasterization-based rendering system.

OpenGL context

A specific set of state used for rendering. The OpenGL context is like a large C-style struct that contains a large number of fields that can be accessed. If you were to create multiple windows for rendering, each one would have its own OpenGL context.

object binding

Objects can be bound to a particular location in the OpenGL context. When this happens, the state within the object takes the place of a certain set of state in the context. There are multiple binding points for objects, and each kind of object can be bound to certain binding points. Which bind point an object is bound to determines what state the object overrides.

Architectural Review Board

The body of the Khronos Group that governs the OpenGL specification.

OpenGL Implementation

The software that implements the OpenGL specification for a particular system.


### References

Taken from: [Glossary](https://nicolbolas.github.io/oldtut/Basics/Intro%20Glossary.html)

