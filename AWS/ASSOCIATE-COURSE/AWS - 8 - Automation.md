#AWS 

# AWS 8 Automation

Automatize the AWS management and provision can help with future changes, having a centralized source of truth about the infraestructure and ease the maintainment, deploy and scalement of this applications in the cloud. 

It is centered in Infrastructure as code or IaC, where you use code to define, configure, update and remove the infrastructure. 
A *template* is a file that defines the resources to be deployed in the environment and then is processed by an *engine* that provision the specified resources. 
It also helps with version control for being able to roll back in case of errors and other features. 

Also offers reusability of the infrastructure to deploy multiple environments or re-deploy in others. 

There are some tools that can be use to automatize it: 

#### AWS Cloudformation

AWS CloudFormation is an API wrapper. 

It uses the same API as the ones used in AWS Management Console for creating the resources but the information entered is in template files. 

An AWS CloudFormation template has some additional points: 

* It can be managed with a verison control tools like Git or Subversion (SVN)
* Define an entire application stack (all resources for an application) in a JSON/YAML template file. 
* Define runtime parameters for a template such as EC2 instance type, EC2 key pair and others. 
* If you create an AWS resource outside CloudFormation, you can import it

<span style="color:orange;">Stack</span> is a collection of resources that can be created, managed and destroyed together and compose an entire application. 
AWS CloudFormation treat all this resoruces as a single unit when creating and deleting it. 

When changes are done to the stack, this one is created without recreating it. 

You can create **cross-stack** references to share parameters between stacks or use the outputs of one of them with others. 

##### Layered architecture

A **layered architecture** organizes different stacks into multiple horizontal layers that build one on top of other. 
Each layer has only dependencies with the layer under it. 
Each layer should have resources with similar lifecycles and ownewship: 

```md
### Example of a layered architecture

Each layer is composed of one or more stacks. 

|----------------------------------------------------------------|
|     Frontend     > Web interface, admin, dashboards...         |
|----------------------------------------------------------------|
|     Backend      > Customers, products, marketing...           |
|----------------------------------------------------------------|
|     Shared       > Databases, monitoring, alarms, subnets, sg  |
|----------------------------------------------------------------|
|     Base network > VPCs, IGWs, VPNs, NAT Gateways              |
|----------------------------------------------------------------|
|     Identity     > AWS IAM users, groups, roles                |
|----------------------------------------------------------------|
```

#### Deployments

When choosing an infrastructure deployment tool, we must find a balance between convenience and control. 

More control you have over the resources, more expertise you need to manage it and less convenient is going to be. 

You can automate the infrastructures deployments with the following tools: 

* **AWS Elastic Beanstalk**: Integrated with developer tools allows to provision and manage the application infrastructure. 
* **AWS Solutions Library**: It groups multiple solutions for most common technology uses. This solutions brings the necesary CloudFormation templates, scripts and reference infrastructures. 
* **AWS Cloud Development Kit**: AWS CDK is an software development fframework to model and provision application resources by using other common programming languages. Offers pre-configured components but you can still configuring it. 
* **AWS CloudFormation**: you define every resource and its configuration. You have granular control over every component of the infrastructure. 
* **AWS Systems Manager**: can be used to view and control the infrastructure of AWS and automate maintenance and deployment tasks. 

#### AWS Elastic Beanstalk

Its designed to help developers to deploy and maintain scalable web applications and services in the cloud without worrying about the underlying infraestructure. 

Elastic Beanstalk configure the EC2 instances in the environment with the components appropriate for the selected application type. 

You don't need to loggin into instances to install the application, Elastic Beanstalk provision it for you. 

#### AWS Solutions Library

Gathers solutions designed by AWS architects and are designed to be operational effective, reliable, secure and cost-efficient. 
They can also include documentacion, deployment configurations. 

#### AWS Cloud Development Kit (CDK)

AWS CDK is a framework for defining the cloud application resources by using a declarative model in another programming languages. 

You can use AWS CDK with common programming languages such as Python, JavaScript, TypeScript, Java, or C#.


#### AWS Systems Manager

AWS System manager helps with the management of the deployed instances. 

Take into account that you may need to install management agents in the instances. 

With Systems Manager you can: 

* Create logical groups of resources such as applications, layer of application stack or different environments. 
* Select a resource group and view its activity. 
* Take actions on resource groups such as installments. 
* Centralize operational data from AWS services and automate across your AWS resources. 