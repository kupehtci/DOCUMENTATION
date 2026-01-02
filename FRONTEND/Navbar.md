#CSS #HTML 

# Navbar

A **navbar** or a **navigation bar** is an user interface element that contains links or buttons to navigate to different sections of a website or an application. 

It lets the users a quick access between pages and views quickly. 

Core functionalities and characteristics of a navbar: 
* Is a list of navigation links (Like Home, About, Contact) grouped together in horizontal or vertical bar. 
* Normally placed at the top of the page (header) or on the side in more wide pages. 

Its normally composed of: 
* Navbar in HTML is normally a `<nav>` element containing an `<ul>` with `<li>` and `<a>` items that are listed, styled and positioned correctly using CSS. 
* Can be responsive and **collapsed** into a "hamburger"  menu on smaller screens. 

A good styling of the navbar using CSS is: 

* Use `display: flex` in the `<ul>` component to make the elements in a flexbox layout that arranges the child elements in a row. 
* Justify the content using one of this options: 
	* `space-betweem` pushing the first and last element to the edges and distribute the rest of the elements along the flexbox. 
	* `flex-end` align the items to the right side.
* `align-items: center` to control the alignment along the Y axis so they are vertically centered. 
* For sticky navbars, `position:fixed` keeps the navbar at the top of the viewport during the scrolling. In that case use `z-index: 20` or higher to keep the navbar on top of other webpage content. 

```css

```

For more advanced navbars, you can split the top navbar into 3 sections: 
* | logo | main navigation | Other info like account | 

So this sections can be distributed using: 
```html
<nav class='navbar'>
<div class='navbar-left'>
	<!--...-->
</div>
<div class='navbar-center'> 
	<ul>
		<!--...-->
		<li class='navbar-item'><a href='About'>About</a></li>
		<!--...-->
	</ul>
</div>
<div class='navbar-right'>
	<!--...-->
</div>

</nav>
```

Or in react: 
```typescript
const Navbar = () =>{  
    return (  
       <nav className='navbar'>  
           <div className='navbar-left'>  
  
           </div>           <div className='navbar-center'>  
               <ul>                   <li className='navbar-item'>Item 2</li>  
                   <li className='navbar-item'>Item 3</li>  
                   <li className='navbar-item navbar-dropdown'>Dropdown</li>  
                   <li className='navbar-item'><a href='/About'>About</a></li>  
               </ul>           </div>           <div className='navbar-right'>  
           </div>       </nav>    );  
}
```

You can distribute the navbar positions using: 
* `display:flex` and `justify-content: space-between` to spread the elements on the left, center and right. 
* Using grids ([[CSS - Grids]] and [[CSS - Grids fractions]]) with: `grid-template-columns: auto 1fr auto;` and `justify-self: start | center | end` on each `<div>` of `navbar-right`, `navbar-center` and `navbar-left`. 