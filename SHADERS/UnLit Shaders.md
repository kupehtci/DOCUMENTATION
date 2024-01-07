#SHADERS #UNITY #COMPUTER_GRAPHICS

## UNLIT SHADERS

Unlit shaders doesnt work with light
#### Working with transparencies

```CSHARP
Pass{

// This enables to see the backwards of a transparent objects
Zwrite Off

// Combines pixels of the shader within the ones there (actual transparency)
Blend SrcAlpha One

//Cullback is used to hide the back of the objects with textures 
Cull Back

}
```

### SHADOWS

UnLit shadows by default, when you apply a new one to an object, it does not reflect the shadows. 

you can delete fog: 

```CSHARP 
// apply fog
UNITY_APPLY_FOG(i.fogCoord, col);
```

##### PARAMETERS

<span style="border: 1px solid white; padding: 0.2rem; ">APPDATA</span> -> <span style="border: 1px solid white; padding: 0.2rem; ">VERTEX</span> -><span style="border: 1px solid white; padding: 0.2rem; ">v2f</span> -> <span style="border: 1px solid white; padding: 0.2rem; ">PIXEL</span> -> <span style="border: 1px solid white; padding: 0.2rem; ">Color</span> 