#PHP 

## $\_SERVER

$\_SERVER its an array that holds information such as headers, paths and script paths. 
This is array entries are setted by the server and are used to access certain server or connection data. 

As an array, it can be accessed like this: 
```PHP
<?php  
echo $_SERVER['SERVER_NAME'];  
?>
```

## INDEXES 

* 'PHP_SELF'

El nombre del archivo de script ejecutándose actualmente, relativa al directorio raíz de documentos del servidor. Por ejemplo, el valor de $_SERVER['PHP_SELF'] en un script ejecutado en la dirección http://example.com/foo/bar.php será /foo/bar.php. La constante [__FILE__](https://www.php.net/manual/es/language.constants.predefined.php) contiene la ruta completa del fichero actual, incluyendo el nombre del archivo. Si PHP se está ejecutando como un proceso de línea de comando, esta variable es el nombre del script desde PHP 4.3.0. En anteriores versiones no estaba disponible.

* '[argv](https://www.php.net/manual/es/reserved.variables.argv.php)'

Array de los argumentos enviados al script. Cuando se ejecuta el script en línea de comando se obtiene acceso a los parámetros de línea de comando con un estilo parecido a como sería en C. Cuando se ejecuta el script mediante el método GET, contendrá la cadena de la consulta.

* '[argc](https://www.php.net/manual/es/reserved.variables.argc.php)'

Contiene el número de parámetros de línea de comando enviados al script (si se ejecuta en línea de comando).

* 'GATEWAY_INTERFACE'

Número de revisión de la especificación CGI que está empleando el servidor, por ejemplo '`CGI/1.1`'.

* 'SERVER_ADDR'

La dirección IP del servidor donde se está ejecutando actualmente el script.

* 'SERVER_NAME'

El nombre del host del servidor donde se está ejecutando actualmente el script. Si el script se ejecuta en un host virtual se obtendrá el valor del nombre definido para dicho host virtual.

* 'SERVER_SOFTWARE'

Cadena de identificación del servidor dada en las cabeceras de respuesta a las peticiones.

* 'SERVER_PROTOCOL'

Nombre y número de revisión del protocolo de información a través del cual la página es solicitada, por ejemplo '`HTTP/1.0`'.

* 'REQUEST_METHOD'

Request method used to access the webpage, for example '`GET`', '`HEAD`', '`POST`', '`PUT`' . 
```PHP 
// If didn't enter by post, reject
if(!$_SERVER['REQUEST_METHOD'] === 'POST'){
	header("Location: ./index.php");
	exit; 
}
```

'REQUEST_TIME'

Fecha Unix de inicio de la petición. Disponible desde PHP 5.1.0.

'REQUEST_TIME_FLOAT'

El timestamp del inicio de la solicitud, con precisión microsegundo. Disponible desde PHP 5.4.0.

'QUERY_STRING'

Si existe, la cadena de la consulta de la petición de la página.

'DOCUMENT_ROOT'

El directorio raíz de documentos del servidor en el cual se está ejecutando el script actual, según está definida en el archivo de configuración del servidor.

'HTTP_ACCEPT'

Contenido de la cabecera `Accept:` de la petición actual, si existe.

'HTTP_ACCEPT_CHARSET'

Contenido de la cabecera `Accept-Charset:` de la petición actual, si existe. Por ejemplo: '`iso-8859-1,*,utf-8`'.

'HTTP_ACCEPT_ENCODING'

Contenido de la cabecera `Accept-Encoding:` de la petición actual, si existe. Por ejemplo: '`gzip`'.

'HTTP_ACCEPT_LANGUAGE'

Contenido de la cabecera `Accept-Language:` de la petición actual, si existe. Por ejemplo: '`en`'.

'HTTP_CONNECTION'

Contenido de la cabecera `Connection:` de la petición actual, si existe. Por ejemplo: '`Keep-Alive`'.

'HTTP_HOST'

Contenido de la cabecera `Host:` de la petición actual, si existe.

'HTTP_REFERER'

