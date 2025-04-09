#AWS 

# AWS Regions

### Availability Zones

An availability Zone is a single data center or a group of data centers within a region. 
Availability zones are isolated zones within a region. 

Each one is a set of Data Centers with redundant power, networking and connectivity within a region. 
They can be used to deploy resources redundant between them, so in case of an instance in an AZ fails, the other instance in the other AZ handles the requests. 


### Regions

Each region in a set of multiple isolated Availability Zones within a geographical area.
In each account you can have resources distributed in different regions and all of them are isolated from others. 
By default, you can only see the resources that you have over a single region that you specify in the console. 

You decide the region where you are going to deploy the resources taking into account the workloads and the latency to the end users. 


### Local Zones

AWS Local Zones can be used for highly demanding applications that requires miliseconds latency to the end-users. 
As an example can be used for: 

* Media and entertainment content creation
* Real-time multiplayer gaming
* Machine learning hosting and training
* Augmented reality and Virtual Reality

### Edge Locations

An edge location is the nearest point to a requester of an AWS Service. 
This locations are placed in major cities around the world that has no full capabilities of all the AWS Services but can be used for services like caching services or content for CDN or fast deliveries of content to the end user.

Regional Edge Caches, that are used by default by CloudFront, are used with content that is not that frequent accessed to remain in an edge location but need to be cached. 

They support services like S3, Amazon Route 53 and Amazon CloudFront.

---

#### Edge locations vs AWS Local zones

When you should use Local Zones or Edge Locations? 

<span style="color:orange;">Local Zones</span> provides services like AWS Compute, storage and database, closer to the end user providing low-latency requirements. Same AWS Infrastructure as in the normal Cloud. 

In <span style="color:orange;">edge locations</span> you can cache data or content to provide a fast delivery for users but cannot be use to hold compute instances or other services. 

## List of regions

This are the main regions provided for an AWS account:  

| Code           | Name                      | Opt-in status |
| -------------- | ------------------------- | ------------- |
| us-east-1      | US East (N. Virginia)     | Not required  |
| us-east-2      | US East (Ohio)            | Not required  |
| us-west-1      | US West (N. California)   | Not required  |
| us-west-2      | US West (Oregon)          | Not required  |
| af-south-1     | Africa (Cape Town)        | Required      |
| ap-east-1      | Asia Pacific (Hong Kong)  | Required      |
| ap-south-2     | Asia Pacific (Hyderabad)  | Required      |
| ap-southeast-3 | Asia Pacific (Jakarta)    | Required      |
| ap-southeast-5 | Asia Pacific (Malaysia)   | Required      |
| ap-southeast-4 | Asia Pacific (Melbourne)  | Required      |
| ap-south-1     | Asia Pacific (Mumbai)     | Not required  |
| ap-northeast-3 | Asia Pacific (Osaka)      | Not required  |
| ap-northeast-2 | Asia Pacific (Seoul)      | Not required  |
| ap-southeast-1 | Asia Pacific (Singapore)  | Not required  |
| ap-southeast-2 | Asia Pacific (Sydney)     | Not required  |
| ap-northeast-1 | Asia Pacific (Tokyo)      | Not required  |
| ca-central-1   | Canada (Central)          | Not required  |
| ca-west-1      | Canada West (Calgary)     | Required      |
| cn-north-1     | China (Beijing)           | Not required  |
| cn-northwest-1 | China (Ningxia)           | Not required  |
| eu-central-1   | Europe (Frankfurt)        | Not required  |
| eu-west-1      | Europe (Ireland)          | Not required  |
| eu-west-2      | Europe (London)           | Not required  |
| eu-south-1     | Europe (Milan)            | Required      |
| eu-west-3      | Europe (Paris)            | Not required  |
| eu-south-2     | Europe (Spain)            | Required      |
| eu-north-1     | Europe (Stockholm)        | Not required  |
| eu-central-2   | Europe (Zurich)           | Required      |
| il-central-1   | Israel (Tel Aviv)         | Required      |
| me-south-1     | Middle East (Bahrain)     | Required      |
| me-central-1   | Middle East (UAE)         | Required      |
| sa-east-1      | South America (São Paulo) | Not required  |
> Take into account! this list is updated in december 2024. 