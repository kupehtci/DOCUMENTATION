
# Eventos Soportados

El EventSystem soporta un número de eventos, y estos pueden ser personalizados aun más en InputModules escritos por el usuario personalizados.

Los Eventos que son soportados por el StandaloneInputModule y TouchInputModule son proporcionados por la interfaz y pueden ser implementas en un MonoBehaviour al implementar la interfaz. Si usted tiene un EventSystem válido configurado, los eventos serán llamados en el tiempo correcto.

| Interface                      | Method                  | Description                                       |
|---------------------------------|-------------------------|---------------------------------------------------|
| IPointerEnterHandler            | OnPointerEnter          | Called when a pointer enters the object           |
| IPointerExitHandler             | OnPointerExit           | Called when a pointer exits the object            |
| IPointerDownHandler             | OnPointerDown           | Called when a pointer is pressed on the object    |
| IPointerUpHandler               | OnPointerUp             | Called when a pointer is released on the GameObject that the pointer is clicking |
| IPointerClickHandler            | OnPointerClick          | Called when a pointer is pressed and released on the same object |
| IInitializePotentialDragHandler | OnInitializePotentialDrag | Called when a drag target is found, can be used to initialize values |
| IBeginDragHandler               | OnBeginDrag             | Called on the drag object when the drag is about to begin |
| IDragHandler                    | OnDrag                  | Called on the drag object when the drag is happening |
| IEndDragHandler                 | OnEndDrag               | Called on the drag object when a drag has ended    |
| IDropHandler                    | OnDrop                  | Called on the object where the drag ends          |
| IScrollHandler                  | OnScroll                | Called when the mouse wheel is scrolled           |
| IUpdateSelectedHandler          | OnUpdateSelected        | Called on the selected object every frame         |
| ISelectHandler                  | OnSelect                | Called when the object becomes the selected object |
| IDeselectHandler                | OnDeselect              | Called when the selected object becomes deselected |
| IMoveHandler                    | OnMove                  | Called when a move event occurs (left, right, up, down, etc.) |
| ISubmitHandler                  | OnSubmit                | Called when the submit button is pressed          |
| ICancelHandler                  | OnCancel                | Called when the cancel button is pressed          |
