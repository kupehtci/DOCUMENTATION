#XML #FILES #CONCEPTS

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
var doc = XDocument.Parse(xml);
var person = doc.Element("person");

// Attribute access
string genderAttr = person.Attribute("gender")?.Value;

// Element access
string genderElem = person.Element("gender")?.Value;
```

Attributes are read with `.Attribute("name")` and elements with `.Element("name")`, so parsing code needs to know in advance which shape the XML uses — this is why the two examples above are **not** interchangeable once real parsing code depends on them.

## Related

* [[JSON - BASICS]] and [[JSON vs XML]] — a comparison against the JSON alternative.
* [[JS - DOM Element vs Node|Element vs Node]] — the distinction between DOM nodes and elements when parsing XML/HTML.
* [[File Extensions]] — the `.xml` extension entry.