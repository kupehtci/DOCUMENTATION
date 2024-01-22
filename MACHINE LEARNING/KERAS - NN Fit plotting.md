#### Neural Network plotting the fit 


You can plot the fitting measures in the different epochs.

When called to `model.fit()` a history can be captured: 

```PYTHON
	#Model buil

model = build_model()

history = model.fit(x=X_train, y=Y_cat, epochs=epochs_value, batch_size=batches_value, verbose = 0)


print(history.history.keys())

  

plt.plot(history.history['accuracy'])

#plt.plot(record.history['val_accuracy'])

plt.title('model accuracy')

plt.ylabel('accuracy')

plt.xlabel('epoch')

plt.legend(['train', 'test'], loc='upper left')

plt.show()

  

plt.plot(history.history['loss'])

#plt.plot(record.history['val_loss'])

plt.title('model loss')

plt.ylabel('loss')

plt.xlabel('epoch')

plt.legend(['train', 'test'], loc='upper left')

plt.show()
```

They can be plotted together but dont have the same value scale and range so the graphic is not as expressive as independent one are

![[acuraccy and loss plot together.png]]