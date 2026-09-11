#NPM 

# NPM Registry

NPM registry is a public oficial database for Javascript and Typescript packages exposing both an online database (registry) that is accessed through the NPM CLI (Command Line Tool `npm`). 

When you run commands from the `npm` binary like `npm install`, the npm client retrieved the packaged information by default from this registry and requests the packages to install. 

The default registry URL is `https://registry.npmjs.org/`. 

<div style="border: 1px solid MediumPurple; color: black; border-radius: 1rem; padding: 0.5rem; ">
<p>Warning: NPM registry has no restriction in the submissions, so packages can vary in quality and also in <b>security</b>.</p>
</div>

## Private Registries

With a registered account in NPM, you can configure custom private registries within this public npm registry, useful for sharing own packages. 

## API 

NPM registry exposes an API, for automated consulting of packages.

The registry exposes the following endpoints: 

* `https://registry.npmjs.org/{package}`: (GET) allows to retrieve information about a certain package, indicating its name. Retrieve ID, nam , versions, creation time, description, creators and the maintainers information: 
* `https://registry.npmjs.org/{package}/{version}`: (GET) get information about the package at a certain version. 
* `https://registry.npmjs.org//-/v1/search`: (GET) search for a package. Valid parameters: 
	* `text`: search string. 
	* `size`: the maximum number of results that should be returned. 
	* `from`: offset to return results from. 
	* `quality`: \[0-1\] how to order the results based in quality of the packages listed. 
	* `popularity`: \[0-1\] how to order the results based in how much is used a certain package. A high value of the weight indicates to list popular packages first. 
	* `maintenance`: \[0-1\] how to order the package depending on the maintenance history. A high value of the weight indicates to show well maintained packages up in the list. 