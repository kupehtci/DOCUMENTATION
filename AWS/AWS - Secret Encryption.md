#AWS 

# AWS Secret Encryption

Secret Encryption in an application is when you need to encrypt application secrets like API keys, database passwords, tokens or others. 

AWS gives various ways of secure this approach: 

## AWS Secrets Manager

Secret is stored in **AWS Secrets Manager**, that is automatically encrypted at rest using a **KMS CMK** (AWS-Managed or Customer-managed). 

The application can retrieve the secret securely at runtime through an API Call (`GetSecretValue`) and KMS will handle the decryption transparently. 

You need: 
* A KMS Key. 
* An IAM Policy attached to the resource that is running the workload of the application with permissions for: 
	* `secretsmanager:GetSecretValue` for that specific secret. 
	* `kms:Decrypt`for the associated KMS Key. 

Example IAM policy: 

```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": [
        "secretsmanager:GetSecretValue"
      ],
      "Resource": "arn:aws:secretsmanager:us-east-1:123456789012:secret:MySecret-*"
    },
    {
      "Effect": "Allow",
      "Action": [
        "kms:Decrypt"
      ],
      "Resource": "arn:aws:kms:us-east-1:123456789012:key/abcd-1234-efgh-5678"
    }
  ]
}
```

### SSM Parameter Store

You can also store the secret under **SSM Parameter Store** as a `SecureString`type. 
KMS encrypts the secret at-rest and the application calls the SSM API to retrieve it securely.

You need: 
* A KMS CMK
* An IAM Policy that allows: 
	* `ssm:GetParameter` for that parameter. 
	* `kms:Decrypt` for the CMK used. 

This is a **lower cost alternative** to Secrets Manager but lacks automatic rotation of keys. 


