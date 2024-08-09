#ML 

Generalization of the model's ability to give sensible outputs to sets of inputs that has never seen before. 
Its <span style="color:#c71595;">underfitted</span> when it cannot capture the underlying trend of data. 
Its <span style="color:#c71595;">overfitted</span>  when the effect if overtraining with certain data for which the desired result is known by the model. 

### How to avoid overfitting 

* **Train with more data**: helps the mode to be more precise and now over know the same data
* **Cross-validation**: partition the sample of data into subsets. The goal of this is to predict new data that was not used in estimating it. 
* **Early stopping**: Stop the training before the performance falls down.
* **Regularization**: Form of regression that constrains the coefficient that the model estimated towards zero. 
	* Ridge regression 
	* Laso regression
* **Ensembling**: ensemble methods are techniques that reduce overfitting by combining different model predictions
