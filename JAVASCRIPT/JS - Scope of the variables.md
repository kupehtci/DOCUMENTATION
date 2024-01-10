#JS 

## SCOPE

Is the range that the variable will have in the code. There are two types of scopes: 

* Local: Its only accesible in a block of code
* Global: Its accesible in all the code. 

In the case of JS, when a variable is declared outside a function or a for block, its treat as global and can be accessed from anywhere. 

Examples: 
```JS
function platzi() {
	const soyEstudiante = true;
	console.log(soyEstudiante);
}

platzi(); // true
console.log(soyEstudiante); // soyEstudiante is not defined
```



```JS
const soyEstudiante = true;

function platzi() {
	console.log(soyEstudiante);
}

platzi(); //true
console.log(soyEstudiante); //true
```

### SCOPE IN JAVASCRIPT

In javascript we have three type of scopes when declarating a variable `let, const and var`

<div style="padding: 0.5rem; border:1px solid white; border-radius:0.3rem;">
let and const: 
	Both of them only have scope inside the block they are within. 
</div>

```JS
let platzi = 'Esto está fuera del bloque';

if (true) {
	let platzi = 'Esto está dentro del bloque';
	console.log(platzi); //Esto está dentro del bloque
}

console.log(platzi) //Esto está fuera del bloque
```

<div style="padding: 0.5rem; border:1px solid white; border-radius:0.3rem;">
var: 
	Its global, so acts outside the block they are within: 
</div>

```JS
var platzi = 'Esto está afuera del bloque'; 
if (true) { 
	var platzi = 'Esto está dentro del bloque'; 
	console.log(platzi); //Esto está dentro del bloque 
} 
console.log(platzi); //Esto está dentro del bloque
```

Take into account that <span style="color:orange;">var</span> expands into other files that are linked in HTML because they are embedded and executed linearly. 

This can be used to declare <span style="color:orange;">var</span> variables in a PHP-HTML file using \<script\> and access this file from inside another JS file linked in the HTML that can be external or internal. 

See: [[JS - Pass variables PHP to JS]] option 5 of passing parameters. 
