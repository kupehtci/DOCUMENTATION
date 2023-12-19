#ANDROID #PYTHON #ML 

# Convert Pytorch (.pt) model file to TFLite (.tflite)

The current ultralytics yolov5 Github repo (by 30 Oct 2021) does not support this conversion for object detection model that is able to add metadata and used on android later.

The reason is YOLOv5 exported models generally concatenate outputs into a single output. TFLite models do not export with NMS, only TF.js and pipelined CoreML models contains NMS.

You can see more details of all the limitations and experiments in this [discussion.](https://github.com/ultralytics/yolov5/discussions/2095) However, there are still some options you can export TFLite that works on Android:

- TFLite model without NMS ([tf-android](https://github.com/zldrobit/yolov5/tree/tf-android) branch)
- TFLite model with NMS but only works on CPU, no GPU acceleration ([tf-android-flex-ops-class-agnostic-nms](https://github.com/zldrobit/yolov5/tree/tf-android-flex-ops-class-agnostic-nms) branch)

In my Github repo, I have incorporated the second option, TFLite with NMS, which you can export a TFLite model using the command below:

```PYTHON
python export.py --weights best.pt --include tflite --tf-nms --agnostic-nms
```

You would have an output tensor of dimension as follows ([source](https://tensorflow.google.cn/lite/inference_with_metadata/task_library/object_detector#model_compatibility_requirements)):

Four Outputs

- **detection_boxes**: a float32 tensor of shape [1, num_boxes, 4] with box locations
- **detection_classes**: a float32 tensor of shape [1, num_boxes] with class indices
- **detection_scores**: a float32 tensor of shape [1, num_boxes] with class scores
- **num_boxes**: a float32 tensor of size 1 containing the number of detected boxes

# Metadata Writer

I provided two versions of Metadata writer in my Github repo which

- V1 attaches the model default name and description
- V2 allows you to specify your model name and description

1. The **first version** is from [TensorFlow metadata writer tutorial](https://tensorflow.google.cn/lite/convert/metadata_writer_tutorial#object_detectors), it attaches the default name and description as below.

```YAML
"name": "ObjectDetector",  
"description": "Identify which of a known set of objects might be present and provide information about their positions within the given image or a video stream."
```

Start generating the metadata by specifying the following arguments:

- `-- model_file`: TFLite model
- `--label_file`: A text file that lists the labels

Example:

python metadata_writer_v1.py --model_file best-fp16.tflite --label_file labels.txt

2. If you want to change the model name and description, you can use the **second version** `metadata_writer_v2.py`.

Update the following in the python file according to your model details.

# Your model details here  

```YAML
model_path = ‘best-fp16.tflite’  
label_path = ‘labels.txt’  
model_meta.name = “Model name”  
model_meta.description = (  
“decription line …”  
“decription line …”  
)
```

Then, generate the TFLite with metadata:

```PYTHON
	python metadata_writer_v2.py
```

# Detection

You already have a TFLite model to put in your android app! Check out the [Android quickstart tutorial](https://tensorflow.google.cn/lite/guide/android) by Tensoflow to deploy it.

# Github

You can find the code all above at [this site](https://github.com/hansheng0512/yolov5-tflite.git).