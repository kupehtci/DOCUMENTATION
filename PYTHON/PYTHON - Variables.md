#PYTHON 

# PYTHON Variables

In python the primitive variables are no hard-typed, so the same value can change the data that is contained within it at runtime. 

This variables are a kind of containers for holding data values 

You declare variables when you give it a value: 

```python
y = "Hello world"
x = 5
z = 2.5
```

The value can be changed in runtime: 

```python
x = 4           # Initialized as a number value
x = "Daniel"    # Now is string type
print(x)        # It will print Daniel
```

And this values can also be **casted**[^cs]: 

```python
x = str(2)      # So x will be x = "2"
y = int(2)      # y its 2
z = float(2)    # z now its 2.0 
```

And you can check the type of a variable and the data within it with `type()` function: 

```python
a = ("Python", "Javascript", "C++")
b = 3
c = "Hello world"
print(type(a))    # output: <class 'tuple'>
print(type(b))    # output: <class 'int'>
print(type(c))    # output: <class 'str'>
```

##### Variable name format

Variable names are <span style="color:DodgerBlue;">case-sensitive</span> so as an example "a" and "A" are not the same variable: 

```python
a = 3
A = 5         # A is independent from a and has another value
b = a + A
print(b)      # output: 8
```

The name of the variables must meet: 

* The variable name must start with a letter or underscore value. 
* A variable name can not start with a number or other special character. 
* A variable name can only contain \[a-Z\], \[0-9\] and "_". 
* Cannot be one of the python keywords. 

##### Multi-value assign

You can assign values following different ways: 

* Assign multiple values to multiple variables: 

```python
x, y, z = "Python", "Javascript", "C++"
```

* Assign one value to more than one variable: 

```python
x = y = z = "Python"
```

* Unpack a collection to multiple variables: 

```python
languages = ["Python", "Javascript", "C++"]
x, y, z = languages
# x is now "Python"
# y is now "Javascript"
# z is now "C++"
```



[^cs]: Casting in python [[PYTHON - Casting]]
