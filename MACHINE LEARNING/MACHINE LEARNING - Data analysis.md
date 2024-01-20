#ML 

Data can be analyzed and explored in various ways: 

The most common techniques are: 

### <span style="color:cyan;">Statistical Correlation</span>

Measure of a mutual relationship between two variables whether they are casual together or not. 

This can be represented with a <span style="color:#cd03f5;">heatmap</span>: 

![[correlation_heatmap.png|200]]

### <span style="color:cyan;">Boxplot</span>

Boxplot or outlier box plot can be used to take a look into data spread. 

And the plot is defined by some parts: 

- The center line in the box shows the median for the data. Half of the data is above this value, and half is below. If the data are symmetrical, the median will be in the center of the box. If the data are skewed, the median will be closer to the top or to the bottom of the box.

- The bottom and top of the box show the 25th and 75th quantiles, or percentiles. These two quantiles are also called quartiles because each cuts off a quarter (25%) of the data. The length of the box is the difference between these two percentiles and is called the interquartile range (IQR).

- The lines that extend from the box are called whiskers. The whiskers represent the expected variation of the data. The whiskers extend 1.5 times the IQR from the top and bottom of the box.

If data falls in the <span style="color:orange;">whiskers</span> its drawn as a dot and considered an outlier because is outside IQR. 

![[understanding-box-plot-diagram.webp]]