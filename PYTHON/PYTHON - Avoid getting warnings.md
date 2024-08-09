#ML #PYTHON 
#### DEACTIVATE WARNINGS 

Some functions that shows some warnings in console and blur the correct data. 

To avoid this, this kind of functions has a parameter called verbose. 
Setting this parameter to 0 avoid getting warning printed

Example:  

```PYTHON 
	scores = cross_val_score(model_fit, X_train, Y_train, cv=kfold, scoring='precision_weighted',verbose = 0)
	print(str(scores))
```


After that, the output was: 

>WARNING:tensorflow:Detecting that an object or model or tf.train.Checkpoint is being deleted with unrestored values. See the following logs for the specific values in question. To silence these warnings, use `status.expect_partial()`. See [https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor](https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor) details about the status object returned by the restore function. WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.count WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.count WARNING:tensorflow:Detecting that an object or model or tf.train.Checkpoint is being deleted with unrestored values. See the following logs for the specific values in question. To silence these warnings, use `status.expect_partial()`. See [https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor](https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor) details about the status object returned by the restore function. WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.count WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.count WARNING:tensorflow:Detecting that an object or model or tf.train.Checkpoint is being deleted with unrestored values. See the following logs for the specific values in question. To silence these warnings, use `status.expect_partial()`. See [https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor](https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor) details about the status object returned by the restore function. WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.count WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.count WARNING:tensorflow:Detecting that an object or model or tf.train.Checkpoint is being deleted with unrestored values. See the following logs for the specific values in question. To silence these warnings, use `status.expect_partial()`. See [https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor](https://www.tensorflow.org/api_docs/python/tf/train/Checkpoint#restorefor) details about the status object returned by the restore function. WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.0.count WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.total WARNING:tensorflow:Value in checkpoint could not be found in the restored object: (root).keras_api.metrics.1.count /usr/local/lib/python3.10/dist-packages/sklearn/metrics/_classification.py:1344: UndefinedMetricWarning: Precision is ill-defined and being set to 0.0 in labels with no predicted samples. Use `zero_division` parameter to control this behavior. _warn_prf(average, modifier, msg_start, len(result))


Now it is: 

>F1 values: [0.61231626 0.65717348 0.60758295]


