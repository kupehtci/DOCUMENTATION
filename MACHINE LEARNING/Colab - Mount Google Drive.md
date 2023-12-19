#PYTHON #ML 

To mount the google drive in <span style="color:#ababf5;">google colab</span> you need to: 
* import drive dependencies from google.colab 
* Mount the drive for being able to load data from there

```python 

import sys

from google.colab import drive

  
drive.mount('/content/drive')

%cd "/content/drive/My Drive/Colab Notebooks/data_preparation_files/"

%pwd

%ls -alrt

sys.path.append("/content/drive/My Drive/Colab Notebooks/")
```


Once you have the desired path mounted you can load data placed in that path: 

```PYTHON 
df = pd.read_csv('DataPreparation1_file1.csv',index_col=0)

print(df)
```

