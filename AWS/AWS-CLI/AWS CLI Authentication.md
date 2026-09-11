#AWS 

# AWS CLI Authentication

In order to authenticate, AWS provides multiple credential configuration with different files in local that define the authentication method and credentials: 

* `~/.aws/credentials` file stores the credentials using the format: 

```ini
[default]
aws_access_key_id = AKIAIOSFODNN7EXAMPLE 
aws_secret_access_key = wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY

[user1]
aws_access_key_id = AKIAIOSFODNN7EXAMPLE
aws_secret_access_key = wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY
aws_session_token = IQoJb3JpZ2luX2VjEH8aCXVzLXdlc3QtMiJIMEYC...
```

Each one of the `[******]` define a profile with the credentials under it. 

* `~/.aws/config` file stores the configuration settings and the SSO profiles used to login into AWS: 

```ini
[default]
region = us-west-2
output = json

[profile user1]
region = eu-west-1
output = json
```

In this file, the default and other profiles are settled with its configuration. 
Other profiles different from the `default` require the `profile` keyword. 

Each SSO profile allows to define the following properties: 
* `sso_start_url`: initial entry point URL for the organization IAM Identity center (AWS SSO Portal). Where users authenticate through the identity provider. 
* `sso_region`: AWS region where the IAM identity center is hosted. Its independent from where the resources are placed. 
* `sso_account_id`: 12 digit AWS Account ID you want to access. 
* `sso_role_name`: name of the IAM Role [[AWS - IAM Roles]] to assume in the target account. 
* `output` format of the AWS CLI command output, available `json`, `yaml`, `yaml-stream`, `text` or `table`. 
* `sso_session`: references a `[sso-session]` block defined in the config file for modern SSO Configuration. 

## Modern SSO Configuration

Modern SSO configuration allows multiple references to the same SSO session: 

```ini
[profile my-new-profile]
sso_session = myorg
sso_account_id = 123456789012
sso_role_name = AdministratorAccess

[sso-session myorg]
sso_start_url = https://myorg.awsapps.com/start
sso_region = us-east-1
sso_registration_scopes = sso:account:access
```
