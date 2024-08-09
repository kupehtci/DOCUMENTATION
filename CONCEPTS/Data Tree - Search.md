#CONCEPTS 

When having a data tree, one of the common problems is to search data contained in the tree. Traversing the different nodes and leafs can be done in different order and each type of searching algorithm has different pros and cons: 

One way for searching objects is to create a method that recursively gets called per each node and calls itself recursively in the child nodes or stops and evaluate the children if its a leaf: 

```CSHARP
public void TraverseNode(Node node)
{
	if(node.IsLeaf())
	{
		// Code to execute with children
		return; 
	}
	else
	{
		//Code to execute with nodes
		TraverseNode(node.childLeft); 
		TraverseNode(node.childRight); 
	}
}
```

