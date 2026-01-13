#PYTHON 

# sys.argv

`sys.argv` is a list of the command line arguments accessed from the python ([[PYTHON]]) script that are passed through the command line. 

The `sys.argv` is a list containing in 0 position the name of the script and then all the arguments passed into the script. 

When you invoke a python script you can pass the arguments: 

```bash
python script.py argA argB
```

And the `sys.argv` as a list, will be `["script.py", "argA", "argB"]`


If you want to input arguments into the script in a more robust way using "labels", also called flags, you can check over [[argparse]]