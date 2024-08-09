#CSS 


### CSS Import font

In order to use a downloaded font or imported from the web we can set this font on the css file in order to apply to certain HTMLElements by the use of `font-family` attribute. 

In order to import and give some parameters to this font we can do by the `@font-face`: 

Structure: 
```css
@font-face {
  font-family: <font_name>;
  src: <origin> [,<origin>]*;
  [font-weight: <weight>];
  [font-style: <style>];
}
```

* `font_name` specify a name in order to use the font in the .css file. 
* `origin` url of the remote font or local path of the font within the project by using `local(<path>)`. 
* `weight` a value of the weight of the font. 
	* Can be: `normal`, `auto` or `bold`.
* `style` a value for the style of the font. 
	* Can be: `normal`, `auto`, `italic`or `oblique`

Example: 

```css
@font-face {  
    font-family: 'JetBrains Mono Bold';  
    src: url("../fonts/JetBrainsMono-Bold.ttf") format('truetype');  
    font-weight: normal;  
    font-style: normal;  
}

p{
	font-family: 'JetBrains Mono Bold' arial Helvetica; 
}
```