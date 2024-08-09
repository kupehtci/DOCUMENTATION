## AUTOMATIC LAYOUT

To be able to adapt some items to keep certain constrains or place in a correct way, an option is to use: Vertical Layout group, Horizontal Layout Group or x



### <span style="color:#ababf5;">GRID LAYOUT GROUP</span>

The grid layout is the combination of the two previous ones. 
Groups child items forming a <span style="color:cyan;">grid</span>


![[Captura de pantalla 2023-12-19 a las 11.24.39.png]]

## Propiedades

|**_Propiedad:_**|**_Función:_**|
|---|---|
|**Padding**| Padding inside the  layout items |
|**Cell Size**| Size for each element of the grid |
|**Spacing**|El espacio entre los layout elements.|
|**Start Corner**| Starting corner where the first layout item is placed |
|**Start Axis**| Primary axis for placing elements along it. Horizontally is going to fill an entire row before starting a new one. Vertically do the same. |
|**Child Alignment**| Alignment to use with layout items when dont fill the space |
|**Constraint**|Restrict the grid to a number of columns or rows for making an auto layout|



## <span style="color:#ababf5;">Content Size Fitter (Ajustador del tamaño del contenido)</span>

## Propiedades

![](https://docs.unity3d.com/es/2019.4/uploads/Main/UI_ContentSizeFitterInspector.png)

|<span style="color:cyan;">Property:</span>|<span style="color:cyan;">Function</span>|
|---|---|
|**Horizontal Fit**|L manera cómo el ancho es controlado.|
|Unconstrained|No se maneja el ancho basándose en el layout element (Elemento de diseño).|
|Min Size|Maneja el ancho basado en el ancho mínimo y el layout element.|
|Preferred Size|Maneja el ancho basándose en el ancho preferido del layout element.|
|**Vertical Fit**|La manera cómo la altura es controlada.|
|Unconstrained|No maneja la altura basándose en el layout element.|
|Min Size|Maneja la altura basándose en la altura minima del layout element.|
|Preferred Size|Maneja la altura basándose en la altura preferida del layout element.|

## Descripción

El Content Size Fitter (Ajustador del tamaño del contenido) funciona como un controlador del layout (diseño) al controlar el tamaño de su propio layout element. El tamaño es determinado por los tamaños mínimos o preferidos proporcionados por los componentes del layout element en el Game Object. Tales layout elements pueden ser los componentes Image (Imagen) o Text (Texto), layout groups (Grupos de diseño), o un componente Layout Element.

Vale la pena tener en cuenta que cuando el Rect Transform cambia de tamaño - ya sea por un Content Size Fitter o algo más - el cambio de tamaño se hace alrededor de un pivote. Esto significa que la dirección del cambio de tamaño puede ser controlado utilizando el pivote.

Por ejemplo, cuando el pivote está en el centro, el Content Size Fitter va a expandir el Rect Transform de manera igual en todas las direcciones. Y cuando el pivote está en la esquina superior izquierda, el Content Size Fitter va a expandir el Rect Transform abajo y a la derecha.