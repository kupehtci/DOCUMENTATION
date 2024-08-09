#CSHARP #NET

### INTRODUCTION 

## En este artículo

1. [Especificación del lenguaje C#](https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/statements/using#c-language-specification)
2. [Vea también](https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/statements/using#see-also)

La instrucción `using` garantiza el uso correcto de una instancia heredada de  [IDisposable](https://learn.microsoft.com/es-es/dotnet/api/system.idisposable):


``` CSHARP 
var numbers = new List<int>();
using (StreamReader reader = File.OpenText("numbers.txt"))
{
    string line;
    while ((line = reader.ReadLine()) is not null)
    {
        if (int.TryParse(line, out int number))
        {
            numbers.Add(number);
        }
    }
}
```

When the control `using` gets end , [IDisposable](https://learn.microsoft.com/es-es/dotnet/api/system.idisposable) adquired instance is deleted. It makes sure that the IDisposable created in the `using` get deleted when get out the block even if the code ends in exception inside the `using`statement. En el ejemplo anterior, se cierra un archivo abierto después de procesar todas las líneas.