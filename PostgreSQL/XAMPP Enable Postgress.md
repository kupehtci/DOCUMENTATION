

To enable postgres database: 

* enter in `http.conf`: 
	* Search Document Root and change the direction to the folder desired for the web
* Enter `php.ini`: 
	* Search the extensions and unmark (delete this `;`) the following extensions

```txt
extension=pdo_pgsql
extension=pgsql
```