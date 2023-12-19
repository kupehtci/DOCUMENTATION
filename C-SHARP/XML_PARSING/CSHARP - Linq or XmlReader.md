#CSHARP #XML #NET 

#### INTRODUCTION

En este artículo se compara LINQ to XML con las siguientes tecnologías XML: [XmlReader](https://learn.microsoft.com/es-es/dotnet/api/system.xml.xmlreader), XSLT, MSXML y XmlLite. Esta información puede ayudarle a decidir las tecnologías que utilizará.

Para ver una comparación de LINQ to XML con Document Object Model (DOM), consulte [LINQ to XML y DOM](https://learn.microsoft.com/es-es/dotnet/standard/linq/linq-xml-vs-dom).

[Microsoft Comparative](https://learn.microsoft.com/es-es/dotnet/standard/linq/linq-xml-vs-xml-technologies#linq-to-xml-vs-xmlreader)

##### DIFFERENCES IN CASE OF USE (Linq to Xml or XmlReader)

[XmlReader](https://learn.microsoft.com/es-es/dotnet/api/system.xml.xmlreader) es un analizador rápido, de solo avance y sin almacenamiento en caché.

LINQ to XML se implementa sobre [XmlReader](https://learn.microsoft.com/es-es/dotnet/api/system.xml.xmlreader) y ambos están estrechamente integrados. Sin embargo, puede utilizar también [XmlReader](https://learn.microsoft.com/es-es/dotnet/api/system.xml.xmlreader) directamente.

Por ejemplo, supongamos que está creando un servicio web que analizará cientos de documentos XML por segundo y los documentos tienen la misma estructura, lo que significa que solo tiene que escribir una implementación de código para analizar el XML. En este caso, probablemente quiera usar [XmlReader](https://learn.microsoft.com/es-es/dotnet/api/system.xml.xmlreader)directamente.

Por el contrario, si crea un sistema que analiza muchos documentos XML más pequeños y cada uno es diferente, quizás quiera aprovechar las mejoras de productividad que LINQ to XML proporciona.