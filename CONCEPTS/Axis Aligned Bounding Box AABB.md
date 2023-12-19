
All the objects in a game engine map, the floors, the walls, the chairs are objects that are enclosed in axis aligned bounding boxes. This is done to accelerate collision detection.

![[AABB.png]]

## CALCULATE THE UNION OF TWO AABBs 

Given two bounding boxes we can compute the union with min and max operations. These can be made efficient using SIMD.

Notice the cup notation. You will see it again.

```CSHARP
public AABB Union(AABB A, AABB B){

AABB C; 
C.lb = Min(A.lb, B.lb); 
C.ub = Max(A.ub, B.ub); 
return C; 
}
```

### DETAILS

Take into account that in mesh do not vary if you scale the object. 
In this case a sphere is scaled in Z and white wired cube is the `mesh.bounds` AABB. 
![[AABB not affected by scale.png]]