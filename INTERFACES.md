## INTERFACES 

Una interfaz define un clase. Cualquier class o struct que implemente esta misma, debe proporcionar una implementación de todos los miembros definidos en la interfaz. Una interfaz puede definir una implementación predeterminada de miembros. También puede definir miembros static para proporcionar una única implementación de funcionalidad común. A partir de C# 11, una interfaz puede definir miembros static abstract o static virtual para declarar que un tipo de implementación debe proporcionar los miembros declarados. Normalmente, los métodos static virtual declaran que una implementación debe definir un conjunto de operadores sobrecargados.


Ejemplo: 
```CSHARP 
interface ISampleInterface
{
    void SampleMethod();
}

class ImplementationClass : ISampleInterface
{
    // Explicit interface member implementation:
    void ISampleInterface.SampleMethod()
    {
        // Method implementation.
    }

    static void Main()
    {
        // Declare an interface instance.
        ISampleInterface obj = new ImplementationClass();

        // Call the member.
        obj.SampleMethod();
    }
}
```
