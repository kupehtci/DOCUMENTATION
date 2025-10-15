#CSS 

# CSS - Grids

A Grid is a bidimensional layout for defining more complex layouts in a more efficient manner than traditional layouts. 

You can use CSS Grid to define rows and columns layouts and precise alignment of the objects. 

Example: 
```css
/* Contenedor Grid */
.grid-container {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-rows: 100px 200px;
    gap: 10px;
}

/* Items del Grid */
.grid-item {
    background: #f0f0f0;
    padding: 20px;
}
```

The main properties for a grid are: 

* `display:grid` or `display:inline-grid` for block or inline layout. 

```css
.container{
	display: grid;
	display: inline-grid; 
}
```

* `grid-template-columns` y `grid-template-rows`

```css
.container {
    /* Valores fijos */
    grid-template-columns: 200px 200px 200px;
    
    /* Unidades flexibles */
    grid-template-columns: 1fr 2fr 1fr;
    
    /* Mixtas */
    grid-template-columns: 200px 1fr 100px;
    
    /* Función repeat() */
    grid-template-columns: repeat(3, 1fr);
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    
    /* Función minmax() */
    grid-template-columns: minmax(200px, 1fr) 200px;
}
```

It uses special units `fr`known as fractions of the available space.  

* spacing using `gap`: 

```css
.container {
    /* Espaciado uniforme */
    gap: 20px;
    
    /* Espaciado específico */
    row-gap: 20px;
    column-gap: 30px;
    
    /* Shorthand */
    gap: 20px 30px; /* row column */
}
```

* implicit grid: 

```css
.container {
    /* Tamaño de tracks implícitas */
    grid-auto-rows: 100px;
    grid-auto-columns: 1fr;
    
    /* Dirección de auto-placement */
    grid-auto-flow: row | column | row dense | column dense;
}
```

* Auto-fit and auto-fill: 

```css
/* Auto-fit: collapse empty tracks */
.auto-fit {
    grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
}

/* Auto-fill: maintain empty tracks */
.auto-fill {
    grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
}
```

### Responsive patterns


```css
/* Patrón: Sidebar colapsable */
.sidebar-layout {
    display: grid;
    grid-template-columns: minmax(0, 1fr);
    grid-template-areas: "main";
}

@media (min-width: 768px) {
    .sidebar-layout {
        grid-template-columns: 250px 1fr;
        grid-template-areas: "sidebar main";
    }
}

/* Patrón: Header sticky */
.sticky-header {
    display: grid;
    grid-template-rows: auto 1fr;
    height: 100vh;
}

.header {
    position: sticky;
    top: 0;
    z-index: 100;
}
```