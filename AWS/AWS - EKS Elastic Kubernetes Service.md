#AWS

# AWS EKS 

AWS EKS or Elastic Kubernetes Service is a managed service that run, control and managed a Kubernetes cluster on AWS. 

Runs this kubernetes[^1] applications without the need to install or manage the kubernetes control plane. 

---

# VPC CNI Plugin

This EKS plugin allows to do custom networking ENIConfig to assign Pod IPs from specified subnets and apply appropriate security groups so Pods can communicate securely within an VPC. 

If set, Pods will recieve IPs from custom subnets defined with ENIConfig resources within the Kubernetes cluster. 

---





[^1]:  Kubernetes automates the management, scaling, deployment and configuration of containerized applications and its interoperability [[KUBERNETES - Basics]]
