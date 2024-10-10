#TERRAFORM 

# TERRAFORM `replace` function

The `replace(string, substring, replacement)` searches in the given `string` the occurrence of a `substring` and replace it with a `replacement` string. 


This can be helpful in some cases: 

* Azure Storage accounts names can only be between 3 and 24 characters in length and only containing numbers and lower-case letters. 

Example of usage for a Storage Account Name: 
```c
// In order to avoid the input by variables of a "-" that is common in environment names
lower(replace(var.environment, "-", " "))
```