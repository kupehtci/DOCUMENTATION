#CMAKE 


Cmake building system accepts `if` and `elseif` statements for making different build depending on certain variables. 

The valid operators between the parentheses are: 

* Unary checks such as: 
	* EXISTS: check if file or directory exists
	* COMMAND: gives true if the given parameter is a macro or predefined function
	* DEFINED: check if a variable is defined or set
* Binary tests such as: 
	* EQUAL 
	* LESS
	* LESS_EQUAL
	* GREATER
	* GREATER_EQUAL
	* STREQUAL
	* STRLESS
	* STRLESS_EQUAL
	* STRGREATER
	* STRGREATER_EQUAL
	* VERSION_EQUAL
	* VERSION_LESS
	* VERSION_LESS_EQUAL
	* VERSION_GREATER
	* VERSION_GREATER_EQUAL
	* PATH_EQUAL
	* MATCHES - Comparison operator
* Unary modifier operators, such as `NOT`
* 