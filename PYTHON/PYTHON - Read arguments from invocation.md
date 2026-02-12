#PYTHON 

# PYTHON - Read arguments from invocation

When you invoque or execute a python script using `python <file>` or `python3 <file>` you can pass arguments into the script for dynamic execution, like: 

```bash
greetings.py Daniel
```

For reading an argument from the script you can use `sys` library to access `sys.argv[...]` like: 

```python
import sys

print("Greetings to" + sys.argv[1])
```


You can also set a more advanced parameters workflow using **argparse** ([[argparse]]). 