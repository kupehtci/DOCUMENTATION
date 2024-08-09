#JS #PHP 

### VARIABLES

Because JS cannot directly use variables from PHP and PHP cannot use JS variables and those are combined in web development there is a current problem. 

There are some methods to do this: 

# 1. Use AJAX to get the data you need from the server

This method is considered the best, because **your server side and client side scripts are completely separate**.

### Pros

- **Better separation between layers** - If tomorrow you stop using PHP, and want to move to a servlet, a REST API, or some other service, you don't have to change much of the JavaScript code.
- **More readable** - JavaScript is JavaScript, PHP is PHP. Without mixing the two, you get more readable code on both languages.
- **Allows for asynchronous data transfer** - Getting the information from PHP might be time/resources expensive. Sometimes you just don't want to wait for the information, load the page, and have the information reach whenever.
- **Data is not directly found on the markup** - This means that your markup is kept clean of any additional data, and only JavaScript sees it.

### Cons

- **Latency** - AJAX creates an HTTP request, and HTTP requests are carried over network and have network latencies.
- **State** - Data fetched via a separate HTTP request won't include any information from the HTTP request that fetched the HTML document. You may need this information (e.g., if the HTML document is generated in response to a form submission) and, if you do, will have to transfer it across somehow. If you have ruled out embedding the data in the page (which you have if you are using this technique) then that limits you to cookies/sessions which may be subject to race conditions.

## Implementation Example

With AJAX, you need two pages, one is where PHP generates the output, and the second is where JavaScript gets that output:

### get-data.php

```php
/* Do some operation here, like talk to the database, the file-session
 * The world beyond, limbo, the city of shimmers, and Canada.
 *
 * AJAX generally uses strings, but you can output JSON, HTML and XML as well.
 * It all depends on the Content-type header that you send with your AJAX
 * request. */

echo json_encode(42); // In the end, you need to `echo` the result.
                      // All data should be `json_encode`-d.

                      // You can `json_encode` any value in PHP, arrays, strings,
                      // even objects.
```

### index.php (or whatever the actual page is named like)

```xml
<!-- snip -->
<script>
    fetch("get-data.php")
        .then((response) => {
            if(!response.ok){ // Before parsing (i.e. decoding) the JSON data,
                              // check for any errors.
                // In case of an error, throw.
                throw new Error("Something went wrong!");
            }

            return response.json(); // Parse the JSON data.
        })
        .then((data) => {
             // This is where you handle what to do with the response.
             alert(data); // Will alert: 42
        })
        .catch((error) => {
             // This is where you handle errors.
        });
</script>
<!-- snip -->
```

The above combination of the two files will alert `42` when the file finishes loading.

## Some more reading material

- **[Using the Fetch API](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch)**
- **[How do I return the response from an asynchronous call?](https://stackoverflow.com/questions/14220321/how-to-return-the-response-from-an-ajax-call)**

# 2. Echo the data into the page somewhere, and use JavaScript to get the information from the DOM

This method is less preferable to AJAX, but it still has its advantages. It's still _relatively_separated between PHP and JavaScript in a sense that there is no PHP directly in the JavaScript.

### Pros

- **Fast** - DOM operations are often quick, and you can store and access a lot of data relatively quickly.

### Cons

- **Potentially Unsemantic Markup** - Usually, what happens is that you use some sort of `<input type=hidden>` to store the information, because it's easier to get the information out of `inputNode.value`, but doing so means that you have a meaningless element in your HTML. HTML has the `<meta>` element for data about the document, and HTML 5 introduces `data-*` attributes for data specifically for reading with JavaScript that can be associated with particular elements.
- **Dirties up the Source** - Data that PHP generates is outputted directly to the HTML source, meaning that you get a bigger and less focused HTML source.
- **Harder to get structured data** - Structured data will have to be valid HTML, otherwise you'll have to escape and convert strings yourself.
- **Tightly couples PHP to your data logic** - Because PHP is used in presentation, you can't separate the two cleanly.

## Implementation Example

With this, the idea is to create some sort of element which will not be displayed to the user, but is visible to JavaScript.

### index.php

```php
<!-- snip -->
<div id="dom-target" style="display: none;">
    <?php
        $output = "42"; // Again, do some operation, get the output.
        echo htmlspecialchars($output); /* You have to escape because the result
                                           will not be valid HTML otherwise. */
    ?>
</div>
<script>
    var div = document.getElementById("dom-target");
    var myData = div.textContent;
</script>
<!-- snip -->
```

# 3. Echo the data directly to JavaScript

This is probably the easiest to understand.

### Pros

- **Very easily implemented** - It takes very little to implement this, and understand.
- **Does not dirty source** - Variables are outputted directly to JavaScript, so the DOM is not affected.

### Cons

- **Tightly couples PHP to your data logic** - Because PHP is used in presentation, you can't separate the two cleanly.

## Implementation Example

Implementation is relatively straightforward:

```php
<!-- snip -->
<script>
    var data = <?php echo json_encode("42", JSON_HEX_TAG); ?>; // Don't forget the extra semicolon!
</script>
<!-- snip -->
```

# 4. JS functions declared in PHP

If you generate the HTML elements from a PHP you can pass a function the arguments that need from PHP. 

Can be done this way: 

```JS
function CleanEmail(email){
	// Implementation 
}
```

```PHP
$email = "example@email.com"; 
echo "<button onclick="CleanEmail({$email});"></button>"
```


## 5. Global variable in \<script\> in PHP document

Also another methodology to set globar variables to be accesed by JS can be creating a \<script\> in the PHP that declare the value: 

```JS
// login.js
let userId = user_id; 
```

```PHP
<?php
echo "<script>var user_id = {$_SESSION['user_id']}; </script>"
?>
<script src="./login.js"></script>
```

This `echo` the script that declares the var. 
So when the `login.js` is executed, can access global <span style="color:orange">var</span>. 

---
Take a look into var usage and scope in: [[JS - Scope of the variables]]




---
Author: Daniel Laplana Gimeno
Date: 09-01-2024
Keynotes: javascript, php