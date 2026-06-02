#PYTHON #PANDAS 

# Pandas - Filtering

Filtering using pandas imply selecting only the rows, columns or data that meet a condition. 

# Filtering a Series 

In a Series ([[Pandas - Series]]), you can filter the elements whose value meet a condition like: 
```python
import pandas as pd
from pandas import Series
even : Series = pd.Series([2, 4, 6])
# Filter elements superior to 5
even_filtered = even[even > 5]
```

# Filtering a DataFrame

On a DataFrame, filtering gets a little bit more complex due to the bi-dimensionality of the data. 

## Filtering rows

You can keep the rows that match a certain condition: 
```python
df[df['topic'] == 'sports']
```

Explained step by step: 
1. `df['topic']` returns only the column named `'topic'` in a Series. 
2. `df['topic'] == 'sports'` return an Series of booleans with True or False depending on the cell content compared to `'sports'`. (Boolean Mask)
3. The boolean mask is then used to mask or only "select" the element in the original DataFrame that meet the condition: `df[df['topic'] == 'sports']`

## Filtering columns

For filtering columns in order to only select the columns desired: 
```python
import pandas as pd
df = pd.DataFrame(....)
# as seen previously, for filtering a single column
topic = df['topic']

# for multiple columns
news_topic = df[['name', 'topic']]

# Also using .loc(...) with : meaning all rows and filtering the columns
subset = df.loc(: , ['name', 'topic'])
 
# Also using .iloc(...) for column positions
subset = df.iloc(:, [0, 2])
```