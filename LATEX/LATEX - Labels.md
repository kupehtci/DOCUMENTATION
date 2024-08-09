#LATEX 


In LATEX you can actually reference everything that can be numbered and LATEX would automatically update the reference number automatically if changes. 

The command that are independent from what they reference are: 

```LATEX
\label{marker}
% Used to give an object to reference a marker. A name to be referenced later

\ref{marked}
% Used to reference the object labeled

\pageref{marker}
% Prints the page where the speicied marker can be found. 
```

Also can be added a little sufix to indicate what is being referenced: 

ch:**chapter**
sec:**section**
subsec:**subsection**
fig:**figure**
tab:**table**
eq:**equation**
lst:**code listing**
itm:**enumerated list item**
alg:**algorithm**
app:**appendix subsection


Like this: 

```LATEX
\section{Greetings}
\label{sec:greetings}

Hello!

\section{Referencing}

I greeted in section~\ref{sec:greetings}.
```