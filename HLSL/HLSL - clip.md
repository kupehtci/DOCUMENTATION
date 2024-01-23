#HLSL

### clip()

In HLSL `clip(x)` is an intrinsic function is used for discarding the pixel if the `x value` is less than 0. 

```CS
clip(Input.color.A < 0.1f? -1 : 1); 
```


Can be used for simulating clipping planes if each component of the `x` parameter represents a distance from a plane. 

|Shader Model|Supported|
|---|---|
|[Shader Model 4](https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-sm4)|yes (pixel shader only)|
|[Shader Model 3 (DirectX HLSL)](https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-sm3)|yes (pixel shader only)|
|[Shader Model 2 (DirectX HLSL)](https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-sm2)|yes (pixel shader only)|
|[Shader Model 1 (DirectX HLSL)](https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-sm1)|yes (pixel shader only)|
