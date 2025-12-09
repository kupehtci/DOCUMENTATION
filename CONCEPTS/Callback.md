#CONCEPTS 

# Callback

A callback is a function that is passed to another function as an argument so can be called later normally under an event trigger or an operation that finishes. 

This type of functions are normally used for asynchronous operations such as network requests, file I/O and others where the callback is called when the operation completes instead of blocking the main thread. 

Also its used for event handling, like passing a function to a button in HTML so in case of that event, the callback function will be the event handler: 

```html
<script>
function AssertHello(){
	console.assert("Hello world")
}
</script>

<button onclick="AssertHello()">Click me</button>
```

