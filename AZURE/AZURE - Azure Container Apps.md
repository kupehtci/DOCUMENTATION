#AZURE 
## Azure Container Apps

Azure container apps is a server-less platform for running containerized applications without managing the underlying infrastructure. 

Automatically managed the compute layer needed to keep the application running.

Its equivalent in <span style="color:orange;">AWS</span> Cloud its the AWS App Runner (With AWS Fargate). 

Its main features are: 
* Serverless execution
* Automatic scaling: scaled based on the HTTP traffic, Memory or CPU Load, event-driven processing or any KEDA supported scaler. 
* Scale to zero: the application can scale down to 0 instance when its not in use. 

Its usually used for: 
* Microservices
* APIs and Web Endpoints. 
* Background Jobs
* Event-driven processing

### Analytics

Azure Container Apps are integrated with <span style="color:DodgerBlue;">Azure Monitor Log Analytics</span> in order to monitor and analyze the container app's logs. 

This log entries can be accessed via Log Analytics Table (Azure Portal) or in the Azure CLI. 


