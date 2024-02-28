#SoftwareQuality 


Section 1.2 - What is Software Quality

The last definition about Software Quality. View 4: ISO 9126. Process + Internal + External + In-use. 

6 Attributes:
* Reliability
* Functionality
* Usability
* Efficiency
* Maintainability
* Portability
The importance of these attributes is different for every type of product. The importance of those attributes might be even different, for the same product, depending on the user (e.g. the cars example)

In any case, as Jeff Atwood mentions in the video we watched, the key thing to produce software that has impact on the users is solving a problem they have and making them feel great when using it.


Section 1.3 - Some additional definitions related to quality:

Technical Debt: sometimes we need to take suboptimal decisions in order to launch our product faster. This is only acceptable if it’s done consciously, with a plan to fix it later, otherwise it’s just doing bad things for the sake of it. The risk of this approach is that product is not sustainable, if we try to evolve it it’s going to be impossible. And a successful software product must be in continuous evolution.
Validation vs. Verification:
Verification: Formal, Meeting the requirements, building the product right
Validation: Informal, Meeting user needs, building the right product


Key Definitions:

* Bug/Defect/Fault: The error made by the developer (a mistake in the source code)
* Error Situation: When the code goes through the bug and gets into an unexpected situation (happens during execution time)
* Failure: When the error situation has an impact to the end-user (it happens during execution time but affecting end-users). Important: Not all the bugs lead always to error situations and to failures.


Some examples of bugs: 
* Therac-25: Bug (race condition) was always there, but it only ended-up in failures when the operators of the system typed the comands very fast: the failure depended on the speed of the user. Key takes: i/ software may fail depending on the speed of the users using it. ii/ when dealing when people's health, failure impact minimization is key.
* Zune Player: When the error situation has an impact to the end-user (it happens during execution time but affecting end-users). Important: Not all the bugs lead always to error situations and to failures. Key takes: i/ software may fail depending on external aspects (the date in which it's executed, connnection is not available, etc.) - we need to take that into account ii/ the concept of limited blast radius is the opposite to what Microsoft did here, a problem with the date calculation make the whole system un-usable.