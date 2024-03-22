#NETWORKING 

### TCP Urgent Mode

All data bytes is give to TCP and transmit the data in order but not always is wanted to keep the data stream ordered. 


Suppose that we are sending a large file through internet and we want to interrupt this transfering, if we queue the 'abort' message is going to be sent once the file has been completely transmitted.  

In order to solve this, TCP provides an <span style="color:LightSeaGreen;text-decoration:italic;"><i>urgent mode</i></span>. A way of telling the other host that this urgent message has been place inside the normal stream of data but its not involves in this chunk of data. 

For setting this urgent mode, <span style="color:orange;">two fields must be set</span> in the TCP header: 

* The `URG` bit is turned to 1
* The `16-bit urgent pointer` is set as a positive offset to obtain the sequence number of the last byte of urgent data. 

### USES

TCP urgent mode is mostly used for: 
* Telnet [[TELNET]] and Rlogin when user types the interrupt key
* FPT[^1] when aborting a file. 

### URGENT MODE

If the `urgent pointer` offset is specified long away from package size continues reading the following ones until reaches the urgent offset. 

During this sequence of "urgent packages" it's considered that the application is in <span style="color:orange;">urgent mode</span>



### OUR-OF-BAND DATA

Because there is no way to specify where this urgent data starts, its left to the application. 

This doesn't need to be confused with out-of-band data. This last 

---

REFERENCES

[^1]: Take a look into [[FTP File Transfer Protocol]]. 



