#HTML #JS 


To get the reference to the object that calls the <span style="color:MediumSpringGreen;">JS function</span>, this one can be pased as an argument by the word <span style="color:#ababf5;">this</span>. 


```HTML
<button onclick="Test(this)">HELLOOOOOO</button>
```

```JS
function Test(ele){
alert(ele.innerText); //HELLOOOOOO
}
```