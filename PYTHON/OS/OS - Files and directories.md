#PYTHON 

# OS - Files and directories

Working with files and directories is one of the common tasks in any OS that can be automated with Python's OS library. 

This guide is a set of the most useful commands to program with OS: 

* `os.getcwd()` show current directory. 
* `os.chdir()` change current working directory.
* `os.listdir(".")` list the content of a directory.
* `path = os.path.join(".", fileName)` retrieve a file or a directory. 
* `os.path.isfile(path)` check is its a file. 
* `os.path.isdir(path)` check is its a directory. 
* `os.mkdir("logs")` create a directory
* `os.makedirs("data", exist_ok=True)` nested and no error if the directory exists. 

* `os.rename("note.txt", "notes.txt)`

## Open a file

```python
with open("notes.txt", "w") as f: 
	f.write("hello")
	
# Also without scoping: 
f = open("notes.txt", "r", encoding="utf-8")
```

You need to specify the path to the file and the opening mode (w for write, r for read, a for appending, x to create a new file). 
* You can add `+` for combining opening modes: 
	* `r+` read and write but file must exists
	* `w+` read and write, truncates or creates the file. 
* You can use `b` mode to read the bytes: 
```python
with open("image.jpeg", "rb") as img: 
	data = img.read()
```

It returns a file object. 

* `f.read()` read the entire file in one line
* `f.read(n)` reads up to `n` characters. 
* `f.readline()` reads one line
* `f.readlines()` reads all lines and creates a list. 
```python
f.readlines("notes.txt")
for line in f: 
	print(line.rstrip("\n"))
```

## Path utilities: 

```python
base = "/var/log"
filename = "syslog"
full = os.path.join(base, filename)   # Will be "/var/log/syslog"

print(os.path.basename(full))   # "syslog"
print(os.path.dirname(full))    # "/var/log"
print(os.path.exists(full))     # True / False
print(os.path.isfile(full))     # is a file? 
print(os.path.isdir(full))      # is a directory?
```