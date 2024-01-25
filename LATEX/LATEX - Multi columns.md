#LATEX 

Text can be distributed within various columns by using `multicols` package: 

```LATEX
\usepackage{multicol}

\begin{multicols}{2}

\section{Hello world}
\blindtext
\end{multicols}
```

You can avoid some items to be in the `multicolum` format by placing them within `[]`.

```LATEX
\usepackage{multicol}

\begin{multicols}{2}
[
\section{abstract}
\blindtext
]
\section{Hello world}
\blindtext
\end{multicols}
```

This would look this way: 

![[abstract-example.png|400]]