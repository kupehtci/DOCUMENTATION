#SHADERS 


## <span style="color:#db7093;">UV Coordinates</span>

This uv coordinates can be used to extract a color point from a texture for a certain point.

This uv coordinates are represented as an image but really are a grid of vectors (X for red and Y for green) because this vectors are transformed into color. 

This image represent this UV coordinates, with (x, y) = (0, 0) being represented as black and (x, y) = (1, 1) being represented as <span style="color:yellow;">Yellow</span> as the sum of <span style="color:red;">red</span> and <span style="color:green;">green</span>. 

![[uv_coordinates.webp]]

This UV coordinates can be altered by using a [[SHADERS - Flow map]]. 
This flowmap simply adds a number to the UV coordinate so it’s accessing other pixels.