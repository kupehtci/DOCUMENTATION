#KUBERNETES 

### HELM

Helm is the package manager for Kubernetes. 

Help manages Kubernetes resources packages through Charts, which are the collection of files organized in a directory structure. 

This <span style="color:orange;">chars</span> files can be archived through repositories and shared. 

### Create a new Chart

To create a new Helm chart: 

```bash
helm create <name>   #example helm create hello-world
```

The \<name\> must be a valid directory name- 

It will create a directory structure as follows: 

```txt
hello-world/ 
	Chart.yaml 
	values.yaml 
	templates/ 
	charts/ 
	.helmignore
```

`Chart.yaml` is the main file that contains the description of the Chart
`values.yaml` contains the default values for the chart. This values will be replaced in the main chart when filling the template with `helm template <dir>`. 
Inside `templates/` there are a few templates for common Kubernetes resources.


### Lint

We can lint the templates in order to run a series of test to check that the chart is correctly defined. 

For doing the linting, use `helm lint <dir>`. `<dir>` directory of the charts declared.  

This will shows a list of the linting and some failures that may encounter.

### Install 

Once we have verified that the helm chart works correctly, we can run the `helm install` command into the cluster: 
```bash
helm install --name <name> /<dir>

# example

helm install --name hello-world ./hello-world
```

### Get

To see the charts that are installed, we can list them: 
```bash
helm ls --all
```
### Take into account

* if using <span style="color:purple;">helm 2</span>, the package manager must be initialized with `helm init` through Helm CLI. 