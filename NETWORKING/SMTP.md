#NETWORKING 

# SMTP 

Is an <span style="color:LightSeaGreen;">Application layer</span> protocol built over a persistent TCP connection(make a handshake before).
It handles a <span style="color:orange;">client - server</span> using a <span style="color:violet;">command-response pattern</span> with status codes (Similar to HTTP). 

Uses <span style="color:LightSeaGreen;">plain text ASCII</span> messages in its communication: 
* **Commands**: following specific order and some parameters
* **Responses**: Human readable phrase and numeric code response. 

Its a <span style="color:LightSeaGreen;">push protocol</span> meant to push files into the server. In order to retreive and manage the emails from MTA we need a pulling protocol like [[POP3]] or [[IMAP]]. 
#### SMTP Commands

Plain ASCII text used for commands and its parameters. 

| Commands | Usage                                                                          |
| -------- | ------------------------------------------------------------------------------ |
| HELO     | Client identify itself                                                         |
| MAIL     | identifies sender of email                                                     |
| RCPT     | Identifies recipients of the message. One RCPT if more than one recipient      |
| DATA     | Sends the content of the email message. Ends with a line with single '.'       |
| RSET     | Aborts current mail transaction                                                |
| VRFY     | client asks sender to verify a recipient address without sending them an email |
| NOOP     | force the server to respond with an OK reply code (Code 200)                   |
| QUIT     | Terminares the email exchange.                                                 |

response in plain text, a phrase following an xyz structure: 

* X represents the success of a request
* Y represents category of the error
* Z identify specific case

`SUCCESS OF REQUEST (X)`

| Code | Category                      | Description                                                                              |
| ---- | ----------------------------- | ---------------------------------------------------------------------------------------- |
| 1yz  | Positive preliminary          | Request action is being initiated                                                        |
| 2yz  | Positive completion           | Request action has been successfully completed                                           |
| 3yz  | Positive Intermediate         | Command accepted, but pending of receipt of more information                             |
| 4yz  | Transient Negative Completion | Command not accepted, but error condition is temporary and action can be requested again |
| 5yz  | Permanent Negative Completion | Command not accepted                                                                     |

`ERROR CATEGORY (y)`

| Code | Category    | Description                                                                                           |
| ---- | ----------- | ----------------------------------------------------------------------------------------------------- |
| x0z  | Syntax      | Refers to syntax errors, syntactically correct commands with no functionality or superfluous commands |
| x1z  | Information | Request for more information                                                                          |
| x2z  | Connections | Refers to more data about transmission channel                                                        |
| x3z  | Unspecified |                                                                                                       |
| x4z  | Unspecified |                                                                                                       |

### BEHAVIOUR

Firstly in order, to establish an SMTP connection, it needs a TCP connection between client and server: 

1. Starts a TCP connection over port 25. 
2. Server answers using TCP socket with a **220 Ready** message. 
3. Client sends a **HELO** command
4. Server answers with **250 Hello, \<sender\>
5. Now transfer of messages starts

1. <span style="color:#7d90b0;">MAIL FROM: &ltsender&gt</span> command is sent by client
2. Server answers <span style="color:#7d90b0;">250 &ltsender&gt Sender OK</span>
3. <span style="color:#7d90b0;">RCPT TO: &ltsender&gt</span> command is sent by the client

| Client                                                       | Server                                                                 |
| ------------------------------------------------------------ | ---------------------------------------------------------------------- |
| <span style="color:#7d90b0;">MAIL FROM: &ltsender&gt</span>  |                                                                        |
|                                                              | <span style="color:#7d90b0;">250 &ltsender&gt Sender OK</span>         |
| <span style="color:#7d90b0;">RCPT TO: &ltrecipient&gt</span> |                                                                        |
|                                                              | <span style="color:#7d90b0;">250 &ltrecipient&gt Rrecipient OK</span>  |
| <span style="color:#7d90b0;">DATA</span>                     |                                                                        |
|                                                              | <span style="color:#7d90b0;">354 Enter mail, end with '.'</span>       |
| Sends n messages and end with .                              |                                                                        |
|                                                              | <span style="color:#7d90b0;">250 Message accepted</span>               |
| <span style="color:#7d90b0;">QUIT</span>                     |                                                                        |
|                                                              | <span style="color:#7d90b0;">221 &ltserver&gt connection closed</span> |

### DATA FORMAT

Data in a basic SMTP email is just ASCII message being simple and limited. In order to expand the number of characters available in a message, [[NETWORKING/MIME]]  is used and defined for different parts of the email in order to be able to send special media. 