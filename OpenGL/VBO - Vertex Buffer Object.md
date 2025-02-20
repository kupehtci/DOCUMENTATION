#OpenGL 

# VBO - Vertex Buffer Object

A VBO or Vertex Buffer Object is  buffer that stores raw data (Vertex's positions, normals, etc) for the GPU to use. 

An example structure of data that can be used: 

```cpp
GLfloat vertices[] = {
    // Position (x, y, z) // Color (r, g, b)
    0.5f,  0.5f, 0.0f,   1.0f, 0.0f, 0.0f,  // Top-right
   -0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,  // Bottom-left
    0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f   // Bottom-right
};
```

This example, store for each vertex, position (x, y, z) and color(r, g, b). 