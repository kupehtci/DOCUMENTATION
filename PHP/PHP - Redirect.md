#PHP 

You can redirect to another url using PHP. 
This redirect will happen inmmediatly. 
## Redirect using header()

One method to redirect is using `header()`.  This method is the more simple and effective but can fail if some HTML has been written yet. 

```PHP
header("Location: https://example.com/myOtherPage.php");
die();
```

You can create a function to redirect: 

```PHP
function Redirect($url, $statusCode = 303)
{
   header('Location: ' . $url, true, $statusCode);
   die();
}
```

Its recomendable to use `die()` or `exit()` due to: 

* Before 2014 were not able to use relative paths, only absolute paths. Now you can use both. 
* Status codes: header location uses <span style="color:cyan;">HTTP 302</span> redirect code, that is a "temporary" redirect, need to consider using <span style="color:cyan;">301</span> permanent redirect or <span style="color:cyan;">303</span> other type of redirect. 


## Redirect using `http_redirect()`

The function `http_redirect($url)` can also be used to redirect to another url but needs the [PECL package pecl](https://pecl.php.net/package/pecl_http) to be installed.


## Redirect using meta

This is not the most professional way but you can also redirect once you have output some HTML by using `<meta>` tag. 

```HTML
// Not supported by all browsers
<meta http-equiv="location" content="0;url=finalpage.html"> 

// Best option
 <meta http-equiv="refresh" content="0;url=finalpage.html">
```


## Redirect using Javascript

The best and most effective way to redirect to another URL is using javascript: 

```JS
window.location.replace("https://example.com/");
//or
window.location.href = "./index.php"; 
``` 

