#powershell 

# POWERSHELL - If conditionals

Basic structure: 
```powershell
if (condition) {
	# Code to execute if condition is true
}
```

Example: 
```powershell
$age = 20
if ($age -ge 18) {
	Write-Host "You are an adult."
}
```


### Comparison operators

Powershell allow different comparison operators to check conditions within the `if` or `elseif` conditions. 

* `-eq`: equal
* `-lt`: less than
* `-le`: less or equal than
* `-gt`: greater than
* `-ge`: greater or equal to
* `-like`: matches a pattern (Text comparison)


## Conditions combination

You can combine different conditions using logical operators such as: 
- `-and`: Both conditions must be true.
- `-or`: At least one of the conditions must be true.
- `-not`: reverses (negates) the condition.


## Ternary operator

PowerShell also allows a shorthand version of if-else condition called ternary operator. 

```powershell
$variable = (condition) ? "value if true" : "value if false"
```

A good example about this: 

```powershell
$name = "Daniel"
$isDany = ($name -like "Dani") ? $true : $false

if($isDany) {
	Write-Host "The name is Daniel"
} else {
	Write-Host "The name is not Daniel"
}
```