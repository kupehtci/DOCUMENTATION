## Action\<\>

Encapsulates a method that has <span style="color:orange;">certain number of arguments</span> specified by the <span style="color:#9EE192">T parameter</span>.
<span style="color:MesiumSpringGreen;">Action&lt&gt</span>
Can have up to 16 parameters. 

```CSHARP 
public delegate Action<in T>(T obj); 
```

Similar to Func\<\> but this last one needs to return a parameter. 

