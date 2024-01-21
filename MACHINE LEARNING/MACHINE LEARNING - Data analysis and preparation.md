#ML #PYTHON 

Data can be analyzed and explored in various ways: 

The most common techniques are: 

### <span style="color:cyan;">NaN anomalous data</span>

Some dataset may contain some empty data in some data rows. 
This NaN data cannot be considered as an input of the model. 

We have two ways of cleaning this data: 

* `Remove the entire row`

If some values contain NaN and we have so much rows, one option to clean the data its to delete the entire sample. 

* `Fill the NaN value`

We can fill this value with a random value, a one random within the samples deviation or even with the mean of the other samples values, so won't affect the final train.

```PYTHON
#using pandas dataframe
df.fillna(value_fill).        #fill the NaN values with the value_fill
df[df.notnull().all(axis=1)]  #select the not null values in axis 1 
```

### <span style="color:cyan;">Statistical Correlation or Cross correlation</span>

Measure of a mutual relationship between two variables whether they are casual together or not. Its not concerned about each measure changes individually but measures the simultaneous variations in all variables. 

The correlations are <span style="color:orange;">linear</span>, so don't take into account non-linear dependencies. 

Its not the same as <span style="color:orange;">causation</span>. Causation may cause correlation but its not the only factor that can link two variables. 

This can be represented with a <span style="color:#cd03f5;">heatmap</span>: 

![[correlation_heatmap.png|200]]
The diagonal line has a correlation of 1, meaning that a feature has a perfect positive correlation with itself. 
Can be measured with <span style="color:MediumSpringGreen;">Pearson's correlation of coeficient</span> 

![[pearson-correlation-coeficient.webp|200]]

The $p$ value will be between \[-1, 1\]: 
* r = 1 (perfectly positive correlation)
* r =-1 (perfectly negative correction)  
* r = 0 (no correlation)

When considering not taking into the model one variable that hold a high correlation with other one, take into consideration the multicollinearity:  [[MACHINE LEARNING - Effect of Multicollinearity]]

### <span style="color:cyan;">Boxplot</span>

Boxplot or outlier box plot can be used to take a look into data spread. 

And the plot is defined by some parts: 

- The center line in the box shows the median for the data. Half of the data is above this value, and half is below. If the data are symmetrical, the median will be in the center of the box. If the data are skewed, the median will be closer to the top or to the bottom of the box.

- The bottom and top of the box show the 25th and 75th quantiles, or percentiles. These two quantiles are also called quartiles because each cuts off a quarter (25%) of the data. The length of the box is the difference between these two percentiles and is called the interquartile range (IQR).

- The lines that extend from the box are called whiskers. The whiskers represent the expected variation of the data. The whiskers extend 1.5 times the IQR from the top and bottom of the box.

If data falls in the <span style="color:orange;">whiskers</span> its drawn as a dot and considered an outlier because is outside IQR. 

![[understanding-box-plot-diagram.webp|600]]

```PYTHON
seaborn.boxplot(x, y, hue, data, orient, color, whis, showfliers); 
```


### <span style="color:cyan;">Violin plot</span>

Also to visualize the data distribution, we can use violin plot. This plot instead of using actual data points, features the <span style="color:orange;">kernel density estimation (KDE)</span> of the distribution. 

![[violin-plot.png|400]]

```PYTHON
seaborn.violinplot(x : string, y : string, data=df); 
```

### <span style="color:cyan;">KDE - Kernel Density Stimation</span>

The kernel density estimation is a non-parametric way to estimate the probability density function of a random variable. 
KDE is a fundamental data smoothing problem where inferences about the population are made, based on a finite data sample. 

Exists different kernels: 

* gaussian
* topath
* epanechnikov
* exponential
* linear 
* cosine

```PYTHON
sklearn.neighbors.KernelDensity(bandwidth : number, algorithm='auto', kernel='gaussian', atol=0, rtol=0)
```

Important:
* bandwidth: depends on the magnitude order
* kernel: depends on the shape of distribution
* atol / rtol: larger -> faster


### <span style="color:cyan;">Data scaling</span>

Some features in the dataset have very different scales and can contain larger outliers. 
This leads into difficulties: 
* Not easy to visualize the data. 
* Can degrade the predictive performance of many algorithms. 
* Can slow down or block the converge of <span style="color:orange;">gradient-based estimators</span>* 

An exception are decision tree-based estimators because they are robust to arbitrary scale of data

\* this is because most estimators are designed to assume that each feature takes values close to zero and all features share the same scale.  

Calculated as.   $x' = x -  \hat{x}/𝝈_x$

