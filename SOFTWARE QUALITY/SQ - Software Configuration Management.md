#SoftwareQuality 

Software is dynamic by nature: 

* Need to support multiple versions in parallel (per OS version, per OS, users that don't update). 
* We need to update continuously the version of the apps delivered to our customers. 
* Successful product continually adapt to user's need. 
* Products are built by multiple developers, at the same time in the same product. 

SCM is the discipline that helps us to deal with <span style="color:LightSlateGrey;">software dynamism</span>. SCM helps with: 

* Software versions are managed in parallel 
* Different people can work in the same software project. 
* Issues and bugs are tracked.
* Software changes are tracked
* Software development process follows a set of rules. 
* Software releases and deliveries are properly managed

SCM can be: 

* <span style="color:CornflowerBlue;">Source Code Management</span>: Git and SVN are code management tools
* <span style="color:CornflowerBlue;">Software Configuration Management</span>: Bug tracking, continuous integration, continuous delivery. 


### Source Code Management

SCM tools help us to control the version of the artifacts we use to create code. 

Its based in <span style="color:fuchsia;">repositories</span>, that are systems that store different versions of all the configuration items. The repository remember the changes written to ir and every change of it such as additions, rearrangement, files, etc. 

A <span style="color:CornflowerBlue;">workspace</span> is the local folder where you make the changes to files you are working to. You can upload this changes into the local or remote repository. 

Version Control systems can be: 

* <span style="color:CornflowerBlue;">Centralized</span>: the repository is located in a single place. 
* <span style="color:CornflowerBlue;">Distributed</span>: each user that uses the repository has a copy of the repository. 

A <span style="color:MediumSlateBlue;">Git branch</span> is an independent line of development, normally used to work on new features, bug fixes in a isolated way from the **master branch**. 

Try to keep branches as short as posible in order to avoid more error possibilities and synchronize with master branch in order to test after merging both branches

So <span style="color:MediumSlateBlue;">branches</span> can them be merged to the main branch once they has finished its goal and resolve the <span style="color:IndianRed;">conflicts</span>. 

This <span style="color:IndianRed;">conflicts</span> are ambiguity because the same file has been modified in both branches and needs to be combined 


### CI - Continuous Integration

<span style="color:orange;">Continuous Integration</span> is a software development practice where work is frequently committed leading into multiple integrations per day. 
Each integration is automatically verified by an automated build that detect integration errors. 

Allows to deploy cohesive build quickly. 


The difference with Continuous Delivery is that in delivery, the deploy to production is manually and in Continuous Integration is automatically. 