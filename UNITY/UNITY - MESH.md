#UNITY #CSHARP #3D
## MESH FILTER 

Mesh filter is the component that store the mesh and consequently the vertices of the `GameObject`

## MESH 

The mesh class allows you to create or modify meshes. 
Meshes are basically vertices and multiple triangle arrays. 

All vertex data is stores in separate arrays of the same size. For example, if you have a mesh of 100 Vertices, and want to have a position, normal and two texture coordinates for each vertex, then the mesh should have [vertices](https://docs.unity3d.com/ScriptReference/Mesh-vertices.html), [normals](https://docs.unity3d.com/ScriptReference/Mesh-normals.html), [uv](https://docs.unity3d.com/ScriptReference/Mesh-uv.html) and [uv2](https://docs.unity3d.com/ScriptReference/Mesh-uv2.html) arrays, each being 100 in size. Data for i-th vertex is at index "i" in each array.

Mesh has: 
* vertices 
* normals 
* uv 
* uv2 ...uv8 - texture coordinates UVs for x channel. 

For every vertex there can be a vertex position, normal, tangent, color and up to 8 texture coordinates. Texture coordinates most often are 2D data ([Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html)), but it is possible to make them [Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html) or [Vector4](https://docs.unity3d.com/ScriptReference/Vector4.html) if needed. This is most often used for holding arbitrary data in mesh vertices, for special effects used in shaders. For skinned meshes, the vertex data can also contain [boneWeights](https://docs.unity3d.com/ScriptReference/Mesh-boneWeights.html).  
  
The mesh face data, i.e. the triangles it is made of, is simply three vertex indices for each triangle. For example, if the mesh has 10 triangles, then the [triangles](https://docs.unity3d.com/ScriptReference/Mesh-triangles.html) array should be 30 numbers, with each number indicating which vertex to use. The first three elements in the triangles array are the indices for the vertices that make up that triangle; the second three elements make up another triangle and so on.  
  
Note that while triangle meshes are the most common use case, Unity also supports other mesh topology types, for example Line or Point meshes. For line meshes, each line is composed of two vertex indices and so on. See [SetIndices](https://docs.unity3d.com/ScriptReference/Mesh.SetIndices.html) and [MeshTopology](https://docs.unity3d.com/ScriptReference/MeshTopology.html).

#### MESH VERTICES 

```CSHARP 
	Mesh mesh; 
	Vector3[] vertices

	public Start(){
		mesh = this.GetComponent<MeshFilter>().mesh; 
		vertices = mesh.vertices; 
	}
```

#### MESH VERTEX COUNT 

`public int`
`Mesh.vertexCount`

Returns the number of vertices in the Mesh (Read Only).

```CSHARP
	Mesh mesh; 
	int numVertex; 

	public Start(){
		mesh = this.GetComponent<MeshFilter>().mesh; 
		numVertex = mesh.vertexCount; 
	}
```