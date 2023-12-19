
 Images of different formats and sizes have been converted to the same format. Then the images are labeled in YOLO format with the labelImg tool. The number of images concerning the classes is not equal. Besides, the number of images given to training and validation for each class was also kept different. In this way, it was aimed to observe the effect of the number of images on the training results. The number of images belonging to each category is as in table 1.


The YOLO algorithm is one of the one-step object detectors. Many versions of the algorithm have come out since the day it was published. Yolov5 was used in the study. The pipeline consists of three parts: backbone, neck, and head. In the model; CSPNET is preferred as a backbone. It extracts important features from the input image. The neck is used to produce feature pyramids. PANET is used here. The head is used to decide the final part. YOLOv5 uses the same head structure as the previous YOLOV3 [36].

Yolov5 has four different models: yolov5s, Yolov5m, Yolov5l and yolov5x. These models are pre-trained with an 80 class MSCOCO dataset. We used the largest model, Yolov5x, to get more accuracy. We trained the model with our poisonous mushrooms dataset. While 70% of the data was used for the training process, the remaining 30% was used for validation. The training process was carried out in a computer environment with Nvidia Geforce Gtx 950M GPU support. Other details of the training are as shown in table 2.



