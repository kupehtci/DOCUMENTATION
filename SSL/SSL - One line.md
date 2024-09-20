#NETWORKING 

### SSL One line differences

There are some ways to pass the traffic with SSL: 

- **SSL Bridging:** The Load Balancer/Proxy decrypts incoming HTTPS traffic and re-encrypts it before forwarding it to the backend server.

![[ssl_one_line_2.webp]]

- **SSL Offloading (also known as SSL Termination):** The Load Balancer/Proxy decrypts incoming HTTPS traffic and sends it to the backend server without encryption.
![[ssl_one_line_1.webp]]



- **SSL Passthrough:** The Load Balancer/Proxy doesn’t decrypt incoming HTTPS traffic and forwards it to the backend server as it is.

![[ssl_one_line_3.webp]]