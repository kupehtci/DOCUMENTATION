#HLSL 

### PROPERTIES

To define properties to the shader that can be modified from outside specially in unity, you can set them in properties, with a type of variable defined and initialized with a value: 

Example: 

```CS
Properties{  
    _MainTex ("Texture", 2D) = "white" {}                                   // texture map  
    _Color("Color", Color) = (1, 1, 1, 1)                                   // COlor to blend the texture  
    [HDR]_AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)            // Ambient color  
    _BumpMap("Normal Map", 2D) = "bump" {}                                    
_BumpStr("Normal Map Strenght", float) = 1  
  
    _FlowMap("Flow (RG)", 2D) = "black" {}  
    _DissolveTexture("Dissolve Texutre", 2D) = "white" {}  
    _DissolveColor("Dissolve Color Border", Color) = (1, 1, 1, 1)   
_DissolveBorder("Dissolve Border", float) =  0.05  
  
  
    _Exapnd("Expand", float) = 1  
    _Weight("Weight", Range(0,1)) = 0  
    _Direction("AdditiveDirection", Vector) = (0, 0, 0, 0)                      
    [HDR]_DisintegrationColor("Disintegration Color", Color) = (1, 1, 1, 1)  
    _Glow("Glow", float) = 1  
  
    _Shape("Shape Texutre", 2D) = "white" {}   
_DiscardValue("Discard Value Of Shape", float) = 0.9  
    _R("Radius", float) = .1  
}

// Then need to be defined after the CGINCLUDE

CGINCLUDE  
  
    //#include "UnityCG.cginc"  
    //#include "Lighting.cginc"  
  
    sampler2D _MainTex;  
    float4 _MainTex_ST;  
    float4 _Color;  
    float4 _AmbientColor;  
    sampler2D _BumpMap;  
    float _BumpStr;  
    float _Metallic;  
  
    sampler2D _FlowMap;  
    float4 _FlowMap_ST;  
    sampler2D _DissolveTexture;  
    float4 _DissolveColor;  
    float _DissolveBorder;  
  
  
    float _Exapnd;  
    float _Weight;  
    float4 _Direction;  
    float4 _DisintegrationColor;  
    float _Glow;  
    sampler2D _Shape;  
    float _DiscardValue;   
float _R;
```