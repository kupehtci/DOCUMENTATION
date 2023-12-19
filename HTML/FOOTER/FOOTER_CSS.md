
For taking a look into html or PHP code, look: [[FOOTER_PHP]]
This is the CSS for a basic footer: 

```CSS
/* Reset some default margin and padding */
footer body, h1, h2, h3, ul {
  margin: 0;
  padding: 0;
}

/* Style the footer */
footer {
  background-color: #333;
  color: #fff;
  padding: 20px 0;
}

.footer-container {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
}

.footer-section {
  max-width: 300px;
}

.footer-section h3 {
  border-bottom: 2px solid #fff;
  padding-bottom: 0.2rem;
  padding-bottom: 5px;
}

ul {
  list-style: none;
  padding: 0;
}

ul li {
  margin-bottom: 10px;
}

a {
  color: #fff;
  text-decoration: none;
}

/* Style social media icons */
.social-media-icons{
  display: inline-flex;
}

.social-media-icons img {
  width: 30px;
  height: 30px;
  margin-right: 10px;

    transition-duration: 0.4s; 
}

.social-media-icons img:hover {
  opacity: 0.7;
  scale: 1.15;
}

/* Style the bottom part of the footer */
.footer-bottom {
  background-color: #222;
  text-align: center;
  padding: 10px 0;
}
```

