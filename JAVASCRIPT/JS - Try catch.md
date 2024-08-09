#JS 

## TRY...CATCH

This try catch blocks is comprised of a `try`block followed by a `catch`block. 
try is executed first and if an exception is thrown, executed the `catch`block. 

Also can be added a `finally` block after them that will get executed once the flow control exits the block.

Syntax: 

```JS
try {
  // Code that can throw an exception
} catch (exceptionVar) {
  // Catch code
} finally {
  // code executed at te end
}
```

* <span style="color:#db7093;">exceptionVar</span> is an optional identifier that would hold the caught exception 

Take into account that `try...catch` needs to be a block and cannot be a single statement: 

```JS
try doSomething(); // SyntaxError
catch (e) console.log(e);
````

## EXCEPTIONS

Exceptions thrown are an object from the class <span style="color:red;">Error</span>. 
You can normalize the exception value to make sure its an error: 
```JS 
try {
  throw "Oops; this is not an Error object";
} 
catch (e) {
  if (!(e instanceof Error)) {
    e = new Error(e);
  }
  console.error(e.message);
}
```

To throw an exception you only need to `throw` a message following this statement. 

```JS
let a = 10; 
try{
	if(a == 10){
		throw "A is 10"; 
	}
}
catch(error){
	console.log("Catch exception: " + error); //Catch exception: A is 10
}
```