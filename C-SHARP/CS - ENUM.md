#CSHARP 

### Introduction to Enums

Enums are a avalue type that declare a set of constants with an associate name. 

For example: 

```CSHARP
enum Color{
	red, green, blue
}
```

Each constant in the  `enum` has a constant value associated. This means that can be use as it is, not because its name, but because of its constant value. 
by default, each name gets associated an <span style="color:#ababf5;">int</span>. 

Cada tipo de enumeración tiene un tipo entero correspondiente denominado el tipo _**subyacente**_ del tipo de enumeración. Este tipo subyacente debe ser capaz de representar todos los valores de enumerador definidos en la enumeración. Una declaración de enumeración puede declarar explícitamente un tipo subyacente de `byte` ,, `sbyte` `short` , `ushort` , `int` , `uint` `long` o `ulong` . Tenga en cuenta que `char` no se puede utilizar como tipo subyacente. Una declaración de enumeración que no declara explícitamente un tipo subyacente tiene un tipo subyacente de `int` .

Having an enum that look like this: 

```CSHARP 
public enum ORDER_STATUS{
PENDING = 0, 
SENT, 
DENIED, 
NON_STOCK_REMAINING
}
```

#### ENUMERATOR TO STRING 

If you need to print or transform the enumerator into an array of `string` that shows all the enumerator values: 

```CSHARP
string[] status = System.Enum.GetNames(typeof(ORDER_STATUS));
```

By using the <span style="color:orange;">System.Enum</span> functions, can be transformed. 

#### GET THE NUMBER OF ENUMERATOR VALUES

There is not a concrete method to get the number of different possible values that the enumerator can have, but taking into account that the previous function gives us an array with all the enum types in string format. 
This imply that with that <span style="color:#ababf5;">string[] enum_arr</span> getting its <span style="color:orange;">.Length</span> its the same as getting the total number of types. 

```CSHARP
int num_enums_types = System.Enum.GetNames(typeof(ORDER_STATUS)).Length; 
```