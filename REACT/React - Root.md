#REACT 

# React - Root

The **root** is the DOM node where react starts rendering the component tree. 

A typical react app created using Create React App (CRA) the `index.html` contains a `<div>` element with `id='root'`. 

React attaches to that element and manipulate the child elements directly in javascript. 

```html
<!-- .... -->
<body>  
  <div id="root"></div>  
  <script type="module" src="/src/main.tsx"></script>  
</body>
```

And the `main.tsx` automatically tells to render into that element the `<App />` react component: 

```ts
// main.tsx
createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
  </StrictMode>,
)
```

