#SHELL 

# `source` command


By default, all the bash or shell scripts are executed inside a sub-shell. 

This means that the created environmental variables are not propagated to the parent shell. 

To execute a shell script in the same shell where its executed you can use `source` followed by the script invocation. 

Example: 
```bash
# example.sh
$hello = "Hello world"
export $hello

# Command line
> source example.sh
> echo $hello
Hellow world
```



