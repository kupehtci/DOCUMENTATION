#AZURE_DEVOPS #DEVOPS 

# Azure DevOps conditionals

For evaluating conditions and execute certain tasks or code depending on pipeline parameters, variables or executions, Azure DevOps offers a set of statements for evaluating this in **compile-time**: 

- `${{ if condition }}`: Start of a conditional block that is included only when condition is true.
- `${{ elseif condition }}`: Additional conditional branch evaluated before the previous if or else if conditions. 
- `${{ else }}`: Fallback block when no one of the previous if or elseif conditions are matched. 

The conditions need to be in YAML format, followed by `:` like: 
```yaml
- ${{ if eq(parameters.Tec, 'java') }}:  
  - task: PowerShell@2  
    displayName: 'Check java installation'  
    inputs:
	    # ...
- ${{ elseif eq(parameters.Tec, 'dotnet') }}:  
  - task: PowerShell@2  
    displayName: 'Check .Net installation'  
    inputs:
	    # ...
	    
- ${{ else }}:  
  - task: PowerShell@2  
    displayName: 'None technology to check'  
    inputs:
	    # ...
```


Azure DevOps provides a set of boolean or utility functions that can be used to evaluate conditions in expressions like `${{ if }}`. 

If conditionals are evaluated over boolean values, can be done without operators like: 
```yaml
- ${{ if parameters.Compile }}: 
  # ...
```

The most common equality, comparison, logical operators or string helpers are the following: 

- `eq(a, b)`: True if a equals b (string, number, bool, or null)​
- `ne(a, b)`: True if a is not equal to b.
- `and(a, b, ...)`: True if all arguments are true​
- `or(a, b, ...)`: True if one argument is true
- `not(a)`: Logical negation; true if a is false
- `gt(a, b)`: True if a > b (numbers only)​
- `ge(a, b)`: True if a ≥ b.​
- `lt(a, b)`: True if a < b.​
- `le(a, b)`: True if a ≤ b.​
- `iif(condition, trueValue, falseValue)`: Inline “if”; returns trueValue when condition is true, otherwise falseValue.​

For string comparison and collections: 

* `startsWith(str, prefix)`: True if str begins with prefix (e.g., refs/heads/feature/).​
* `endsWith(str, suffix)`: True if str ends with suffix.​
* `contains(strOrArray, value)`: True if a string contains a substring, or an array contains a value.​
* `in(value, 'a', 'b', ...)`: True if value matches one of the listed options (e.g., build reasons).​
* `format('pattern {0} {1}', a, b)`: Returns a formatted string; often used to build names/paths.​
* `coalesce(a, b, ...)`: Returns the first non‑null/non‑empty argument.​


To react to previous jobs or step status you can use one of the following conditionals:

* `succeeded()`: True when all dependencies succeeded (default for steps/jobs).​
* `succeededOrFailed()`: True when dependencies are either succeeded or failed, but not canceled.​
* `failed()`: True when at least one dependency failed.​
* `canceled()`: True when the run or dependency was canceled.​
* `always()`: Always evaluates to true, even if canceled (subject to hard failures like checkout errors).​
* `succeededWithIssues()`: True if a dependency finished with warnings/issues.