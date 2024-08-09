#C 

### IO EXAMPLE 

Here is an example of how to read from console and print a character: 

``` C
#include <stdio.h>
int main()
{
    char chr;
    printf("Enter a character: ");
    scanf("%c",&chr);     
    printf("You entered %c.", chr);  
    return 0;
}   
```

#### IO SPECIFIERS

## Format Specifiers for I/O

As you can see from the above examples [[C - IO BY CONSOLE]] , we use

- `%d` for `int`
- `%f` for `float`
- `%lf` for `double`
- `%c` for `char`

Here's a list of commonly used C data types and their format specifiers.

|Data Type|Format Specifier|
|---|---|
|`int`|`%d`|
|`char`|`%c`|
|`float`|`%f`|
|`double`|`%lf`|
|`short int`|`%hd`|
|`unsigned int`|`%u`|
|`long int`|`%li`|
|`long long int`|`%lli`|
|`unsigned long int`|`%lu`|
|`unsigned long long int`|`%llu`|
|`signed char`|`%c`|
|`unsigned char`|`%c`|
|`long double`|`%Lf`|

