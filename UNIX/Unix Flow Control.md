#UNIX 

### UNIX Flow control

Bash and shells in general has some flow control abilities: 

##### `if/else`

Common if else statement but the conditions are no classic boolean expressions. They are: 

* test of shell variables
* test of file characteristics
* exit status conditions

```bash
if command1; then
	# commands
elif command2; then
	# commands
else command3; then
	# commands
fi

# Example 
if [ $1 -gt $2 ]
then 
	echo "$1 is greater than $2"
fi
```

##### `Select`

Select allows to create simple menus easily. It generates a menu of each item in the list formatted with number for selecting each one of then. 
The user select one of the options with the number, the selected choice in the `name` variable and the number selected in `REPLY` variable. 

```bash
select name [in list]
do 
	# commands using $name or $REPLY
done

# Example
select day in Monday Tuesday Wednesday Thursday Friday Saturday Sunday
do
	echo "Day selected: $day"
done
> ./select.sh
1) Monday     3) Wednesday  5) Friday     7) Sunday
2) Tuesday    4) Thursday   6) Saturday
#? 1
Day selected: Monday
```

* `case`

Its similar to a switch in C. 
Allows use of patterns that contains wildcards characters. 
Any pattern may actually be composed of several patters separated by | 
The patterns are evaluated in order and if no one is met, nothing happens. 

```bash
case expression in
pattern1) 
	# command1
	;;
pattern2)
	# command2
	;; 
*) 
	# command if no other one was met
	;; 
esac

#Example: 

case $day in 
    Monday)
        echo "Monday selected"
        ;;
    Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday) 
        echo "Not monday"
        ;;
    *)
        echo "Not a valid name"
        ;;
esac
```

* `for` 

Classical for loop. It can be used to iterate over a list while there are elements remaining to go through in the list:  

```bash
for name [in list]
do
	# commands
done

# Example

for number in 1 2 3 4 5
do
	echo $number
done

# Print all .sh files in the current path
for script in *.sh
do
	echo $script
done
```

You can exit a loop iteration and start the next one by invoking `continue`. 

```bash
for day in Monday Tuesday Wednesday
do 
	if($day -eq "Tuesday")
	then
		continue
	fi

	echo $day
done
```

* `while` and `until`

Loop through a piece of code until the condition is met or not
`while` repeats while the condition is true
`until` repeats while the condition is false

```bash
while [command]
do 
	# command
done

# or 

until [command]
	#command
done

# Example: 

while [ "$*"]
do
	echo $1
	shift
done
```

* `break`

Exits from the current loop. 

```bash
days=(Monday Tuesday Wednesday Thursday Friday Saturday Sunday)
workdays = 0

for day in ${days[*]}; do
	if [$workdays -le 4]; then
		echo $day
		workdays=$((workdays+1))
	else
		break
	fi
done
```

