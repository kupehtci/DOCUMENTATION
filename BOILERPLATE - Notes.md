
### Activar metricas de argocd en prometheus

Para activar las metricas de argocd en prometheus, en la seccion de `metrics` activarlas: `enabled: true` y activar tambien `serviceMonitor`: 

```YAML
  metrics:
    enabled: false
    service:
      annotations: {}
      labels: {}
      servicePort: 8082

    # TODO: Enable service monitor to sync with prometheus
    serviceMonitor:
      enabled: false
    #   selector:
    #     prometheus: kube-prometheus
    #   namespace: monitoring
    #   additionalLabels: {}
```

Las reglas de las diferentes alertas que puede lanzar y su formato se puede configurar en la seccion de `metrics.rules`