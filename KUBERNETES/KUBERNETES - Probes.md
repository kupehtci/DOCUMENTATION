#KUBERNETES 


Kubernetes probes are used in order to configure <span style="color:DodgerBlue;">health checks</span>. 

This probes are used to detect: 

* Containers that have not started yet and can not serve traffic
* Containers that are overwhelmed and can not server additional traffic
* Containers that are completely dead and not serving any traffic. 

Kubernetes has various types of probes: 

## <span style="color:#CFEE4E;">Readiness probe</span>

Determine when a container is ready to start accepting traffic. 

This is used to know when to waiting for an application to perform time consuming initial tasks, such as networks connections, load of files and caches. 

If readiness probe returns a failed state, kubernetes removes the pod from the service endpoints. 

## <span style="color:#CFEE4E;">Liveness probe</span>

Determine when to restart a container.
It catches a deadlock, when the application is running but unable to make a progress. 
If fails repeatedly, the kubelet restarts the container.

Liveness probe do not wait for readiness probes to succeed. If you need the liveness probe to wait you can define `initialDelaySeconds` or use a startup probe. 

## <span style="color:#CFEE4E;">Startup probe</span>


Verifies whether the container's application is started. This can starts the liveness checks on slow starting containers, avoiding them getting killed by the kubelet before they are up. 

It disables liveness and readiness checks until it success. 

Its only executed at startup. 

---

[^1]: [Liveness, Readiness, and Startup Probes | Kubernetes](https://kubernetes.io/docs/concepts/configuration/liveness-readiness-startup-probes/)