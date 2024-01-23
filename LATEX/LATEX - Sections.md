#LATEX 

### Section and subsection

A section can be used to create a header title with a numeric ordering in a document. 
This section can be ordered with other sections and have subsections inside of it. 

Its used for document sectioning and its one of the 7 levels of depth that can be used for organizing the document: 

|   |   |
|---|---|
|-1|`\part{part}`|
|0|`\chapter{chapter}`|
|1|`\section{section}`|
|2|`\subsection{subsection}`|
|3|`\subsubsection{subsubsection}`|
|4|`\paragraph{paragraph}`|
|5|`\subparagraph{subparagraph}`|
Although `section` is the top-level for most documents, normally scientific ones, its no the top one in the hierarchy. 
This is because `\part` and `\chapter` is more common for books. 


To create a section you can make: 

```LATEX
\section{section_name}
% some text
```

The section would be until another sectioning command is found and would be numbered by order of sections. 

The number can be omited by using `*` between section and section_name: 

```LATEX
\section*{section_name}
%some text
``` 

