#HTML #PHP 


When using a basic form, we define the form property `action` that specify the action / php to execute and send it the properties fullfilled in the form as `$_POST` variables.

If no `target` property is defined, the action would be executed and redirected to that page. 
The target default value is `target = "_blank"` . 

If we want to submit a form without redirecting we can set the target to an non-visible `<iframe>` HTMLElement that will hold the response of the `action`  executed. 

We can set a basic form that won't redirect like this: 

```HTML
<body>
	<iframe id="dummy-iframe" style="display:none;"></iframe>
	
	<form action="handle_form.php" target="dummy-iframe">
		<!-- Some form elements -->
		<input type="submit" >
	</form>
</body>
```