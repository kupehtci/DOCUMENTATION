#LATEX 

BibTeX is a reference management software for formatting reference list and in-text citations in combination with <span style="color:orange;">typesetting system LaTeX</span>. 

In LaTex we can include bibliography references in an external file or inside the `.tex` file itself. 

By creating a `.bib` file adjacent to the main tex file, can be linked and cited its references. 

Include the `.bib` file in the LaTeX document by including this commands in the place that bibliography would be rendered: 

```LATEX
\bibliographystyle{your-style} % Choose your bibliography style 
\bibliography{your-bib-file} % Specify the name of your .bib file
```

style can be between: 
* `plain`
* `unsr`
* `abbrv`
* or a custom one

Also replace bib-file with the name or path to the current bibliography `.bib`file. 
To cite you can use `\cite{ref_name}` command. 

```LATEX
%bib 
@article{smith2020,
title={A good example},
journal={ASDASDasdasdas},
year={2021},
volume={13},
pages={2507},
doi={10.34782/asSEDAS2342}, 
}

%LaTeX document
This is a citation: \cite{smith2020}.

\section{Bibliography}
\bibliographystyle{plain}
\bibliography{ref.bib}


```

