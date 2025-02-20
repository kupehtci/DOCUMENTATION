#OpenGL 

# VAO Vertex Array Object 




### Binding VBO to VAO

A VAO is an array of buffers, so its an array that contains references to VBO or Vertex Buffer Objects. 

In order to bind them together, a VAO needs to be binded before the binding of the VBO: 

```cpp
GLuint VAO, VBO;
glGenVertexArrays(1, &VAO);
glGenBuffers(1, &VBO);

glBindVertexArray(VAO);              // 1️⃣ Bind the VAO

glBindBuffer(GL_ARRAY_BUFFER, VBO);  // 2️⃣ Bind the VBO (while VAO is bound)

// Define vertex attributes (linked to VAO)
glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
glEnableVertexAttribArray(0);

glBindVertexArray(0);  // 3️⃣ Unbind VAO (VBO is now "remembered" inside VAO)
```