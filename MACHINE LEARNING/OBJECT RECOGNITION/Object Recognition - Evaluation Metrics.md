
There are many measurement criteria used to evaluate the performance of an object detection model. Intersection over Union (IoU) Precision, Recall, Average Precision (AP), and mean Average Precision (mAP) can be given as examples of the most used criteria [39].

#### Precision

Precision is the metric used to measure correct predictions. It is calculated as in equation (2).

Precision= TP/(TP+FP) (2)

#### Recall

Recall is the true positive rate. It measures the probability that exact reference objects will be detected correctly. It is calculated as in equation (3).

Recall= TP/(TP+FN) (3)

#### Average Precision (AP)
<span style="color:#ababf5;">AP</span> is another criterion used to evaluate the performance of object detectors. It includes precision and recall. It is a single number metric that summarizes the Precision-Recall curve by averaging the recall values from 0 to 1. It is calculated with the equation given in 11-point interpolated AP (4).

<span style="color:#ababf5;">mAP</span> If the dataset contains M class category while calculating mAP, it takes AP average over M classes [41]. mAP is calculated as in equation (5).

![[Captura de pantalla 2023-12-13 a las 17.38.00.png]]

#### CONFIDENCE

<span style="color:#ababf5;">Confidence</span> is the score that measures how likely the obejct is withing the bounding box. 



