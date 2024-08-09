#CSHARP #CONCEPTS 
## CAN SIMD BE USED? 

Before executing custom SIMD algorithms, it's possible to check if the host machine supports SIMD by using [Vector.IsHardwareAccelerated](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector.ishardwareaccelerated#system-numerics-vector-ishardwareaccelerated), which returns a [Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean). This doesn't guarantee that SIMD-acceleration is enabled for a specific type, but is an indicator that it's supported by some types.

## .NET SIMD-accelerated types

The .NET SIMD-accelerated types include the following types:

- The [Vector2](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector2), [Vector3](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector3), and [Vector4](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector4) types, which represent vectors with 2, 3, and 4 [Single](https://learn.microsoft.com/en-us/dotnet/api/system.single) values.
- Two matrix types, [Matrix3x2](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.matrix3x2), which represents a 3x2 matrix, and [Matrix4x4](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.matrix4x4), which represents a 4x4 matrix of [Single](https://learn.microsoft.com/en-us/dotnet/api/system.single) values.
- The [Plane](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.plane) type, which represents a plane in three-dimensional space using [Single](https://learn.microsoft.com/en-us/dotnet/api/system.single) values.
- The [Quaternion](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.quaternion) type, which represents a vector that is used to encode three-dimensional physical rotations using [Single](https://learn.microsoft.com/en-us/dotnet/api/system.single) values.
- The Vector type, which represents a vector of a specified numeric type and provides a broad set of operators that benefit from SIMD support. The count of a  Vector T instance is fixed for the lifetime of an application, but its value depends on the CPU of the machine running the code.

## Simple Vectors


``` CSHARP 
var v1 = new Vector2(0.1f, 0.2f);
var v2 = new Vector2(1.1f, 2.2f);
var vResult = v1 + v2;
```

It's also possible to use .NET vectors to calculate other mathematical properties of vectors such as `Dot product`, `Transform`, `Clamp` and so on.

C#Copy

``` CSHARP
var v1 = new Vector2(0.1f, 0.2f);
var v2 = new Vector2(1.1f, 2.2f);
var vResult1 = Vector2.Dot(v1, v2);
var vResult2 = Vector2.Distance(v1, v2);
var vResult3 = Vector2.Clamp(v1, Vector2.Zero, Vector2.One);
```
