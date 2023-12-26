#CSHARP #UNITY 

## What is gizmos 


### Main functions

For being able to use Gizmos, one the main importante features in the ability to change the color that Gizmos uses for drawing. 

This color is not changed when drawing. This color gets changes before calling a drawing method. 
```CSHARP 
Color col = Color.cyan; 
Gizmos.color = col; 
```

References of how to use `Color` class: [[UNITY - Color]]

Main functions: 

```CSHARP 

```

### Gizmos debug

You can draw using `Gizmos`class inside methods: 

```CSHARP
// Gets call in the editor always
void OnGizmosDraw(){
	
}

// Gets called in the editor when the gameobject is selected
void OnDrawGizmosSelected(){

}
```