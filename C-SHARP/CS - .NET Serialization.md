#NET #CSHARP 
#  .NET Serialization

La serialización es el proceso de convertir el estado de un objeto en un formato que se pueda almacenar o transportar. El complemento de serialización es deserialización, que convierte una secuencia en un objeto. Juntos, estos procesos permiten almacenar y transferir datos.

.NET has the following serialization technologies:

- La [serialización binaria](https://learn.microsoft.com/es-es/dotnet/standard/serialization/binary-serialization) preserva la fidelidad de tipo, lo que es útil para conservar el estado de un objeto entre distintas invocaciones de una aplicación. Por ejemplo, puede compartir un objeto entre distintas aplicaciones si lo serializa en el Portapapeles. Puede serializar un objeto en una secuencia, un disco, la memoria, a través de la red, etc. La comunicación remota utiliza la serialización para pasar objetos "por valor" de un equipo o dominio de aplicación a otro.

- La [serialización de SOAP y XML](https://learn.microsoft.com/es-es/dotnet/standard/serialization/xml-and-soap-serialization) solo serializa propiedades y campos públicos y no preserva la fidelidad de tipo. Esto es útil si se desea proporcionar o utilizar los datos sin restringir la aplicación que utiliza los datos. Dado que XML es un estándar abierto, es una opción atractiva para compartir los datos por el web. SOAP es igualmente un estándar abierto, que lo convierte en una opción atractiva.

- La [serialización de JSON](https://learn.microsoft.com/es-es/dotnet/standard/serialization/system-text-json-overview) solo serializa propiedades públicas y no preserva la fidelidad de tipo. JSON es un estándar abierto que constituye una opción atractiva para compartir datos en Internet.


[Serialization](https://learn.microsoft.com/es-es/dotnet/standard/serialization/#reference)