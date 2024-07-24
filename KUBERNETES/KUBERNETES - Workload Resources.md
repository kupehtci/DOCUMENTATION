#KUBERNETES 

## <span style="color:DodgerBlue;">KUBERNETES</span> - Workload Resources

The workload in kubernetes is the application running within the system, so workload resources are components that manages the sets of Pods during its lifecycle.

Because the application is running within the containers inside Pods, you don't need to control each pod independently. For doing this you can set a group of workload resources that control the entire set of pods: 

* `Deployment`[^1] and `ReplicaSet`[^2] are components to control a stateless application where each Pod can be easily exchanged
* `StatefulSet`[^3] is a component similar to deployment but keeps track of the state



[^1]: Deployment component in kubernetes: [[KUBERNETES - Deployment]]
[^2]: ReplicaSet component in kubernetes: [[KUBERNETES - ReplicaSets]]
[^3]: StatefulSet component in kubernetes: [[KUBERNETES - StatefulSet]]
[^4]: Jobs within kubernetes [[KUBERNETES - CronJob]]