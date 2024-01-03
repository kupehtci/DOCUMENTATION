#UNITY #CSHARP 

## UNITY MATERIAL

Unity material can be accessed in the <span style="color:orange;">MeshRenderer</span>. 

```CSHARP
Material mat = this.GetComponent<MeshRenderer>().sharedMaterial; 
```

### SHARED VS NORMAL

The `sharedMaterial` is a reference for the material saved in the project. Modifying this will affect all gameobjects that has it and change settings stored in project. 

On other hands, `material` is the first instantiated material assigned to its renderer. 
This imply that changing the material affect only the material of this object. 

If is used by other renderers, this will clone the `sharedMaterial` and starts using this one. 
