#ATLANTIS #TERRAFORM 


The basic behavior of atlantis is receiving webhooks from a Git host and execute Terraform commands locally. 

In order to work, a route is needed to communicate between the Git client and the Atlantis. In order to do this, its recommended to expose the atlantis to an independent public IP or one within the managed DNS zone in order to set the Git Repository webhook properly. 


Atlantis has no external database, stores the plan files on disk, so needs a persistent disk provisioned for it. 


### AZ CLI

In order to execute azure login

