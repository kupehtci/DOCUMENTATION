#SHELL

# `read` command

Read command can be used to read an input in the console by the user. 

By default, it will place the input string in the `$REPLY` variable. But the variable where it will be place can be set while invoking the command: 

```bash
> read 
> Hello world
> echo $REPLY
Hello world

# By setting the variable to save the input: 
> read var1
> Hello world
> echo $var1
Hello world
```


It can be also used in a `while` loop and once the while has stopped, all the input can be recollected and used. 
 
Example: 
```bash
while read line; do
	echo "Next value: "
	echo $line
done
```

Read from a file: 

```bash
IFS=:
while read username line; do
	echo "Next value: "
	echo $line
done < /etc/passwd

# Or in a more readable way(But less efficient): 

IFS=:
cat /etc/passwd | while read username line; do
	echo $username
done
```

