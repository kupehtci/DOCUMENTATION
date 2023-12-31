#CONCEPTS 


The simplest method to accelerate ray tracing can't necessarily be considered as an acceleration structure, however this is certainly the simplest way to cut down render times. Each one of the grid from the teapot has potentially more than a hundred triangles: with 8 divisions, the grid contains 128 triangles, which requires a similar number of intersection test for each ray cast into the scene. What we can do instead, is ray trace a box containing all the vertices of the grid. Such box is called a **bounding volume**:it is the tightest possible volume (a box in that case but it could also be a sphere) surrounding the grid. Figure 1 shows the bounding boxes of each one of the 32 Bézier patches making up the teapot model.

![[Captura de pantalla 2023-12-23 a las 14.55.30.png]]



---
#### REFERENCES
https://www.scratchapixel.com/lessons/3d-basic-rendering/introduction-acceleration-structure/bounding-volume.html