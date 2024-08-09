#NETWORKING 

## MIME 

<span style="color :orange;">MIMe or Multipurpose Internet Mail Extensions</span>  is a series of standards that extend the format of email messages to support text in character sets others than basic ASCII. 

This standard defines: 

* Various **headers** used to describe the structure of the MIME message and character set used. 
* The **general structure** of the MIME media typing system
* An initial set of **media types**
* Extensions to allow **non-US-ASCII** text data in mail header fields. 
* Various IANA registration procedures for MIME related facilities. 

## MIME HEADER

MIME defines a number of new IMF header fields that are used to describe the content of a MIME entity. 
There are header field in: 
* As part of a regular message header (RFC 2822)
* In a MIME body part header within a multipart construct. 

The MIME standard header fields are: 

| Header               | Name          | Protocol                                      |
|----------------------|---------------|-----------------------------------------------|
| MIME-Version         | MIME          | MIME version number                           |
| Content-ID           | MIME          | Identify content body part                   |
| Content-Description  | MIME          | Description of message body part             |
| Content-Transfer-Encoding | MIME     | Content transfer encoding applied           |
| Content-Type         | MIME          | MIME content type                            |
| Content-Base         | MIME          | Base to be used for resolving relative URIs within this content part |
| Content-Location     | MIME          | URI for retrieving a body part               |
| Content-Features     | MIME          | Indicates content features of a MIME body part |
| Content-Disposition  | MIME          | Intended content disposition and file name  |
| Content-Language     | MIME          | Language of message content                  |
| Content-Alternative  | MIME          | Alternative content available                |
| Content-MD5          | MIME          | MD5 checksum of content                      |
| Content-Duration     | MIME          | Time duration of content                     |

### MESSAGE FORMAT

MIME messages are introduced inside an IMF message. 

A basis message is composed of: 

* Default IMF header
* A MIME header
* MIME entity

MIME messages can have more than one entity

![[MIME_header_message_format.png]]



### BOUNDARIES

By defining boundaries and assigning the content-type of each boundary, a message can have multiple MIME types in same message: 

This can be done following this boundaries format: 

```email
MIME-Version: 1.0
From: Nathaniel Borenstein <nsb@nsb.fv.com>
To: Ned Freed <ned@innosoft.com>
Date: Fri, 07 Oct 1994 16:15:05 -0700 (PDT)
Subject: A multipart example
Content-Type: multipart/mixed; boundary=unique-boundary-1

--unique-boundary-1
Hello this is a text of a MIME message
Content---unique-boundary-1Type: image/jpeg


Content-Transfer-Encoding: base64
... base64-encoded image data goes here ...
```

By defining: `Content-Type: multipart/mixed; boundary=unique-boundary-1` for a specific boundary, we can enclose the MIME entity as the text until the end of message or next boundary. 