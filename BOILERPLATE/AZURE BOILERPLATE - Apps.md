#AZURE #AKS 

The apps are deployed to the Kubernetes cluster using Helm provider of terraform. 

Deploys the application from a remote helm charts repository by selecting the version and overwrite values in the default `values.yaml` provided in the repository, through the yaml file in the terraform repository. 

### 1. NGINX Configuration

Nginx by default is configured to listen and control all the ingresses that include the alias `ingressClassName:nginx`. 

Its configured to act as Load Balancer. This can be set to "LoadBalancer", "NodePort" or "ClusterIP" in `service.type`. 

To use an specified IP, can be set in `service.loadBalancerIP:"XXX.XXX.XXX.XXX"`, by default te Load Balancer will automatically deploy a Public IP resource depending on the provider and use this IP as Load Balancer entry point. 

NGINX **auto-scaling** can be enabled by setting `autoscaling.enabled: true` and configuring the autoscaler with `autoscaling.minReplicas`, `autoscaling.maxReplicas` and resources targets: 

```yaml
autoscaling:
  enabled: false
  minReplicas: ""
  maxReplicas: ""
  targetCPU: ""
  targetMemory: ""
```

By default **network policy** is enabled. This default policy allows external access to the pods and egress access to the same ones. 

The update strategy for the deployment of NGINX is Rolling. This can be modified in `updateStrategy.type` 

The default values are in: [nginx 18.1.10 · bitnami/bitnami (artifacthub.io)](https://artifacthub.io/packages/helm/bitnami/nginx?modal=values)


### 2. ArgoCD configuration

There are different ArgoCD deploy properties that can be adjusted: 

The ArgoCD `server` is the main dashboard service that can be configured. By default, its `autoscaling` is not enabled. 

To configure ArgoCD ingress through NGINX service: 

```yaml
global:
  domain: argocd.example.com

certificate:
  enabled: true

server:
  ingress:
    enabled: true
    ingressClassName: nginx
    annotations:
      nginx.ingress.kubernetes.io/force-ssl-redirect: "true"
      nginx.ingress.kubernetes.io/ssl-passthrough: "true"
    tls: true
```

For configuring the ingress without NGINX checkout documentation about AKS / AWS / GKE Load Balancing ingress in [argo-cd 7.4.5 · argoproj/argo (artifacthub.io)](https://artifacthub.io/packages/helm/argo/argo-cd)  

ArgoCD's Custom Resource Definitions (CRD) are installed via terraform kubernetes provider before deploying ArgoCD chart. This avoid possible versioned error 

#### 2.1. ArgoCD Prometheus

To enable or disable the ArgoCD metrics `enabled: true` and also enable/disable `serviceMonitor`: 

```YAML
  metrics:
    enabled: false
    service:
      annotations: {}
      labels: {}
      servicePort: 8082
      
    serviceMonitor:
      enabled: false
    #   selector:
    #     prometheus: kube-prometheus
    #   namespace: monitoring
    #   additionalLabels: {}
```

Las reglas de las diferentes alertas que puede lanzar y su formato se puede configurar en la seccion de `metrics.rules`

### 3. Prometheus and Grafana 

By default, prometheus and grafana needs a ServiceAccount for the server in order to have permissions over the monitoring within the cluster. Leave the ServiceAccount creation by default, instead you want to create one and configure it with limited permissions. 

By default, prometheus monitor all namespaces and this can need to be disabled in case you want to run without Cluster-admin privileges. In case of restrict the namespaces to monitor to certain ones: 

```yaml
server: 
	releaseNamespace: true
	namespaces:
		- namespace1
		- namespace2
		...
```

The prometheus ingress is disabled in order to use NGINX ingress controller. 
In case of disable NGINX, define hostnames. 

For configuring the **data retention** can be restricted by time span to retain this data (default 15 days) or define a maximum size of data to hold: 

```yaml
server: 
  retention: "15d"     # Max timespan for data retention
  retentionSize: ""    # Max data size for retention
```

Retention size must be in string format with the following unit:  B, KB, MB, GB, TB, PB, EB.


### 4. Velero

Velero needs various roles assigned in order to have access to different resources needed to make the backups and restores of the cluster and make and store snapshots depending on the provider. 

The authentication within the cluster that is needed is automatically created through the Helm deployment with a `ClusterRole` resource that has "get" permissions to almost all resources. 

Velero have two main Velero's Custom Resources, BackupStorageLocation[^bsl] and VolumeSnapshotLocation[^vsl]

##### 4.1. Velero AKS roles

The authentication and permissions to the elements in the Azure provider, needs to be granted in order to have permissions over the Storage Account, blob container to store the backups, disk backups reader and writer, snapshots contribution and disk restoration permissions. 

This roles are created and assigned to a **service principal** assigned to it.


### 5. Cert Manager

Cert manager is not pre-configured by default. It need to be configured on demand depending on the project. 

All of the most relevant configuration parameters are left in the values.yaml that is used in the Cert Manager helm deployment in the terraform project. 

In case of using Cert manager, remember to set an appropriate domain name and set it in an Azure Domain Zone and set an NS record in the domain register pointing to this domain authoritative server. 

To set the Cert Manager configuration to use the NGINX ingress controller, you can take a look to the tutorial: [Securing NGINX-ingress - cert-manager Documentation](https://cert-manager.io/docs/tutorials/acme/nginx-ingress/) and for a basic installation without the NGINX, look at the appropriate tutorial for deploying Cert manager to a cluster within the correct provider: \[AKS, EKS or GKE\] [cert-manager - cert-manager Documentation](https://cert-manager.io/docs/). 

For configuring TLS for prometheus ingress, un comment  `tls-acme` annotation in prometheus for Certificate issue the external URL exposed for Prometheus monitoring: 

```yaml
  annotations: {
      kubernetes.io/ingress.class: nginx
    #   kubernetes.io/tls-acme: 'true'      #TODO: Enable for cert manager
    }
```

And define: 

```yaml
  tls: 
       - secretName: prometheus-server-tls
         hosts:
           - prometheus.mydomain.com
```

```yaml
   ## Additional Prometheus server hostPath mounts
  extraHostPathMounts:
    - name: certs-dir
      mountPath: /etc/kubernetes/certs
      subPath: ""
      hostPath: /etc/kubernetes/certs
      readOnly: true

  extraConfigmapMounts:
    - name: certs-configmap
      mountPath: /prometheus
      subPath: ""
      configMap: certs-configmap
      readOnly: true

```

The rest of the configuration depends on the type of Certificate validation methodology that is going to be used and the CA Entity that validated the certificates. 
This should be configured depending on the project. 

[^bsl]: BackupStorageLocation Velero's CRD [[VELERO - BackupStorageLocation]]
[^vsl]: VolumeSnapshotLocation Velero's CRD [[VELERO - VolumeSnapshotLocation]]

