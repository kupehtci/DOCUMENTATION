#NETWORKING 


### DNS

The DNS or Domain Name System is the most important **open** and **free** infrastructure. 

Hostnames provide low information about the location of a host in the internet, but are more easy to memorize to humans. On other hand, IP provides a lot of information for locating the hosts but are hard to memorize, so the solution is to translate the hostname into the IP using the <span style="color:orange;">DNS system</span>. 
# What are the different types of DNS queries?

DNS queries can be classified according the manner in which a complete request is processed. Generally queries can be classified as follows.

* ***recursive query**
* *iterative query OR Nonrecursive query**
* ***Inverse queries**

## What is a recursive query?

A recursive query is a kind of query, in which the DNS server, who received your query will do all the job of fetching the answer, and giving it back to you. During this process, the DNS server might also query other DNS server's in the internet on your behalf, for the answer.

Lets understand the entire process of recursive queries by the following steps.

Suppose you want to browse www.example.com, and your resolve.conf file has got the following entry.

[root@myvm ~]# cat /etc/resolv.conf
nameserver 172.16.200.30
nameserver 172.16.200.31

The above resolve conf entry means that,Your DNS servers are 172.16.200.30 & 31. Whatever application you use, the operating system will send DNS queries to those two DNS servers.

**STEP 1:** You enter www.example.com in the browser. So the operating system's resolver will send a DNS query for the A record to the DNS server 172.16.200.30 .

**STEP2:** The DNS server 172.16.200.30 on receiving the query, will look through its tables(cache) to find the IP address(A record) for the domain www.example.com. But it does not have the entry.

**STEP 3:** As the answer for the query is not available with the DNS server 172.16.200.30, this server sends a query to one of the DNS root server,for the answer. Now an important fact to note here is that root server's are always iterative servers.

**Related:** [DNS root servers and their Locations](http://www.slashroot.in/dns-root-servers-most-critical-infrastructure-internet "DNS root servers Explained")

**STEP 4:** The dns root server's will reply with a list of server's (referral) that are responsible for handling the **.COM** gTLD's.

**STEP 5:**  Our DNS server 172.16.200.30 will select one of the .COM gTLD server from the list given by the root server, to query the answer for "www.example.com"

**STEP 6:** Similar to the root server's , the gTLD server's are also iterative in nature, so it replies back to our DNS server 172.16.200.30 with the list of IP addresses of the DNS server's responsible for the domain(authoritative name server for the domain) www.example.com.

**Related:** [DNS Zone File And Its Contents](http://www.slashroot.in/what-dns-zone-file-complete-tutorial-zone-file-and-its-contents)

**STEP 7:** This time also our DNS server will select one of the IP from the given list of authoritative name servers, and queries the A record for www.example.com. The authoritative name server queried, will reply back with the A record as below.

**www.example.com = <XXX:XX:XX:XX> (Some IP address)**

**STEP 8**: Our DNS server 172.16.200.30 will reply us back with the ip domain pair(and any other resource if available). Now the browser will send request to the ip given, for the web page www.example.com.

Below shown diagram might make the concept clear.

![](https://www.slashroot.in/sites/default/files/recursive%20dns%20query.png)

As you can see from the above figure. Our DNS server(172.16.200.30) queries through other dns server's on behalf of us.

**Note:** The above explained scenario of recursive query happened, only because, our DNS server 172.16.200.30 was configured as a recursive name server. You can also disable this feature for your DNS server. 

### How does the name server select one from the given list of servers to query?

In the above case, you might have seen that our DNS server 172.16.200.30, had to select one server, from the given list of servers to query, multiple times.

For example there are 13 root servers(Well when i say 13 root servers, 13 is the number of addresses that is universal. There are Hundreds of servers at different locations in the world. These 13 root server addresses are anycasted addresses.), which root server will be queried, for an answer?

**Related:** [What is IP Anycast, and how it works?](http://www.slashroot.in/what-anycast-and-how-it-works)

Almost all DNS server's uses an algorithm, to select one from the list, in order to distribute the load and response time.

The most Famous DNS server software BIND uses a technique called as rtt metric(Round Trip Time metric). Using this technique, the server tracks the RTT of each root server, and selects the one,with lower RTT.

## What is an iterative or Non-recursive query?

Before beginning the explanation for iterative query. An important thing to note is that, all DNS server's must support iterative(non-recursive)query.

In an iterative query, the name server, will not go and fetch the complete answer for your query, but will give back a referral to other DNS server's, which might have the answer. In our previous example our DNS server 172.16.200.30, went to fetch the answer on behalf of our resolver, and provided us with the final answer.

But if our DNS server 172.16.200.30 is not a recursive name server(which means its iterative), it will give us the answer if it has in its records. Otherwise will give us the referral to the root servers(it will not query the root server's and other servers by itself.).

Now its the job of our resolver to query the root server, .COM TLD servers, and authoritative name server's, for the answer.

Lets go through the steps involved. 

**STEP 1:** You enter www.example.com in the browser. So the operating system's resolver will send a DNS query for the A record to the DNS server 172.16.200.30 .

**STEP 2:** The DNS server 172.16.200.30 on receiving the query, will look through its tables(cache) to find the IP address(A record) for the domain www.example.com. But it does not have the entry.

**STEP 3:** Now instead of querying the root server's, our DNS server will reply us back with a referral to root servers. Now our operating system resolver, will query the root servers for the answer.

Now the rest of the steps are all the same. The only difference in iterative query is that 

- if the DNS server does not have the answer, it will not query any other server for the answer, but rather it will reply with the referral to DNS root server's
- But if the DNS server has the answer, it will give back the answer(which is same in both iterative and recursive queries)
- in an iterative query, the job of finding the answer(from the given referral), lies to the local operating system resolver.

![](https://www.slashroot.in/sites/default/files/iterative%20dns%20query.png)

It can be clearly noted from the above figure, that in an iterative query, a DNS server queried will never go and fetch the answer for you(but will give you the answer if it already has the answer). But will give your resolver a referral to other DNS server's(root server in our case).

We will be discussing inverse queries in another post. Hope this post was helpful in understanding iterative(non-recursive) & recursive DNS queries.