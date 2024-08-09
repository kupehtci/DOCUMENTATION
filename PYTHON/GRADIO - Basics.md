#GRADIO #PYTHON 

## WHAT IS GRADIO? 

One of the _best ways to share_ your machine learning model, API, or data science workflow with others is to create an <span style="color:orange;">interactive app</span> that allows your users or colleagues to try out the demo in their browsers.

Gradio allows you to <span style="color:LightPink;">build demos and share them</span>, all in Python.** And usually in just a few lines of code! So let’s get started. 
## Hello, World

To get Gradio running with a simple “Hello, World” example, follow these three steps:

1. Install Gradio using pip:

```
pip install gradio
```

2. Run the code below as a Python script or in a Jupyter Notebook (or [Google Colab](https://colab.research.google.com/drive/18ODkJvyxHutTN0P5APWyGFO_xwNcgHDZ?usp=sharing)):

```PYTHON
import gradio as gr

def greet(name):
    return "Hello " + name + "!"

demo = gr.Interface(fn=greet, inputs="text", outputs="text")
    
if __name__ == "__main__":
    demo.launch(show_api=False)   
```

We shorten the imported name to `gr` for better readability of code using Gradio. This is a widely adopted convention that you should follow so that anyone working with your code can easily understand it.

![[gradio_basic_interface.png]]

When developing locally, if you want to run the code as a Python script, you can use the Gradio CLI to launch the application **in reload mode**, which will provide seamless and fast development. Learn more about reloading in the [Auto-Reloading Guide](https://gradio.app/developing-faster-with-reload-mode/).

## The `Interface` Class

To be able to build the demo, we created a `gr.Interface`. This `Interface` class can wrap any Python function with a user interface. In the example above, we saw a simple text-based function, but the function could be anything from music generator to a tax calculator to the prediction function of a pretrained machine learning model.

The core `Interface` class is initialized with three required parameters:

- `fn`: the function to wrap a UI around
- `inputs`: which component(s) to use for the input (e.g. `"text"`, `"image"` or `"audio"`)
- `outputs`: which component(s) to use for the output (e.g. `"text"`, `"image"` or `"label"`)

Let’s take a closer look at these components used to provide input and output.

## Components Attributes

We saw some simple `Textbox` components in the previous examples, but what if you want to change how the UI components look or behave?

Let’s say you want to customize the input text field — for example, you wanted it to be larger and have a text placeholder. If we use the actual class for `Textbox` instead of using the string shortcut, you have access to much more customizability through component attributes.

```PYTHON
import gradio as gr

def greet(name):
    return "Hello " + name + "!"

demo = gr.Interface(
    fn=greet,
    inputs=gr.Textbox(lines=2, placeholder="Name Here..."),
    outputs="text",
)
demo.launch()
```
## Inputs and Outputs

Inputs can be defined by a tag that only specify the type of input or output like: 

```PYTHON
gr.Interface(fn=test, input="image", output="image"); 
```

Or input and output can be defined using gradio classes: 

```PYTHON
# Image definition
inputs = gr.Image(type='pil', label="Original Image")
outputs = gr.Image(type='pil', label="Output Image")

# Text definition
inputs=gr.Textbox(lines=2, placeholder="Name Here...")
```

Image defines an image input and TextBox ask for a text input with a placeholder. 

## Processing 

The function `fn`that its specified in the `gr.Interface(fn = )` gets processed, passing it the given input to Gradio and needs to return the same output as the defined by Gradio: 

For example with a textbox, the function can add some lines or modify the text like in the first example. 

## Machine learning using YOLO

An example of how to use YOLO to validate images with an interface created with <span style="color:orange;">gradio</span>. 
In this code, a yolo model is loaded using torch to use it to validate the input image. 

Firstly the function, resizes the image and then is infered by the model. Then the result is passed as the output. 

```PYTHON
import gradio as gr

	def yolo(im, size=640):
	gain = (size / max(im.size)) # gain
	im = im.resize((int(x * gain) for x in im.size), Image.ANTIALIAS) 
	model = torch.hub.load('.', 'custom', path='/content/drive/MyDrive/Colab Notebooks/YOLOOBJ/mData/yolov5/mushrooms2/ex/weights/best.pt', source='local')
	results = model(im) # inference
	results.render() # updates results.imgs with boxes and labels
	return Image.fromarray(results.ims[0])

  
  

inputs = gr.Image(type='pil', label="Original Image")
outputs = gr.Image(type='pil', label="Output Image")

  

title = "YOLOv5 MUSHROOM DETECTION"

description = "YOLOv5 USJ Gradio to see mushroom detection between CoW and chanterelle mushrooms. Upload an image or click an example image to use."

article = "<p></p>"

  
  

gr.Interface(yolo, inputs, outputs, title=title, description=description, article=article, analytics_enabled=True).launch(debug=True,share = True)
```