Dirección de la pagina (si la hay) que emplea el agente de usuario para la pagina actual. Es definido por el agente de usuario. No todos los agentes de usuarios lo definen y algunos permiten modificar HTTP_REFERER como parte de su funcionalidad. En resumen, es un valor del que no se puede confiar realmente.

'HTTP_USER_AGENT'

Contenido de la cabecera `User-Agent:` de la petición actual, si existe. Consiste en una cadena que indica el agente de usuario empleado para acceder a la pagina. Un ejemplo típico es: Mozilla/4.5 [en] (X11; U; Linux 2.2.9 i586). Entre otras opciones, puede emplear dicho valor con [get_browser()](https://www.php.net/manual/es/function.get-browser.php) para personalizar el resultado de la salida de la página en función de las capacidades del agente de usuario empleado.

'HTTPS'

Ofrece un valor no vacío si el script es pedido mediante el protocolo HTTPS.

'REMOTE_ADDR'

La dirección IP desde la cual está viendo la página actual el usuario.

'REMOTE_HOST'

El nombre del host desde el cual está viendo la página actual el usuario. La obtención inversa del dns está basada en la REMOTE_ADDRdel usuario.

'REMOTE_PORT'

El puerto empleado por la máquina del usuario para comunicarse con el servidor web.

'REMOTE_USER'

El usuario autenticado.

'REDIRECT_REMOTE_USER'

El usuario autenticado si la petición es redirigida internamente.

'SCRIPT_FILENAME'

La ruta del script ejecutándose actualmente en forma absoluta.

'SERVER_ADMIN'

El valor dado a la directiva SERVER_ADMIN (de Apache) en el archivo de configuración del servidor web. Si el script se está ejecutando en un host virtual, el valor dado será el definido para dicho host virtual.

'SERVER_PORT'

El puerto de la máquina del servidor usado por el servidor web para la comunicación. Para las configuraciones por omisión, el valor será '`80`'; el empleo de SSL, por ejemplo, cambiará dicho valor al valor definido para el puerto HTTP seguro.

'SERVER_SIGNATURE'

Cadena que contiene la versión del servidor y el nombre del host virtual que son añadidas a las páginas generadas por el servidor, si esta habilitada esta funcionalidad.

'PATH_TRANSLATED'

Ruta de acceso basada en el sistema (no en el directorio raíz de documentos del servidor) del script actual, después de cualquier mapeo de virtual a real realizada por el servidor.

'SCRIPT_NAME'

Contiene la ruta del script actual. Esto es de utilidad para las páginas que necesiten apuntarse a si mismas. La constante [__FILE__](https://www.php.net/manual/es/language.constants.predefined.php)contiene la ruta absoluta y el nombre del archivo actual incluido.

'REQUEST_URI'

La URI que se empleó para acceder a la página. Por ejemplo: '`/index.html`'.

'PHP_AUTH_DIGEST'

Cuando se hace autenticación Digest HTTP, esta variable se establece para el encabezado 'Authorization' enviado por el cliente (el cual se debe entonces usar para hacer la validación apropiada).

'PHP_AUTH_USER'

Cuando se hace autenticación HTTP, esta variable se establece para el nombre de usuario provisto por el usuario.

'PHP_AUTH_PW'

Cuando se hace autenticación HTTP, esta variable se establece para la clave provista por el usuario.

'AUTH_TYPE'

Cuando se realiza la autenticación HTTP, está variable se establece para el tipo de autenticación.

'PATH_INFO'

Contiene cualquier información sobre la ruta proporcionada por el cliente a continuación del nombre del fichero del script actual pero antecediendo a la cadena de la petición, si existe. Por ejemplo, si el script actual se accede a través de la URLhttp://www.example.com/php/path_info.php/some/stuff?foo=bar, entonces $_SERVER['PATH_INFO'] contendrá `/some/stuff`.

'ORIG_PATH_INFO'

Versión original de 'PATH_INFO' antes de ser procesado por PHP.