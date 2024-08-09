#ML #PYTHON #GRADIO

## How to create a <span style="color:orange;">GRADIO</span> interface 

Now that we have our predictive function set up, we can create a Gradio Interface around it.

In this case, the input component is a drag-and-drop image component. To create this input, we can use the `"gradio.inputs.Image"` class, which creates the component and handles the preprocessing to convert that to a numpy array. We will instantiate the class with a parameter that automatically preprocesses the input image to be 224 pixels by 224 pixels, which is the size that MobileNet expects.

The output component will be a `"label"`, which displays the top labels in a nice form. Since we don’t want to show all 1,000 class labels, we will customize it to show only the top 3 images.

Finally, we’ll add one more parameter, the `examples`, which allows us to prepopulate our interfaces with a few predefined examples. The code for Gradio looks like this:

```PYTHON
import gradio as gr

gr.Interface(fn=classify_image,
             inputs=gr.Image(shape=(224, 224)),
             outputs=gr.Label(num_top_classes=3),
             examples=["banana.jpg", "car.jpg"]).launch()
```

This produces the following interface, which you can try right here in your browser (try uploading your own examples!):

---

And you’re done! That’s all the code you need to build a web demo for an image classifier. If you’d like to share with others, try setting `share=True` when you `launch()` the Interface!

To see how to import <span style="color:MediumSpringGreen;">GRADIO</span>: [[PYTHON - Imports]]

