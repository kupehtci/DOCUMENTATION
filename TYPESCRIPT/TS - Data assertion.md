#Typescript

# TS Data assertion

Data assertion or Type assertion is when a data is ensured to be a data type or primitive value. 

When you do type assertion you are telling the compiler to trust that a variable has a certain data or a certain model. 

Type assertions  don't perform runtime type checking and don' t make sure that is contains the specified data. 

An example of assertion is: 
```
interface User{
	username : string; 
	password : string; 
}
```