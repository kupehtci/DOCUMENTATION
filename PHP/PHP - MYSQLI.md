#PHP #SQL 

MYSQLI extension lets you interact with SQL and execute statement and get its results. 

### mysqli class

```PHP
// 
int $affected_rows;
int $connect_errno;
string $connect_error;
int $errno;
array $error_list;
string $error;
int $field_count;
int $client_version;
string $host_info;
string $protocol_version;
string $server_info;
int $server_version;
string $info;
mixed $insert_id;
string $sqlstate;
int $thread_id;
int $warning_count;
```

### Main functions, methods and properties


- [mysqli](https://www.php.net/manual/es/class.mysqli.php) — Main mysqli class
    - [mysqli::$affected_rows](https://www.php.net/manual/es/mysqli.affected-rows.php) — Obtain the last statement affected rows
    - [mysqli::autocommit](https://www.php.net/manual/es/mysqli.autocommit.php) — Activa o desactiva las modificaciones de la base de datos autoconsignadas
    - [mysqli::begin_transaction](https://www.php.net/manual/es/mysqli.begin-transaction.php) — Inicia una transacción
    - [mysqli::change_user](https://www.php.net/manual/es/mysqli.change-user.php) — Cambia el usuario de la conexión de bases de datos especificada
    - [mysqli::character_set_name](https://www.php.net/manual/es/mysqli.character-set-name.php) — Devuelve el juego de caracteres predeterminado para la conexión a la base de datos
    - [mysqli::close](https://www.php.net/manual/es/mysqli.close.php) — Cierra una conexión previamente abierta a una base de datos
    - [mysqli::commit](https://www.php.net/manual/es/mysqli.commit.php) — Consigna la transacción actual
    - [mysqli::$connect_errno](https://www.php.net/manual/es/mysqli.connect-errno.php) — Devuelve el código de error de la última llamada
    - [mysqli::$connect_error](https://www.php.net/manual/es/mysqli.connect-error.php) — Devuelve una cadena con la descripción del último error de conexión
    - [mysqli::__construct](https://www.php.net/manual/es/mysqli.construct.php) — Abre una nueva conexión al servidor de MySQL
    - [mysqli::debug](https://www.php.net/manual/es/mysqli.debug.php) — Realiza operaciones de depuración
    - [mysqli::dump_debug_info](https://www.php.net/manual/es/mysqli.dump-debug-info.php) — Volcado de información de depuración en el registro
    - [mysqli::$errno](https://www.php.net/manual/es/mysqli.errno.php) — Devuelve el código del error de la última función llamada
    - [mysqli::$error_list](https://www.php.net/manual/es/mysqli.error-list.php) — Devuelve una lista de errores desde el último comando ejecutado
    - [mysqli::$error](https://www.php.net/manual/es/mysqli.error.php) — Devuelve una cadena que describe el último error
    - [mysqli::execute_query](https://www.php.net/manual/es/mysqli.execute-query.php) — Prepares, binds parameters, and executes SQL statement
    - [mysqli::$field_count](https://www.php.net/manual/es/mysqli.field-count.php) — Devuelve el número de columnas para la consulta más reciente
    - [mysqli::get_charset](https://www.php.net/manual/es/mysqli.get-charset.php) — Devuelve un objeto que contiene el conjunto de caracteres
    - [mysqli::get_client_info](https://www.php.net/manual/es/mysqli.get-client-info.php) — Obtiene información de la biblioteca cliente de MySQL
    - [mysqli_get_client_version](https://www.php.net/manual/es/mysqli.get-client-version.php) — Devuelve la versión clientes de MySQL como valor de tipo integer
    - [mysqli::get_connection_stats](https://www.php.net/manual/es/mysqli.get-connection-stats.php) — Devuelve estadísticas sobre la conexión del cliente
    - [mysqli::$host_info](https://www.php.net/manual/es/mysqli.get-host-info.php) — Devuelve una cadena que representa el tipo de conexión usada
    - [mysqli::$protocol_version](https://www.php.net/manual/es/mysqli.get-proto-info.php) — Devuelve la versión del protocolo MySQL utilizada
    - [mysqli::$server_info](https://www.php.net/manual/es/mysqli.get-server-info.php) — Devuelve la versión del servidor MySQL
    - [mysqli::$server_version](https://www.php.net/manual/es/mysqli.get-server-version.php) — Devuelve la versión del servidor MySQL como un valor entero
    - [mysqli::get_warnings](https://www.php.net/manual/es/mysqli.get-warnings.php) — Obtiene el resultado de SHOW WARNINGS
    - [mysqli::$info](https://www.php.net/manual/es/mysqli.info.php) — Obtiene la información de la última consulta ejecutada
    - [mysqli::init](https://www.php.net/manual/es/mysqli.init.php) — Inicializa y devuelve un recurso para utilizarlo con mysqli_real_connect()
    - [mysqli::$insert_id](https://www.php.net/manual/es/mysqli.insert-id.php) — Devuelve el id autogenerado que se utilizó en la última consulta
    - [mysqli::kill](https://www.php.net/manual/es/mysqli.kill.php) — Pide al servidor poner fin a un hilo de MySQL
    - [mysqli::more_results](https://www.php.net/manual/es/mysqli.more-results.php) — Comprueba si hay más resultados de una multi consulta
    - [mysqli::multi_query](https://www.php.net/manual/es/mysqli.multi-query.php) — Realiza una consulta a la base de datos
    - [mysqli::next_result](https://www.php.net/manual/es/mysqli.next-result.php) — Prepara el siguiente resultado de multi_query
    - [mysqli::options](https://www.php.net/manual/es/mysqli.options.php) — Establecer opciones
    - [mysqli::ping](https://www.php.net/manual/es/mysqli.ping.php) — Comprueba la conexión al servidor, o trata de reconectar si se perdió la conexión
    - [mysqli::poll](https://www.php.net/manual/es/mysqli.poll.php) — Almacena en caché conexiones
    - [mysqli::prepare](https://www.php.net/manual/es/mysqli.prepare.php) — Prepara una sentencia SQL para su ejecución
    - [mysqli::query](https://www.php.net/manual/es/mysqli.query.php) — Realiza una consulta a la base de datos
    - [mysqli::real_connect](https://www.php.net/manual/es/mysqli.real-connect.php) — Abre una conexión a un servidor mysql
    - [mysqli::real_escape_string](https://www.php.net/manual/es/mysqli.real-escape-string.php) — Escapa los caracteres especiales de una cadena para usarla en una sentencia SQL, tomando en cuenta el conjunto de caracteres actual de la conexión
    - [mysqli::real_query](https://www.php.net/manual/es/mysqli.real-query.php) — Ejecuta una consulta SQL
    - [mysqli::reap_async_query](https://www.php.net/manual/es/mysqli.reap-async-query.php) — Obtener el resultado de una consulta asincrónica
    - [mysqli::refresh](https://www.php.net/manual/es/mysqli.refresh.php) — Refresca
    - [mysqli::release_savepoint](https://www.php.net/manual/es/mysqli.release-savepoint.php) — Elimina el punto salvado con nombre del conjunto de puntos salvados de la transacción actual
    - [mysqli::rollback](https://www.php.net/manual/es/mysqli.rollback.php) — Revierte la transacción actual
    - [mysqli::savepoint](https://www.php.net/manual/es/mysqli.savepoint.php) — Define el nombre de un punto de salvaguarda de la transacción
    - [mysqli::select_db](https://www.php.net/manual/es/mysqli.select-db.php) — Selecciona la base de datos por defecto para realizar las consultas
    - [mysqli::set_charset](https://www.php.net/manual/es/mysqli.set-charset.php) — Establece el conjunto de caracteres predeterminado del cliente
    - [mysqli::$sqlstate](https://www.php.net/manual/es/mysqli.sqlstate.php) — Devuelve el error SQLSTATE de la operación de MySQL previa
    - [mysqli::ssl_set](https://www.php.net/manual/es/mysqli.ssl-set.php) — Usada para establece conexiones seguras usando SSL
    - [mysqli::stat](https://www.php.net/manual/es/mysqli.stat.php) — Obtiene el estado actual del sistema
    - [mysqli::stmt_init](https://www.php.net/manual/es/mysqli.stmt-init.php) — Inicializa una sentencia y devuelve un objeto para usarlo con mysqli_stmt_prepare
    - [mysqli::store_result](https://www.php.net/manual/es/mysqli.store-result.php) — Transfiere un conjunto de resultados de la última consulta
    - [mysqli::$thread_id](https://www.php.net/manual/es/mysqli.thread-id.php) — Deveulve el ID del hilo de la conexión actual
    - [mysqli::thread_safe](https://www.php.net/manual/es/mysqli.thread-safe.php) — Devuelve si la seguridad a nivel de hilos está dada o no
    - [mysqli::use_result](https://www.php.net/manual/es/mysqli.use-result.php) — Inicia la recuperación de un conjunto de resultados
    - [mysqli::$warning_count](https://www.php.net/manual/es/mysqli.warning-count.php) — Devuelve el número de mensajes de advertencia de la última consulta para un enlace dado
- [mysqli_stmt](https://www.php.net/manual/es/class.mysqli-stmt.php) — La clase mysqli_stmt
    - [mysqli_stmt::$affected_rows](https://www.php.net/manual/es/mysqli-stmt.affected-rows.php) — Devuelve el número total de filas cambiadas, borradas, o insertadas por la última sentencia ejecutada
    - [mysqli_stmt::attr_get](https://www.php.net/manual/es/mysqli-stmt.attr-get.php) — Se utiliza para obtener el valor actual de un atributo de la sentencia
    - [mysqli_stmt::attr_set](https://www.php.net/manual/es/mysqli-stmt.attr-set.php) — Se utiliza para modificar el comportamiento de una sentencia preparada
    - [mysqli_stmt::bind_param](https://www.php.net/manual/es/mysqli-stmt.bind-param.php) — Agrega variables a una sentencia preparada como parámetros
    - [mysqli_stmt::bind_result](https://www.php.net/manual/es/mysqli-stmt.bind-result.php) — Vincula variables a una sentencia preparada para el almacenamiento de resultados
    - [mysqli_stmt::close](https://www.php.net/manual/es/mysqli-stmt.close.php) — Cierra una sentencia preparada
    - [mysqli_stmt::__construct](https://www.php.net/manual/es/mysqli-stmt.construct.php) — Construye un nuevo objeto mysqli_stmt
    - [mysqli_stmt::data_seek](https://www.php.net/manual/es/mysqli-stmt.data-seek.php) — Busca una fila arbitraria en un conjunto de resultados de una sentencia
    - [mysqli_stmt::$errno](https://www.php.net/manual/es/mysqli-stmt.errno.php) — Devuelve el código de error de la llamada de la sentencia más reciente
    - [mysqli_stmt::$error_list](https://www.php.net/manual/es/mysqli-stmt.error-list.php) — Devuelve una lista de errores de la última sentencia ejecutada
    - [mysqli_stmt::$error](https://www.php.net/manual/es/mysqli-stmt.error.php) — Devuelve una descripción en forma de string del último error de una sentencia
    - [mysqli_stmt::execute](https://www.php.net/manual/es/mysqli-stmt.execute.php) — Ejecuta una consulta preparada
    - [mysqli_stmt::fetch](https://www.php.net/manual/es/mysqli-stmt.fetch.php) — Obtiene los resultados de una sentencia preparadas en las variables vinculadas
    - [mysqli_stmt::$field_count](https://www.php.net/manual/es/mysqli-stmt.field-count.php) — Devuelve el número de campos de la sentencia dada
    - [mysqli_stmt::free_result](https://www.php.net/manual/es/mysqli-stmt.free-result.php) — Libera la memoria de los resultados almacenados del gestor de sentencia dado
    - [mysqli_stmt::get_result](https://www.php.net/manual/es/mysqli-stmt.get-result.php) — Obtiene un conjunto de resultados de una sentencia preparada
    - [mysqli_stmt::get_warnings](https://www.php.net/manual/es/mysqli-stmt.get-warnings.php) — Obtener los resultados de SHOW WARNINGS
    - [mysqli_stmt::$insert_id](https://www.php.net/manual/es/mysqli-stmt.insert-id.php) — Obtener el ID generado en la operación INSERT anterior
    - [mysqli_stmt::more_results](https://www.php.net/manual/es/mysqli-stmt.more-results.php) — Comprobar si existen más resultados de una consulta de consultas múltiples
    - [mysqli_stmt::next_result](https://www.php.net/manual/es/mysqli-stmt.next-result.php) — Lee el siguiente resultado de una consulta múltiple
    - [mysqli_stmt::$num_rows](https://www.php.net/manual/es/mysqli-stmt.num-rows.php) — Devuelve el número de filas de un conjunto de resultados de una sentencia
    - [mysqli_stmt::$param_count](https://www.php.net/manual/es/mysqli-stmt.param-count.php) — Devuelve el número de parámetros de la sentencia dada
    - [mysqli_stmt::prepare](https://www.php.net/manual/es/mysqli-stmt.prepare.php) — Preparar una sentencia SQL para su ejecución
    - [mysqli_stmt::reset](https://www.php.net/manual/es/mysqli-stmt.reset.php) — Reinicia una sentencia preparada
    - [mysqli_stmt::result_metadata](https://www.php.net/manual/es/mysqli-stmt.result-metadata.php) — Devuelve los metadatos del conjunto de resultados de una sentencia preparada
    - [mysqli_stmt::send_long_data](https://www.php.net/manual/es/mysqli-stmt.send-long-data.php) — Enviar datos en bloques
    - [mysqli_stmt::$sqlstate](https://www.php.net/manual/es/mysqli-stmt.sqlstate.php) — Devuelve el error SQLSTATE de la operación de sentencia previa
    - [mysqli_stmt::store_result](https://www.php.net/manual/es/mysqli-stmt.store-result.php) — Transfiere un conjunto de resultados desde una sentencia preparada
- [mysqli_result](https://www.php.net/manual/es/class.mysqli-result.php) — La clase mysqli_result
    - [mysqli_result::__construct](https://www.php.net/manual/es/mysqli-result.construct.php) — Constructs a mysqli_result object
    - [mysqli_result::$current_field](https://www.php.net/manual/es/mysqli-result.current-field.php) — Obtener posición del campo actual de un puntero a un resultado
    - [mysqli_result::data_seek](https://www.php.net/manual/es/mysqli-result.data-seek.php) — Ajustar el puntero de resultado a una fila arbitraria del resultado
    - [mysqli_result::fetch_all](https://www.php.net/manual/es/mysqli-result.fetch-all.php) — Obtener todas las filas en un array asociativo, numérico, o en ambos
    - [mysqli_result::fetch_array](https://www.php.net/manual/es/mysqli-result.fetch-array.php) — Obtiene una fila de resultados como un array asociativo, numérico, o ambos
    - [mysqli_result::fetch_assoc](https://www.php.net/manual/es/mysqli-result.fetch-assoc.php) — Obtener una fila de resultado como un array asociativo
    - [mysqli_result::fetch_column](https://www.php.net/manual/es/mysqli-result.fetch-column.php) — Fetch a single column from the next row of a result set
    - [mysqli_result::fetch_field_direct](https://www.php.net/manual/es/mysqli-result.fetch-field-direct.php) — Obtener los metadatos de un único campo
    - [mysqli_result::fetch_field](https://www.php.net/manual/es/mysqli-result.fetch-field.php) — Retorna el próximo campo del resultset
    - [mysqli_result::fetch_fields](https://www.php.net/manual/es/mysqli-result.fetch-fields.php) — Devuelve un array de objetos que representan los campos de un conjunto de resultados
    - [mysqli_result::fetch_object](https://www.php.net/manual/es/mysqli-result.fetch-object.php) — Devuelve la fila actual de un conjunto de resultados como un objeto
    - [mysqli_result::fetch_row](https://www.php.net/manual/es/mysqli-result.fetch-row.php) — Obtener una fila de resultados como un array enumerado
    - [mysqli_result::$field_count](https://www.php.net/manual/es/mysqli-result.field-count.php) — Obtiene el número de campos de un resultado
    - [mysqli_result::field_seek](https://www.php.net/manual/es/mysqli-result.field-seek.php) — Establecer el puntero del resultado al índice del campo especificado
    - [mysqli_result::free](https://www.php.net/manual/es/mysqli-result.free.php) — Libera la memoria asociada a un resultado
    - [mysqli_result::getIterator](https://www.php.net/manual/es/mysqli-result.getiterator.php) — Retrieve an external iterator
    - [mysqli_result::$lengths](https://www.php.net/manual/es/mysqli-result.lengths.php) — Retorna los largos de las columnas de la fila actual en el resultset
    - [mysqli_result::$num_rows](https://www.php.net/manual/es/mysqli-result.num-rows.php) — Obtiene el número de filas de un resultado
- [mysqli_driver](https://www.php.net/manual/es/class.mysqli-driver.php) — La clase mysqli_driver
    - [mysqli_driver::embedded_server_end](https://www.php.net/manual/es/mysqli-driver.embedded-server-end.php) — Detener el servidor incrustado
    - [mysqli_driver::embedded_server_start](https://www.php.net/manual/es/mysqli-driver.embedded-server-start.php) — Inicializa e inicia el servidor embebido
    - [mysqli_driver::$report_mode](https://www.php.net/manual/es/mysqli-driver.report-mode.php) — Habilita o desabilita las funciones internas de notificación
- [mysqli_warning](https://www.php.net/manual/es/class.mysqli-warning.php) — La clase mysqli_warning
    - [mysqli_warning::__construct](https://www.php.net/manual/es/mysqli-warning.construct.php) — Private constructor to disallow direct instantiation
    - [mysqli_warning::next](https://www.php.net/manual/es/mysqli-warning.next.php) — El propósito next
- [mysqli_sql_exception](https://www.php.net/manual/es/class.mysqli-sql-exception.php) — La clase mysqli_sql_exception
- [Alias y Funciones de MySQLi obsoletos](https://www.php.net/manual/es/ref.mysqli.php)
    - [mysqli_connect](https://www.php.net/manual/es/function.mysqli-connect.php) — Alias de mysqli::__construct
    - [mysqli_escape_string](https://www.php.net/manual/es/function.mysqli-escape-string.php) — Alias de mysqli_real_escape_string
    - [mysqli_execute](https://www.php.net/manual/es/function.mysqli-execute.php) — Alias para mysqli_stmt_execute
    - [mysqli_get_client_stats](https://www.php.net/manual/es/function.mysqli-get-client-stats.php) — Returns client per-process statistics
    - [mysqli_get_links_stats](https://www.php.net/manual/es/function.mysqli-get-links-stats.php) — Devolver información sobre enlaces abiertos y almacenados en caché
    - [mysqli_report](https://www.php.net/manual/es/function.mysqli-report.php) — Alias de mysqli_driver->report_mode
    - [mysqli::set_opt](https://www.php.net/manual/es/function.mysqli-set-opt.php) — Alias de mysqli_options

