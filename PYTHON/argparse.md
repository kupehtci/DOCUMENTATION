#PYTHON 

# Python - argparse

**argparse** is a python's module that can be used to use flags in a robust way when calling a python script. 

```python 
# script.py
import argparse

# Declare a parser
parser = argparse.ArgumentParser(description="Demo of flags")

# You need to add the flags as arguments: 
parser.add_argument("-n", "--name", type=str, required=True, help="Your name")
parser.add_argument("-a", "--age", type=int, default=18, help="Your age")
parser.add_argument("-v", "--verbose", action="store_true", help="Enable verbose mode")
```

The common workflow for using `argparse` is to declare a parser with a description and then define all the arguments using `parser.add_argument`: 

The parser defines the "help" section prompted when using the program: 
```python
parser = argparse.ArgumentParser(
				prog='ProgramName',
				description='What the program does',
				epilog='Text at the bottom of help')
```

The `add_argument()` declares an argument that can be the input of the script: 

```python
parser.add_argument("-v", "--verbose", action="store_true", help="Enable verbose mode")
```

It accepts: 
- `name or flags` - Either a name or a list of option strings, e.g. `'foo'` or `'-f', '--foo'`.
- `action`: the basic type of the action to execute when the flag is used. 
- `nargs`: number of arguments that must be consumed. 
- `const`:  a constant value required by `action` and `nargs`
- `default`: the default value consumed if its not defined when calling the script. 
- `type`: the type that the value must be converted to when called. 
- `choices`: a list of admitted values that the argument can have
- `required`: define if the argument can be omitted. 
- `help`: a brief description of the argument usage.
- `metavar`: a name for the argument in the usage menu.     
- `deprecated`: Whether or not use of the argument is deprecated.