#REACT 

# React

React is a JavaScript / TypeScript library for building dynamic user interfaces for web applications focused on creating **reusable** components that update individually as data changes. 

React allows to build the UI as a tree of components (DOM [[JS - DOM elements Basics]]) with each one managing their own state and rendering JSX content (Similar to HTML) based on its state. 

Its used for: 
* SPA (Single Page Applications) Applications where the page updates dynamically without full reloads. 
* Component based architecture where UI is splited into small pieces that are updated and tracked independently. 

It uses a **declarative** format, where you define the UI elements and the changes depending on the state and React updates the DOM accordingly. 

# Create a React application

For creating a React application with TypeScript language and Vite as project scaffolder (The most recommended): 

Using vite: 
```bash
npm create vite@latest
````

And then select: React -> TypeScript / TypeScript + React Compiler / TypeScript + SWC ->

Using React's Create React app: 
```bash
npx create-react-app {name}
```

* **name** for the application and cannot contain capital letters. 
* 

