#CSS 

### EM Relative values

`em` is a relative unit of measure that can be used to define lengths in a webpage. 
This unit is relative to the parent and page size properties. 

Using an `em` value creates a dynamic or computed font size (historically the `em` unit was derived from the width of a capital "M" in a given typeface.).

Example of usage: 

```css
p {
  font-size: 2em;
}
```


The `em` relative value can be calculated as: 

$$em = \frac{desired\ element\ pixel\ value}{parent\ element\ size}$$

### WHY TO USE

Its better to use `em` values in terms related to image size or font size because: 

1. Its a good idea that the text is dependent of the device default size
2. express better font sizes

### Alternatives

Other option instead of use `em` is to use `rem` or root-em meaning the root element em unit value. 

The difference is that `em` can be different for each HTML element but `rem` is constant through the document