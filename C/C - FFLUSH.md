
Imagine that you have the following code, asking the user to enter some numbers by console. 

```C
#include <stdio.h>  
  
int main()  
{  
   int a, b;  
  
   printf( "Introduzca el primer numero: " );  
   scanf( "%d", &a );  
   printf( "Introduzca el segundo numero: " );  
   scanf( "%d", &b );  
   printf( "Los valores son: %d, %d ", a, b );  
  
   return 0;  
}

```


With this there is no problem, but what happen if you have to enter some characters: 

```C

```