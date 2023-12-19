#shaders #UNITY 

## TOON SHADER


This image shows the difference between a <span style="color:orange;">unlit shader</span> and a <span style="color:orange;">toon shader</span>

![[toon_shader_charcteristics.png]]

This changes all the natures of light in the object by don't having `blur`. 
For theory of light, take a look into [[Theory of light]]
### How to make a toon shader

First step, once you create an unlit shader, delete the fog references, because they only work for `unity fog` and its not needed for a toon shader. 
Add color as a property for being able to modify the . This can be added in properties section:

```SHADER
Properties  
{  
    _MainTex ("Texture", 2D) = "white" {}  
    _Color ("Color", Color) = (1,1,1,1)  
}
```

### - Add directional lighting 

Add two tags to set the lighting. 

```SHADER
Tags  
{  
    "LightMode" = "ForwardBase"  
    "PassFlags" = "OnlyDirectional"  
}
```

The model blinn-phong of reflectional light stablish this diagram: 

![[220px-Blinn_Vectors.svg.png]]

We need access to the object\'s normal data within the shader by adding the following code: 

```SHADER
// Inside appdata struct 
float3 normal : NORMAL; 

// Within the v2f struct
float3 worldNormal : NORMAL; 
```

The normals in appdata are populated automatically, while values in v2f must be manually populated in vertex shader. 

We want to transform the normal from object space to world space as the light's direction is provided in <span style="color:orange;">world space</span>. 

```SHADER
// Add this in vertex shader
o.worldNormal = UnityObjectToWorldNormal(v.normal); 
```

This line transforms the normal into world space and pass it to the `fragment shader`.


By making a dot product, with the world light position, we can calculate the light reflection direction. 
It will generate shadows because a dot product calculation of a light with a normal in the same direction, will return a 0 and multiplying this with the light output generates a dark texture.  

```SHADER
// Top of fragment shader
float3 normal = normalize(i.worldNormal); 
float NdotL = dot(_WorldSpaceLightPos0, normal); 

// Modify the following one
return col * _Color * NdotL; 
```

By multipliying the col output by our own color and the ndot, the color and the light are calculated. 

Also, \_Color needs to be defined as a variable linked to the property we previously defined. 

For doing this, declare in the variables section: 

```SHADERS
float4 _Color;          
```

With this, you will have a totally black shadow of the object. 
The shadow is created because dot(normal, light_direction) = 0; 
![[Captura de pantalla 2023-12-19 a las 15.56.29.png]]

To make the shadow to dont o a degrade, just gro from 0 to 1, can be done with an if to make the dot product be 0 or 1: 

```SHADERS
//After NdotL declaration
float lightIntensity = NdotL > 0 ? 1 : 0;    
```



If you want to make a ramp or steps degradation of the shadow: 

float2 uv = float2(1 - (NdotL * 0.5*) //...


### Ambient Light


Declare as a property and create a variable associated with it: 

```SHADERS
_AmbientColor("Ambient Color", Color) = (0.4, 0.4, 0.4, 1)

// IN variables section 
float4 _AmbientColor; 
```

And to apply the `ambient light` , sum to the <span style="color:orange;">lightIntensity</span>. 


### Using unity light

Include the lighting library of unity and set the light calculated from unity: 

```SHADERS
#include "Lighting.cginc"
```

```SHADER
float lightIntensity = NdotL > 0 ? 1 : 0;       
float4 light = lightIntensity * _LightColor0;
```


### BLUR 

Add a little bit of blur between shadow and visible color: 

```SHADER
float lightIntensity = smoothstep(0, 0.01, NdotL);
```

![[Captura de pantalla 2023-12-19 a las 16.21.51.png]]

This blur can be modified to be wider by increasing the step number from 0.01 to 0.1 or above. 
### SPECULAR REFLECTION

Specular reflection models the individual, distinct reflections made by light sources.

This reflection is view dependent, in that it is affected by the angle that the surface is viewed at.

We will calculate the world view direction in the vertex shader and pass it into the fragment shader.

•The strength of the specular reflection is defined in Blinn-Phong as the dot product between the normal of the surface and the half vector.

•The half vector is a vector between the viewing direction and the light source; we can obtain this by summing those two vectors and normalizing the result.

•This is the direction from the current vertex towards the camera.

```SHADERS
float3 viewDir : TEXCOORD1; 
o.viewDir = WorldSpaceViewDir(v.vertex); 
```


Add the new properties: 

```SHADERS
// add new properties
_SpecularColor("Specular Color", Color) = (0.9, 0.9, 0.9, 1); _Glossiness("Glossiness", Float) = 32;

//And the correspondent variables
float4 _SpecularColor; 
float _Glossiness;
```

Once you have the variables, remains to calculate the specular light: 

```SHADERS
float3 viewDir = normalize(i.viewDir);  
  
float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);  
float NdotH = dot(normal, halfVector);  
  
float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
```

With this you will have this specular light: 

![[Captura de pantalla 2023-12-19 a las 16.36.35.png]]
