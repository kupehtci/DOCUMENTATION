#PYTHON #COLLAB 

## CONNECT GOOGLE DRIVE 

You can connect your google drive folders to Collab environment by using drive module from `google.colab`. 

```PYTHON
import sys
from google.colab import drive


drive.mount('/content/drive')
import os
%cd "/content/drive/My Drive/Colab Notebooks/YOLOOBJ/mData/yolov5"
%ls
print(os.getcwd())
```

## ENVIRONMENT

You can get environment specifications by executing `nvidia-smi` command. 
```PYTHON 
!nvidia-smi
```

This will print the specs of the Environment this way: 

![[nvidia-smi-collab-environment.png]]

## EXECUTE COMMANDS

In google colaboratory you use an environment, something similar to a <span style="color:orange">docker</span>. 
You can execute <span style="color:orange;">bash</span> commands by writing `!` before the statement: 

```PYTHON
!cd folder/file.txt 
!pip install gradio
```