```PYTHON
sklearn.preprocessing.StandardScaler(*, copy=True, with_mean=True, with_std=True)

sklearn.preprocessing.MinMaxScaler(feature_range=(0,1), *, copy=True, clip=False)
sklearn.preprocessing.MaxAbsScaler(_*_, _copy=True_)
sklearn.preprocessing.RobustScaler(*, with_centering=True, with_scaling=True, quantile_range=(25.0, 75.0),copy=True, unit_variance=False)
sklearn.preprocessing.PowerTransformer(method='yeo-johnson', *, standardize=True, copy=True)
sklearn.preprocessing.QuantileTransformer(*, n_quantiles=1000, output_distribution='uniform',subsample=100000, random_state, copy=True)
```

The `QuantileTransformer()` transform features values using quantiles information. 
Transforms the features following a uniform or a normal distribution. 
Reduces the impact of outliers. 
This transformation is non-linear, so may distort linear correlations. 

### <span style="color:cyan;">Dimensional Reduction</span>

Dimensional reduction methods allows us to reduce the number of variables with minimal loss of information. 

Only effective with a <span style="color:orange;">High correlation</span> between the variables and have the <span style="color:orange;">same order of scale</span>. 

Advantages: 
* Increase the speed of machine learning models
* Reduce the size of data in memory
* Difficult over-fitting
* Improves visualization

Dimensional reduction methods: 

* <span style="color:orange;">Principal Component Analysis (PCA)</span>: Linear dimensionality reduction using Singular Value Decomposition of the data to project to a lower dimensional space. 
```PYTHON
sklearn.decomposition.PCA(n_components, random_state, …)
```
* <span style="color:orange;">Kernel-PCA</span> extension of principal PCA but using kernel methods. 

```PYTHON
sklearn.decomposition.KernelPCA(n_components, kernel, degree, max_iter, random_state, n_jobs, ...)
```
* <span style="color:orange;">t-distributed Stochastic Neighbor embedding (t-SNE)</span> is a statistical method for visualizing high-dimensional data by giving each datapoint a location in a two or three-dimensional map
```PYTHON
sklearn.manifold.TSNE(n_components, n_iter, n_iter_without_progress, verbose, random_state, n_jobs, …)
```

### <span style="color:cyan;">Data split</span>

In the development of a complete flow of machine learning models, its very important how the training and test data are selected. 

Important to preserve: 
* randomness
* balance in data segmentation

Split the data into 2 or 3 splits: 
* `train`: used for training the models. 
* `validation`: used for tuning hyper-parameters. 
* `test`: used for evaluations the model. 

Type of splitters from `sklearn.model_selection`: 

| Technique                   | Description                                                   |
|-----------------------------|---------------------------------------------------------------|
| `train_test_split`          | Split arrays or matrices into random train and test subsets   |
| `GroupKFold`                | K-fold iterator variant with non-overlapping groups          |
| `GroupShuffleSplit`         | Shuffle-Group(s)-Out cross-validation iterator                |
| `KFold`                     | K-Folds cross-validator                                      |
| `LeaveOneGroupOut`          | Leave One Group Out cross-validator                           |
| `LeavePGroupsOut`           | Leave P Group(s) Out cross-validator                           |
| `LeaveOneOut`               | Leave-One-Out cross-validator                                 |
| `LeavePOut`                 | Leave-P-Out cross-validator                                   |
| `PredefinedSplit`           | Predefined split cross-validator                              |
| `RepeatedKFold`             | Repeated K-Fold cross-validator                               |
| `RepeatedStratifiedKFold`   | Repeated Stratified K-Fold cross-validator                    |
| `ShuffleSplit`              | Random permutation cross-validator                           |
| `StratifiedKFold`           | Stratified K-Folds cross-validator                            |
| `StratifiedShuffleSplit`    | Stratified ShuffleSplit cross-validator                       |
Most important ones: 

* `Stratified K-fold cross-validation`: K-fold particiones that data without maintaining a balance but maintains the <span style="color:orange;">ratio of different classes</span> per each k-fold partition. 
* `Leave p-out cross validation`: Not recomendable for imbalanced datasets. High computational time. 
* `Leave one-out cross-validation`: Same as `Leave p-out` but using only $1$ as validations and $n-1$ is used for training. 
* `Montecarlo cross-validation`: Each iteration takes $p$ random values for testing randomly for the dataset. 
* `Time series cross-validation`: Because data is ordered by time, small subset an dits forecast is used for training in the next one. Once time is passing, always take the last time samples for testing because cannot use future to predict past. 

--- 
All of this steps can be <span style="color:orange;">encapsulated</span> in different unions that simplify production, increase safety and reduce lines of code. 

Use of: 

```PYTHON
sklearn.pipeline.Pipelibe(steps, memory, verbose)
```

Sequentially apply a list of transforms with a final estimators. 

And concatenate: 

```PYTHON
sklearn.pipeline.FeatureUnion(transformer_list, n_jobs, transformer_weights, verbose)
```

This estimators applies a list of transformer objects in parallel to the input data. 





