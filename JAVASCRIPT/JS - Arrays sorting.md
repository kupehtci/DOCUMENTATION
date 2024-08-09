#JS 

## SORTING

<span style="color:orange;">Sorting</span> can be made with `sort()` or `toSorted()`method. 
Its functionality its the same but `toSorted()` don't mutate the original array, instead make a copy and `sort()` works by sorting the original one. 

```JS
sort()
sort(compareFn)
toSorted()
toSorted(compareFn)
```

```JS
const values = [1, 10, 21, 2];
const sortedValues = values.toSorted((a, b) => a - b); //sortedValues = [1, 2, 10, 21]
values.sort((a, b)=> a - b); // values = [1, 2, 10, 21]
```


Also can be used to sort an object's array by specifying in the `compareFn` the value to check. 

### <span style="color:#91b4fa;">compareFn</span> property 

> `compareFn` consist in a function that receive values `a` and `b` for each value to compare to the one at the side and lets evaluate. Its needs to return a signed value and depending on the value consider that its greater or lower than the side one. 
> The more common one is <span style="color:#db7093;">(a, b) => a - b</span> that order its values. 

The expected value is:

|`compareFn(a, b)` return value|sort order|
|---|---|
|> 0|sort `a` after `b`, e.g. `[b, a]`|
|< 0|sort `a` before `b`, e.g. `[a, b]`|
|=== 0|keep original order of `a` and `b`|

So a **-x** mean switch values, **+x** means inverse switch and **x === 0** means maintain original order.