#PYTHON #GRADIO

The `gradio.inputs` and `gradio.outputs` modules have been deprecated.

We don't recommend you use them on new apps although they are still in the library as of version 3.1.

From now on, you should use the components defined in the the gradio module. These are the components listed in the [docs](https://gradio.app/docs/#components).

The following table shows how transition to the recommended API, you just have to remove `.outputs.` or `.inputs.` from your code!

|Deprecated API|Recommended API|
|---|---|
|gr.inputs.Image|gr.Image|
|gr.outputs.Label|gr.Label|

Thank you for using gradio and enjoy the fewer character you have to type now 😎
