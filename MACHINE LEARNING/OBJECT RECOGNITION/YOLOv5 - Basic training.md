#ML #DEEP_LEARNING #PYTHON 
# Train custom Yolov5 model

As an example, let’s use this public dataset from roboflow, [North American Mushrooms Dataset](https://public.roboflow.com/object-detection/na-mushrooms/1/download/yolov5pytorch) (Yolov5 Pytorch version). Unzip and place the folder under `data/` folder of `yolov5` folder. For simplicity, let’s rename <span style="color:cyan;">North American Mushrooms.v1-416x416.yolov5pytorch/</span> to <span style="color:cyan;">sample/</span>. 

![](https://miro.medium.com/v2/resize:fit:1328/1*Jy-u15PXvlBwHU7kFVc5Aw.png)

If you are annotating the images yourself, check out [ultralytics Train-Custom-Data](https://github.com/ultralytics/yolov5/wiki/Train-Custom-Data) to prepare your data and labels by using <span style="color:orange; text-decoration: underline; ">RoboFlow</span>. 

Remember to change the config according to your dataset in the `.ymal` file.
Note about how to edit the <span style="color:#ababf5;">configuration files</span>.      [[YOLOv5 - Configuration Files]]
If you are using the mushroom dataset, replace the content in `data.ymal` file:

<span style="border-radius:0.5rem; padding:0.2rem; margin-bottom: 0.3rem; background-color:#090909;color:grey;">`data.yaml`: </span>
```yaml
path: data/sample  
train: train/images  
val: valid/images  
test: test/images

nc: 2  
names: ['CoW', 'chanterelle']

```
#### Start training

Start your training by specifying the following arguments:

- `--img`: image size
- `--batch`: batch size
- `--epochs`: epochs number
- `--data`: dataset `.yaml` files which list the config
- `--weights yolov5s.pt`: pretrained weights (recommended)
- or `--weights '' --cfg yolov5s.yaml`: randomly initialized

Example:

```python
python train.py --img 640 --batch 16 --epochs 300 --data sample/data.yaml --weights yolov5s.pt
```

Training parameters: 
- weights — path to initial weights. COCO model will be downloaded automatically.
- freeze — number of layers to freeze
- project— name of the project
- name — name of the run

To train without using weights see <span style="color:orange;"> Training from scratch</span>. [[YOLOv5 - Training from scratch]]

Your train results will be saved at `runs/train/exp<no.>` . You can find your best and last weights under `weights/`inside the folder.

Let’s move the Pytorch model file (Eg. `best.pt`) ou want to convert to TFLite model to the root folder (`yolov5/`).