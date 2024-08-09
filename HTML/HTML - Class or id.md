#HTML #CSS 

### Class or id

For selecting an specific tag from an external file like `css` or `javascript` its a common use to assign each tag a class or id: 

* **ID**: Can only be repeated once per script 
* **CLASS**: Can me more than once per script with the same name

```HTML
<body>
	<h1 class="title-class">Hello class</h1>
	<h1 id="title-id"></h1>
</body>
```

Both elements can have id and class but only a single ID and multiple classes.  

So as conclusion, you should use <span style="color:MediumSlateBlue;">class</span> if the element is repeated through the element and <span style="color:orange;">id</span> if the element is single. 

### TAKE INTO ACCOUNT

When naming the **id** or **class**, take into account some naming rules: 

* class or id name cannot start with a number. This will end in an imposibility of 

Also some differences in terms of performance and rendering need to be taken into account:

* ID elements are performed before class elements because they are more specific. So the final computation order is: 
	* Values defined as important
	- Inline styles
	- ID selectors
	- Class selectors
	- Element

