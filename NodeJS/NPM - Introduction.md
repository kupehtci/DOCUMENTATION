#NPM #NodeJS 

# NPM Introduction

NPM is a package manager for Node.js. 

It allows to easily install, update, maintain and manage software packages used in NodeJS projects. 


NPM has a vast repository of open-source packages that can be used your NodeJS projects. 

It can be used via the NOM command line interface using the `npm` command. 

You can: 

* search for packages
* install packages with `npm install` or `yarn install` to install the tracked packaged in the project
* manage dependencies using `package.json`. 
* update dependencies using `npm update` or `yarn upgrade`. 

### Basic cheat note

To initialize the project: 

```bash
npm init -y
```

This generates a `package.json` for managing the dependencies and the project metadata. 

To install the dependencies of the `package.json` you can run: 

```bash
npm install 
# or 
yarn add
```

And run the code with: 

```bash
npm start
# or
yarn start
```


