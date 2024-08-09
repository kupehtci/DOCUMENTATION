#ML #DEEP_LEARNING #PYTHON 

## METRICS GATHER

Once we have build the model: 

We can search in the same folder as the results, some plots in images about the performance of the model and the validation and test output. 


In the results.png we can found a group of charts with all the metrics along the different <span style="color:orange;">epochs</span> . 
The image would look like this: 

![[Unknown.png]]

In this case we can see the development of certain metrics in the epochs from 0 to 30 iteration comparing train with evaluation.

Analyzing certain metrics:

* `box_loss` — bounding box error ratio. A lower value indicates that predicted boxes are so much close to the real boxes.
* `obj_loss` - the mean error of how likely the object is really in the area selected in the box
* `cls_loss` — the classification loss calculated over cross-entropy. This gives us a measure of the error ratio when predicting a class over an box.

Precision measures how much of bounding boxes are correctly detected compared with the number of boxes that are predicted but are not currently an object.

In other hand, Recall measures how many of the boxes predicted are correctly labeled.

In this case because we are interested in a good recall for detecting which of the mushrooms are from wich type to differ if they are edible or not, is more important to detect correctly between the two types, than being able to detect a mushroom correctly compared with obejcts that are not currently a mushroom.


`mAP_0.5` is the mean Average Precision calculated with a IoU value of 0.5.

`mAP_0.5:0.95`is the same but taking into account a IoU between 0.5 and 0.95.


Because we are not interested in the precision of the image detection, we are interested in the correct classification between the labels, all the measures related to how the images are represented are not as much relevant as Precision and recall.

#### Visual Outputs

When you train a <span style="color:#ababf5;"> YOLOv5 model</span> you ges an an output in the `--name` and `--project`folder that is specified during training, you get a certain charts in an image format. 

- **F1 Score Curve (`F1_curve.png`)**: This curve represents the F1 score across various thresholds. Interpreting this curve can offer insights into the model's balance between false positives and false negatives over different thresholds.

- **Precision-Recall Curve (`PR_curve.png`)**: An integral visualization for any classification problem, this curve showcases the trade-offs between precision and recall at varied thresholds. It becomes especially significant when dealing with imbalanced classes.

- **Precision Curve (`P_curve.png`)**: A graphical representation of precision values at different thresholds. This curve helps in understanding how precision varies as the threshold changes.

- **Recall Curve (`R_curve.png`)**: Correspondingly, this graph illustrates how the recall values change across different thresholds.

- **Confusion Matrix (`confusion_matrix.png`)**: The confusion matrix provides a detailed view of the outcomes, showcasing the counts of true positives, true negatives, false positives, and false negatives for each class.

- **Normalized Confusion Matrix (`confusion_matrix_normalized.png`)**: This visualization is a normalized version of the confusion matrix. It represents the data in proportions rather than raw counts. This format makes it simpler to compare the performance across classes.

- **Validation Batch Labels (`val_batchX_labels.jpg`)**: These images depict the ground truth labels for distinct batches from the validation dataset. They provide a clear picture of what the objects are and their respective locations as per the dataset.

- **Validation Batch Predictions (`val_batchX_pred.jpg`)**: Contrasting the label images, these visuals display the predictions made by the YOLOv8 model for the respective batches. By comparing these to the label images, you can easily assess how well the model detects and classifies objects visually.

By training the model you obtain the mentioned images, but can also be procesed by using <span style="color:orange;background-color:#0909090;">val.py</span>

#### Results Storage

For future reference, the results are saved to a directory, typically named runs/detect/val.