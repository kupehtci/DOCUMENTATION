

## XML Elements vs. Attributes

Take a look at these two different examples:

```XML
<person gender="female">  
  <firstname>Anna</firstname>  
  <lastname>Smith</lastname>  
</person>

<person>  
  <gender>female</gender>  
  <firstname>Anna</firstname>  
  <lastname>Smith</lastname>  
</person>
```

In the first one, gender is an <span style="color:#f5a5f5">attribute</span>.
In the last one, gender is an <span style="color:#f5a5f5">element</span>. 
Both examples provide the same information.

There are no rules about when to use attributes or when to use elements in XML.

But you need to take this into consideration when parsing XML using another language like <span style="color:#FFd5FF; "> C#</span> because attributes and elements are accesed diferently: 

For example in C\# : 

```CSHARP 

```