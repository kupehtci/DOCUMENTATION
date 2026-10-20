#DBVH #CSHARP #CONCEPTS 

## DEFINITION 

<span style="color:#aff5aa;">Bounding volume Hierarchy</span> is a data structure based on a binary tree meant to optimize <span style="color:#ababf5;">ray-tracing</span> and <span style="color:#ababf5;">[[Collision Detection|collision detection]]</span>. 

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

This algorithm is meant to make the global search faster. It is the actual technique used to **query** a BVH — this is what makes ray-tracing and collision detection fast in the first place, since it avoids testing every single object one by one. 

For a general introduction on searching tree data structures, see [[Data Tree - Search]]. 

The idea of branch and bound is simple: 

1. Start at the **root** node. 
2. Test the query (a ray, another AABB, a point) against the node's bounding box. 
3. **Bound**: if the query does not intersect the box, <span style="color:orange;">prune</span> the whole branch — none of its children can possibly be relevant, so skip them entirely without visiting them. 
4. **Branch**: if the query does intersect the box and the node is a leaf, test the query against the actual object. If it is an internal node, recurse (branch) into both children. 

This way, a query that only touches a small part of the scene only visits a small fraction of the tree — O(log n) on average instead of O(n). 

### Ray intersection query 

To find what a ray hits, we walk down the tree, only descending into children whose AABB the ray intersects: 

```CSHARP 
void QueryRay(Node node, Ray ray, ref RaycastHit closestHit) 
{ 
    if (!IntersectRayAABB(ray, node._box)) 
        return; // Bound: prune this branch, the ray misses the box entirely 

    if (node._isLeaf) 
    { 
        TestRayAgainstObject(ray, node._objIndex, ref closestHit); // Branch: test the real geometry 
        return; 
    } 

    QueryRay(tree.nodes[node._child1], ray, ref closestHit); 
    QueryRay(tree.nodes[node._child2], ray, ref closestHit); 
} 
```

A further optimization is to keep the distance to the **closest hit found so far** as the bound: once we have a hit, any node whose AABB starts farther away than that distance can be pruned too, since it can never produce a closer result. 

### Overlap / collision query 

For collision detection, instead of a ray we test two AABBs for overlap. To find every pair of colliding leaves between two trees (or a single tree against itself for self-collision), the same branch and bound idea is applied to both trees at once: 

```CSHARP 
void QueryOverlap(Node nodeA, Node nodeB, List<Pair> results) 
{ 
    if (!Overlaps(nodeA._box, nodeB._box)) 
        return; // Bound: the two subtrees can't possibly collide 

    if (nodeA._isLeaf && nodeB._isLeaf) 
    { 
        results.Add(new Pair(nodeA._objIndex, nodeB._objIndex)); // Branch: an actual candidate collision pair 
        return; 
    } 

    if (nodeA._isLeaf || (!nodeB._isLeaf && nodeB._box.Area() > nodeA._box.Area())) 
    { 
        QueryOverlap(nodeA, tree.nodes[nodeB._child1], results); 
        QueryOverlap(nodeA, tree.nodes[nodeB._child2], results); 
    } 
    else 
    { 
        QueryOverlap(tree.nodes[nodeA._child1], nodeB, results); 
        QueryOverlap(tree.nodes[nodeA._child2], nodeB, results); 
    } 
} 
```

Descending into the larger of the two nodes first keeps the recursion balanced and avoids unnecessary splits. The resulting pairs are only **candidates** — this is the <span style="color:orange;">broad phase</span> of collision detection. A precise <span style="color:orange;">narrow phase</span> check (e.g. GJK, SAT) is still needed afterwards to confirm an actual collision between the real shapes. See [[Collision Detection]]. 

## Object movement strategies

What happen if we move objects?. We dont need to rebuild the whole BVH. 
We have different options: 

* <span style="color:orange;">Refit ancestors</span>: leads into low quality trees because an object move into the surface of another AABB but continue belonging to the other branch. 
* <span style="color:orange;">Rebuild subtrees</span>: is expensive
* <span style="color:orange;">Remove and re-insert</span>: also expensive but useful. 

### Enlarged AABBs

At 60Hz objects normally dont move far per frame, so we can use enlarged AABB in the BVH. 
This allows us to only update a leaf if the tight fit AABB moves outside the enlarged AABB

![[enlarged_aabb.png]]

## Compare cost in BVH

To be able to compare the efficiency of a BVH, the cost can be calculated and compared by taking the total area of the internal nodes. 
This gives a comparison in how well the objects are grouped: a good tree wraps its objects in tight, non-overlapping boxes, so the sum of all internal node areas stays small. A bad tree has large, overlapping boxes and a higher total cost. 


```CSHARP 
// Calculate total area of internal nodes
float ComputeCost(Node node) 
{ 
    if (node._isLeaf) 
        return 0.0f; // Leaves don't count, only internal nodes do 

    float cost = node._box.Area(); 
    cost += ComputeCost(tree.nodes[node._child1]); 
    cost += ComputeCost(tree.nodes[node._child2]); 
    return cost; 
}
```

Cost can be evaluated when choosing the axis to split the AABB by calculating the resultants nodes Area and choosing the less resultant area split. 

### Surface Area Heuristic (SAH)

The <span style="color:orange;">Surface Area Heuristic</span> is the formalization of this idea, used to pick the best split (axis and position) while [[DBVH - Top Down Build|building the tree top-down]], instead of just picking the longest axis or the median. 

It estimates the cost of a candidate split as: 

```
cost = Area(leftBox) * numObjectsLeft + Area(rightBox) * numObjectsRight
```

The intuition: the probability of a random ray hitting a box is proportional to its **surface area**, so a split's expected traversal cost is the area of each side weighted by how many objects (and therefore how many further tests) it contains. Trying several candidate split positions per axis (or all of them, for a small object count) and keeping the one with the lowest SAH cost produces noticeably better trees than a fixed alternate-axis or median split, at the price of a more expensive build. 

## Related

* [[AABB (Axis Aligned Bounding Box)]] — the bounding volume used at every node.
* [[DBVH - Top Down Build]] — a detailed walkthrough of the top-down build, including SAH split evaluation.
* [[Data Tree - Basics]] and [[Data Tree - Search]] — general binary tree and search tree fundamentals.
* [[Tree]] and [[Heap]] — a BVH is a specialized binary tree, comparable to how a heap constrains a tree for a different purpose.
* [[Collision Detection]] — the broad-phase/narrow-phase pipeline a BVH accelerates.