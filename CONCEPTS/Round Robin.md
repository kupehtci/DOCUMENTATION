#CONCEPTS 

# Round Robin

Round Robin is a simple scheduling algorithm used in computer science. 

Is a general algorithm used to distribute tasks, resources, or requests in a cyclic and sequential manner. The core idea of Round Robin is that each participant in a set (tasks, processes, requests, etc.) gets an equal opportunity to execute or receive resources, one after another, in a circular order. Once the last participant in the set is served, the cycle restarts from the first participant.

Its commonly used in Load balancing, process scheduling in operating systems and in networking. 

The key characteristics are: 

- **Cyclic Order:** Tasks or participants are served in a fixed sequence. After the last participant is served, the process loops back to the first one.

- **Fairness:** Each participant gets an equal opportunity to be served, preventing any single entity from monopolizing resources.

- **Simplicity:** The algorithm is straightforward and easy to implement, making it widely applicable in different domains.

#### Round Robin in Load Balancing

Load Balancing is the process of distributing incoming network traffic across multiple servers or instances to distribute the traffic equitative. 

Example, in a Round Robin load balancer, incoming requests are distributed sequentially to a pool of servers. If you have three servers (Server A, Server B, Server C), the load balancer sends the first request to Server A, the second to Server B, the third to Server C, and then loops back to Server A for the fourth request, and so on.


#### Round Robin in operating systems

In operating systems, Round Robin is used as a **CPU scheduling algorithm**.

In this context, each process in the ready queue is assigned a fixed time slice or quantum (e.g., 100 milliseconds). The CPU scheduler picks the first process in the queue, lets it run for one time slice, then moves it to the end of the queue and picks the next process. This continues in a cyclic manner until all processes are complete.


#### Round Robin in Networking

In **networking**, Round Robin is often used in **DNS load balancing** and **packet scheduling**.

When multiple IP addresses are associated with a single domain, the DNS server rotates through the list of IP addresses, returning a different one each time it receives a query. This helps distribute traffic across multiple servers.