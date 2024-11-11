#PYTHON 

# PYTHON Variable scope

The variables that are created outside a function are known as global variables and its scope is all the script. 

Otherwise, if the variable is defined within a function, its scope its the block where is contained, once the function ends, it loses its value. 


##### Take into account

This scopes has some particularities that need to be taken into account: 

* If a variable is defined as global and then declared within a function, its use will be local and can only be used within the function. When the function ends, the variable as global will remain the same as the original value: 

```python
x = "Hello"

def foo(): 
	x = "world"
	print(x)      #output: world

foo()

print(x)          #output: Hello
```

* you can use the <span style="color:DodgerBlue;">global</span> keyword you can declare a global scope variable from within a function. This also allows to change a variable that has been previously defined in the global scope

```python
def foo(): 
	global x
	x = "Hello world"

foo()
print(x)       #output: Hello world
```

