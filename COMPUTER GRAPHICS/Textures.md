
IN order to map a texture to a triangle, each vertex have a <span style="color:MediumSlateBlue;">texture coordinate</span> associated with it that specify the part of the texture image that is sampled from. 

Take into account that texture coordinates is a 2D Vector that goes \[0, 1\] for each axis (x and y). 

The process of retrieving the texture color using texture coordinates is called <span style="color:orange;">sampling</span>. 

#### Texture wrapping

Texture Wrapping is the format that a texture sampling takes in case that the texture coordinates are outbound the range or the texture doesn't "cover" the whole drawn object. 

For OpenGL as an example we have 4 different ways to wrap the texture: 

* `GL_REPEAT`: Repeat the texture image for the outbound coordinates. 
* `GL_MIRRORED_REPEAT`: Same as the repeat method but the contiguous images are mirrored
* `GL_CLAMP_TO_EDGE`: Clamps the coordinates between 0 and 1 and the higher coordinates are clamped to the edge of the drawn object. So the higher values results in an stretched image of the borders of the texture. 
* `GL_CLAMP_TO_BORDER`: Coordinates outside the texture are not filled with other parts of the texture, only with another color. 