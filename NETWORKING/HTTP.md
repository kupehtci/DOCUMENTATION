#NETWORKING 

## HTTP - Hyper Text Transfer Protocol


Hyper-Text Transfer Protocol is an application layer protocol capable of transfer Hyper-Text documents. The most common Hyper Text Markup Language to define Hyper Text documents is HTML [[HTML - Basics]]. 

The different Web Objects like the HTML webpage itself are stored with an unique URI. 

Lest see the different concepts that conforms the HTTP Protocol: 

##### HTML 

Hyper-Text Markup Language or HTML is a text language used to define hypertext document. Its capable, by adding tags to a regular document to allow data formatting and external linking like images. 

##### URIs (Uniform Resource Identifiers)

Uniform Resource Identifiers or URIs is a method of labelling to identify resources so can be easily founded. 

Originally can be used to locate hyper-text documents, like coordinates to the document. 

##### URLs ( Uniform Resource Locators)

Allows web objects to be uniquely addressed by the **host name**, **directory** and **filename**. 
For webs the schema will always be **http(s)://**

```markdown
http://<user>:<password>@<host>:<port>/<url-path>? <query>#<bookmark>
```

 * <span style="color:LightSeaGreen;">User and password</span>: Optional authentication (Rarely used)
 * <span style="color:LightSeaGreen;">Host</span>: Hostname of the web where resource is located. Normally a fully qualified domain name or an IP address
 * <span style="color:LightSeaGreen;">Port</span>: TCP port number 
 * <span style="color:LightSeaGreen;">url-path</span>: Path to specific resource to be retreived. A full directory with the secuences of directories and filename except is `index.html`. 
 * <span style="color:LightSeaGreen;">Query</span>: An optional query to sent to server used in interactive functions.
 * <span style="color:LightSeaGreen;">Bookmark</span>: Identifies a section within the current HTML document. 

##### WEB SERVERS

Mix of software an hardware hosts that keeps hyper-text documents and render them. Interprets CSS, HTML and other media content. 


##### WEB OBJECTS

Its the most basic web element that can be uniquely identified. Any of these resources can be: 

* Addresable by a single URL
* Sent by over HTTP
* Renderable by a web browser
* Storable in a Web server

##### WEBPAGES

Is a type of web object and is built using the HTML. 

May content nested web objects like: 
* Images
* Text
* Images
* Video
* ...

