#AWS 

# Lambda 

AWS Lambda is a serverless compute service that lets you run code without thinking in the servers. 

Serverless computing lets abstract the infrastructure in the cloud from the code that its executed. 

### Use cases

Lambda is commonly used for scenarios where the application need to scale up rapidly and scale down to zero when there is no demand. 

This can be used for example for: 

* <span style="color:DodgerBlue;">file processing</span>: use an Amazon S3[^s3] that triggers a lambda data processing after each upload. 
* <span style="color:DodgerBlue;">Stream processing</span>: using lambda and Amazon Kinesis, it can process real-time streaming data for application activity tracking, transaction order processing, log filtering, social media analysis, telemetry. 
* <span style="color:DodgerBlue;">Web applications</span>: Combined with other AWS services to build highly scalable web applications. 
* <span style="color:DodgerBlue;">IoT backends</span> build serverless backends to handle web, mobile, IoT and third parties API requests.
* <span style="color:DodgerBlue;">Mobile backends</span>: build backends with Lambda and API gateway to authenticate and process API requests and integrate with iOS, Android, Web and react using AWS Amplify[^amp]

You only pay for the compute time that its used. 


[^s3]: Amazon Simple Storage Service or S3 [[AWS - S3]]
[^amp]: Amazon Web Services Amplify service [[AWS - Amplify]]