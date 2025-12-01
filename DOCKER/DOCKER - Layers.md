#DOCKER 

# DOCKER - Layers

A docker layer is a snapshot of the filesystem changes that represent one steps in the image build (One Dockerfile instruction like RUN or COPY). 
Multiple layers are stacked into the final image filesystem that containers can use on container start. 

A Docker Image[^2] is made up of 1 or more layers and each one of them **store only the changes** from the layer bellow it. 

On **container run**, docker overlays all the image layers plus a top writable layer to present a unified filesystem. 

## Layers outcome 

Each layer represent the differences or changes in comparison with the previous one. 
Take into account that the outcome or layer is what ends at the execution of the instruction, so if an instruction creates a large file and deletes it at the end of the same instruction, this file it won't be part of the layer's outcome. 

> Note: On the other hand, is a file is created in an instruction and deleted in the next one, the generated file is stored in the image in the "creation layer" and the next layer stores the deletion change, increasing the image size. 
> So.... One single RUN instruction for this cases is better. 

## Writable layer

The writable layer exists as part of the container instance, separate from the read-only image layers.


# Layer immutability 

Docker layers are immutable, meaning that once a layer is created as part of an image it cannot be changed or modified. 
Each modification of the layer will result in another layer. 

Each Dockerfile[^1] instruction (like RUN, COPY or ADD) generates an immutable layer. 

Also improves the efficiency as the unchanged layers are cached and reused across images. 



[^1]: Dockerfile is the file that defines the layers and steps to create an docker image. [[Dockerfile]]
[^2]: Docker image is a set of layers that define an isolated application environment [[DOCKER - Images]]