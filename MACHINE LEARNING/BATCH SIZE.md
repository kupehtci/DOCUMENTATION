#ML #DEEP_LEARNING #PYTHON 

## BATCH SIZE DEFINITION 

  
Batch size is a parameter that controls how many number of samples need to go through some layers before the model's internal parameters are rebalanced.

At the end of a batch, an error is calculated and model is recalculated for improve its performance. This could lead into more performance but more time to compile each model.

The <span style="color:orange;">batch size</span> is a number of samples processed before the model is updated.
The <span style="color:orange;">number of epochs</span> is the number of complete passes through the training dataset.

### BATCH SIZE DECISION 

1  <  batch_size  <  number samples in dataset

### COMPARISON WITH EPOCHS 

The number of epochs can be set to an integer value between one and infinity. You can run the algorithm for as long as you like and even stop it using other criteria besides a fixed number of epochs, such as a change (or lack of change) in model error over time.

They are both integer values and they are both hyper-parameters for the learning algorithm. 

You must specify the batch size and number of epochs for a learning algorithm.
There are no magic rules for how to configure these parameters. You must try different values and see what works best for your problem.