#SoftwareQuality 


Is related to prevention. Actions that intend to minimize the number of defects that are injected in the software by developers. 

Refactoring are changes that affect the internal quality of the software product but maintaining the external quality, performance and behaviour. 

Take into account that testing and refactoring are different activities. 

To do a refactor the first step is to identify "bad smells". This is a reference to code traces that can be easily identified as bad performance or bad formatted code. 

But refactoring have risks: 

##### Refactoring risks

* May introduce subtle error
* You can never guaranty once the refactoring is done, all is going to work properly as before. 


### GOOD PRACTICES

### Consolidate conditional expressions

When having some if conditions that lead into same result or return: 

```c
if(_month = 12){
	return true; 
}
else if(day < 30 & _month >= 6){
	return true; 
}
if(day == 18){
	if(month == 12){
		return true; 
	}
}
```

One solution is to combine them into one `if` statement but in this case with so much `or` conditions, would not be so much readable. 

If combining them into a method that returns a boolean, code would be self explanable: 

```C
if(IsDayAndMonth(1, 12)){
	return true; 
}
```

#### Null object

Always checking if instances are null can be replaced with null default values with a certain return or explicit behavior defined instead of crashing or doing some code if value is null. 