### BASIC FOOTER SECTION 
#PHP #HTML #CSS 

This is how to make a basic footer section divided in 3 parts and with a common section in the bottom part. 

![[./FOOTER/mFooterSection.png]]

```HTML
<link rel='stylesheet' href='./style/footer.css'>

<footer>

	<div class='footer-container'>
		<div class='footer-section'>
			<h3>Contact Us</h3>
			<p>Email: alu.122308@usj.es</p>
			<p>Phone: 651 456-7890</p>
		</div>
	
	  
	
	<div class='footer-section'>
		<h3>Quick Links</h3>
		<ul>
			<li><a href='/'>Home</a></li>
			<li><a href='/games'>Games</a></li>
			<li><a href='./about.php'>About Us</a></li>
			<li><a href='/about.php'>Contact</a></li>
		</ul>
	</div>
	
	  
	
	<div class='footer-section'>
		<h3>Follow Us</h3>
		<p>Stay connected on social media:</p>
	
		<ul class='social-media-icons'>
			<li><a class="media-icon" href='#' target='_blank'><img src='./style/icons/facebook-icon.png' alt='Facebook'></a></li>
			<li><a class="media-icon" href='https://twitter.com/Dani_Laplana' target='_blank'><img src='./style/icons/twitter-icon.png' alt='Twitter'></a></li>
			<li><a class="media-icon" href='https://www.instagram.com/danieell21/' target='_blank'><img src='./style/icons/instagram-icon.png' alt='Instagram'></a></li>
		</ul>
	</div>
</div>
	
	  
	
<div class='footer-bottom'>
	<p>&copy; 2023 Aura game Store. All rights reserved.</p>
</div>
<div class='footer-bottom'>
	<p>Rights Attribution: </p>
	<a href='https://www.flaticon.es/iconos-gratis/instagram' title='instagram iconos'>Instagram, facebook, twitter, linkedin icons created by Freepik - Flaticon</a>
</div>
</footer>
```

As you can see, the upper section is divided in 3 `foooter-section` and within the `footer-container` . 
This is made this way to use the css property display: [flex](https://www.w3schools.com/css/css3_flexbox.asp) to make them aligned in the same horizontal section and keep them flexible in terms of responsiveness.
Take a look into [[CSS - DISPLAY PROPERTY]] for display: property documentation. 

For taking a look into the css properties and PHP File: 
[[FOOTER_CSS]]
[[FOOTER_PHP]]


---
Author: Daniel Laplana
Date: 24/03/2023