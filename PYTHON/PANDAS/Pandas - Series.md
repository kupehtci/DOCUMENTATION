#PANDAS #PYTHON 

# Pandas - Series

A **Series** in Pandas is a one-dimensional labeled array that can store data of any type of python. 
It has a single axis (Like a vector or an array) and has labels, as any item in the Series have a customizable index label. (By default 0, 1, 2, ...)

You can create a **Series** like: 
```python
import pandas as pd

# Create a series
series = pd.Series(["Zelda", "Persona", "Mario Bros"])

# Create a labeled Series
labeledSeries = pd.Series(["Zelda", "Persona", "Mario Bros"], index=["a", "b", "c"])

# Create a series from a dictionary (dict)
mDic = {'a': 1, 'b': 2, 'c': 3}
seriesFromDic = pd.Series(mDic)
```

As Series has labels, you can access data from any index using the label: 
```python
# Default series
series[0]

# Custom labeled series
labeledSeries['a']
```