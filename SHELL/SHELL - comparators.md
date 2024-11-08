#SHELL 

### SHELL Comparator

In shell scripting, comparison operators are used within `if` and `while` statements to control the flow of the execution of a script. 

Here is a cheat sheet of the main comparison operators available for different primitives.

##### Numeric Comparisons

These operators are used to compare integer values.

| Operator | Description              | Example             |
| -------- | ------------------------ | ------------------- |
| `-eq`    | Equal to                 | `[ "$a" -eq "$b" ]` |
| `-ne`    | Not equal to             | `[ "$a" -ne "$b" ]` |
| `-lt`    | Less than                | `[ "$a" -lt "$b" ]` |
| `-le`    | Less than or equal to    | `[ "$a" -le "$b" ]` |
| `-gt`    | Greater than             | `[ "$a" -gt "$b" ]` |
| `-ge`    | Greater than or equal to | `[ "$a" -ge "$b" ]` |
```bash 
if [ "$a" -gt 10 ]; then     
	echo "a is greater than 10" 
fi
```

##### String Comparisons

String comparisons are used to compare text values.

|Operator|Description|Example|
|---|---|---|
|`=`|String is equal|`[ "$str1" = "$str2" ]`|
|`!=`|String is not equal|`[ "$str1" != "$str2" ]`|
|`<`|String is less than (alphabetically)|`[ "$str1" \< "$str2" ]`|
|`>`|String is greater than (alphabetically)|`[ "$str1" \> "$str2" ]`|
|`-z`|String is empty|`[ -z "$str" ]`|
|`-n`|String is not empty|`[ -n "$str" ]`|

> **Note:** For `<` and `>` in string comparisons, escape them with a backslash (`\`) to avoid confusion with redirection operators.

```bash
if [ "$str1" = "hello" ]; then     
	echo "String is 'hello'" 
fi
```

##### File Comparisons

These operators help determine file types and properties, such as existence, permissions, and types.

|Operator|Description|Example|
|---|---|---|
|`-e`|File exists|`[ -e "$file" ]`|
|`-f`|File exists and is a regular file|`[ -f "$file" ]`|
|`-d`|File exists and is a directory|`[ -d "$file" ]`|
|`-r`|File is readable|`[ -r "$file" ]`|
|`-w`|File is writable|`[ -w "$file" ]`|
|`-x`|File is executable|`[ -x "$file" ]`|
|`-s`|File exists and is not empty|`[ -s "$file" ]`|
|`-L`|File is a symbolic link|`[ -L "$file" ]`|
```bash
if [ -d "/etc" ]; then     
	echo "/etc is a directory" 
fi
```

##### Compound Comparisons

You can combine conditions using `&&` (AND) and `||` (OR) operators.

|Operator|Description|Example|
|---|---|---|
|`&&`|Logical AND|`[ "$a" -gt 0 ] && [ "$b" -lt 5 ]`|
|`||`|
```bash 
if [ "$a" -gt 0 ] && [ "$b" -lt 10 ]; then     
	echo "a is positive and b is less than 10" 
fi
```

