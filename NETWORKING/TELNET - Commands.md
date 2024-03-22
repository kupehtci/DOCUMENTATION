#NETWORKING 

### TELNET COMMANDS

All this commands work by the use of **negotiation** with the `WILL` and `DO` commands. [[TELNET]].  

All of this commands are sent though the same channel as the data and are signaled before with a <span style="color:orange;">(IAC) Interpret As Command</span>. 

Are represented using a special byte 240-254 (decimal value) \[11110000 - 11111110\]. 


| **Command Byte Value (Decimal)** | **Command Code** | **Command** | **Description** |
| ---- | ---- | ---- | ---- |
| **240** | **_SE_** | **Subnegotiation End** | Marks the end of a Telnet option subnegotiation, used with the _SB_ code to specify more specific option parameters. [See the topic on Telnet options for details](http://www.tcpipguide.com/free/t_TelnetOptionsandOptionNegotiation.htm). |
| **241** | **_NOP_** | **No Operation** | Null command; does nothing. |
| **242** | **_DM_** | **Data Mark** | Used to mark the end of a sequence of data that the recipient should scan for urgent Telnet commands. [See the topic on Telnet interrupt handling for more information](http://www.tcpipguide.com/free/t_TelnetInterruptHandlingUsingOutOfBandSignalingTheT.htm). |
| **243** | **_BRK_** | **Break** | Represents the pressing of the “break” or “attention” key on the terminal. |
| **244** | **_IP_** | **Interrupt Process** | Tells the recipient to interrupt, abort, suspend or terminate the process currently in use. |
| **245** | **_AO_** | **Abort Output** | Instructs the remote host to continue running the current process, but discard all remaining output from it. This may be needed if a program starts to send unexpectedly large amounts of data to the user. |
| **246** | **_AYT_** | **Are You There** | May be used to check that the remote host is still “alive”. When this character is sent the remote host returns some type of output to indicate that it is still functioning. |
| **247** | **_EC_** | **Erase Character** | Instructs the recipient to delete the last undeleted character from the data stream. Used to “undo” the sending of a character. |
| **248** | **_EL_** | **Erase Line** | Tells the recipient to delete all characters from the data stream back to (but not including) the last end of line (“CR”+”LF”) sequence. |
| **249** | **_GA_** | **Go Ahead** | Used in Telnet half-duplex mode to signal the other device that it may transmit. |
| **250** | **_SB_** | **Subnegotiation** | Marks the beginning of a Telnet option subnegotiation, used when an option requires the client and server to exchange parameters. [See the topic on Telnet options for a full description](http://www.tcpipguide.com/free/t_TelnetOptionsandOptionNegotiation.htm). |
| **251** | **_WILL_** | **Will Perform** | In [Telnet option negotiation](http://www.tcpipguide.com/free/t_TelnetOptionsandOptionNegotiation.htm), indicates that the device sending this code is willing to perform or continue performing a particular option. |
| **252** | **_WON’T_** | **Won’t Perform** | In [Telnet option negotiation](http://www.tcpipguide.com/free/t_TelnetOptionsandOptionNegotiation.htm), indicates that the device sending this code is either not willing to perform a particular option, or is now refusing to continue to perform it. |
| **253** | **_DO_** | **Do Perform** | In [Telnet option negotiation](http://www.tcpipguide.com/free/t_TelnetOptionsandOptionNegotiation.htm), requests that the other device perform a particular option or confirms the expectation that the other device will perform that option. |
| **254** | **_DON’T_** | **Don’t Perform** | In [Telnet option negotiation](http://www.tcpipguide.com/free/t_TelnetOptionsandOptionNegotiation.htm), specifies that the other party not perform an option, or confirms a device’s expectation that the other party not perform an option. |
| **255** | **_IAC_** | **Interpret As Command** | Precedes command values 240 through 254 as described above. A pair of IAC bytes in a row represents the data value 255. |


### OPTIONS FOR OPTION NEGOTIATION

The following set of options can be negotiates using WILL and DO  and their negatives in order to handle the Telnet Session between a client and a server. 

| Num | Option Code       | Option Name                             | Description                                                                                           |
| --- | ----------------- | --------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| 0   | TRANSMIT-BINARY   | Binary Transmission                     | Allows binary communication in 8bit instead of 7-bit ASCII.                                           |
| 1   | ECHO              | Echo                                    | Send an echo mode for Keystroke transmission and their terminal appearance and behavior.              |
| 3   | SUPPRESS-GO-AHEAD | Suppress go ahead                       | Allows when not operating in half-duplex mode to not need to use GO-AHEAD when ending transmission.   |
| 5   | STATUS            | Status                                  | Requests the status of a Telnet Option                                                                |
| 6   | TIMING-MARK       | Timing Mark                             | Allows devices to negotiate the insertion of a timing mark into data stream. Used for synchronization |
| 10  | NAOCRD            | Output Carriage-Return Disposition      | How carriage returns would be handled                                                                 |
| 11  | NAOHTS            | Output Horizontal Tab Stops             | Negotiate which horizontal tabs will be used.                                                         |
| 12  | NAOHTD            | Output Horizontal Tab Stops Disposition | Negotiate how horizontal tabs are handled and if end the connection                                   |
| 13  | NAOFFD            | Output Formfeed Disposition             | Negotiate how form feed characters will be handled.                                                   |
