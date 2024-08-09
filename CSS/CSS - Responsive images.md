#CSS 

## CSS Responsive images

In order to make responsive the images and adapt to the type of device or screen size / resolution, and resize to the changes, there are so many forms to maintain their scale: 

### `WIDTH` property

By setting the width property to a value and let the height be automate, the image will scale with the screen size and maintain the <span style="color:LightSeaGreen;">aspect ratio</span>.

Example: 
```css
img{
	width: 30%; 
	height: auto; 
}
```

This will scale up or down depending on the screen resizing

### `MAX-WIDTH` property

By setting the `max-width` property to a value and the height in automatic, the image will scale with the screen size but never be bigger than the set maximum width. 

Example: 

```css
img{
	max-width: 30rem; 
	height: auto; 
}
```