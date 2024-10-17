#AKS #KUBERNETES 


### KUBERNETES - CronJob


A CronJob create a Job[^2] on a repeated schedule. Is meant to perform regular actions such as backups, generate reports and similar.  

Is the same as Linux crontab file in the Unix system, so needs to be defined in Cron format.

The control plane [^1] creates new Jobs and Pods to hold them, with the `.metadata.name` being a valid DNS name. 

### Manifest 

The format of the CronJob defines its schedule and the template of the Job that its created following that schedule: 
```yaml
apiVersion: batch/v1
kind: CronJob
metadata:
  name: <cronjob-name>
spec:
  schedule: "0 0 * * *" # Define schedule
  jobTemplate:
    spec:
	    #...
```

[^1]: Kubernetes Control plane description [[KUBERNETES - Basics]] 
[^2]: Kubernetes Job resource that creates and maintain enough pods to perform an certain actions and destroy it when finished. [[KUBERNETES - Job]]