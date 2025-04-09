#CONCEPTS #OPTIMIZATION

## BIG O NOTATION

This notation lets us to give a nomenclature or symbology to the <span style="color:#ababf5; text-decoration:underline;">complexity</span> of an algorithm. 

Its important because when taking about performance <span style="color:#ff8469;">we cannot talk about time</span> . This is because an algorithm time consuption is dependant from the hardware. 

Also many algorithm change its performance depending on the <span style="color:#ababf5; text-decoration:underline;">size of the data</span> to handle. 


BIG O notation gives the worst scenario that the algorithm can handle. 


## O(1) — Constant Notation

This expression indicates a <span style="color:#ababf5;">constant time</span>. 
The algorithm will be executed with the same performance independently from the input size. 

```JAVASCRIPT
function findByIndex(food, index) {  
  return food[index];  
}
var food = ['🍿', '🍔', '🍩', '🍗'];
console.log(findByIndex(food, 2));   //🍩
```
## O(n) — Lineal Notation

This expression is about <span style="color:#ababf5;">lineal grow</span> of the performance depending from the input size. 
The consumption is proportional to the input.

```JAVASCRIPT
function selectedFood(food) {  
  food.forEach(objectFood =>   
       console.log(objectFood, objectFood)  
  );  
}
const food = ['🍿', '🍔', '🍩', '🍗'];
selectedFood(food); // 🍿🍿​​​​​ 🍔🍔​​​​​ ​​​​🍩🍩​​​​​ ​​​​​🍗🍗​​​​​
```

## O(n2) — Quadratic notation

Indicates that the increment in complexity is proportional to the square of the size of the input. 
This algorithms are less efficient, so they are not recommended for huge sizes of data. 
They are normally originated when we use nested loops. 

Example:

```javascript
function bubbleSort(array){  
  array = array.slice();  
  for (let i = 0; i < array.length; i++) {  
    for (let j = 0; j < array.length - 1; j++) {  
      if (array[j] > array[j + 1]) {  
        [array[j], array[j + 1]] = [array[j + 1], array[j]];  
      }  
    }  
  }  
  return array;  
}
var array = [ 4, 3, 2, 1];
console.log(bubbleSort(array)); // [ 1, 2, 3, 4]
```
## O(log n) — Logarithmic notation

The logarithmic notation indicates that the time increases linearly, while `n` scales exponentially. 
Si if it takes 1 second to calculate 10 elements, it will take 2 seconds for 100 elements and 3 for 1000 and so on. 

Example:
```javascript
function binarySearch(array, element, start = 0, end = (array.length - 1)) {  
  if (end < start) return -1;  
  var middle = Math.floor((start + end) / 2);  
  return element === array[middle]  
    ? middle  
    : element < array[middle]  
      ? binarySearch(array, element, start, middle - 1)  
      : binarySearch(array, element, middle + 1, end);  
}
var unsortedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
console.log("Index of 2: ", binarySearch(unsortedArray, 2)); // Index of 2:1  
console.log("22 not found: ", binarySearch(unsortedArray, 22)); // 22 not found: -1 
```

A good comparison: 

![](https://miro.medium.com/v2/resize:fit:1188/1*L69ET_yAApxwq7vSxWivPA.png)


### NOTES

Algorithms depends from: 

* Hardware power
* Data size

--- 
### REFERENCES

* [Medium](https://medium.com/nowports-tech/introducción-a-big-o-notation-95ecca8bd866)

--- 
Author: Daniel Laplana 
Date: 21 - 12 - 2023 
CONCEPTS ABOUT COMPUTER SCIENCE
%%TODO Translate into english%%