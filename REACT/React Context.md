#REACT 

# React Context

**React Context** is a feature of React that allows to manage an global state of the application. 
It allows to make a component to share data to any nested component without implicitly passing the data as `props` to each children element (prop drilling). 

Its normally used in "global" concerns like the current theme, the authenticated user so each component has the same information. 

In order to create and use the context in React you need to: 

1. Create a react context object using `createContext` call that defines like a channel for the shared data. 
2. Set the value of the context at somewhere in the DOM tree in the nested elements of the parent element that created the context. 
3. Any descendant component can consume the context using `useContext` hook [^1] 




[^1]: `useContext` hook allows to interact with the state and other react functions without using React classes [[React - Hooks]]

