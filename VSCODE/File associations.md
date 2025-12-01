#VSCODE

# VSCode File associations

A file association in Visual Studio Code defines how the editor matches certain file extensions or patterns to a programming language so it controls: 
* Syntax highlighting
* Snippets
* Linters
* Other language specific features


In defaultSettings.json: 
```json
// Files
// Configure [glob patterns](https://aka.ms/vscode-glob-patterns) of file associations to languages (for example `"*.extension": "html"`). Patterns will match on the absolute path of a file if they contain a path separator and will match on the name of the file otherwise. These have precedence over the default associations of the languages installed.
"files.associations": {},
// ...
```

You can add associations, by adding in the `settings.json` file: 
```json
"files.associations": { 
	"web.config": "xml",
	"file-name": "language-association"
}
```

Using the format: `"pattern" : "language-type"`. 

