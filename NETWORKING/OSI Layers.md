#NETWORKING 

# Networking OSI Layers 

The <span style ="color:#ababf5;">Open Systems Interconnection</span> (OSI) describes seven layers used to communicate over the network. 

| **OSI Layer**           | **Description**                                                                                                                                                                                                                                  |
|-------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **7. Application Layer** | Human computer interaction layer. This layer supports application and end-user processes, such as email, file transfer, and web browsing. Protocols like HTTP, FTP, and SMTP operate at this layer.                                              |
| **6. Presentation Layer**| **Data representation and encryption.** This layer ensures that data is presented in a usable format and handles data encryption, compression, and translation. Common formats include JPEG, GIF, and ASCII.                                      |
| **5. Session Layer**     | **Establishes, manages, and terminates sessions.** This layer controls the dialogues (sessions) between computers, maintaining connections and handling the flow of data. Protocols like NetBIOS and RPC work at this layer.                       |
| **4. Transport Layer**   | **Reliable transmission of data segments between points on a network.** This layer ensures complete data transfer with error checking, flow control, and retransmission of lost packets. TCP and UDP are key protocols here.                     |
| **3. Network Layer**     | **Path determination and logical addressing.** This layer is responsible for determining the best physical path for data to reach its destination. It manages logical addressing (e.g., IP addresses) and routing. Protocols include IP, ICMP, and OSPF. |
| **2. Data Link Layer**   | **Data transfer between adjacent network nodes.** This layer handles the physical addressing (MAC addresses), error detection and correction, and data frame sequencing. Ethernet, PPP, and Switches operate at this layer.                      |
| **1. Physical Layer**    | **Transmission and reception of raw bit streams over a physical medium.** This layer involves the hardware elements, such as cables, switches, and network interface cards, that transmit the raw data. It deals with the electrical, mechanical, and procedural interface to the physical medium. |

