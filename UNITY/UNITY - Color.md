#UNITY #CSHARP 

## Color usage 

Color is used when rendering or showing lines / debuging information using Gizmos drawing in unity. [[UNITY - Gizmos]]

## Different classes

##### [Unity - Scripting API: Color 3](https://docs.unity3d.com/ScriptReference/Color.html)

`Color` `struct` constructor accepts RGBA `float` values in `0.0`-`1.0` range.

`Color red = new Color( 1.0f , 0.0f , 0.0f , 1.0f  );`

  

##### [Unity - Scripting API: Color32 18](https://docs.unity3d.com/ScriptReference/Color32.html)

`Color32` `struct` constructor accepts RGBA `int` values in `0`-`255` range.

`Color32 red = new Color32( 255 , 0 , 0 , 255 ); Color32 also_red = new Color32( 0xFF , 0x00 , 0x00 , 0xFF );`
Both `Color` and `Color32` (32bit) can be used to define valid color values.