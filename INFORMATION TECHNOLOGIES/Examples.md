
Puede entrar preguntas sobre ETL, ¿como pasar de operacional a informacional? 

Era un ejemplo de un cine que querían actualizar su base de datos, necesitaban tener roles para poder acceder a ciertas cosas. Luego además querían poder a futuro guardar diferentes tipos de datos como videos y cosas así.
Más adelante se explicaba que querrían poder analizar los comentarios para mejorar el servicio.

4 puntos:

1. Ventajas vs desventajas de la migración a un NO-SQL

* Ventajas:
Análisis
Coste-Eficacia
Flexibilidad
Velocidad

* Desventajas:
Complejidad de la migración
Control de acceso
No documentación
Tolerancia a fallos - Cassandra MongoDB y Redis más o menos tolerante
Consistencia
Transacción y Concurrencia (la concurrencia importante)

2. Que teconología es mejor? 

(Ejemplo, Mongo vs Cassandra vs Redis vs Neo4j)

Redis: Persistencia bueno para unas cosas y malas para otras
Redis: Velocidad de escritura ventaja 
Redis: Rollback es desventaja por posible perdida de datos en mitad de una traacción
MongoDB: DataTypes ventaja
Cassandra: Lectura más lenta para muchos usuarios descventaja
Cassandra: Eventualmente consistente, a veces será consistente y luego puede que si
MongoDB, Cassandra, Redis: Partición Ventajas Más escalabilidad horizontal
Neo4j: No partición desventaja Menos escalabilidad horizontal
MongoDB: JSON Embeded -> No joins -> Ej: Pelicula Join Sala    Ventaja
Neo4j: Menor tolerancia a fallos  Desventaja
MongoDB: No Access Control for fields   Desventaja


3. Datawarehousing o BigData, cual es mejor? (esta vale menos)

Datawarehouse: Mejor si no es en tiempo real, menor volumen de datos y tipo de decisiones con tiempo (tomar decisión para futuro)
BigData: Mejor en tiempo real, mayor volumen de datos y tipo de decisión inmediata (decisiones que afectan gravemente a lo que va a ocurrir inmediatamente despues)

2 puntos:

1. Verdadero falso

Q: The operational database are usually NoSQL databases while te informational databases are usually Relational Databases.
A: F, las bases de datos opereacionales no tienen porque ser normalmente NOSQL

2. In the previous question, the new NOSQL database will contain the information about movies, theaters, employees, registred custoomers, etc. Will this database be an operational or informational system= Justifi your awnser.
A: En este caso ambas, el enunciado base era solo operacional, pero luego han dicho que querían hacer analisis de datos con Datawarehouse y entonces también era informacional. Sería una buena opción separarla.



2.5 puntos:

Captura de las 4 teconología y 5 preguntas

- Que teconología es y db? 
- Cual es la estructura? 
- Problemas en la query?
- Corregir query?
- Extenedr query?


1.5 puntos:

Seleccionar uno de los trabajos en grupo.

Verdadero y falso con justficiación y comparar al resto.