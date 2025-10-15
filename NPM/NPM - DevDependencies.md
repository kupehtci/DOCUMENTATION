
The `devDependencies` are dependencies that are only available in local or development environment and won't be included in the compiled versions of the application. 

They are defined in the `package.json` file like this: 

```json
{
  "devDependencies": {
    "jest": "^29.0.0",
    "eslint": "^8.0.0",
    "typescript": "^4.8.0"
  }
}
```

And can be installed with the `-D` flag in the install command: 

```bash
# Install a single dev dependency
npm install --save-dev package-name
# or the short form
npm install -D package-name
# Install multiple dev dependencies
npm install --save-dev jest eslint prettier
```