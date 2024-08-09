#ML 

## Effect of Multicollinearity:

A key goal in regression analysis in machine learning is to isolate the relationship between each independent variable,
and the dependent variable. So change in one independent variable shouldn't affect any other variables in the given
data. 
However, when independent variables are correlated, it indicates that changes in one variable are associated with shifts 
in another variable. As the severity of the multicollinearity increases so do these problematic effects.

So during the fitting of the model, a small change in one variable can lead to a significant amount of swing in the
model output. However, these issues affect only those independent variables that are correlated.

However, these issues affect only those independent variables that are correlated. 

Solution:
•	The severity of the problems increases with the degree of multicollinearity. Therefore, if you have only moderate 
     multicollinearity, you may not need to resolve it.

•	Multicollinearity affects only the specific independent variables that are correlated. Therefore, if 
     multicollinearity is not present for the independent variables that you are particularly interested in, you may not 
     need to resolve it. Suppose your model contains the experimental variables of interest and some control variables.
     If high multicollinearity exists for the control variables but not the experimental variables, then you can 
     interpret the experimental variables without problems.

•	For distance based ml algorithms, if one of the collinear feature has not much to contribute in prediction or 
     classification then we can drop the feature for analysis.(This method is not highly practiced and can be used with proper reason to show)