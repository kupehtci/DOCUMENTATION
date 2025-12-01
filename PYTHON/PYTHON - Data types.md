#PYTHON 

# PYTHON Variable types

Python can have the following type of variables, taking into account that python is a dynamically typed language. 

# How to check the type

You can check the type of a variable using `type(...)` like: 
```python
x = 25
type(x) # int
```

Which can be used to ensure data type: 
```python
x = 25
if type(x) == int: 
	print("x is an integer")
elif type(x) == str: 
	print("x is an string")
else: 
	print ("x is neither an integer nor a string")
```

## Scalar types

An scalar type is the one that contains a single value, without any internal structure like: 

Text Type:	
* str
Numeric Types:	
* int: single numerical value without decimal: 
```python
x = 5
```

* float
```python
x = 5.0
```

* complex

Sequence Types:	
* list
* tuple 
* range

Mapping Type:
* dict

Set Types:	
* set
* frozenset

Boolean Type:
* bool: true or false: 
```python
myBool = False
myBool = True
```

Binary Types:	
* bytes
* bytearray
* memoryview
None Type:	
* NoneType


## Dynamically typed language

Python is a dynamically typed language, meaning that variable types are determined at runtime. 
Rather than other languages like C where you need to declare a variable type when the variable is declared by code. 

Additionally the variables can change type during the program execution. 