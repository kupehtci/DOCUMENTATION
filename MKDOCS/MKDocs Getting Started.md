
# MKDocs Getting Started

To install MKDocs, python3 needs to be installed as it is a binary built over python. 

Then: 

```bash
pipx install mkdocs
```

To create a new project: 
```bash
mkdocs new {project_name}
# Go to the folder created
cd {project_name}
```

Dentro del cual estara una estructura basica: 

* mkdocs.yml: configuration file
* docs/: directory for the markdown files


The configuration file will look like: 
```yml
site_name: {Project name}
theme: readthedocs  # Select the theme
nav:         # Files included in the project
  - Inicio: index.md
  - Acerca: about.md
```

### Install and configure PDF generation

Pipx install the packages isolateled in the different applications. For installing `mkdocs-with-pdf`plugin you need to execute: 

```bash
pipx inject mkdocs mkdocs-with-pdf
```

This ensures the plugin is installed in the same environment as MkDocs.

```bash
pipx install mkdocs-pdf-export-plugin --include-deps 
```




- Swagger --> PDF --> distribuir (sharepoint, unidad de red...)
- PDF markdown --> distribuir (sharepoint, unidad de red...)