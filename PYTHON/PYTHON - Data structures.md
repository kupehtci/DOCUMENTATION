#PYTHON 

Data structures are a way of organizing data to be accessed in a more efficient way or organized one. 

In python, data structures are simpler comparing them to other languages. 

There are 4 main of them with this main characteristics

* Lists
* Dictionaries

| Data structure | Representation | Allow duplicates | mutable? | ordered? | function |
| ---- | ---- | ---- | ---- | ---- | ---- |
| List | \[\] | yes | yes | yes | list() |
| Tuple | () | yes | no | yes | tuple() |
| Set | {} | no | yes | no | set() |
| Dictionary | {} | no  | yes (keys no) | yes | dict() |

#### LISTS

Remember that list are not initialized with a size, unless you initialize them with some values. 
If trying to assign values using `[]` operator, can lead into error if its out of bounds. 

```PYTHON
lis = [1, 3, 5]
list[3] = 7   #error out of bounds
list.append(7)

```
There is a way to initialize a list by assigning initial values and fulling the list. 
```PYTHON
_size = 10; 
_list = [None] * _size;
```
For that you need to use `.insert(newValue)` or `.append(newValue)`. 


#### TUPLES


#### SET



#### DICTIONARY




##### Example of all data structures

```PYTHON
# Lists
l = []
 
# Adding Element into list
l.append(5)
l.append(10)
print("Adding 5 and 10 in list", l)
 
# Popping Elements from list
l.pop()
print("Popped one element from list", l)
print()
 
# Set
s = set()
 
# Adding element into set
s.add(5)
s.add(10)
print("Adding 5 and 10 in set", s)
 
# Removing element from set
s.remove(5)
print("Removing 5 from set", s)
print()
 
# Tuple
t = tuple(l)
 
# Tuples are immutable
print("Tuple", t)
print()
 
# Dictionary
d = {}
 
# Adding the key value pair
d[5] = "Five"
d[10] = "Ten"
print("Dictionary", d)
 
# Removing key-value pair
del d[10]
print("Dictionary", d)```