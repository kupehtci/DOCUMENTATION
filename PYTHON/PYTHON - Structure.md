#PYTHON 

# PYTHON - Structure

In Python you can define and use te following structure to compose a python file: 

## Functions

The functions are began with a `def` followed by name of the function and `(parameters...)` like: 

```python
def printName(name):
	print("Name: " + name)
```

Parameters can specify variables that are passed into python function and its scoped to the function.

## Imports

For using certain packages or dependencies for python, you need to import them into the file. 
For doing so, use the `import` statement followed by the dependency name: 

```python
# Import math library for using Square Root function 
import math

print(math.sqrt(25))
```

## Conditionals

Conditional executions can be declared in python using `if`, `else` and `elif` statements like: 

```python
age = 7: 
if age > 10: 
	print("Age is greater than 10")
elif age > 5: 
	print("Age is greater than 5")
else: 
	print("Age is 5 or less")
```


## For loops

A `for` loop in python is used to iterate the elements of a sequence or set of continuously placed items. 

The syntax is always: 
```python
for element in sequence: 
	# code
```

An example of an iteration over a sequence can be: 
```python
fruits = ["apple", "pear", "watermelon"]

for fruit in fruits: 
	print(fruit)
```

So when you want a loop with a defined number of iterations but without going through a set like previous example, you should use `range()` function like: 

```python
for i in range(5): 
	print(i)       # 0, 1, 2, 3, 4
```

You can also travel an string character by character: 
```python
for c in "Daniel": 
	print(c)
```

Or a dictionary going through each key and value: 
```python
dic = {"name":"Daniel" ,"age", 25}

for key in dic: 
	print(key + " " + dic[key])
	
# Or using double iterator
for key, value in dic: 
	print(key + " " + value)
```

In case you want to exit or avoid an iteration in a for loop, you can use `break` and `continue` statements: 
```python
for i in range(10):
    if i == 5:
        break      # stops the loop at 5
    if i % 2 == 0:
        continue   # avoid evaluating pair numbers
    print(i)
```

