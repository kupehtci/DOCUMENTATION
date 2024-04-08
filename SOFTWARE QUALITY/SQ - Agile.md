#CONCEPTS 

### Software quality in Agile methodology

While developing software using <span style="color:orange;">agile methodology</span>, software quality also be ensured, taking into account various aspects: 

##### 1 - USER STORIES

User Story: Every user story should have a clear definition and:  
- Acceptance Criteria
- At least 10 Test Cases
##### 2 - WORKFLOW  

During the workflow we have to take into consideration: 
- Engineers should mark a <span style="color:MediumSlateBlue;">User Story</span> as completed when they have finished their work and merged it into master branch.
- No code will be merged in the master branch without a peer review of the code (see 3)
- When a user story is marked as completed, QA Engineers will execute the defined test cases for all the supported browser (Chrome, Firefox, Safari). (see 4)

##### 3 - CODE REVIEWS

When doing code reviews by other users: 
- No code can be merged without a peer review
- Only code owner or peers for a given component can review code for that component. 
- Code Reviews must be registered in GitHub or other tools. 

##### 4 - TEST CASES EXECUTION  

When a QA Engineer has executed all the test cases for that particular user story they will:  

- Register the execution of the test cases in the tool XXX.
- Register all the bugs detected in the tool XXX.
- Indicate the severity of all the bugs.
- If all the criteria for the Definition of Done (see 5) are met, it will mark the <span style="color:MediumSlateBlue;">user story</span> as "DONE”, if not, it will mark it as "YYYY”.

##### 5 - DEFINITION OF DONE  

A <span style="color:MediumSlateBlue;">user story</span> is done when:  

- The criteria for the number of test cases is met    
- Code Peer Reviewed
- It includes at least 1 new automatic regression test case
- The user story test cases have been executed for all the target browsers by QA Engineers
- No major bug has been reported as a result of the execution of the user story test cases.
- Regression Tests have been executed automatically when code was merged and no regression has been detected (see 6) 
    

##### 6 - REGRESSION TESTS  

Every time a new commit is merged into the <span style="color:MediumSlateBlue;">master branch</span>:  

- A new build is generated automatically
- A set of regression tests is automatically executed
- The result of the execution of the regression test is recorded. If not successful, an e-mail is sent to the Release Manager and merges are not allowed.