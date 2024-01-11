#JS 

## <span style="color:#ababf5;">ARRAYS</span>

Arrays in JS are a special variable that can hold more than 1 value. 

Compared to other languages, in Javascript arrays are object


### <span style="color:#7ab3ef;">CHECK IF ITS AN ARRAY</span>

Because Javascript is a weakly typed language, its important to make sure if an variable stores an array. 

You can <span style="color:#db7093;">check</span> if an object is an array by using `Array.isArray(value); `

```JS
const arr1 = [1, 3, 5]; 
Array.isArray(arr1);      //true

// use Array.isArray or Object.prototype.toString.call
// to differentiate regular objects from arrays
typeof [1, 2, 4] === "object";
typeof(arr1) === "object"; 
```

 [developer.mozilla link](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/isArray)

``` JS
// all following calls return true
Array.isArray([]);
Array.isArray([1]);
Array.isArray(new Array());
Array.isArray(new Array("a", "b", "c", "d"));
Array.isArray(new Array(3));
// Little known fact: Array.prototype itself is an array:
Array.isArray(Array.prototype);

// all following calls return false
Array.isArray();
Array.isArray({});
Array.isArray(null);
Array.isArray(undefined);
Array.isArray(17);
Array.isArray("Array");
Array.isArray(true);
Array.isArray(false);
Array.isArray(new Uint8Array(32));
// This is not an array, because it was not created using the
// array literal syntax or the Array constructor
Array.isArray({ __proto__: Array.prototype });
```

### <span style="color:#7ab3ef;">INSERT NEW VALUES</span>

To insert a value in JS arrays, can be done with `push()` or by index. 

```JS
// Push method
const arr = [1, 2, 4, 6]; 
arr.push(8); 

// BY index
const fruits = ["Banana", "Orange", "Apple"];  
fruits[fruits.length] = "Lemon";  

fruits[6] = "Pineapple"; 
```

Take into account that indexing can create undefined values between the last array value and the position inserted 

### <span style="color:#7ab3ef;">DELETE EXISTING VALUES</span>

A value that exists in the array can be deleted by giving its position with `splice(pos, numElements);`
* `pos` position to start deleting
* `numElements` number of elements to delete starting from `pos` position. 
```JS
let fruits ["Manzana", "Banana", "Fresa"]
let deletedItem = fruits.splice(pos, 1);
// ["Manzana", "Fresa"]
```

### <span style="color:#7ab3ef;">ADD AND DELETE FROM BEGIN</span>

Values can be added and deleted from the beginning of the array with `shift()` and `unshift(value)`. 

```JS
let arr = ["pineaple","apple","pear"]; 
arr.unshift("cherry"); // ["cherry", "pineaple","apple","pear"]
```

### <span style="color:#7ab3ef;">FIND THE INDEX</span>

In javascript the arrays are indexed values so their index can be found with 

```JS
let arr = ["pineaple","apple","pear"]; 
frutas.push("cherry");
// ["pineaple","apple","pear","cherry"]

let pos = frutas.indexOf("pineaple"); // (pos) es la posición para abreviar
// 0
```

### <span style="color:#7ab3ef;">COPY AN ARRAY</span>

You can copy an array by using `slice()` function. 

```JS
let arrayCopy = fruits.slice(); 
```


### <span style="color:#7ab3ef;">ACCESSING ITEMS</span>

Items in the array can be accessed with index with \[\] operator. 

```JS
let arr = ["Hello", "World"]; 
console.log(arr[0]);                 // First element
console.log(arr[1]); 
console.log(arr[arr.length - 1]);    // Last element
```



