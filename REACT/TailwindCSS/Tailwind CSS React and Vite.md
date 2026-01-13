# Tailwind CSS, React and Vite

To implement Tailwind CSS in a React + Vite project, you need to add the Tailwind CSS as a npm package and install it as a Vite Plugin.  
Also, the generates styles need to be imported in the React entry. 

Guide to install Tailwind CSS: 

1. Create the application if its a new one: 
```bash
npm create vite@latest {APP-NAME}
cd {APP-NAME}
npm install
```

2. Install Tailwind with Vite plugin: 
	* Tailwind is a Dev dependency, as is required to generate the final bundle of the application but not needed in application runtime. 
```bash
npm install -D tailwindcss @tailwindcss/vite
```

3. Edit the `vite.config.ts` (Or `.js`) to register the Tailwind CSS. plugin along with the react one: 
```ts
// vite.config.ts
// Other configs
import tailwindcss from "@tailwindcss/vite";

// Add here the tailwindcss()
export default defineConfig({
  plugins: [react(), tailwindcss()],
});
```

4. Add the tailwind layer directives into the main CSS file (Commonly `src/index.css` or `src/main.css`): 
```ts
@import "tailwindcss/base";
@import "tailwindcss/components";
@import "tailwindcss/utilities";
```

5. Make sure that this edited CSS file is added into the React main entry file (Commonly `src/main.tsx`)

```ts
import "./index.css"; // Import the file with the directives

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
```

6. Verify that Tailwind CSS is working properly, by adding Tailwind's classes into the App or other component. As an example: 

```ts
function App() {
  return (
    <div className="min-h-screen flex items-center justify-center bg-slate-900">
      <h1 className="text-4xl font-bold text-emerald-400">
        Tailwind + React + Vite working
      </h1>
    </div>
  );
}
```

You should see the component or the App styled with a dark background and the `<h1>` with style. 