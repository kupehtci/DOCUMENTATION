#JS #HTML 

Javascript is meant to use in combination with HTML for web development


### Where to place \<script\>

The location of the script changes completelly the invocation of the code. 

|Location| How it gets downloaded? |State of the webpage|
|---|---|---|
|In `<head>`|**BEFORE** starting to draw the page|Page not draw yet|
|In `<body>`|**WHILE** the drawing|Draw until the tag `<script>`.|
|Before `</body>`|**AFTER** drawing the page|100% drawn|

If we want to be executed before the webpage gets show, needs to be placed in the `<head>`
