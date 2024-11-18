
# Lab 1: Exploring and Interacting with the AWS Management Console and AWS CLI

© 2024 Amazon Web Services, Inc. or its affiliates. All rights reserved. This work may not be reproduced or redistributed, in whole or in part, without prior written permission from Amazon Web Services, Inc. Commercial copying, lending, or selling is prohibited. All trademarks are the property of their owners.

Note: Do not include any personal, identifying, or confidential information into the lab environment. Information entered may be visible to others.

Corrections, feedback, or other questions? Contact us at [_AWS Training and Certification_](https://support.aws.amazon.com/#/contacts/aws-training).

## Lab overview

The Amazon Web Services (AWS) environment is an integrated collection of hardware and software services designed to provide quick and inexpensive use of resources. The AWS API sits atop the AWS environment. An API represents a way to communicate with a resource. There are different ways to interact with AWS resources, but all interaction uses the AWS API. The AWS Management Console provides a simple web interface for AWS. The AWS Command Line Interface (AWS CLI) is a unified tool to manage your AWS services through the command line. Whether you access AWS through the AWS Management Console or using the command line tools, you are using tools that make calls to the AWS API.

This lab follows the Architecting Fundamentals module, which focuses on the core requirements for creating workloads in AWS. This lab reinforces module discussions on the what, where, and how of building AWS workloads. Students first explore the features of the AWS Management Console and then use the Amazon Simple Storage Service (Amazon S3) API to deploy and test connectivity to an Amazon S3 bucket using two different methods:

- AWS Management Console
- AWS CLI

### Objectives

After completing this lab, you should be able to do the following:

- Explore and interact with the AWS Management Console.
- Create resources using the AWS Management Console.
- Explore and interact with the AWS CLI.
- Create resources using the AWS CLI.

### Icon key

Various icons are used throughout this lab to call attention to different types of instructions and notes. The following list explains the purpose for each icon:

-  **Note:** A hint, tip, or important guidance.
-  **Learn more:** Where to find more information.
-  **Caution:** Information of special interest or importance (not so important to cause problems with the equipment or data if you miss it, but it could result in the need to repeat certain steps).
-  **WARNING:** An action that is irreversible and could potentially impact the failure of a command or process (including warnings about configurations that cannot be changed after they are made).
-  **Expected output:** A sample output that you can use to verify the output of a command or edited file.
-  **Command:** A command that you must run.
-  **Consider:** A moment to pause to consider how you might apply a concept in your own environment or to initiate a conversation about the topic at hand.

## Start lab

1. To launch the lab, at the top of the page, choose Start Lab.
    
     **Caution:** You must wait for the provisioned AWS services to be ready before you can continue.
    
2. To open the lab, choose Open Console .
    
    You are automatically signed in to the AWS Management Console in a new web browser tab.
    
     **Warning:** Do not change the **Region** unless instructed.
    

### Common sign-in errors

#### Error: You must first sign out

![Log out error](https://s3-us-west-2.amazonaws.com/us-west-2-aws-training/awsu-spl/sts-sign-in-images/media/logouterror.png)

If you see the message, **You must first log out before logging into a different AWS account:**

- Choose the **click here** link.
- Close your **Amazon Web Services Sign In** web browser tab and return to your initial lab page.
- Choose Open Console again.

#### Error: Choosing Start Lab has no effect

In some cases, certain pop-up or script blocker web browser extensions might prevent the **Start Lab** button from working as intended. If you experience an issue starting the lab:

- Add the lab domain name to your pop-up or script blocker’s allow list or turn it off.
- Refresh the page and try again.

---

### Lab environment

The lab environment provides you with the following resources to get started: an Amazon Virtual Private Cloud (Amazon VPC), the necessary underlying network structure, a security group allowing the HTTP protocol over port 80, an Amazon Elastic Compute Cloud (Amazon EC2) instance with the Amazon CLI installed, and an associated Amazon EC2 instance profile. The instance profile contains the permissions necessary to allow Session Manager, a capability of AWS Systems Manager, to access the Amazon EC2 instance.

The following diagram shows the interactive flow of the AWS API for creating AWS services and resources used in the lab through the AWS Management Console and AWS CLI.

![Interactive Flow Diagram for creating AWS services and resources using AWS Management Console and AWS CLI.](https://us-west-2-tcprod.s3.us-west-2.amazonaws.com/courses/ILT-TF-200-ARCHIT/v7.8.0.prod-4c57a67d/lab-1-Explore/instructions/en_us/images/Lab-1-Overview.png)

### AWS services not used in this lab

AWS services not used in this lab are deactivated in the lab environment. In addition, the capabilities of the services used in this lab are limited to only what the lab requires. Expect errors when accessing other services or performing actions beyond those provided in this lab guide.

---

## Task 1: Explore and configure the AWS Management Console

In this task, you explore the AWS Management Console and the unified search tool. You then configure the Region, widgets, and services.

 **Learn more:** The AWS Management Console provides secure sign-in using your AWS account root user credentials or AWS Identity and Access Management (IAM) account credentials. When you first sign in, the user credentials are authenticated and the home page is displayed. The home page provides access to each service console and offers a single place to access the information you need to perform your AWS related tasks. For more information, see [What is the AWS Management Console?](https://docs.aws.amazon.com/awsconsolehelpdocs/latest/gsg/learn-whats-new.html).

### Task 1.1: Choose an AWS Region

In this task, you choose an AWS Region that specifies where your resources are managed. Regions are sets of AWS resources located in the same geographical area.

3. On the navigation bar, choose the **Region** selector displayed at the top-right corner of the console, and then choose the Region to which you want to switch.

The Region on the console home page is now changed to the Region you chose.

 **Caution:** If the chosen Region opens up a different webpage instead of the console home page, choose Cancel and try to choose a different Region.

Next, you configure the default Region.

4. To open the General Settings page, click gear icon from menu bar.
    
5. Click on **More user settings**.
    

The **Unified Settings** page is displayed.

6. In the **Localization and default Region** section, choose Edit.
    
7. For **Default Region**, select any _Region_ from the dropdown menu.
    
8. Choose Save settings.
    

A  **Successfully updated localization and Region settings** message is displayed on top of the screen.

 **Caution:** If the current Region shown on the Region selector in the top-right corner is the same Region you choose in the default Region dropdown list, you will not see the success message with Go to new default Region. Try choosing a different Region from the dropdown menu to see this message and complete the next step.

9. Choose Go to new default Region.

The **Unified Settings** page is displayed with the Region set to the **Default Region** you chose.

 **Note:** If you do not choose a default Region, the last Region you visited becomes your default.

10. Choose the **AWS logo** displayed in the upper-left-hand corner to return to the console home page.
    
11. On the navigation bar, choose the **Region selector** displayed at the top-right corner of the console, and then choose the **Region** that matches the **LabRegion** value located to the left of these instructions.
    

 **Caution:** Verify that you are in the **correct region** that matches to the **LabRegion** value located to the left of these instructions.

### Task 1.2: Search with the AWS Management Console

In this task, you explore the search box on the navigation bar, which provides a unified search tool for locating AWS services and features, service documentation, and the AWS Marketplace.

12. To open a console for a service, go to the  _Search_ box in the navigation bar of the AWS Management Console, and enter 
    
    cloud
    
    .

The more characters you type, the more the search refines your results.

13. To narrow the results to the type of content that you want, choose one of the categories on the left navigation pane.
    
14. To quickly navigate to a service or popular features of a service, in the **Services** section, hover over the **AWS Cloud Map** service name in the results and choose the link.
    

The **AWS Cloud Map console** page is displayed.

 **Note:** For more details about a documentation result or AWS Marketplace result, hover on the result title and choose a link.

15. Choose the **AWS logo** displayed in the upper-left-hand corner to return to the console home page.

### Task 1.3: Add and remove favorites

In this task, you explore the AWS Management Console to add AWS services to your Favorites list and remove added services from the Favorites list.

#### Add a service to the list of favorites

16. On the navigation bar, choose Services to open a full list of services.
    
17. From the left navigation menu, choose **All services** or **Recently visited**, and then choose a service from the list that you want to add as a favorite.
    
18. To the left of the service name, select the **star**.
    

 **Note:** Repeat the previous step to add more services to your Favorites list.

19. To view the list of favorite services, from the left navigation menu, choose **Favorites**.

 **Note:** Alternatively, Favorites are pinned and visible on the navigation bar at the top of the console window.

#### Remove a service from the list of favorites

20. On the navigation bar, choose Services to open a full list of services.
    
21. In the **Favorites** list, deselect the star next to the name of a service you wish to remove.
    

 **Note:** Alternatively, in the **Recently visited** list or **All services** list, deselect the star next to the name of a service that is in your Favorites list.

### Task 1.4: Open a console for a service

22. On the navigation bar, choose Services to open a full list of services.
    
23. Choose a service under **Favorites** or **Recently visited** or **All services** to quickly navigate to a specific service.
    

The chosen **service console** page is displayed.

24. Choose the **AWS logo** displayed in the upper-left-hand corner to return to the AWS Management Console home page.

### Task 1.5: Create and use dashboard widgets

In this task, you learn about the widgets that display important information about your AWS environment and provide shortcuts to your services. You can customize your experience by adding and removing widgets, rearranging them, or changing their size.

25. To add a widget, choose + Add widgets.

The **Add widgets** window is displayed.

26. In the **Add widgets** menu, choose the **title bar** at the top of the widget that you want to add and then drag the widget on the console page.
    
27. To rearrange a widget, configure the following:
    

- Choose the **title bar** at the top of the widget, for example, Favorites, and then drag the widget to a new location on the console page.

28. To resize a widget, configure the following:

- Choose the **Recently Visited** widget.
    
- Drag the bottom-right corner of the widget to resize.
    

 **Note:** You cannot adjust the size of the Welcome to AWS, Explore AWS, and AWS Health widgets.

29. To remove a widget, configure the following:

- Choose the **Welcome to AWS** widget.
    
- In the upper-right corner of the widget, choose the widget actions **ellipsis icon**, represented by three vertical dots.
    
- Choose **Remove widget**.
    

 Congratulations! You have explored the AWS Management Console and learned to customize your console home screen.

---

## Task 2: Create an Amazon S3 bucket using the AWS Management Console

In this task, you create and configure a new Amazon S3 bucket in the _LabRegion_ using the AWS Management Console.

 **Caution:** Verify that you are in the **correct region** that matches to the **LabRegion** value located to the left of these instructions.

 **Learn more:** Amazon S3 is an object storage service that offers industry-leading scalability, data availability, security, and performance. Customers can use Amazon S3 to store and protect any amount of data for a range of use cases, such as data lakes, websites, mobile applications, backup and restore, archive, enterprise applications, Internet of Things (IoT) devices, and big data analytics. For more information, see [What is Amazon S3?](https://docs.aws.amazon.com/AmazonS3/latest/userguide/Welcome.html).

![Interactive Flow Diagram for creating AWS Services and resources using AWS Management Console.](https://us-west-2-tcprod.s3.us-west-2.amazonaws.com/courses/ILT-TF-200-ARCHIT/v7.8.0.prod-4c57a67d/lab-1-Explore/instructions/en_us/images/Task2.png)

30. On the Services menu, choose **All Services**.
31. On the left navigation menu, scroll down the list and choose **Storage**.
32. From the **Storage** list, choose **S3**.

 **Note:** You can also search for 

S3

 in the search bar  _Search_ at the top of the console.

33. In the navigation pane on the left-hand side of the console, choose **Buckets**.
    
34. Choose Create bucket.
    

The **Create bucket** page is displayed.

35. In the **General configuration** section, for **Bucket name**, enter 
    
    labbucket-NUMBER
    
    .

 **Note:** Replace _NUMBER_ in the bucket name with a random number. This ensures that you have a unique name.

- Example bucket name: 
    
    labbucket-987987
    

 **Note:** Amazon S3 bucket names must be globally unique and Domain Name System (DNS) compliant.

36. The **AWS Region** should match the _LabRegion_ value found to the left of these lab instructions.
    
37. Leave all other settings on this page as the default configurations.
    
38. Choose Create bucket at the bottom of the screen.
    

 In terms of implementation, you can create a bucket using the Amazon S3 API, but you performed the same operation using the Amazon S3 console instead. The console uses the Amazon S3 APIs to send requests to Amazon S3.

A  **Successfully created bucket “labbucket-xxxxx”** message is displayed on top of the screen.

The S3 console is displayed. The newly created bucket is displayed among the list of all the buckets for the account.

 Congratulations! You have created a new Amazon S3 bucket with the default configuration.

---

## Task 3: Upload an object into the Amazon S3 bucket using the S3 console

In this task, you upload an object into the previously created S3 bucket using the S3 console.

39. To open the context (Right-click) menu, choose this [image link](https://us-west-2-tcprod.s3.us-west-2.amazonaws.com/courses/ILT-TF-200-ARCHIT/v7.8.0.prod-4c57a67d/lab-1-Explore/instructions/en_us/images/HappyFace.jpg) and choose the option to save the image to your computer.

- Name your file similar to _HappyFace.jpg_.

 **Note:** The method to save files varies by web browser. Choose the appropriately worded option from your context menu.

40. In the **Amazon S3** console, choose the **labbucket-xxxxx** bucket.
    
41. Choose Upload.
    

The **Upload** page is displayed.

42. Choose Add files.
    
43. Browse to and choose the **HappyFace.jpg** picture you downloaded.
    
44. Choose Upload.
    

A  **Upload succeeded** message is displayed on top of the screen.

45. Choose Close.

 Congratulations! You have uploaded an object into the Amazon S3 bucket.

---

## Task 4: Create an Amazon S3 bucket and uploading an object using the AWS CLI

In this task, you use the AWS CLI to create an Amazon S3 bucket. The AWS CLI is an open-source tool that you can use to interact with AWS services using commands in your command line shell.

### Task 4.1: Create a connection to the Command Host using Session Manager

An Amazon EC2 instance pre-configured with the AWS CLI has been provided for you to use in this lab. It has the name _Command Host_.

![Interactive Flow Diagram for creating AWS Services and resources using AWS CLI.](https://us-west-2-tcprod.s3.us-west-2.amazonaws.com/courses/ILT-TF-200-ARCHIT/v7.8.0.prod-4c57a67d/lab-1-Explore/instructions/en_us/images/Task4.png)

46. At the top of the AWS Management Console, in the search box, search for and choose 
    
    EC2
    
    .
    
47. In the navigation pane on the left-hand side of the console, choose **Instances**.
    
48. Select  **Command Host**.
    
49. Choose Connect.
    

The **Connect to instance** page is displayed.

50. Choose the **Session Manager** tab.

 **Learn more:** With Session Manager, you can connect to Amazon EC2 instances without having to expose the SSH port on your firewall or Amazon VPC security group. For more information, see [AWS Systems Manager Session Manager](https://docs.aws.amazon.com/systems-manager/latest/userguide/session-manager.html).

51. Choose Connect.

 **Note:** Alternatively, you can copy the **CommandHostSessionUrl** value from the left side of these lab instructions and paste it in a new browser tab. The terminal for the Command Host instance opens.

A new browser tab or window opens with a connection to the Command Host instance.

### Task 4.2: Use high-level S3 commands with the AWS CLI

In this task, you access the high-level features of Amazon S3 using the AWS CLI.

52.  **Command:** Enter the following command in your Command Host session:

 **Tip:** To copy the command, hover on it and choose the copy  icon. Paste the command in the Command Host session.

 **Note:** The following **ls** command lists all of the buckets owned by the user.

```
aws s3 ls
```

53.  **Command:** Copy the following command to a text editor, replace _NUMBER_ with the random number you chose for your bucket, and paste the command in the Command Host session.

 **Note:** The following **mb** command creates a bucket.

```
aws s3 mb s3://labclibucket-NUMBER
```

- Example bucket name: _
    
    labclibucket-787787
    
    _

54. To run the modified command in your Command Host session, press Enter.

 **Expected output:**

```
make_bucket: labclibucket-xxxxx
```

 **Note:** To simplify the instructions in this lab, this newly created bucket will be referred to as the **labclibucket-NUMBER** for the remainder of the instructions, regardless of what bucket name you actually choose in this step.

55.  **Command:** Enter the following command in your Command Host session:

```
aws s3 ls
```

Notice the newly created bucket in the output list.

56.  **Command:** Copy the following command to a text editor, replace _labclibucket-NUMBER_ with the name of the S3 bucket you created in the previous step, and paste the command in the Command Host session.

 **Note:** The following **cp** command copies a single file to a specified bucket.

```
aws s3 cp /home/ssm-user/HappyFace.jpg s3://labclibucket-NUMBER
```

57. To run the modified command in your Command Host session, press Enter.

 **Expected output:**

```
upload: ../../home/ssm-user/HappyFace.jpg to s3://labclibucket-xxxxx/HappyFace.jpg
```

58.  **Command:** Copy the following command to a text editor, replace _labclibucket-NUMBER_ with the name of the S3 bucket you created in the previous step, and paste the command in the Command Host session.

 **Note:** The following **ls** command lists objects under a specified bucket.

```
aws s3 ls s3://labclibucket-NUMBER
```

 Notice the uploaded object in the newly created bucket in the output list. You can close the browser tab.

As demonstrated in this task, the high-level Amazon S3 commands simplify managing Amazon S3 objects. Using these commands, you can manage the contents of Amazon S3 within itself and with local directories. The S3 commands are built on top of the operations found in the S3 API commands.

 Congratulations! You have used the AWS CLI to create, list, and copy objects into the Amazon S3 bucket.

---

## Conclusion

 Congratulations! You now have successfully:

- Explored and interacted with the AWS Management Console.
- Created resources using the AWS Management Console.
- Explored and interacted with the AWS CLI.
- Created resources using the AWS CLI.

## End lab

Follow these steps to close the console and end your lab.

59. Return to the **AWS Management Console**.
    
60. At the upper-right corner of the page, choose **AWSLabsUser**, and then choose Sign out.
    
61. Choose End Lab and then confirm that you want to end your lab.
    

## Additional resources

- [What is the AWS Management Console?](https://docs.aws.amazon.com/awsconsolehelpdocs/latest/gsg/learn-whats-new.html)
- [What is the AWS Command Line Interface?](https://docs.aws.amazon.com/cli/latest/userguide/cli-chap-welcome.html)
- [AWS Systems Manager Session Manager](https://docs.aws.amazon.com/systems-manager/latest/userguide/session-manager.html)

For more information about AWS Training and Certification, see [_https://aws.amazon.com/training/_](https://aws.amazon.com/training/).

_Your feedback is welcome and appreciated._  
If you would like to share any feedback, suggestions, or corrections, please provide the details in our [_AWS Training and Certification Contact Form_](https://support.aws.amazon.com/#/contacts/aws-training).