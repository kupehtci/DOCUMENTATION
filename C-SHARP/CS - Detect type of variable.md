#CSHARP #NET 

### INTRODUCTION 

When using inheritance, we can have a lot of objects that inherit from a father class. 
When collecting or grouping them in an array by using the father variable, once we need to deal with them could be a mess, you need to detect with object are you dealing with before doing something. 

For this detection of type we can use: 

#### typeof() and GetType()

`typeof()` returns a string containing the <span style="color:#ababf5;">type</span>. 
This method can be use to check the <span style="color:#ababf5;">GetType()</span> of a variable comparing it with the <span style="color:#ababf5;">typeof()</span> of the type. 
```CSHARP 
Employee emp = new Employee(); 

if (emp.GetType() == typeof(Employee)) 
{ 
	Console.WriteLine(emp.GetType()); 
	Console.WriteLine(num.GetType()); 
}
```

#### Safe casting 

One way to deal with this is to use <span style="color: cyan; ">safe casting</span>. This `is` method returns a bool if can be **casted**. 

Both <span style="color:#ABABF5;">typeof</span> and GetType() method are used to get the type in C#.

**The is operator** is called runtime type identification, is operator is used to check if an object can be cast to a specific type at runtime. It returns Boolean value, if object type is match with specified type it returns true else it will return false.

```csharp
Employee emp = new Employee();
if (emp is Employee)
{
    Console.WriteLine(emp.Gettype());
}
```

C#

In C# 7, is operator is also used to do safe casting, if left hand side object is match with given type.