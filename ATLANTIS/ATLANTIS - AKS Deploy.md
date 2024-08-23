#AKS #ATLANTIS 


## ATLANTIS - AKS Deploy

Once the atlantis have been deployed to an Azure Container instance via CLI, manually or via terraform, needs some configuration to be done. 

In the AKS case, the ACI will have a IP Address or a dns label defined in the ACI. The atlantis service is listening in that fqdn in the port **4141**. 

If search that dns label or IP address on that port in a web browser you can see basic information about Atlantis runtime. 

Once we can access that IP / FQDN, we need to configure the repo that we have specify in the atlantis configuration in order to send webhooks to this atlantis direction. 

Atlantis listen to webhooks at: `<atlantis-fqdn>|<atlantis-ip>:4141/events`