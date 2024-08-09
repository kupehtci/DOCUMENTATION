#JS 

## <span style="color:#ababf5;">FOR LOOPS</span>



## <span style="color:#ababf5;">FOR ITERABLE</span>

JS Arrays are iterables using the <span style="color:orange;">for([scope] [variable] of [iterable])</span>

```JS
let iterable = [10, 20, 30];

for (let value of iterable) {
  value += 1;
  console.log(value);
}
```

A map is also interactable: 

```JS
let iterable = new Map([
  ["a", 1],
  ["b", 2],
  ["c", 3],
]);

for (let entry of iterable) {
  console.log(entry);
}
// ['a', 1]
// ['b', 2]
// ['c', 3]

for (let [key, value] of iterable) {
  console.log(value);
}
// 1
// 2
// 3
```

