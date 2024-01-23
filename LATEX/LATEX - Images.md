#LATEX

Images requires from the `graphicx` package that can be inserted like: 
```LATEX
\usepackage{graphicx}
\graphicspath{ {./images/} }
```

Also using `\graphicspath{ {./images/} }` tells LATEX that images are kept within a folder path named images/ in the same directory as the `.tex`. 
### How to insert images in LATEX

```LATEX
\begin{figure}
    \centering
    \includegraphics[width=0.5\linewidth]{dislexic-bar-chart.png}
    \caption{Enter Caption}
    \label{fig:enter-label}
\end{figure}
```


### Using environments

When setting images, can be placed inside a new <span style="color:cyan;">environment</span> 

```LATEX
\begin{figure}[h]
\includegraphics[width=8cm]{Plot}
\end{figure}
```

This allows to use

#### Image size

Overall scale or width and height parameters can be adjusted: 

```LATEX
\includegraphics[scale=1.5]{overleaf-logo}.  %general scale modify
\includegraphics[width=5cm, height=4cm]{overleaf-logo}.  %width and height adjustment
\includegraphics[width=\textwidth]{universe}. %relative to text width 
\includegraphics[scale=1.2, angle=45]{overleaf-logo}. % rotate a certain angle
```

### Centering images

You can center images without using `\begin{figure}` by just using `\begin{center}`: 

```LATEX
\begin{center}    
    \includegraphics[width=1\linewidth]{images/dislexic-bar-chart.png}
    \captionof{figure}{Dyslexic bar chart}
    \label{fig:dislexic-bar}
\end{center}
```


### Reference images

To reference to an image dynamic, you can enter a `\label{}`  [[LATEX - Labels]]. 