#LINUX 

# CP (Copy) Diferences using recursive

There are some differencies when copying files and folders using the `cp` command: 
As its not the same: 
* `cp -rv customTheme/* folder/` using the `*` 
* `cp -rv customTheme/ folder/` using only the folder as arguments
* `cp -rv customTheme/ folder/customTheme` using the source folder as destination


---

### 1. `cp -rv soource/* destination/`

- The  `*` expands to all files within the `source`**, but **not the folder itself**.
    
- Result: All the content within`customTheme`gets copied directly into `destination/`.
```
Example: 
source/  
├── a.txt  
└── subdir/

After executing:

destination/  
├── a.txt  
└── subdir/
```
---

### 2. `cp -rv customTheme/ folder/`

- With this arguments, the whole folder `source` gets whole copied, included its directory name
- Result: in `destination/` appears a new folder called `source` that contains all the contents of the source folder indicated in the command. 
```
Example: 
folder/  
└── customTheme/       
	├── a.txt       
	└── subdir/`
```
---

### 3. `cp -rv source/ destination/source`

- Aquí le indicas explícitamente que el destino debe llamarse también `customTheme`.
    
- Si **`folder/customTheme` no existe**, se creará y el contenido de `customTheme` se copiará dentro.
    
- Si **ya existe**, entonces se copiará la carpeta `customTheme` dentro de esa `folder/customTheme` → quedaría `folder/customTheme/customTheme/`.
    

Ejemplo (si `folder/customTheme/` ya existía):

`folder/  └── customTheme/       └── customTheme/            ├── a.txt            └── subdir/`

---

👉 En resumen:

- `customTheme/*` → copia solo el contenido.
    
- `customTheme/` → copia la carpeta entera.
    
- `customTheme/ folder/customTheme` → puede duplicar la carpeta dependiendo de si ya existe el destino.