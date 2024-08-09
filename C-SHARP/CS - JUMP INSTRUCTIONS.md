#CSHARP 
#### CONTINUE INSTRUCTION



#### BREAK INSTRUCTION

The `break`instruction ends the iteration instruction that contains it more closer. 
This includes the instructions `for`, `foreach`, `while` o `do - while` or even`swtich` instruction. 
This break transfer the control to the next instruction before the iteration container. 

```CSHARP 
// this program finds the first odd number in an array
int array = [1, 3, 5, 2, 1 , 10, 4, 1, 2, 33]; 

int result = -1; 
for( int i = 0; i < array.Length; i++){
	if(i % 2 == 0 ){
		result = i; 
		break; 
	}
}
```

In this case breaks ends the closer <span style="color:orange">iteration isntruction</span>, gets out the for() loop. This can get used inside an if inside an iteration to get out the iteration or in a `switch` statement to get out each `case:`to avoid cascade effect. 

```CSHARP
// CASCADE EFFECT 
int i = 1; 
switch(i){
case 0: 
	// some code
case 1: 
	Console.Write("Case 1"); 
case 2: 
	Console.Write("Case 2"); 
	break; 
case 3: 
	Console.Write("Case 3"); 
	break; 
}
// Outputs: 
// Case 1 
// Case 2
```

Because there is no break in the `switch` statement , when the execution enters the **case 1** , it also gets into **case 2** like a cascade.  

