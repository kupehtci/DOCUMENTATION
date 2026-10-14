#Linux #RHEL #RedHat

- RHEL is not sold as a perpetual license; it is sold as an **annual subscription**.
- A subscription includes access to RHEL binaries, updates, patches, certified repositories, and support depending on the tier.

Subscription type depends on the deployment model:
* Physical server
* Virtual machine
* Cloud instance
* Developer workstation
* Enterprise agreement

## Support tiers

|Tier|Typical use|Support included|
|---|---|---|
|**Self-Support**|Labs, testing, non-critical systems|No Red Hat technical support; updates and Customer Portal access only.|
|**Standard**|General production servers|Business-hours web and phone support; unlimited cases.|
|**Premium**|Mission-critical systems|24x7 support for severity 1 and 2; business-hours support for severity 3 and 4.|
## Physical server licensing

RHEL Server subscriptions are commonly counted by **socket-pair** [^1]. 
A **socket-pair** covers up to **two occupied CPU sockets** on one physical server.

| Physical server | Occupied sockets | RHEL Server subscriptions |
| --------------- | ---------------- | ------------------------- |
| 1 CPU           | 1                | 1 socket-pair             |
| 2 CPUs          | 2                | 1 socket-pair             |
| 4 CPUs          | 4                | 2 socket-pairs            |
| 8 CPUs          | 8                | 4 socket-pairs            |

## Hypervisor-based model

Use **RHEL for Virtual Datacenters (VDC)** that is licensed by the **socket-pair of the physical hypervisor host**.

It allows an **unlimited number of RHEL guests** on supported hypervisors, such as VMware, Hyper-V, and OpenShift Virtualization.    

|Physical hypervisor|Occupied sockets|VDC subscriptions|RHEL guests covered|
|---|---|---|---|
|2 CPUs|2|1|Unlimited|
|4 CPUs|4|2|Unlimited|
|8 CPUs|8|4|Unlimited|

- VDC covers the RHEL guest VMs, not the hypervisor operating system itself.
    
- In Red Hat Satellite environments, VDC subscriptions are attached to the hypervisor and inherited by guests; `virt-who` is used to report host-guest associations.

## Choosing between per-VM and VDC

|Scenario|Recommended model|
|---|---|
|1–4 RHEL VMs|Per-VM RHEL Server subscriptions|
|5–10 RHEL VMs|Compare per-VM cost versus VDC host sockets|
|Many RHEL VMs on few hypervisors|RHEL for Virtual Datacenters|
|Few VMs across many hosts|Per-VM RHEL Server subscriptions|

## Cloud licensing

Two common options:

- **Pay-as-you-go**: RHEL cost is included in the cloud provider’s hourly instance price.
- **BYOS / Cloud Access**: use existing eligible Red Hat subscriptions on certified public clouds such as Azure, AWS, or GCP. You pay Red Hat for the subscription and the cloud provider for infrastructure.


## Enterprise agreements

- Larger organizations can purchase through a **Red Hat Enterprise Agreement**.
- These agreements define commercial terms for Red Hat products and services and are commonly negotiated by volume, term, products, support level, and add-ons.
- Enterprise agreements are appropriate when many systems, products, or support tiers need centralized procurement and compliance management.

## Developer Servers

**RHEL for Business Developers**, allows up to 25 systems per registered developer.

This type of license allow a registered RHEL machine without active support from RedHat.


[^1]: A **socket** is the physical CPU socket on the motherboard; it is not a core or thread.