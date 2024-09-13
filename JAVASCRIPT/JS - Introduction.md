#JS 

# Javascript introduction

JavaScript is a versatile, high-level programming language that is primarily used to create dynamic and interactive content on websites. 

It runs in web browsers, allowing developers to build interactive web applications.

## Key Features

The key features of Javascript: 
- **Client-Side Scripting:** JavaScript is executed in the user's web browser, enabling interactive features like form validation, animations, and dynamic content updates.
- **Event-Driven Programming:** JavaScript responds to user actions such as clicks, key presses, and mouse movements.
- **Dynamic Typing:** Variables in JavaScript can hold any type of data, and types are determined at runtime.
- **Interoperability:** JavaScript can interact with HTML and CSS to modify web page content and styling.

## Basic Syntax

#### 1. Variables

Variables are used to store data. JavaScript uses `var`, `let`, and `const` to declare variables.

```javascript
let message = "Hello, World!";
const pi = 3.14159;
```

#### 2. Functions

Functions are blocks of code designed to perform a particular task. They can be defined and then called when needed.

```js
function greet(name) {
    return "Hello, " + name + "!";
}

let greeting = greet("Alice");
console.log(greeting);  // Output: Hello, Alice!
```

#### 3. Conditionals

Conditionals are used to perform different actions based on different conditions.

```js
let age = 18;

if (age >= 18) {
    console.log("You are an adult.");
} else {
    console.log("You are a minor.");
}
```

### 4. Loops

Loops are used to execute a block of code repeatedly.

```js
// for loop
for (let i = 0; i < 5; i++) {
    console.log(i);
}

// while loop

let count = 0;
while (count < 5) {
    console.log(count);
    count++;
}
```

### 5. Arrays

Arrays are used to store multiple values in a single variable.

```js
let fruits = ["Apple", "Banana", "Cherry"]; console.log(fruits[1]);  // Output: Banana
```

### 6. Objects

Objects are used to store collections of data in key-value pairs.

```js
let person = {
    name: "John",
    age: 30,
    greet: function() {
        return "Hello, " + this.name;
    }
};

console.log(person.greet());  // Output: Hello, John

```
## Integrating JavaScript into HTML

On of the main features of Javascript is to be embedded and executed  in an HTML document, by including it in the `<script>` tag.

It can be included internally or externally: 

* `internally`

```js
<!DOCTYPE html>
<html>
<head>
    <title>My Page</title>
</head>
<body>
    <h1>Hello World</h1>
    <script>
        document.body.style.backgroundColor = "lightblue";
    </script>
</body>
</html>
```

* `external`
s
```html
<!DOCTYPE html>
<html>
<head>
    <title>My Page</title>
    <script src="script.js"></script>
</head>
<body>
    <h1>Hello World</h1>
</body>
</html>
```

And in the `script.js` file: 

```js
document.body.style.backgroundColor = "lightblue";
```