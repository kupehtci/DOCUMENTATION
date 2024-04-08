#NETWORKING 


### DNS

The DNS or Domain Name System is the most important **open** and **free** infrastructure. 

Hostnames provide low information about the location of a host in the internet, but are more easy to memorize to humans. On other hand, IP provides a lot of information for locating the hosts but are hard to memorize, so the solution is to translate the hostname into the IP using the <span style="color:orange;">DNS system</span>. 
# What are the different types of DNS queries?

DNS queries can be classified according the manner in which a complete request is processed. Generally queries can be classified as follows.

* ***recursive query**
* *iterative query OR Nonrecursive query**
* ***Inverse queries**

### AUTHORITATIVE RESPONSES

Because all DNS server not stores all records available, the different DNS queries can be temporally stored in a DNS server cache (to reduce network traffic) can be consulted until the DNS server expires them or are renew again.

If the server not always store that DNS records and its only in its cache, the response of the query would be non-authoritative. 

On other hand, if the server always store that DNS record, it would response an <span style="color:MediumSlateBlue;">authoritative</span> response. 

## What is a recursive query?

A recursive query is a kind of query, in which the DNS server, who received your query will do all the job of fetching the answer, and giving it back to you. During this process, the DNS server might also query other DNS server's in the internet on your behalf, for the answer.

As summary, the server consulted is on charge of consulting other NS records servers in order to find the A, AAAA ... requested record. 

Below shown diagram might make the concept clear.

![](https://www.slashroot.in/sites/default/files/recursive%20dns%20query.png)



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