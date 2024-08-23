#NETWORKING 

## POP3 Post Office Protocol 3

POP3 is a networking protocol that allows access to a mailbox hold in a mail server. 

It allows get number of emails, download the mails from the server and made deletions. 

**CONS:** It has no synchronization and no folder management. 
**PROS:** Works without internet connection and more efficient space management


### BEHAVIOUR 

In order to do this basic features it has a <span style="color:LIghtSeaGreen;">plain text</span> messages system: 

* From MUA to POP3 server --> `Commands + parameters`
* From POP3 Server to MUA --> `responses (+OK / -ERR) + data`


### COMMANDS

The commands used by the MUA in order to be executed and have a response from the server are: 

* `STAT`: gets the number of messages
* `LIST`: get the list of messages and their size
* `RETR <id>`: retreive a message by specifying the id
* `DELE <id>:` deleted a message
* `QUIT`: terminates the connection and mail exchange



