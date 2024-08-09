#HTML 


### Line break in HTML

You can make a line break in html by using the `<br>` element:

```html
<!-- EXAMPLE --> 
<p>
  O’er all the hilltops<br />
  Is quiet now,<br />
  In all the treetops<br />
  Hearest thou<br />
  Hardly a breath;<br />
  The birds are asleep in the trees:<br />
  Wait, soon like these<br />
  Thou too shalt rest.
</p>
```

Its a <span style="color: #b8004d">bad practice</span> to use `<br>` element in order to create paragraphs, being more recomendable to divide the paragraphs by the use of separate `<p></p>` elements. 

This is because **reader** mode is not able to interpret and clear the `<br>` elements in order to adapt the text for lecture. 

## Style with CSS

As `<br>` are pure structural elements and provide no clear representation of them so has little style to apply to them. 

* We can alter the margin in order to increase the spacing between the lines, but this can also be done with `line-height` [^1] property. 

--- 
##### REFERENCES

[^1]:

---
Author: Daniel Laplana