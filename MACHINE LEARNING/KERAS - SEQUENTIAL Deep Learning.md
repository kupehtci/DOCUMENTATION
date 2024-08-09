#KERAS #ML 
## INTRODUCTION

Keras models are defined as a sequence of layers.

We create a sequential model and add layers one at a time until we are satisfied with our network topology.

## SETUP

```PYTHON
	import keras from 
	from keras import layers
	from keras import ops
	
	from keras.models import Sequential
	from keras.layers import Dense
	
	import keras.models
	import keras.layers
```

## CREATE MODEL

A `Sequential` model is appropriate for **a plain stack of layers** where each layer has **exactly one input tensor and one output tensor**.

```PYTHON
	# create model
	model = Sequential()
```
You can specify the layers when creating the model or add them before. 

## INPUT LAYER

The first thing you should do is make sure that the input layer has the correct number of entries. This can be specified when creating the first layer with the argument input_dim and setting it to 8 for the 8 input variables.
```PYTHON
	# add layers
	model.add(Dense(12, input_dim=8, activation='relu'))
	model.add(Dense(15, activation='relu'))
	model.add(Dense(15, activation='relu'))
	model.add(Dense(1, activation='sigmoid'))
```

## DETERMINE NUMBER OF LAYERS

How do we know the number of layers and their types?

This is a very difficult question. There are heuristics that we can use and often the best network structure is found through a process of trial and error of experimentation. Generally, a network large enough to capture the structure of the problem is needed if that helps at all.

In this example, we will use a network structure fully connected with three layers.

You can check the number of **layers** by printing the length of the layers array: 
```PYTHON
	print(len(model.layers))
```


Fully connected layers are defined using the Dense class. We can specify the number of neurons in the layer as the first argument, the initialization method as the second argument as init and specify the activation function using the activation argument.

In this case, we initialize the weights of the network to a small random number generated from a uniform distribution ('uniform'), in this case between 0 and 0.05 because it is the initialization of uniform weight by default in Keras. Another traditional alternative would be "normal" for small random numbers generated from a Gaussian distribution.

We will use the activation function of the rectifier ('relu') in the first two layers and the sigmoid function in the output layer. Before, the sigmoid and tanh activation function used to be used. These days, better performance is achieved with the rectification activation function. We use a sigmoid in the output layer to ensure that the output of the network is between 0 and 1 and easy to assign to a class 1 probability or to fit a hard classification of any kind with a default threshold of 0.5.

We can put all together by adding each layer. The first layer has 12 neurons and expects 8 input variables. The second hidden layer has 8 neurons and finally, the output layer has 1 neuron to predict the class (onset of diabetes or not) or in case that its multiclass needs to have more neurons.

## FINAL LAYER 

The final layer need to have as much neurons as the posible resultant classes of the classification

## ANALYZE THE RESULT

Once the model is build, you can call `summary()` for analyze the model parameters: 
```PYTHON
	model.summary()
```


## COMPILE MODEL

Take into account that if you compile using for loss function "sparse_categorical_crossentropy" this will lead into an accepted output of \[0,n_neurons\).  Not including the last one. 

Once the layers are decided, we need to compile the resultant model.

Compilation will assign the weights to each independent neuron for the specified problem.

For the function, we need to specify some parameters:

-> **loss** this function calculates the error or deviation when calculating the model. I have choosen **categorical_crossentropy** because is a common use when dealing with classification problems with two or more output classes.


> I didnt use sparse_categorical_crossentropy or categorical_crossentropy because lead into error. This loss functions put the scope of the output into (0,6) making label 6 to be out of scope because the accepted values are 0 to 6 but not this last included.

-> **optimizer** is used for calibrating the input weights by comparing the prediction and the loss.

As we can see in this comparison between different Keras optimizers: [how to compare optimizers](https://wandb.ai/sauravm/Optimizers/reports/How-to-Compare-Keras-Optimizers-in-Tensorflow-for-Deep-Learning--VmlldzoxNjU1OTA4) the different optimizers have different performance.

We can see that if GPU and CPU usage is an important factor, **adagrad** its the best one, but taking into account that our dataset has less than 1000 instances, this is not an important fact.

Taking into consideration only the performance of the model, **nadam** has the best accuracy values when comparing all optimizers and the lowest loss.

  

-> **metrics** this is use for evaluating the performance of the model during the training. As said in the problem analysis section at the begin of the document, recall is the most important measure in the evaluation of this problem so the compilation is going to be done with that metric in evaluation part. For the compilation, accuracy is the metric selected.

```PYTHON
	model.compile(optimizer='nadam', loss='spare_categorical_crossentropy', metrics=['accuracy'])
```

