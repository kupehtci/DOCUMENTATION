#NodeJS 

In some callback invocation we must need to pass `this`to the callback function that is being invoked. 
### **Why is `.bind(this)` needed?**

In JavaScript, when a method is passed as a callback (e.g., to a router or event handler), the `this` context is lost because the function is executed outside of its original object context. By default, `this` in such cases often points to `undefined` (in strict mode) or the global object.

When you bind the method to the current instance (`this`), it ensures that the `this` inside the method always refers to the `CalculatorController` instance, no matter how the method is called.