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

This method dont work with 

Example dealing with ajax: 


```JS
if(!Object.hasOwn(person, "name")){  
    alert("Person has no name");  
    return;  
}

let pname = person.name; 
```



---

#### BROWSERS SUPPORT

![[HasOwnBrowserSupport.png]]
