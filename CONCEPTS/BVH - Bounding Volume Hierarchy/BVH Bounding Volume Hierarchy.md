
## DEFINITION 

<span style="color:#aff5aa;">Bounding volume Hierarchy</span> is a data structure based on a binary tree meant to optimize <span style="color:#ababf5;">ray-tracing</span> and <span style="color:#ababf5;">collision detection</span>. 

## UTILITY

DBVH are use to accelerate collision detection in game physics and Ray-Tracing. 

## Components

For structuring the tree in a OOP format, we need: 

The tree consists of <span style="color:orange;">internal nodes</span> and <span style="color:orange;">leaf nodes</span>.  
The leaf nodes are the collision objects and the internal nodes only exist to accelerate collision queries.

Recall that the number of internal nodes can be computed from the number of leaf nodes, regardless of the tree structure.


> Node class, a node in the tree for handling the data. 


```CSHARP 
public struct Node  
{  
    public AABB _box;  
    public int _objIndex;  
    public int _parentIndex;  
  
    public int _child1;  
    public int _child2;  
    public bool _isLeaf; 
}
```


## BUILD A Bounding Volume Hierarchy

Bounding Volume Hierarchies can be built automatically using different algorithms: 
* Bottom up 
* Top down 
* Incremental

### Bottom up - amalgamation 

This algorithm has the following steps: 

* Start with many loose leaf nodes (Objects). 
* Build the AABBs for each one of the objects, so starts being considered as leaf nodes. 
* Join two nodes under a single internal node: 

![](bottomup_1.png =200)

* Drop A and B from the working set and replace them with box 1
* Combine two more and repeat until you have cover all leafs
* Combine top nodes until you get a single top level node. 
![[bottomup_2.png]]


### Top Down - Divide and conquer

* Start with many loose leaf nodes (Objects). 
* Build the AABBs for each one of the objects, so starts being considered as leaf nodes. 
* Wrap all AABBs under a single root AABB. This will result in a node with lots of children, so we need to split them. 
* Divide into two groups and keeep dividing until you have nodes with only one child (Itself AABB)
![[topdown_1.png]]

When coding this, take into account that when building it you need to split the AABB for an axis that is the largest and group the objects inside that AABB into a leaf node. 
More details and how to build it: [[DBVH - Top Down Build]]

### Incremental - dynamic

An incremental build only adds one AABB to the tree at each iteration. 
* In each object iteration, insert one into the tree. 
* When a leaf is inserted, the code needs to find a sibling for it. The sibling can be a leaf node or a internal one
![[incremental_1.png]]

## Insertion Algorithm 

The key for dynamic bounding volume hierarchies is the algorithm for inserting the leaves. 

The steps of the insertion are: 
1. Find the best sibling for the new leaf

![[dint_best_sibling.png]]

3. Create a new parent

![[createnewinternalnode.png]]

1.   Go back up the tree in order to refit AABBs. This means to resize the AABBs for fitting the new childs. This ensure that all nodes enclose their children and refits the parent bounding boxes. 

```CSHARP
int index = tree.nodes[leafIndex].parentIndex; 
while(index != null) //Different from root
{
	int child1 = tree.nodes[leafIndex].child1;
	int child2 = tree.nodes[leafIndex].child2; 
	tree.nodes[index].box = Union(tree.nodes[child1.box], tree.nodes[child2.box]); 
	index = tree.nodes[index].parentIndex; 
}
```

This code iterates between the leaf node to the root and resize the AABB calculating an <span style="color:orange;">Union</span> of the children.


## Branch and Bound Algorithm 

This algorithm is meant to make the global search faster. 
You can see how to search in trees data structures in: 

## Object movement strategies

What happen if we move objects?. We dont need to rebuild the whole BVH. 
We have different options: 

* <span style="color:orange;">Refit ancestors</span>: leads into low quality trees because an object move into the surface of another AABB but continue belonging to the other branch. 
* <span style="color:orange;">Rebuild subtrees</span>: is expensive
* <span style="color:orange;">Remove and re-insert</span>: also expensive but useful. 

### Enlarged AABBs

At 60Hz objects normally dont move far per frame, so we can use enlarged AABB in the BVH. 
This allows us to only update a leaf if the tight fit AABB moves outside the enlarged AABB

![[Captura de pantalla 2023-12-21 a las 15.30.35.png]]

## Compare cost in BVH

To be able to compare the efficiency of a BVH, the cost can be calculated and compared by taking the total area of the internal nodes. 
This gives a comparison in how well the objects are grouped. 


```CSHARP 
// Calculate total area of internal nodes
float ComputeCost(){



}
```

Cost can be evaluated when choosing the axis to split the AABB by calculating the resultants nodes Area and choosing the less resultant area split. 