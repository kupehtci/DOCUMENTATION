#KUBERNETES 

## <span style="color:DodgerBlue;">KUBERNETES</span> - Job

A Job in Kubernetes is a component that creates one or more Pods[^1] in order to complete a certain defined task. 

It will continue to retry the execution of the Pods until get an specified number of completed executions. 

Its also defined though a manifest: 

```yaml
apiVersion: batch/v1
kind: Job
metadata:
  name: job-name
  namespace: default 
  labels: 
	app: batch-job
spec:
  parallelism: 1 
  completions: 1
  backoffLimit: 4
  template:
	metadata: 
		name: example-job-pod
		labels: 
			app: batch-job
    spec:
      containers:
      - name: pi
        image: perl:5.34.0
        command: ["perl",  "-Mbignum=bpi", "-wle", "print bpi(2000)"]
      restartPolicy: Never
```


it has some required components: 

* `apiVersion` must be set to `batch/v1` for jobs. 
* `spec.template` requires a **pod** template following the same schema as  pod[^1] without `kind` or `apiVersion`. 
* `restartPolicy` equals to `Never` or `OnFailure`. This sets if the pod restarts itself or not. 

If want to change how the Job will work you need to set: 

* `parallelism` specify the number of pods that will run at the same time. 
* `completions` define the number of successful number of completions required for the Job to be completed. 
* `backoffLimit` specify the number of times the Job controller will retry the Job in case of failure. 


[^1] Kubernetes pod component [[KUBERNETES - Pods]]

