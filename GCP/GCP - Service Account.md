#GCP #CLOUD 

# GCP - Service Account

A service account in GCP is an special type of account used by an application or a compute workload like an Compute Engine Instance and not a user. 

This service account its identified by its email address uniquely for the account.

This is the most common way to let an application authenticate as a Service Account by attaching it to the resource running the application, like linking the Service Account to the Google Compute VM Instance.

### Service Account credentials

Like a Google Cloud Principal[^1] you can authenticate to an Service Account using OAuth 2.0 access token to call Google APIs but this works different for Service Account than for common IAM principal objects. 

You can authenticate by using: 
* short live service account credentials
* service account key assigned to a JWT

##### Short-lived service account credentials

By default this tokens expire after 1 hour. 

##### Service Account key and assign to JSON Web Token (JWT)




[^1]: Google Cloud principal is an IAM resource that represents the **who** that can be assigned to an IAM role[[GCP - IAM Identity and Access Management]]