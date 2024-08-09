#ML #DEEP_LEARNING #OBJECT_RECOGNITION 

 
# Segmentation algorithm

Once a segmentation algorithm is applied to the image and region proposals (bounding boxes) are draws based on the segmentation map. 
This <span style="color:MediumSlateBlue;">segmentation map</span> is iteratively merged and region proposals are drawn from a refined map using <span style="color:orange;">Non-Max suppression</span>. 
 
# **Non-Max Suppression:**

The algorithm may find multiple detections of the same object. Non-max suppression is a technique by which the algorithm detects the object only once. 

Consider an example where the algorithm detected three bounding boxes for the same object. The boxes with respective probabilities are shown in the image below.

![](https://miro.medium.com/v2/resize:fit:1400/1*tRhnFJ7_Rw2lH613rLNvNw.jpeg)
\*\*Bounding boxes for the same object with their confidence tagged\*\*

The probabilities of the boxes are 0.7, 0.9, and 0.6 respectively. To remove the duplicates, we are first going to select the box with the highest probability and output that as a prediction. Then eliminate any bounding box with IoU > 0.5 (or any threshold value) with the predicted output. The result will be:

![](https://miro.medium.com/v2/resize:fit:1400/1*mJXACfW3I5vuP8j1PJCeBA.jpeg)
