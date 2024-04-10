#SoftwareQuality 

## CODE REVIEWS

Code reviews are meant to prevent defects that affect the <span style="color:MediumSlateBlue;">internal quality</span> of a software product. 

Its main characteristics is that some people (Reviewers) review the code of the author or developers and provide feedback in order to improve the code. 


There are two main types of code reviews: 

##### FORMAL REVIEWS

Require an established procedure, meeting with a set of members and showing the code and fulfill a set of checklist. 

Planning --> Introductory meeting --> Inspection Meeting --> Rework --> Verification Meeting --> Complete


Or a <span style="color:MediumSlateBlue;">formal walkthrough</span> where some test cases are choossen and then mentally executed. 

##### INFORMAL REVIEWS

In order to minimize the time and cost of this QA activities, a more informal reviews can be done: 

* Over-the-shoulder: 

A developer (reviewer) standing over developer's computer while the author do a review though the set of code changes. 
Its <span style="color:green;">simple, encourage people to cooperate and increase feedback</span>. 
On the other hand, it requires people <span style="color:red;">to be in the same place, no traceability (no data fulfilled) and very-author driven</span>. 

* Offline reviews: 

The author submits the code to be reviewed and a peer can review it without being with the developer during the review. 

Advantages: <span style="color:green;">Simple, works well remotelly and its traceable</span>
Disadvantages: <span style="color:red;">takes longer and missed cooperation</span>

By using <span style="color:MediumSlateBlue;">SCM tools</span>, this kind of reviews are easily implemented (e.g. Github). 


