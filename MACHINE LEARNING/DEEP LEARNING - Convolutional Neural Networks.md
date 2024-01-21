#ML 

Convolutional Neural networks or CNNs were primarily designed for image data. 

CNNS use a <span style="color:MediumPurple;">convolutional operator</span> for extracting data features. 
* Allows parameters sharing 
* Efficient to train
* Have less parameters than NNs with fully-connected layers. 
CNNs are <span style="color:MediumPurple;">robust to spatial translations</span> of objects in images. 

When a <span style="color:orange;">convolutional filter</span> is scanned over the image, captures useful features like <span style="color:#ababf5;">edge detections by convolutions</span>

![[cnns-edge-detection.png|400]]

`CONVOLUTIONAL LAYER`

Performs the main computations. Preserves spatial relationship between pixels by learning features within small squares of the data. Each point in the matrix computes a **dot product** between the matrix value and a kernel value. 

`MAX-POOLING LAYER`

Also know as downsampling, serve to reduce the dimensionality of each layer. Its done by: 
1. `Max Pooling:` It selects the pixel with the maximum value to send to the output array.
2. `Average pooling:` It calculates the average value within the receptive field to send to the output array.
![[max-pooling-layer.webp]]

`FULLY CONNECTED LAYER`

A layer that consist in all neurons connected. Combine and transforms all this high level features into the final output. 

`SOFTMAX ACTIVATION LAYER`

This layer with each input connected to an output with a softmax function calculated for each input, select the most probable output of the inputs. 

![[softmax-function.png|200]]


In this example of input layer - hidden layers and an output layer, each 2 convolutional layer, a <span style="color:MediumPurple;">max-pooling</span> reduces the size of the feature maps (typically by 2)
A fully convolutional and a <span style="color:MediumPurple;">softmax</span> layers are added last to perform classification. 



![[diagram-cnn.png]]

