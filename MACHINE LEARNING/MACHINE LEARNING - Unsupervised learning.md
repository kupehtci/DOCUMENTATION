#ML 


### <span style="color:MediumPurple;">Clustering</span>

Arranging data into groups without having previous knowledge of the group they belong to. 

Classification with no predefined classes.

Tries to find objects with similar features and merge them or group them in <span style="color:MediumSlateBlue;">clusters</span>. 

Types of clustering algorithms

`K-MEANS`

Unsupervised algorithm that cluster objects into $k$ groups depending on their characteristics. 
The $k$ number of clusters needs to be provided. 
Grouping is done by <span style="color:MediumPurple;">minimizing the sum of distances</span> between each closer object and the centroid of each group or cluster via iterative process
Sensitive to <span style="color:MediumPurple;">noise</span> in data

`MEANSHIFT`

Updating centroids candidates to be the mean of the point within a region
Starts with a kernel (circular sliding window) with predefined bandwidth and a radius by the user. 
The $k$ number of clusters is determined by the algorithm. 

`DBSCAN`

<span style="color:MediumPurple;">DBScan</span> or <span style="color:MediumPurple;">Density-Based Spatial Clustering of Applications with noise</span> is a clustering method to separate high density clusters from low density ones. 
Stablished a kernel, starts moving the kernel into each object and propagate into all objects that are inside the kernel in each iteration until all objects that are closer, keeps inside the same cluster. 
The $k$ number of clusters is determined by the algorithm. 
Its <span style="color:MediumPurple;">not sensible to noise</span> in data. 

`OPTICS`

<span style="color:MediumPurple;">OPTICS</span> or <span style="color:MediumPurple;">Ordering Points To Identify Clustering Structure</span>, finds core examples of high density and expands clusters for them. 
Similar to DBScan but this one, adjust the radio of the kernel and in DBScan is a constant. 

`AFFINITY PROPAGATION`

Based in "passing messages" between data points. 
The $k$ number of clusters doesn't need to be specified before running the algorithm. 
They exchange messages and compare similarities between points with other exemplars until a high-quality set and cluster merges. 

`SPECTRAL CLUSTERING`

Reduces multi-dimensional datasets into clusters of similar data in fewer dimensions. 
Once the dimension is reduces, are grouped not only by the distance, also with <span style="color:MediumPurple;">connectivity</span>. 

![[spectral-clustering.png]]
### Elbow method

The most important step in supervised learning is to <span style="color:MediumPurple;">determine the number of resultant clusters</span>. 
By plotting the <span style="color:orange;">inertia</span> variation depending on the number of clusters, and picking the elbow. 

<span style="color:orange;">Inertia</span> is the sum of squared distances of samples to their closes cluster center. 

![[elbow-method.png|400]]

### Silhouette score

Measure to determine the number of clusters of the data. 
This measure represents how similar is an object to its own cluster (Cohesion) compared to other clusters (Separation). The value goes from \[-1, 1\], meaning a high value a good match to his own cluster. 

$s = \frac{b - a}{max(a,b)}$

Being:  
* $a$ = mean distance between this sample and other points in the same cluster 
* $b$ = mean distance between the sample and all of the points in the nearest cluster. 
Then calculate the mean of all coefficients of all samples and can be represented in a chart comparing the values for different cluster values

![[shilhouette-score.png|300]]

