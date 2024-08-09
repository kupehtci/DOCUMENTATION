#LATEX 

A <span style="color:cyan;">Latex environment</span> is a 




### Comment environment

The comment environment let that all text inside the env, its treated as a comment itself. 

This allows to have multiline comments made easily and clear: 

```LATEX
\usepackage{comment}

\begin{document}
\section{Multi-line comments}

\begin{comment}
This is a comment,
a multi-line comment,
indeed.
\end{comment}

\end{document}
```