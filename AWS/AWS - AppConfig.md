#AWS 

# AWS - AppConfig

**AWS AppConfig** is a fully managed service that allows to deploy application configuration changes safely and quickly. 

AppConfig allows to manage and deliver configuration settings for your applications without redeploying the code. 

Its part of **AWS Systems Manager**. 

The key characteristics of this resource are: 

* **Centralized configuration management**: store feature flags, environmental variables, database endpoints or any application parameter. 

### How to use AppConfig

In order to create an AppConfig's configuration profile you need to: 
1. Create an application in AppConfig.
2. Create **Environments** for the application.
3. Create a **configuration profile** with the settings that you want the app to consume. 

Optionally define a **deployment strategy** to control rollout. 

1. Deploy the Configuration to the chosen environment

The application can integrate the AppConfig via the AppConfig API or the AWS SDK: 

example: 
```python
import boto3

client = boto3.client('appconfigdata')

# Start a configuration session
response = client.start_configuration_session(
    ApplicationIdentifier='MyWebApp',
    EnvironmentIdentifier='prod',
    ConfigurationProfileIdentifier='MyConfigProfile'
)
session_token = response['InitialConfigurationToken']

# Retrieve configuration
config_response = client.get_latest_configuration(
    ConfigurationToken=session_token
)
config_data = config_response['Configuration'].read()
print(config_data.decode('utf-8'))
```

### Rollout

AWS App Config can be gradually rollout to users and rollback if needed to previous configuration states. 