#REACT 

%%TODO%%


## Reusability

You can make a button more "reusable" by making the function that is called when clicked passed as an argument as well as the children of the component: 

```tsx
function Button({children, handleClick}){
	return <button type="button" onCLick={handleClick}>
		{children}
	</button>
}
```

So as the `<Button />` react component has children and the function passed as arguments you can use it just like: 

```tsx
import "Button.tsx"

function App() {
	return (
		<Button onClick={() => console.log("Has been clicked")}
			Click on me
		</Button>	
	); 
}
```

## Props

Also, using the built-in button attribute props allows to pass all the `<button>` props like `type`, `disabled`, `onClick` directly: 

```tsx
type ButtonProps = React.ButtonHTMLAttributes<HTMLButtonElement>;

const Button: React.FC<ButtonProps> = (props) => (
  <button {...props} />
);
```