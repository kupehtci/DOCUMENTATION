#REACT #TailwindCSS

# Tailwind CSS

**Tailwind CSS** is an open-source utility-first CSS framework that allows to style interfaces by using single-purpose classes directly in HTML instead of writing custom CSS rules in separate files. 


TailwindCSS provides many utility CSS classes like `flex`, `p-4` or `bg-blue-500` (Blue background), that each one has a **one-to-one relationship** with a CSS property or a small set. 
By **combining these utilities** in the HTML, you can style the UI Components by simply adding classes instead of writing a custom CSS file for all the components. 

Examples of using Tailwind: 

```HTML
<li class="flex">
	<!-- ... -->
</li>

<!-- is equal to: -->
<li class="list">
	<!-- ... -->
</li>

<style>
list{
	display: flex; 
}
</style>
```

They can be combined: 
```html
<li class="flex bg-red-500">
	<!-- ... -->
</li>

<!-- is equal to: -->
<li class="list">
	<!-- ... -->
</li>

<style>
list{
	display: flex; 
	background-color: rgb(239 68 68);
}
</style>
```
```



# Compiling and final bundle

The **modern Tailwind** uses a JIT (Just-in-Time) compiler that creates the styles on demand, so the CSS bundle doesn't have all the CSS classes, only the used ones. 

