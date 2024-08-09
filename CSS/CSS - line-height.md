#CSS 

### CSS `line-height` property


The `line-height` css property sets the height of a line box and can be used to change the distance between lines in the text. 

It has different impact depending on type of HTML element: 

* On block elements, specifies **minimum height** of the line boxes.
* On inline elements, specifies the height used to calculate line box height. 

It can be set as a **percentage** or **relative values**[^1] and would depend on parent size. 

It doesn't affect the <span style="color:red;">font size</span>, to do so, can be modified with `font-size` property [^2]. 
### SYNTAX

```css
/* Keyword value */
line-height: normal;

/* Unitless values: use this number multiplied
by the element's font size */
line-height: 3.5;

/* <length> values */
line-height: 3em;

/* <percentage> values */
line-height: 34%;

/* Global values */
line-height: inherit;
line-height: initial;
line-height: revert;
line-height: revert-layer;
line-height: unset;
```

--- 

[^1]: A relative value can be set by the use of `em` or `ex` values [[CSS - EM relative values]]. 
[^2]: [[CSS - font-size]]
