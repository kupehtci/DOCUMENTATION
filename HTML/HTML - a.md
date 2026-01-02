#HTML 

# HTML `<a>` element

The `<a>` element in HTML is an **anchor** that allows to create hyperlinks to other resources like web pages, files, emails or positions in the same page. 

The `<a>` element defines a clickable element and the destination under the click action is specified in the `href` prop: 

```html
<!-- Link to about page within the website -->
<a href="/about">About </a>

<!-- Link to external webpage -->
<a href="https://example.com">Visit example</a>

<!-- Email -->
<a href="mailto:user@example.com">user.example.com</a>

<!-- Section -->
<a href="#section1">Go to section 1</a>
```

The `<a>` element can have link states, that can be referenced in CSS ([[CSS - Pseudo-class]]): 
* `:link`  the unvisited link that has not been clicked yet. 
* `:visited` a link that the user has previously clicked or visited. 
* `:hover` a link then the user mouse cursor is positioned over it but not clicked yet. 
* `:active` a link at the exact moment when its clicked. 
* `:focus` a link when is selected using keyboard navigation (Tab key). 
