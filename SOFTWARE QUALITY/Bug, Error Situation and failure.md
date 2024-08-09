
In a bug or error case of a software development, it's common to <span style="color:orange;">distinguish between this three aspects</span>: 

* `bug`: is the mistake that caused the error in the source code. 
* `Error Situation`: is the system state that is hold while hapening the bug or the environment variables that causes the bug. 
* `Failure`: the deviation from the expected behavior. Its the result of the bug that the user notices ir the form that the bug takes. 

Bug not always leads into a failure.
A bug may sometimes lead into a failure depending on: 
* input values on the software
* when the software is executed
* external circumstances

###### Example

Imagine Peter is driving towards Zaragoza: 

If in an intersection, he decide to go left and now is heading towards Valencia. 

* bug is the mistake, he took the wrong direction
* error situation is the current state. now is heading Valencia and no Zaragoza. 
* Failure is when Peter arrives into Valencia and notices that has not reach Zaragoza. 