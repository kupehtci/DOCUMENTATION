#CSHARP 

## ACTION vs FUNC

Actions and Funcs are pre-defined delegates in C#. 

_If you don’t know how to use delegates, please visit_ [_my article_](https://medium.com/@serhat21zor/c-delegate-fc74d2bf6596)

Actions can only take input parameters, while Funcs can take input and output parameters. It is the biggest difference between them.

### ACTION\<\>

An action usage example: 
```CSHARP 
public static void RunActionFuncSample()
{
	Action<int, int> sumAndShowOnConsole = new Action<int, int>(Sum);
	sumAndShowOnConsole(10, 20);
}

public static void Sum(int number1, int number2)
{
	Console.WriteLine(number1 + number2);
}
        
```

See more documentation in: [[CS - Delegate Action<>]]

### FUNC\<\>

A func should return a value. So its last parameter will be its return type.

>If you define a single parameter in a func, the parameter will be its return value, and the func doesn’t take any input parameter.


```CSHARP 
public static void RunFuncSample()
{
	Func<int> generateRandomFunc = new Func<int>(GenerateRandomFunc);
		
	Console.WriteLine(generateRandomFunc());

	Func<int, int, string> sumFunc = new Func<int, int, string>(SumAsStringFunc);
	string sum = sumFunc(12, 24);
	Console.WriteLine(sum);
}

public static int GenerateRandomFunc()
{
	return Random.Shared.Next();
}

public static string SumAsStringFunc(int number1, int number2)
{
	return (number1 + number2).ToString();
}
```

See more documentation in: [[CS - Delegate Func<>]]


### CONCLUSION 

Both methodologies let a method to be <span style="color:MediumSpringGreen;">encapsulated within a delegate object</span>. 
The only differ when taking into account that the function need to return a value or not. 
In this case, Functions return a value and Actions returns no value. 
