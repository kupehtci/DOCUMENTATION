#AWS 

# AWS Amplify

AWS Amplify allows to develop and deploy cloud powered mobile and web applications. 

This service provides front-end libraries, UI components and backend for building fullstack applications for AWS. 

With <span style="color:orange;">Amplify hosting</span> you are allowed to do continuous delivery and hosting a service for this applications within the Cloud. 

You can link amplify to a local / remote repository and do CD with it to the AWS infrastructure. 

This means that you can build an application that will be granted with this services: 

* Authentication: with services like Amazon Cognito. 
	* You can also easily manage user roles and permissions using Amazon IAM[^iam]. 
* Backend usage: by using REST and GraphQL apis you can connect to the backend services, integrate with databases, lambda functions
* Storage: by using easy cloud access using Amazon S3[^s3]
* Push notifications for mobile apps though Amazon Pinpoint


[^iam]: IAM roles of amazon [[AWS - IAM]]
[^s3]: Simply Storage Service of Amazon [[AWS - S3]]
[^pin] Amazon pinpoint [[AWS - PinPoint]]