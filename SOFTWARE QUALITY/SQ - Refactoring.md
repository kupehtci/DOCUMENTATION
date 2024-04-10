#SoftwareQuality 

# REFACTORING AS A QA ACTIVITY

Refactoring consists in modifying software to improve its readability, maintainability and extensibility without changing its characteristics and behaviour. 

Is related to prevention. Actions that intend to <span style="color:orange;">minimize the number of defects</span> that are injected in the software by developers. 

Refactoring are changes that <span style="color:orange;">affect the internal quality</span> of the software product but maintaining the external quality, performance and behaviour. 

Take into account that testing and refactoring are different activities. 

To do a refactor the first step is to identify <span style="color:MediumSlateBlue;">"bad smells"</span>. This is a reference to code traces that can be easily identified as bad performance or bad formatted code. 

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

If always checking that is a value is null, its replaced with a default value, we can define a null object for that: 

```CSHARP

class Person{
	string name; 
	int age; 
	public Person(){}
}

// ---------NULL OBJS ---------
Person _person = null; 

if(_person == null){
_person = new Person("Pablo", 21);
}

// ---------replace with this---------

class Person{
	string name; 
	int age; 
	public Person(){}
	public bool IsNull(){
		return false; 
	}
}

class NullPerson : Person{

public NullPerson(){

}

public bool IsNull(){
	return true; 
}
}

Person _person = (_auxPerson == null) ? _auxPerson : new NullPerson(); 

_person.IsNull(); 
```