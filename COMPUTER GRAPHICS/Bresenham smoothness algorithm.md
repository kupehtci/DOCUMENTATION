#COMPUTER_GRAPHICS 

### BRESENHAM SMOOTHNESS ALGORITHM

Bresenham is a line drawing algorithm to smooth this line and make it representable in a pixel matrix like a screen or a grid. 

This algorithm determines the points in a n-dimensional raster that need to be selected in order to represent a <span style="color:orange;">straight line</span>. 

Can also be used for smoothing paths in pathfinding : [[Pathfinding]]. 

$f(x) = y = .5x +1$
$f(x, y) = x - 2y +2$


This algorithm is cheap because is based in an incremental error algorithm, that "stores" the error acumulated by the slope of the line to determine the pixels that can represent that line. 