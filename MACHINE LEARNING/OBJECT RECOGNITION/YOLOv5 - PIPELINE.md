
## Before You Start

Clone repo and install [requirements.txt](https://github.com/ultralytics/yolov5/blob/master/requirements.txt) in a [**Python>=3.7.0**](https://www.py environment, including [**PyTorch>=1.7**](https://pytorch.org/get-started/locally/). Models and datasets download automatically from the latest YOLOv5 [release](https://github.com/ultralytics/yolov5/releases).

```shell
git clone https://github.com/ultralytics/yolov5  # clone
cd yolov5
pip install -r requirements.txt  # install
```

## Train On Custom Data

[![](https://github.com/ultralytics/assets/raw/main/im/integrations-loop.png)](https://bit.ly/ultralytics_hub)  
  

Creating a custom model to detect your objects is an iterative process of collecting and organizing images, labeling your objects of interest, training a model, deploying it into the wild to make predictions, and then using that deployed model to collect examples of edge cases to repeat and improve.

### 1. Create Dataset

YOLOv5 models must be trained on labelled data in order to learn classes of objects in that data. There are two options for creating your dataset before you start training:

Use [Roboflow](https://roboflow.com/?ref=ultralytics) to create your dataset in YOLO format 🌟

### 1.1 Collect Images

Your model will learn by example. Training on images similar to the ones it will see in the wild is of the utmost importance. Ideally, you will collect a wide variety of images from the same configuration (camera, angle, lighting, etc.) as you will ultimately deploy your project.

If this is not possible, you can start from [a public dataset](https://universe.roboflow.com/?ref=ultralytics) to train your initial model and then [sample images from the wild during inference](https://blog.roboflow.com/computer-vision-active-learning-tips/?ref=ultralytics) to improve your dataset and model iteratively.

### 1.2 Create Labels

Once you have collected images, you will need to annotate the objects of interest to create a ground truth for your model to learn from.

[![](https://camo.githubusercontent.com/25db1cf12486b46356c3bbe82b587176883ae44c880b94a21bf6f1ce7907d4dd/68747470733a2f2f75706c6f6164732d73736c2e776562666c6f772e636f6d2f3566366263363065363635663534353435613165353261352f3631353261323735616434623461633230636432653231615f726f626f666c6f772d616e6e6f746174652e676966)](https://app.roboflow.com/?model=yolov5&ref=ultralytics "Create a Free Roboflow Account")

[Roboflow Annotate](https://roboflow.com/annotate?ref=ultralytics) is a simple web-based tool for managing and labeling your images with your team and exporting them in [YOLOv5's annotation format](https://roboflow.com/formats/yolov5-pytorch-txt?ref=ultralytics).

### 1.3 Prepare Dataset for YOLOv5

Whether you [label your images with Roboflow](https://roboflow.com/annotate?ref=ultralytics) or not, you can use it to convert your dataset into YOLO format, create a YOLOv5 YAML configuration file, and host it for importing into your training script.

[Create a free Roboflow account](https://app.roboflow.com/?model=yolov5&ref=ultralytics) and upload your dataset to a `Public` workspace, label any unannotated images, then generate and export a version of your dataset in `YOLOv5 Pytorch` format.

Note: YOLOv5 does online augmentation during training, so we do not recommend applying any augmentation steps in Roboflow for training with YOLOv5. But we recommend applying the following preprocessing steps:

![](https://camo.githubusercontent.com/3589d5a5dbe29a713cdc33f48c703f3c6f239ee963229b97ba0130865864f6fa/68747470733a2f2f75706c6f6164732d73736c2e776562666c6f772e636f6d2f3566366263363065363635663534353435613165353261352f3631353261323733343737666363663432613066643364365f726f626f666c6f772d70726570726f63657373696e672e706e67 "Recommended Preprocessing Steps")

- **Auto-Orient** - to strip EXIF orientation from your images.
- **Resize (Stretch)** - to the square input size of your model (640x640 is the YOLOv5 default).

Generating a version will give you a point in time snapshot of your dataset so you can always go back and compare your future model training runs against it, even if you add more images or change its configuration later.

![](https://camo.githubusercontent.com/9d29e9b67812709641e607c250527412b8dde257e759ecd27864792109ee675f/68747470733a2f2f75706c6f6164732d73736c2e776562666c6f772e636f6d2f3566366263363065363635663534353435613165353261352f3631353261323733336664316461393433363139393334655f726f626f666c6f772d6578706f72742e706e67 "Export in YOLOv5 Format")

Export in `YOLOv5 Pytorch` format, then copy the snippet into your training script or notebook to download your dataset.

![](https://camo.githubusercontent.com/ed652a62fbab5476de2e8adc57aecf8993f49a1bba06ab096f8876414ca5edd6/68747470733a2f2f75706c6f6164732d73736c2e776562666c6f772e636f6d2f3566366263363065363635663534353435613165353261352f3631353261323733613932653466356362373235393464665f726f626f666c6f772d736e69707065742e706e67 "Roboflow dataset download snippet")

Now continue with `2. Select a Model`.

Or manually prepare your dataset

### 2. Select a Model

Select a pretrained model to start training from. Here we select [YOLOv5s](https://github.com/ultralytics/yolov5/blob/master/models/yolov5s.yaml), the second-smallest and fastest model available. See our README [table](https://github.com/ultralytics/yolov5#pretrained-checkpoints) for a full comparison of all models.

![YOLOv5 Models](https://github.com/ultralytics/yolov5/releases/download/v1.0/model_comparison.png)

### 3. Train

Train a YOLOv5s model on COCO128 by specifying dataset, batch-size, image size and either pretrained `--weights yolov5s.pt` (recommended), or randomly initialized `--weights '' --cfg yolov5s.yaml` (not recommended). Pretrained weights are auto-downloaded from the [latest YOLOv5 release](https://github.com/ultralytics/yolov5/releases).

```shell
# Train YOLOv5s on COCO128 for 3 epochs
$ python train.py --img 640 --batch 16 --epochs 3 --data coco128.yaml --weights yolov5s.pt
```

💡 ProTip: Add `--cache ram` or `--cache disk` to speed up training (requires significant RAM/disk resources).  
💡 ProTip: Always train from a local dataset. Mounted or network drives like Google Drive will be very slow.

All training results are saved to `runs/train/` with incrementing run directories, i.e. `runs/train/exp2`, `runs/train/exp3`etc. For more details see the Training section of our tutorial notebook. [![Open In Colab](https://camo.githubusercontent.com/84f0493939e0c4de4e6dbe113251b4bfb5353e57134ffd9fcab6b8714514d4d1/68747470733a2f2f636f6c61622e72657365617263682e676f6f676c652e636f6d2f6173736574732f636f6c61622d62616467652e737667)](https://colab.research.google.com/github/ultralytics/yolov5/blob/master/tutorial.ipynb) [![Open In Kaggle](https://camo.githubusercontent.com/a08ca511178e691ace596a95d334f73cf4ce06e83a5c4a5169b8bb68cac27bef/68747470733a2f2f6b6167676c652e636f6d2f7374617469632f696d616765732f6f70656e2d696e2d6b6167676c652e737667)](https://www.kaggle.com/ultralytics/yolov5)

Note about how to train a model using YOLOv5: [[YOLOv5 - Basic training]]

### 4. Visualize

#### Comet Logging and Visualization 🌟 NEW

[Comet](https://bit.ly/yolov5-readme-comet) is now fully integrated with YOLOv5. Track and visualize model metrics in real time, save your hyperparameters, datasets, and model checkpoints, and visualize your model predictions with [Comet Custom Panels](https://bit.ly/yolov5-colab-comet-panels)! Comet makes sure you never lose track of your work and makes it easy to share results and collaborate across teams of all sizes!

Getting started is easy:

```shell
pip install comet_ml  # 1. install
export COMET_API_KEY=<Your API Key>  # 2. paste API key
python train.py --img 640 --epochs 3 --data coco128.yaml --weights yolov5s.pt  # 3. train
```

To learn more about all of the supported Comet features for this integration, check out the [Comet Tutorial](https://github.com/ultralytics/yolov5/tree/master/utils/loggers/comet). If you'd like to learn more about Comet, head over to our [documentation](https://bit.ly/yolov5-colab-comet-docs). Get started by trying out the Comet Colab Notebook:[![Open In Colab](https://camo.githubusercontent.com/84f0493939e0c4de4e6dbe113251b4bfb5353e57134ffd9fcab6b8714514d4d1/68747470733a2f2f636f6c61622e72657365617263682e676f6f676c652e636f6d2f6173736574732f636f6c61622d62616467652e737667)](https://colab.research.google.com/drive/1RG0WOQyxlDlo5Km8GogJpIEJlg_5lyYO?usp=sharing)

![yolo-ui](https://user-images.githubusercontent.com/26833433/202851203-164e94e1-2238-46dd-91f8-de020e9d6b41.png)

#### ClearML Logging and Automation 🌟 NEW

[ClearML](https://cutt.ly/yolov5-notebook-clearml) is completely integrated into YOLOv5 to track your experimentation, manage dataset versions and even remotely execute training runs. To enable ClearML:

- `pip install clearml`
- run `clearml-init` to connect to a ClearML server (**deploy your own open-source server [here](https://github.com/allegroai/clearml-server)**, or use our free hosted server [here](https://cutt.ly/yolov5-notebook-clearml))

You'll get all the great expected features from an experiment manager: live updates, model upload, experiment comparison etc. but ClearML also tracks uncommitted changes and installed packages for example. Thanks to that ClearML Tasks (which is what we call experiments) are also reproducible on different machines! With only 1 extra line, we can schedule a YOLOv5 training task on a queue to be executed by any number of ClearML Agents (workers).

You can use ClearML Data to version your dataset and then pass it to YOLOv5 simply using its unique ID. This will help you keep track of your data without adding extra hassle. Explore the [ClearML Tutorial](https://github.com/ultralytics/yolov5/tree/master/utils/loggers/clearml) for details!

[![ClearML Experiment Management UI](https://github.com/thepycoder/clearml_screenshots/raw/main/scalars.jpg)](https://cutt.ly/yolov5-notebook-clearml)

#### Local Logging

Training results are automatically logged with [Tensorboard](https://www.tensorflow.org/tensorboard) and [CSV](https://github.com/ultralytics/yolov5/pull/4148) loggers to `runs/train`, with a new experiment directory created for each new training as `runs/train/exp2`, `runs/train/exp3`, etc.

This directory contains train and val statistics, mosaics, labels, predictions and augmentated mosaics, as well as metrics and charts including precision-recall (PR) curves and confusion matrices.

![Local logging results](https://github.com/ultralytics/yolov5/releases/download/v1.0/image-local_logging.jpg)

Results file `results.csv` is updated after each epoch, and then plotted as `results.png` (below) after training completes. You can also plot any `results.csv` file manually:

```python
from utils.plots import plot_results
plot_results('path/to/results.csv')  # plot 'results.csv' as 'results.png'
```

![results.png](https://github.com/ultralytics/yolov5/releases/download/v1.0/results.png)

## Next Steps

Once your model is trained you can use your best checkpoint `best.pt` to:

- Run [CLI](https://github.com/ultralytics/yolov5#quick-start-examples) or [Python](https://github.com/ultralytics/yolov5/issues/36) inference on new images and videos
- [Validate](https://github.com/ultralytics/yolov5/blob/master/val.py) accuracy on train, val and test splits
- [Export](https://github.com/ultralytics/yolov5/issues/251) to TensorFlow, Keras, ONNX, TFlite, TF.js, CoreML and TensorRT formats
- [Evolve](https://github.com/ultralytics/yolov5/issues/607) hyperparameters to improve performance
- [Improve](https://docs.roboflow.com/adding-data/upload-api?ref=ultralytics) your model by sampling real-world images and adding them to your dataset

---
Documentation taken from: 
[GITHUB YOLOv5 PIPELINE](https://github.com/ultralytics/yolov5/wiki/Train-Custom-Data#train-on-custom-data)