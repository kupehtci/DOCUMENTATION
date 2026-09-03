#AZURE_DEVOPS 

# Azure DevOps - Variables and parameters




## Access variables 

In Azure DevOps you have three different to define and access variables and they differ in the evaluation and scope: 

1. `${{  }}` Template expressions are evaluated before the pipeline executes, during the phase of compilation / parsing of the YAML. 
	* Example: `${ parameters.name}``
	* Used for static variables defined in the same YAML. 
	* Used in template functions like `if`, `else`, `and`, `or`, `notIn` and similars. 
	* Valid for: 
		* Variables
		* Parameters
		* Conditions
	* Cannot be used for: 
		* Runtime variables like `Build.SourceBranch` 

2. `$[  ]` Runtime expressions for runtime logic using defined variables. 
	* Example: `$[ Build.SourceBranch ]`
	* Used for predefined variables (`Build.*` and `System.*`)
	* Variables self-defined
	* Functions like `replace()`, `lower()`, `upper()`, `concat()` and similars. 
	* Valid for: 
		* Variables
		* Conditions
		* Expressions
	* In comparison with `$()` it allow to make transformation and logic. 

3. `$(  )` Macro syntax in runtime with simple expansion
	* Replaced in the execution but its a simple replacement without logic or functions. 
	* Example: `echo "$(v_project)"`
	* Valid for: 
		* Inside scripts like bash, powershell or python. 
		* Property values that accept variables. 
	* Cannot be used for: 
		* Evaluating expressions
		* Introduce logic. 