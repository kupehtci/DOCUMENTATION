#PYTHON #ML 

---
## Training from scratch (no weights) and Parameter Tunning

For the simplicity of this tutorial, we will train the small parameters size model YOLOv5s6, though bigger models can be used for improved results. Different training approaches might be considered for different situations, and here we will cover the most commonly used techniques.

### Training from scratch

When having a large enough dataset, the model will benefit most by training from scratch. The weights are randomly initialized by passing an empty string (‘ ‘) to the weights argument. Training is induced by the following command:

![](https://miro.medium.com/v2/resize:fit:1400/1*mzPShrF4E6qo3B8O4gArVg.png)

- batch — batch size (-1 for auto batch size). Use the largest batch size that your hardware allows for.
- epochs — number of epochs.
- data — path to the data-configurations file.
- cfg — path to the model-configurations file.
- weights — path to initial weights.
- cache — cache images for faster training.
- img — image size in pixels (default — 640).

### Transfer learning

#### Hot start from pretrained model:

Since my penguins dataset is relatively small (~250 images), transfer learning is expected to produce better results than training from scratch. Ultralytic’s default model was pre-trained over the COCO dataset, though there is support to other pre-trained models as well (VOC, Argoverse, VisDrone, GlobalWheat, xView, Objects365, SKU-110K). 

<span style="color:cyan; text-decoration:underline;">COCO</span> is an object detection dataset with images from everyday scenes. It contains 80 classes, including the related ‘bird’ class, but not a ‘penguin’ class. Our model will be initialize with weights from a pre-trained COCO model, by passing the name of the model to the ‘weights’ argument. The pre-trained model will be automatically download.

#### Feature extraction

Models are composed of two main parts: the backbone layers which serves as a feature extractor, and the head layers which computes the output predictions. To further compensate for a small dataset size, we’ll use the same backbone as the pretrained COCO model, and only train the model’s head. YOLOv5s6 backbone consists of 12 layers, who will be fixed by the ‘freeze’ argument.

```PYTHON
python train.py --batch 32 --epochs 150 --data 'data/penguins_data.yaml' --weights `yolo5s6.pt' --cache --freeze 12 --project 'run_penguins' --name 'feature_extraction' 
```

- weights — path to initial weights. COCO model will be downloaded automatically when specified <span style="color:cyan;">weights</span> are from YOLO directories. 
- freeze — number of layers to freeze
- project— name of the project
- name — name of the run

If ‘project’ and ‘name’ arguments are supplied, the results are automatically saved there. Else, they are saved to ‘runs/train’ directory. We can view the metrics and losses saved to results.png file:

```PYTHON 
display.Image(f"runs_penguins/feature_extraction/results.png"; 
```

![](https://miro.medium.com/v2/resize:fit:1400/1*XQeZp8enQ-Xu-99aCn8caQ.png)

Results of ‘feature extraction’ training | image by author

To better understand the results, let’s summarize YOLOv5 losses and metrics. YOLO loss function is composed of three parts:

1. **box_loss** — bounding box regression loss (Mean Squared Error).
2. **obj_loss** — the confidence of object presence is the objectness loss.
3. **cls_loss** — the classification loss (Cross Entropy).

Since our data has one class only, there are no class mis-identifications, and the classification error is constantly zero.

<span style="color:orange;">Precision</span> measures how much of the bboxpredictions are correct ( True positives / (True positives + False positives))

<span style="color:orange;">Recall</span> measures how much of the true bbox correctly predicted ( True positives / (True positives + False negatives)).

<span style="color:orange;">‘mAP_0.5’</span> is the mean Average Precision (**mAP**) at IoU (Intersection over Union) threshold of 0.5. ‘ mAP_0.5:0.95’ is the average mAP over different IoU thresholds, ranging from 0.5 to 0.95. You can read more about it at reference [5].

#### Fine Tuning

The final optional step of training is fine-tuning, which consists of un-freezing the entire model we obtained above, and re-training it on our data with a very low learning rate. This can potentially achieve meaningful improvements, by incrementally adapting the pretrained features to the new data. The learning rate parameter can be adjusted at the hyperparameters-configurations file. For the tutorial demonstration, we’ll adopt the hyperparameters defined at built-in ‘hyp.finetune.yaml’ file, which has much smaller learning rate then the default. The weights will be initialized with the weights saved on the previous step.

python train.py --hyp 'hyp.finetune.yaml' --batch 16 --epochs 100 --data 'data/penguins_data.yaml' --weights 'runs_penguins/feature_extraction/weights/best.pt' --project 'runs_penguins' --name 'fine-tuning' --cache

- hyp — path to the hyperparameters-configurations file

As we can see below, during fine tuning stage the metrics and losses are still improving.

![](https://miro.medium.com/v2/resize:fit:1400/1*WFRgRjpN9caEjcMmw34dyw.png)

# **Validation**

To evaluate our model we’ll utilize the validation script. Performances can be evaluated over the training, validation or test dataset splits, controlled by the ‘task’ argument. Here, the test dataset split is being evaluated:

![](https://miro.medium.com/v2/resize:fit:1400/1*zfeJAMU7ILzHekx_rC2Syw.png)

We can also obtain the Precision-Recall curve, which automatically saved at each validation.

![](https://miro.medium.com/v2/resize:fit:1400/1*OgAGKah5NOGdrDEbwgpImQ.png)

Precision — Recall Curve of the test data split | Image by author

# **Inference**

Once we obtained satisfying training performances, our model is ready for inference. ==Upon inference, we can further boost the predictions accuracy by applying test-time augmentations (TTA): each image is being augmented (horizontal flip and 3 different resolutions), and the final prediction is an ensemble of all these augmentation==. If we’re tight on the Frames-Per-Second (FPS) rate, we’ll have to ditch the TTA since the inference with it is 2–3 times longer.

The input for inference can be an image, a video, a directory, a webcam, a stream or even a youtube link. In the following detection command the test data is used for inference.

![](https://miro.medium.com/v2/resize:fit:1400/1*92CIezUMH4XwBuffPZthEg.png)

- source — input path (0 for webcam)
- weights — weights path
- img — image size for inference, in pixels
- conf — confidence threshold
- iou — IoU threshold for NMS (Non Max Supression)
- augment — augmented inference (TTA)

Inference results are automatically saved to the defined folder. Let’s review a sample of the test predictions:

![](https://miro.medium.com/v2/resize:fit:1400/1*7Ejlh-TKWVtEbV16RYFixg.jpeg)

Take a look into: 
[[Object Recognition - Basics]]

[[YOLOv5 - Configuration Files]]

[[YOLOv5 - Basic training]]



WEBPAGE of reference: 

[YOLO TRAINING](https://towardsdatascience.com/the-practical-guide-for-object-detection-with-yolov5-algorithm-74c04aac4843)