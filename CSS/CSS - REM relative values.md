#CSS 

### REM relative values

`rem` or root-em meaning the root element em unit value is a relative value associated with the document root size predefined by the browser. 

The difference is that `em` can be different for each HTML element but `rem` is constant through the document. 

If user changes font size of the browser, this value would be changes and all the properties set to be dependant of rem will change: 

Example: 
```css
html {
  font-size: 16px; /* Default in most browsers */
}

h1 {
  font-size: 2rem; /* 2 * 16px = 32px */
}
```

### COMPARISON WITH PIXELS

| Feature       | Pixels (px)                                     | REM                                          |
| ------------- | ----------------------------------------------- | -------------------------------------------- |
| Type of unit  | Absolute                                        | Relative                                     |
| Scaling       | Fixed (does not adjust based on root font-size) | Scales dynamically with the root font-size   |
| Accessibility | Less flexible for user preferences              | More adaptable to user font-size adjustments |
