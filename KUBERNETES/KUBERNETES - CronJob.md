#AKS #KUBERNETES 


### KUBERNETES - CronJob


A CronJob create a Job on a repeated schedule. Is meant to perform regular actions such as backups, generate reports and similar.  

Is the same as Linux crontab file in the Unix system, so needs to be defined in Cron format.

The control plane [^1] creates new Jobs and Pods to hold them, with the `.metadata.name` being a valid DNS name. 


[^1]: Kubernetes Control plane description [[KUBERNETES - Basics]] 