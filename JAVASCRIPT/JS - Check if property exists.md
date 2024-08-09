#JS #OOP 

When we need to check if JavaScript object contains specific property we can use several methods including JavaScript operators, specific static methods from Object class, object instance methods, array instance methods and custom JavaScript function.


### in operator

This operator returns true if the specified property is inside the object or inside its prototype chain. 
Also works with object created using `Object.create()` static method. 

```JS
const person = {  
name: 'John',  
surname: 'Doe',  
age: 41  
};  
  
const hasLocation = 'location' in person;  
if (hasLocation) {  
console.log("We have the location data");  
} else {  
console.log("We don't have the location data")  
}  
// result: We don't have the location data  


const user = Object.create({ name: 'Donald' });  
console.log('name' in user); // true
```


### hasOwn()

When dealing with objects and dont knowing if they can have a concrete property because you have recieved them from an <span style="color:orange">ajax request</span> or another file, you can use: 

>`hasOwn(object, string parameter)`

This method also work with `Object.Create()` but its so new that not all browser version support it. 

Example dealing with ajax: 


```JS
if(!Object.hasOwn(person, "name")){  
    alert("Person has no name");  
    return;  
}

let pname = person.name; 
```


### CUSTOM 

You can create your custom `hasKey()` function for checking if an object contains a specific key. 

```JS
const person = {  
name: 'John',  
surname: 'Doe',  
age: 41  
};  
  
const user = Object.create({ name: 'Kevin' });  
  
function hasKey(object, target) {  
	if (object && target) {  
		for (const key in object) {  
			if (key === target) {  
				return true;  
			}  
		}  
		return false;  
	} else {  
		return false;  
	}  
}  
  
console.log(hasKey(person, 'name')); // true  
console.log(hasKey(person, 'location')); // false  
console.log(hasKey(user, 'name')); // true
```

### Own recommendation

Its preferred to use <span style="color:orange">in operator</span> for now, because its high compatibility, more than <span style="color:orange">hasOwn()</span>. 

>“in” operator and Object.hasOwn() method are the methods we need to stick to in our every day work

---

#### BROWSERS SUPPORT

![[HasOwnBrowserSupport.png]]
