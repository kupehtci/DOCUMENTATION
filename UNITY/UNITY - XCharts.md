#UNITY #CSHARP 

## LIBRARY USAGE

This library allows to draw a lot of charts in Unity


### PROPERTIES

Each `chart` has a group of series (`SerieData[]`) and each one of tham contains a list of `data` that can be `Add()` to be shown in the chart. 


### ADD DATA 

Each chart has a <span style="color:MediumSpringGreen;">series</span> list component that holds the `data` component. 

To access each series you can access via the Component and index array: 

```CSHARP
RadarChart _chart = GetComponent<RadarChart>(); 

_chart_.series[0].data.Clear();
```
