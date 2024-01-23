#LATEX 

### Latex authors

A single author at the begin of the document before the `\begin{document}` can be declared to be shown in the upper part of the document. 

```LATEX
\author{
    Laplana, Daniel\\
    \texttt{alu.122308@usj.es}
}
```

`\texttt{}` is optional, is a command to use text-mode material in <span style="color:orange;">type writer font</span>. Its kind of a convention for emails in papers to use this type of font. 

Can be shown more than 1 author: 

```LATEX
\title{DYSLEXIA SERIOUS GAME}
\author{
    Laplana, Daniel\\
    \texttt{alu.122308@usj.es}
    \and
    Lorenzo, Jose Manuel\\
    \texttt{alu.120818@usj.es}
    \and
    Azcón, Enrique Borja\\
    \texttt{alu.123200@usj.es}
}
\date{January 2024}
%begin document
\begin{document}
```