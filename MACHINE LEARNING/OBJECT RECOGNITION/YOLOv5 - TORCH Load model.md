#ML #OBJECT_RECOGNITION #PYTHON 

You can load you local model that was previously calculated via: 

```PYTHON
python train.py --data 'data.yaml' --name 'detrection' --proyect 'ex1' --cache 
```

Would generate the resultant weights in <span style="color:#ababf5;">./detrection/ex/</span>  in a folder called   <span style="color:#ababf5;">weights/</span>. called `best.pt`

You can load this weights into torch for using a model variable as: 

```PYTHON
import torch
model = torch.hub.load('.', 'custom', path='/path/to/yolov5/runs/train/exp5/weights/best.pt', source='local') 

img = '/path/to/test/image/25.jpg'
# Inference
results = model(img)

# Results, change the flowing to: results.show()
results.show()  # or .show(), .save(), .crop(), .pandas(), etc
```