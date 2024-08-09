### IoU (Intersection over Union)

A measurement that finds the difference between the ground truth annotations and the predicted bounding boxes. This metric is used in the state of the art object detection algorithms. In object detection, the model predicts multiple bounding boxes for each object and removes unnecessary boxes depending on the threshold value based on the confidence scores of each bounding box. A threshold value is determined according to requirements. If the IoU value is greater than the threshold value, it is taken as an object, otherwise, the box is removed.

<div style="color: white; border: 1px solid white; border-radius: 0.3rem; padding:1rem; width: max-content; ">   IOU = Area of union / Area of intersection      </span>

IoU Is a measure of the distance between the predicted box and the truth box. Measures the distance and difference between them.

Its calculated dividing the intersection area between each bounding box and the total area of them joined.

![[Pasted image 20231215134856.png]]

This metric is calculated by dividing the two areas. 

![[Pasted image 20231215134940.png]]

A IoU value for the prediction over 0.5 is considered as a good value. 
