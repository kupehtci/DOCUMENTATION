#PYTHON #ML 
# **Configuration files**

The configurations for the training are divided to three YAML files, which are provided with the repo itself. We will customize these files depending on the task, to fit our desired needs.

1. The **data-configurations file** describes the dataset parameters. Since we are training on our custom penguins dataset, we will edit this file and provide: the paths to the train, validation and test (optional) datasets; the number of classes (nc); and the names of the classes in the same order as their index. In this tutorial we only have one class, named ‘Penguin’. We named our custom data configurations file as ‘penguin_data.yaml’ and placed it under the ‘data’ directory. The content of this YAML file is as follow:

![](https://miro.medium.com/v2/resize:fit:1400/1*Igc2asE5sIIqUPY_K9Kexw.png)

2. The **model-configurations file** dictates the model architecture. Ultralytics supports several YOLOv5 architectures, named P5 models, which varies mainly by their parameters size: YOLOv5n (nano), YOLOv5s (small), YOLOv5m (medium), YOLOv5l (large), YOLOv5x (extra large). These architecture are suitable for training with image size of 640*640 pixels. Additional series, that is optimized for training with larger image size of 1280*1280, called P6 (YOLOv5n6, YOLOv5s6, YOLOv5m6, YOLOv5l6, YOLOv5x6). P6 models include an extra output layer for detection of larger objects. They benefit the most from training at higher resolution, and produce better results [4].

Ultralytics provides build-in, model-configuration files for each of the above architectures, placed under the ‘models’ directory. 
If you are training from scratch to detect objects within the built-in classesm just train using the YOLOv5s6 model and just edit the number of classes (nc) parameter to the correct number of classes in your custom data.

```YAML
nc: 1;  
```

When training is initialized from pre-trained weights as in this tutorial, no need to edit the model-configurations file since the model will be extracted with the pretrained weights.

3. **The hyperparameters-configurations file** defines the hyperparameters for the training, including the learning rate, momentum, losses, augmentations etc. Ultralytics provides a default hyperparameters file under the ‘data/hyp/hyp.scratch.yaml’ directory. It is mostly recommended to start training with default hyperparameters to establish a performance baseline, as we’ll do on this tutorial.
# **Training**

For the simplicity of this tutorial, we will train the small parameters size model YOLOv5s6, though bigger models can be used for improved results. Different training approaches might be considered for different situations, and here we will cover the most commonly used techniques.


How to train with a custom dataset using YOLOv5. [[YOLOv5 - Basic training]]
Basic training with weights prebuild :   [[YOLOv5 - Training from scratch]]