#SHADERS

## <span style="color:#2f4f4f;">CONCEPTS</span>

To make an object disolve in particles, it can be divides into each <span style="color:MediumSpringGreen;">triangle</span> that conforms the mesh and displace it. 

To calculate a direction of movement for each triangle we use a <span style="color:orange;">flow map</span> that defines a grip of 2D vector for different points. [[SHADERS - Flow map]]

This process is made in the <span style="color:MediumSpringGreen;">geometry shader</span>. 

For more information about the render pipeline: [[RENDERING PIPELINE]]


## Movement of the primitives

To be able to move the different triangles of the mesh we can use a flow map to displace each of them by the vector of the flow map. 

```SHADERS

```





