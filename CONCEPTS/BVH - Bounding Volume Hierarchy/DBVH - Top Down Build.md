#DBVH #CSHARP #CONCEPTS 

## TOP DOWN 

Top down is a method to build a <span style="color:orange;">Bounding Volume Hierarchy</span> by dividing and conquer methodology. 
You start by enclosing all game objects in a single AABB and start spliting the space along an axis, and through iterations, get all the space splitted into different internal nodes in a Binary Tree and leafs with a single GameObject each one. 

### SPLIT SPACE

On of the main features of the <span style="color:#ababf5;">Top down algorithm</span> is that if a AABB have more than object, need to split the space into two and this repeatedly into finishing the algorithm. 

For spliting the 3D space, we need to select an axis. There are two main methods to select an axis to split the AABB: 

* Alternate: Split by following the sequence of axis, first iteration x axis, second y axis, third z axis, fourth x axis and so on. 
* By range of centroids: Calculate the range between the max centroid and the min and the axis that has the objects more separated, is the choosen one: 
![[find_best_axis.png]]

Here, in two dimensions, their extent is largest along the `y axis` (filled points on the axes), so the primitives will be partitioned in `y axis` .

Because we have calculated the AABB of all the objects, we <span style="color:#ababf5;">dont need to calculate the sum of each axis</span> the extends axis of the AABB that encloses the gameobject that is the largest, is the one needed to be splitted


1. Split plane axis and position: for now, we will split the AABB along its longest axis. To do this we can calculate the `extends` (size) of the AABB by substracting min to max of the AABB that encloses all GameObjects. 

```CSHARP 
AABB enclosureAABB = AABB.CalculateBounds(objects); Vector3 boundsExtends = enclosureAABB.ub - enclosureAABB.lb;   

// Calculate the axis to split by taking the longest one  
int axis = 0;  
if (boundsExtends.x >= boundsExtends.y 
	&& boundsExtends.x >= boundsExtends.z) axis = 0; 
else if (boundsExtends.y >= boundsExtends.x 
		 && boundsExtends.y >= boundsExtends.z) axis = 1; 
else if (boundsExtends.z >= boundsExtends.x 
		 && boundsExtends.z >= boundsExtends.y) axis = 2;   
```

This let us and index axis for accessing the desired one ( x = 0, y = 1, z = 2). 

The first problem with median difference is not taking into account larger volumes.
For this we can take into consideration the <span style="color:orange;">SAH cost of each split axis</span> and take that into consideration. 


2. Split the group in two halves: this sounds like a complicated thing to do, but in BVH construction this is surprisingly simple. Because we are not splitting any triangles, the combined size of the list of triangles in both halves is exactly the size of the unsplit list. That means the split can be done in place. For this, we walk the list of primitives, and swap each primitive that is not on the left of the plane with a primitive at the end of the list. This is functionally equivalent to a QuickSort partition.

```CSHARP
int i = node.firstPrim;
int j = i + node.primCount - 1;
while (i <= j)
{
    if (tri[i].centroid[axis] < splitPos)
        i++;
    else
        swap( tri[i], tri[j--] );
}

```

Note that the triangles do not need to be sorted; it is sufficient that the two groups of triangles on both sides of the split plane are stored consecutively.

3. Creating child nodes for each half: Using the outcome of the partition loop we construct two child nodes. The first child node contains the primitives at the start of the array; the second child node contains the primitives starting at i. The number of primitives on the left is thus i - node.firstPrim; the right child has the remaining primitives. In code:
```CSHARP
int leftCount = i - node.firstPrim;
if (leftCount == 0 || leftCount == node.primCount) return;
// create child nodes
int leftChildIdx = nodesUsed++;
int rightChildIdx = nodesUsed++;
node.leftNode = leftChildIdx;
bvhNode[leftChildIdx].firstPrim = node.firstPrim;
bvhNode[leftChildIdx].primCount = leftCount;
bvhNode[rightChildIdx].firstPrim = i;
bvhNode[rightChildIdx].primCount = node.primCount - leftCount;
node.primCount = 0;
```

Resultant splitting space function: 

```CSHARP 
AABB enclosureAABB = AABB.CalculateBounds(objects); Vector3 boundsExtends = enclosureAABB.ub - enclosureAABB.lb;   
// Calculate the axis to split by taking the longest one  
int axis = 0;  
if (boundsExtends.x >= boundsExtends.y && boundsExtends.x >= boundsExtends.z) axis = 0; else if (boundsExtends.y >= boundsExtends.x && boundsExtends.y >= boundsExtends.z) axis = 1; else if (boundsExtends.z >= boundsExtends.x && boundsExtends.z >= boundsExtends.y) axis = 2;   
  
  
//Calculate mean axis split postision  
float axisCentroidsSumPos = 0.0f; for (int i = 0; i < objects.Length; i++)  
{  
    axisCentroidsSumPos += (objects[i].transform.position[axis] - enclosureAABB.lb[axis]) ; }  
  
float splitPos = enclosureAABB.lb[axis] + (axisCentroidsSumPos / objects.Length);//boundsExtends[axis] * 0.5f;//(axisCentroidsSumPos / objects.Length);// remains to end  
  
Debug.Log("Axis: " + axis + "splitPosition" + splitPos);  
  
// Divide the gameobjects depending on the side they belong  
List<GameObject> objsL = new List<GameObject>(); List<GameObject> objsR = new List<GameObject>();  
foreach (GameObject ob in objects)  
{  
    if (ob.transform.position[axis] < splitPos)  
    {        objsL.Add(ob);   
    }  
    else if (ob.transform.position[axis] > splitPos)  
    {        objsR.Add(ob);  
    }}
```

Some details to point out here:

Theoretically, the split in the middle can yield an empty box on the left or the right side. Not easy to come up with such a situation though! Left as an exercise for the reader. 😉

We should not forget to set the primitive count of the node we just split to zero. Since we do not store the isLeaf boolean anymore, we rely on the primCount to identify leaves and interior nodes.
Since we increment the ‘next free bvh node counter’ nodesUsed twice on consecutive lines, it is obvious that rightChildIdx is always equal to leftChildIdx + 1. This of course should have consequences for the BVHNode struct, which gets reduced to 36 bytes.
We’re almost done with the subdivide functionality. One we have generated the left and right child nodes, we update their bounds (using a call to UpdateNodeBounds, which we created earlier), and we recurse into the child nodes (using a call to the Subdivide function we’re currently writing). Leaves us with one question: when does the recursion end? One would say: once there is one primitive left. This is sadly not true. The point is, two triangles quite often form a quad in real-world scenes. If this quad is axis-aligned, there is no way we can split it (with an axis-aligned plane) into two non-empty halves. For this reason, we typically terminate when we have 2 or less primitives in a leaf. Even this is not completely safe – but for a solution we need a seemingly unrelated technique, which will be discussed in the next article.






--- 
#### Phases in pseudocode 

This phases are also coded in pseudoprograming language taking into consideration the vuild of a BVH for a 2 dimensional environment

Selection of the axis: 

```CSHARP
float3 extent = node.aabbMax - node.aabbMin;
int axis = 0;
if (extent.y > extent.x) axis = 1;
if (extent.z > extent[axis]) axis = 2;
float splitPos = node.aabbMin[axis] + extent[axis] * 0.5f;
```

