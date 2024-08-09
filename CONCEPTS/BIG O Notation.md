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

## O(n2) — notación cuadrática

Indica que el crecimiento en complejidad es proporcional al cuadrado del tamaño del **_input._** Estos algoritmos suelen ser los menos eficientes, no se recomiendan para datos grandes y normalmente se dan cuando usamos_ciclos for_ o iteraciones anidadas; es decir, si dentro de cada iteración de un arreglo lo vuelves a iterar, tendrás un algoritmo de complejidad cuadrada. Estos pueden llegar a complejidades cúbicas o factoriales.

_Ejemplo_:

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
}var array = [ 4, 3, 2, 1];console.log(bubbleSort(array)); // [ 1, 2, 3, 4]

## O(log n) — notación logarítmica

Indica que el tiempo aumenta linealmente, mientras que `n` sube exponencialmente. Entonces, si se tarda `1` segundo en calcular `10`elementos, se necesitarán `2` para `100`, `3` para `1000` y así sucesivamente.

_Ejemplo_:

function binarySearch(array, element, start = 0, end = (array.length - 1)) {  
  if (end < start) return -1;  
  var middle = Math.floor((start + end) / 2);  
  return element === array[middle]  
    ? middle  
    : element < array[middle]  
      ? binarySearch(array, element, start, middle - 1)  
      : binarySearch(array, element, middle + 1, end);  
}var unsortedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];console.log("Index of 2: ", binarySearch(unsortedArray, 2));    // Index of 2: 1  
console.log("22 not found: ", binarySearch(unsortedArray, 22)); // 22 not found: -1

Bien, teniendo en cuenta estas expresiones, quiero mostrarles un resumen visual de **Aditya Y. Bhargav** en su libro [**grokking algorthims**](https://www.manning.com/books/grokking-algorithms)**,** que muestra una comparativa genial de tiempo y tamaño de ejecución de lo que acabamos de ver:

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