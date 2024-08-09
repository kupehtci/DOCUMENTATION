#UNITY 


Has the transform changed since the last time the flag was set to 'false'?

A change to the transform can be anything that can cause its matrix to be recalculated: any adjustment to its position, rotation or scale. 

All the operations that use <span style="color:orange;">tranform.position</span> will set the flag to true without checking if the transform has been changed. 

This means that this code placed in a update: 

```CSHARP 

```