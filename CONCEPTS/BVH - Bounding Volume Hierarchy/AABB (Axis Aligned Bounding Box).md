
All the objects in a game engine map, the floors, the walls, the chairs are objects that are enclosed in axis aligned bounding boxes. This is done to accelerate collision detection.

This boxes are align in terms of axis, making it more optimized to calculate collision, proximity and vectorial and meshes calculations. 

![[AABB.png]]

AABBs can be stores in two different structures. 
Can be saved as the <span style="color:orange;">min</span> and <span style="color:orange;">max</span> vectors that encloses its or save the <span style="color:orange;">center</span> and the <span style="color:orange;">extends</span>. 

`Extends` is a vector3 that stores the distance in 3 axis between the center and the bounds. 

![[AABB_Types.png]]

In Unity the two different structs are saved inside <span style="color:#d291bc;">Bounds</span> class. 
```CSHARP 
class Bounds{
	 Vector3 min; 
	 Vector3 max; 
	 Vector3 center; 
	 Vector3 bounds; 
}
```

These two pairs of parameters are <span style="color:orange;">equivalent</span>. 
Both can be calculated from the other pair: 

```CSHARP 
public Vector3 CalculateCenter(Vector3 min, Vector3 max){
	return (max - min)/2; 
}

public Vector3 CalculateExtends(Vector3 min, Vector3 max){
	return max - min
}
```

### CALCULATE THE UNION OF TWO AABBs 

Given two bounding boxes we can compute the union with min and max operations. These can be made efficient using SIMD.


```CSHARP
public AABB Union(AABB A, AABB B){

	AABB C; 
	C.lb = Min(A.lb, B.lb); 
	C.ub = Max(A.ub, B.ub); 
	return C; 
}
```


### CALCULATE THE AREA OF AN AABB

The area can be calculated by substracting the two bounds and multiply cross components. 

This cs code shows the calculation
```CSHARP
public float Area()  
{  
    Vector3 c = _ub - _lb;  
    return 2.0f * (c.x * c.y + c.y * c.z + c.z * c.x);  
}
``` 
### DETAILS

Take into account that in mesh do not vary if you scale the object. 
In this case a sphere is scaled in Z and white wired cube is the `mesh.bounds` AABB. 
![[AABB not affected by scale.png]]


## Group AABB

If you need to calculate the resultant AABB of a combination of AABBs, you can generate an <span style="color:orange;">enclosure</span> AABB by acumulating the union of each one of them. 

```CSHARP
/// <summary>  
/// Calculate an AABB that enclosures all the game objects of the Node  
/// This is done by generating a Union between pairs of objects and the last saved union. /// </summary>  
public void CalculateBounds()  
{  
    if (_gos == null || _gos.Count <= 0) { return; }  
  
    Bounds bounds1= _gos[0].GetComponent<MeshFilter>().sharedMesh.bounds;  
    AABB resultantAABB = new AABB(_gos[0].transform.position + bounds1.min, _gos[0].transform.position + bounds1.max);  
  
    for (int i = 0; i < _gos.Count; i++)  
    {        Bounds bounds = _gos[i].GetComponent<MeshFilter>().sharedMesh.bounds;  
  
        resultantAABB = AABB.Union(resultantAABB, new AABB(_gos[i].transform.position + bounds.min, _gos[i].transform.position + bounds.max));   
    }  
  
    _bounds = resultantAABB; }
```



### How to calculate the AABB

When calculating the AABB need to take into consideration that is the minimum volume for enclosing the object: 