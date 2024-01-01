#JS #OOP
## OOP in Javascript

Like other languages, <span style="color:MediumSpringGreen;">Javascript</span> sustains Object Oriented Programming (OOP). 

A class in Javascript has the following format: 

```JS
class Rectangle {
 // Constructor of the class
  constructor(height, width) {
	this.height = height;
	this.width = width;
  }
  // Getter
  get area() {
	return this.calcArea();
  }
  
  // Method
  calcArea() {
    return this.height * this.width;
  }
}

```

### GET

The getter declaration is done by the `get` statement. 
This getter let us have access to a variable which value is dinamically calculated and its retrieve gets called like a method: 

```JS 
const PI = 3.141592; 

class Circle{
	constructor(radius){
		this.radius = radius; 
	}

	get area(){
		return radius * radius * PI; 
	}
}

let circleA = new Circle(2); 
console.log(circleA.area);    //Output: 12.56
```



### Take into account

<div style="color: black; background-color: #ede6a4; padding: 0.3rem; justify-content: center; text-align: center;"><p>A javascript class is not an object.</p>
<p>A JS class is a template for Javascript Objects.</p> </div>


