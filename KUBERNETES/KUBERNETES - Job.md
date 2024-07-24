#KUBERNETES 

## <span style="color:DodgerBlue;">KUBERNETES</span> - Job

A Job in Kubernetes is a component that creates one or more Pods[^1] in order to complete a certain defined task. 

It will continue to retry the execution of the Pods until get an specified number of completed executions. 

Its also defined though a manifest: 

```yaml
apiVersion: batch/v1
kind: Job
metadata:
  name: pi
spec:
  template:
    spec:
      containers:
      - name: pi
        image: perl:5.34.0
        command: ["perl",  "-Mbignum=bpi", "-wle", "print bpi(2000)"]
      restartPolicy: Never
  backoffLimit: 4
```


it has some required components: 

* `spec.template` requires a **pod** template following the same schema as  pod[^1] without `kind` or `apiVersion`. 
* `restartPolicy` equals to `Never` or `OnFailure`. This sets if the pod restarts itself or not. 

If want to change the completion count of executions


[^1] Kubernetes pod component [[KUBERNETES - Pods]]

