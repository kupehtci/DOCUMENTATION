
#### Target is multiclass but average='binary'. Please choose another average setting, one of [None, 'micro', 'macro', 'weighted'].

this error is displayed when dealing with cross validation 

```python
	scores = cross_val_score(model_fit, X_train, Y_train, cv=kfold, scoring='f1')
```

This error indicated that the target model is multiclass instead of binary class. 
TO change this just add as a parameter that the f1 needs to be weighted: 

```python 
	scores = cross_val_score(model, X_train, Y_train, cv=5, scoring="f1_weighted")
```

