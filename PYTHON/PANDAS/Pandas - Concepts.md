#PANDAS #PYTHON 

# Pandas - Concepts

## Data load

For working with real values, normally the first step is to load the data from a CSV, Excel or Json: 

* `pd.read_excel()` loads an excel table into a DataFrame. 
	* `pd.to_excel()` stores the data into an excel file. 
* `pd.read_json()` loads a JSON into a DataFrame.
	* `pd.to_json()` stores the data into a JSON. 
* `pd.read_csv()` loads a CSV into a DataFrame. 
	* `pd.to_csv()` stores the data into a CSV,

## Inspect and explore

To read a dataset and understand its structure you can use: 
* `df.info()` for types and nulls
* `df.describe()` for numerical statistics
* `df.head()` for reading the first rows
* `df.tail()` for reading the last rows

You can also check the size of the DataFrame with `df.shape`, returning (rows, columns) like: (3793, 10). 

## Select

For selecting items you can: 
* `df['col']` or `df[['col1', 'col2']]` select by name of the column.

This will return a Series or a DataFrame for that set of columns. 

## Filter

For filtering you need to index the DataFrame using a boolean like: 

* `df[df['age'] > 25]` for filtering the rows that meet the condition. 
	* Take into account that `df['age'] > 25` will return a Series containing the indexed where the condition is met. 


## Data modification

You can add columns with calculated or conditionals like: 
```python
df['total'] = df['a'] + df['b']
```

## Null handling

To handle null values you can detect left values using `df.isnull()` or `df.isna()`. 
This can also be combined with `.sum()` to count the number of null values. 

## Order and agrupation

For ordering data you can use `.sort_values(config)` like: 
```python
df.sort_values(by='col')

df.sort_values(ascending)
```

## Combine (Join)

Pandas allows to combine tables using different formats: 

* `pd.merge` like a SQL Join
* `pd.concat` stack a df with another. 
* `join` join columns using indexes. 

