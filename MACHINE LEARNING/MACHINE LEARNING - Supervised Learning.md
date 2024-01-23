#ML 

Learning about a <span style="color:orange;">classified dataset</span> (labels or expected values) to be able of making future predictions. 

Can be: 

`Classification`

Predicts an <span style="color:orange;">objects' cathegory</span> 
Data should be labeled with features for making the machine to assign the classes. 
Binary or multiclass. 

`Regression`

Classification where the <span style="color:orange;">forecast is a continuous number</span> instead of a category. 
Needs to identify how the features are related to current output. 
Works defining a regression line. 


### Models

`LINEAR REGRESSION`

Attempts to model the relationship between two variables by fitting a linear equation to the data for calculating output values. 
<span style="color:MediumSpringGreen;">Regression algorithm</span> 

Equation with the form of    $Y = a +bX$

`LOGISTIC REGRESSION`

<span style="color:MediumSpringGreen;">Classification algorithm</span>, used when <span style="color:orange;">target variable is categorical</span> by nature. 

Converts the value into \[0, 1\] and can be binomial and multinomial. 


`DECISION TREE`

Uses a decision tree to go from observations about an item to conclusions about the items target value represented in the leaves and decision being placed in each node with a next sub-node to choose. 

<span style="color:MediumSpringGreen;">Classification and regression</span>. 

`RANDOM FOREST`

<span style="color:MediumSpringGreen;">Ensemble Learning method</span> that construct a multitude of decision trees at training time. 

* For <span style="color:MediumSpringGreen;">classification</span>: outputs of the random forest is the class selected by most trees  (voting)
* For <span style="color:MediumSpringGreen;">regression</span>: outputs the mean or average of the individual trees. 

Considered as <span style="color:RebeccaPurple;">Black Box</span>

`EXTRA TREES`

<span style="color:MediumSpringGreen;">Ensemble machine learning method</span> that combines predictions from many decision trees. 
Unlike random forest that train each tree with a split of the data, extra trees trains each tree with the <span style="color:orange;">whole training dataset</span>

<span style="color:MediumSpringGreen;">Classification and regression</span>


`GRADIENT BOOSTING`

Machine learning technique that produces a prediction model by assembly weak prediction models like decision trees one after another using the output of one as input of the following one. 
Relies in that the next model will improve the results of the last one. 

Considered as <span style="color:RebeccaPurple;">Black Box</span> because the trees combination makes this models less interpretables. 

`XGBoost`

<span style="color:orange;">Decision tree</span> based ensemble machine that uses <span style="color:orange;">gradient boosting</span> but with a more regularized model formation to control over-fitting and gives a better performace. 

<span style="color:MediumSpringGreen;">Classification and regression</span>

`SUPER VECTOR MACHINE (SVM)`

Supervised learning algorithm based in the idea of <span style="color:orange;">finding an hyperplane</span> that separes the features into certain domain / areas. 

Long to process so requires small datasets. 

Effective when  $num\_dimensions >= num\_samples$. 

<span style="color:MediumSpringGreen;">Classification and regression</span>
Considered as <span style="color:RebeccaPurple;">Black Box</span>

![[supper-vector-machine-diagram.png|300]]

`K-NEAREST NEIGHBORS`

Simplest machine learning algorithm that assumes the similarity between new data and avaliable data and puts the data into the most similar category. 

Calculated with distance functions in a dimensional space placing in function of samples features. 

Considered as <span style="color:RebeccaPurple;">Black Box</span> for being less interpretable, specially when data dimensions increases. 

<span style="color:MediumSpringGreen;">Classification and regression</span>

![[k-nearest-neighbor.png]]


`MULTILAYER PERCEPTRON`

Deep artificial, <span style="color:orange;">artificial neural network</span> composed of an input layer that receives the input, an arbitrary number of hidden layers and an output layer that makes the decision or prediction. 


### <span style="color:#ababf5;">Ensembles</span>

Combine the predictions of multiple base estimators in order to improve generalizability and robustness over only one estimator. 

Can be of two types: 

* `Averaging method`:  Builds estimators in parallel an average its predictions
* `Boosting method`:  Build estimators sequentially and one tries to reduce the bias of the previous one. Combine weak estimators to create a powerful ensemble. 

The most common ensembles: 

`BAGGING`

Built several instances of black box estimators on <span style="color:#c71585;">random subsets</span> of the training set and aggregate their own predictions. 

`ADABOOST`

Fit a sequence of weak learners on repeatedly modified versions of the data, Predictions combined from all of them <span style="color:#c71595;">weighted</span>. 

`VOTING`

Combine machine learning classifiers and use the majority vote or average prediction. 

`STACKING`

Combine estimators by using predictions of each individual estimator stacked as an input for a <span style="color:#c71595;">final estimator</span> that compute the final prediction. 


Ensemble methods in general are considered as <span style="color:RebeccaPurple;">Black Box</span>, and more when they are formed of black box models