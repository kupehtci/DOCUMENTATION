#CS #CONCEPTS 

### BITMASK

When needing to store and keep some flags that can be combined between them and not having only one as an **enum** [^1] . 

This flags can be combined by using an enumerator and combine this enum flags as a bit operator that combined the sum of them: 

```c#
enum Color{
	COLOR_NONE = 0; 
	COLOR_RED = 1 << 0, 
	COLOR_GREEN = 1 << 1, 
	COLOR_BLUE = 1 << 2, 
	COLOR_YELLOW = 1 << 3, 
	COLOR_CYAN = 1 << 4, 
	COLOR_MAGENTA = 1 << 5, 
	COLOR_BLACK = 1 << 6, 
	COLOR_WHITE = 1 << 7
}
```

By storing them as bitwise values, the binary can be stacked together and understanded as different flags: 

If a color share red and blue, can be stored together as: 
```c#
Color col = Color.COLOR_RED | Color.COLOR_BLUE; 
```



### BITWISE OPERATORS


```txt
~ bit complement operator  
| OR operator  
& AND operator  
^ IR operator
```


[^1]: [[CS - ENUM]]