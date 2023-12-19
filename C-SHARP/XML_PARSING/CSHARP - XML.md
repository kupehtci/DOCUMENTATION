#CSHARP #NET #XML
## XML Document parsing and reading 

In this note are gathered the ways of reading and interpreting a XML using C#

#### STRUCTURE OF A XML 

An XMLElement can contain: 
* text
* attributes <span style="color:cyan;">hello</span>
* other elements 
* mix of the above

Having this example: 

```XML
<bookstore>  
  <book category="children">  
    <title>Harry Potter</title>  
    <author>J K. Rowling</author>  
    <year>2005</year>  
    <price>29.99</price>  
  </book>  
  <book category="web">  
    <title>Learning XML</title>  
    <author>Erik T. Ray</author>  
    <year>2003</year>  
    <price>39.95</price>  
  </book>  
</bookstore>
```

In the example above:

\<title\>, \<author\>, \<year\>, and \<price\> have **text content** because they contain text (like 29.99).

\<bookstore\> and \<book\> have **element contents**, because they contain elements.

\<book\> has an **attribute** (category="children" and category="web") .

#### INITIALIZATION 




---
#### GET ELEMENTS

Elements are inherited from Nodes. You can get elements by its tag name: 

```CSHARP 
XmlDocument xmlDoc = new XmlDocument();
xmlDoc.LoadXml(cleanBpmn);

XmlElement firstBook = (XmlElement) xmlDoc.GetElementsByTagName("book")[0];
```

Another way is to get a 

To get the text inside an element use: \[XmlElement.InnerText\] : 

```csharp
XmlElement ele; 
string eleText = ele.InnerText; 
```


#### Get Elements using <span style ="color:cyan; ">XPath</span>

To find nodes in an XML file you can use <span style="color:cyan;  text-decoration:bold; ">XPath expressions </span>, that are similar to Directory path search. 
Method **[XmlNode.Selec­tNodes](http://msdn2.microsoft.com/en-us/library/system.xml.xmlnode.selectnodes.aspx)returns a list of nodes** selected by the XPath string. Method **[XmlNode.Selec­tSingleNode](http://msdn2.microsoft.com/en-us/library/system.xml.xmlnode.selectsinglenode.aspx) finds the first node** that matches the XPath string.

Suppose we have this XML file, simple with only a list of names with each name having `FirstName` and `LastName`. 
```XML
<Names>
    <Name>
        <FirstName>John</FirstName>
        <LastName>Smith</LastName>
    </Name>
	<Name>
        <FirstName>James</FirstName>
        <LastName>White</LastName>
    </Name>
</Names>
```

Using 

---
#### GET ELEMENTS INSIDE ELEMENTS

To get elements that are inside another one, those are related as <span style="color:blue">child elements</span>. 
These child elements can be acceded as an array \[XmlElement.ChildNodes\] with:

```csharp
XmlElement ele; 
XmlElement firstChildEle = ele.ChildNodes[0]; 
```


An example for getting all child nodes would be: 
```CSHARP
XmlDocument doc = new XmlDocument(); 

doc.LoadXml("<book ISBN='1-861001-57-5'>" + 
			"<title>Pride And Prejudice</title>" + 
			"<price>19.95</price>" + 
			"</book>"); 
XmlNode root = doc.FirstChild;

//Display the contents of the child nodes. 
if (root.HasChildNodes) { 
	for (int i = 0; i < root.ChildNodes.Count; i++) 
	{ 
		Console.WriteLine(root.ChildNodes[i].InnerText); 
	} 
}
```

###### REFERENCES

Documentation of .NET use in .NET 8.0 version can be found in [Learn.Microsoft](https://learn.microsoft.com/es-es/dotnet/api/system.xml.xmldocument?view=net-8.0#Find)


#### XML ELEMENT DOCUMENTATION 

https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmlnode.childnodes?view=net-8.0#system-xml-xmlnode-childnodes


