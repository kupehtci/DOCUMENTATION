
### TYPES OF ACTIVATION

#### SOFTMAX

Before exploring the ins and outs of the <span style="color:orange;">Softmax activation function</span>, we should focus on its building block—the <span style="color:orange;">sigmoid/logistic activation function</span> that works on calculating probability values.
![[probability_calculation.jpg]]

The output of the sigmoid function was in the range of 0 to 1, which can be thought of as probability.   

But, This function faces certain problems.  

Let’s suppose we have five output values of 0.8, 0.9, 0.7, 0.8, and 0.6, respectively. How can we move decide an output. 

The above values don’t make sense as the sum of all the classes/output probabilities should be equal to 1.   

You see, the Softmax function is described as a combination of multiple sigmoids.   

It calculates the relative probabilities. Similar to the sigmoid/logistic activation function, the SoftMax function returns the probability of each class.   

It is most commonly used as an activation function for the last layer of the neural network in the case of multi-class classification.   

Mathematically it can be represented as:

![[softmax_equation.jpg]]

Let’s go over a simple example together.

Assume that you have three classes, meaning that there would be three neurons in the output layer. Now, suppose that your output from the neurons is [1.8, 0.9, 0.68].

Applying the softmax function over these values to give a probabilistic view will result in the following outcome: [0.58, 0.23, 0.19]. 

The function returns 1 for the largest probability index while it returns 0 for the other two array indexes. Here, giving full weight to index 0 and no weight to index 1 and index 2. So the output would be the class corresponding to the 1st neuron(index 0) out of three.

You can see now how softmax activation function make things easy for multi-class classification problems.