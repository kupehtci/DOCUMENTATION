#AWS 

# AWS - AppFlow

**AppFlow** is a fully managed integration service to securely transfer data between AWS and SaaA [^1] Applications like: 
* Salesforce
* Slack
* ServiceNow
* Zendesk
* SAP
* Google Analytics
* Amazon S3. 

It doesn't require to write custom code for the data integration. 

You need to define a destination (Where the extracted data go) like: 
* Amazon S3
* Redshift
* Snowflake

And optional transformations like filtering, mappings or validations that can be done over the data transfer. 

Also define a trigger type, when the flow will run: 
* **On-demand**: manual trigger
* **Scheduled**: hour or daily
* **Event-Based**: Like triggered with an update in the SaaS software.




[^1]: Software As A Service or SaaS [[IaaS PaaS and SaaS]]