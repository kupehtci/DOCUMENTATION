
In case that we want to draw a rectangle, we can draw it using two triangles. 

But if we indicate two different triangles that conform a rectangle some vertices may overlap as they join together to conform the final object. 

This is no a problem if we only want to draw a quadrangle but in more complex models it gets complicated. 

So the best format is to store all the vertices without overlapping, only indicating the vertices that are unique and then tell the order that they must be drawn or which vertices conform each triangles. 

Example: 

```cpp

float vertices[] = {
     0.5f,  0.5f, 0.0f,  // top right
     0.5f, -0.5f, 0.0f,  // bottom right
    -0.5f, -0.5f, 0.0f,  // bottom left
    -0.5f,  0.5f, 0.0f   // top left 
};
unsigned int indices[] = {  
    0, 1, 3,   // first triangle
    1, 2, 3    // second triangle
};  
```

In this case for the indices it starts at 0 indicating the vertices that join together, so in this case we only specify 4 vertices instead of 4 to draw a rectangle. 

The process then to create an EBO: 

1. Generate a buffer object: 
```cpp
unsigned int EBO; 
glGenBuffers(1, &EBO);
```

2. Similar to VBO we need to bind the Element Buffer Object and copy the properties into it: 
```cpp
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO);
glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW); 
```

3. As we are binding `GL_ELEMENT_ARRAY_BUFFER` as the buffer target and then draw it using `glDrawElements()` function to draw them. 
```cpp
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO);
glDrawElements(GL_TRIANGLES, 6, GL_UNSIGNED_INT, 0);
```
