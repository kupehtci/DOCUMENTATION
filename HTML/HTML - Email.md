#HTML #CSS 

## Format HTML Link to email

There is a way to format a link to an email direction to automatically open the default mail application within your device and a new mail to the email direction clicked. 

This can be do with the option `mailto:`. 


```html
<body>
	<h1>Write an email to "example" by clicking in this:<h1>
	<a href="mailto:name@mail.com">name@mail.com</a>
</body>
```


##### Additional settings

Some additional settings can be personalized to the email sended like for example subject. body, CC, other recipients and more: 

```html

<body> <p> Creating an HTML Email Link </p>
<a href= "mailto: name@email.com 
  ?subject=Subject test 
   &body=This mail is generated using HTML email link."> Click here to Send Mail</a> 
</body> 
```