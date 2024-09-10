#ArgoCD

# ArgoCD Application

ArgoCD uses a CRD application to register and define an application, source and kubernetes path destination to keep synced in the repository. 

The application can be created manually in the argocd service or define a manifest that follows this format: 

``` yaml
apiVersion: argoproj.io/v1alpha1
kind: Application
metadata:
  name: <application-name>
  namespace: <namespace-of-this-resource>
spec:
  project: default
  source:
    repoURL: https://repo.git.com/username/reponame
    targetRevision: HEAD
    path: /
  destination:
    server: https://kubernetes.default.svc
    namespace: <namespace-for-application>
```


And in a more complete way: 

```yaml
apiVersion: argoproj.io/v1alpha1
kind: Application
metadata:
  name: demo
  # You'll usually want to add your resources to the argocd namespace.
  namespace: argocd
  # Add a this finalizer ONLY if you want these to cascade delete.
  finalizers:
    - resources-finalizer.argocd.argoproj.io
spec:
  # The project the application belongs to.
  project: default

  # Source of the application manifests
  source:
    repoURL: https://github.com/codefresh-contrib/gitops-certification-examples.git
    targetRevision: HEAD
    path: ./declarative/manifests
   
    # directory
    directory:
      recurse: false
  # Destination cluster and namespace to deploy the application
  destination:
    server: https://kubernetes.default.svc
    namespace: default

  # Sync policy
  syncPolicy:
    automated: # automated sync by default retries failed attempts 5 times with following delays between attempts ( 5s, 10s, 20s, 40s, 80s ); retry controlled using `retry` field.
      prune: true # Specifies if resources should be pruned during auto-syncing ( false by default ).
      selfHeal: true # Specifies if partial app sync should be executed when resources are changed only in target Kubernetes cluster and no git change detected ( false by default ).
      allowEmpty: false # Allows deleting all application resources during automatic syncing ( false by default ).
  
```

Source: [Codefresh (github.com)](https://github.com/codefresh-contrib)