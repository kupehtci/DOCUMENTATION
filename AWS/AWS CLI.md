#AWS 

## AWS CLI

AWS CLI or command line interface is a powerful tool that allows users to interact with AWS directly with commands. 

Through it you can manage, control, deploy and configure AWS services through simple commands



### Configure the credentials

To configure the credentials to login into AWS: 

```bash
> aws configure
AWS Access Key ID [None]: xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
AWS Secret Access Key [None]: xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Default region name [None]: eu-north-1
Default output format [None]: json
```

### Use SSO

In order to use SSO to login to an defined `my-sso.awsapps.com/start#/` sso portal, you need to configure it properly: 

```bash
> aws configure sso
SSO session name (Recommended): <example>
SSO start URL [None]: <https://my-sso-portal.awsapps.com/start>
SSO region [None]: us-east-1
SSO registration scopes [None]: sso:account:access
```


### Use a profile as default

To change which profile to use as default, you can set it as default profile: 

```bash
# In AWS cli v1
export AWS_DEFAULT_PROFILE=<profile_name>

# In AWS cli v2
export AWS_PROFILE=<profile_name>
```