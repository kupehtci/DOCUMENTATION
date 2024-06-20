#### DESCRIPTION

On 31st December 2008 all the Microsoft's Zune players stopped working. Microsoft said that players should function properly once fully charged and switched on again on 1st January.

This is an excerpt of the news:

> "In what appears to be the biggest worldwide device failure in consumer electronics history, tens of thousands of owners of Microsoft's Zune turned on the music player Wednesday morning only to discover it was the day the music died. By early afternoon, Microsoft released a statement saying the problem, which affected the original 30-gigabyte model of the Zune that first went on sale in September 2006, was solved. The issue: a bug in the way the gadget's internal clock handles a leap year.”


The bug occurred in the following piece of code:

```c
year = ORIGINYEAR; /* = 1980 */

while (days > 365){

  if (IsLeapYear(year)) {       

    if (days > 366)     {            
      days -= 366;            
      year += 1;   
    }    

  }  else{        
    days -= 365;        
    year += 1;    
  }
}
```


#### WORKING CODE  

- The bug: [https://jsfiddle.net/dcoloma/apby8kwz/](https://jsfiddle.net/dcoloma/apby8kwz/) 
- A simple solution: [https://jsfiddle.net/dcoloma/k3tcdsw5/](https://jsfiddle.net/dcoloma/k3tcdsw5/)  
- A more complex solution: [https://jsfiddle.net/dcoloma/tmcxnq35/](https://jsfiddle.net/dcoloma/tmcxnq35/)

#### QUESTIONS FOR YOU

- What was the fault that the developer made?
- Describe situations in which the fault lead to an error situation?
- Are there any situations in which the fault does not lead to an error situation?
- Why the error is always leading to a failure? Is there any way to avoid it

--- 

Practice case for Software Quality subject.