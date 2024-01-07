#SHADERS 


## FLOW MAP CONCEPT

A flow-map shader animates the UV mapping by using a specially crafted texture encoded with velocity information


![[flow_map_1.webp]]

To understand the flow map, we need to understant the UV mapping and Textures. 

Unlike UV map is represented as an image, its not a texture, its a grid of vectors and its represented by using: 
* the color **RED** for X-axis 
* the color **GREEN** for Y-axis.

The brighter the colors the higher the axis value is. 

## USAGE


We usually use UV map from the graphics engine and use this information to figure out what color that pixel on the mesh is by directly using the UV coordinate to find a color from a texture. 
The flowmap simply adds a number to the UV coordinate so it’s accessing other pixels.

This flowmap simply _adds a number to the UV coordinate_ so it’s accessing other pixels.

Take a look into Medium post: [louisgamedev medium](https://louisgamedev.medium.com/shader-tutorial-flow-map-4410af832a8d)