#ML 

Depending on the type of algorithm used, different metrics are more relevant than others to analyze the model performance. 
### <span style="color:cyan;">Evaluation of classification models</span>

`CONFUSION MATRIX`

Gives us a matrix as output that describes the output of the models prediction placed in the correct hole. 

It shows values in: 
* (TP) True positive and (TN) True negative correct labeled values
* (FN) False negative and (FP) False positive, wrongly labeled as negative or positive. 

![[confusion-matrix.png|400]]

This table can be generalized for multiclass models: 

 * True labels placed in diagonal and signal correctly labeled samples in testing
 * False labels rest of the table and indicated the wrongly labeled and the original one. 

`PRECISION`

How precise is the model by taking into account the predicted positives and how many of them are really positives

$Precision = \frac{TP}{TP+FP} = \frac{True Positives}{Total Predicted Positives}$


`RECALL (Sensitivity, True Positive Rate)`

Recall measures the ability of a model to capture all the relevant examples in the dataset.

$Recall = \frac{TP}{TP+FN} = \frac{True Positives}{Total Actual Positives}$

`F1 SCORE`

The F1 Score is the harmonic mean of precision and recall, providing a balanced measure.

$F1 Score = \frac{2 \times Precision \times Recall}{Precision + Recall}$

`ACCURACY`

Accuracy measures the overall correctness of the model predictions.

$Accuracy = \frac{TP+TN}{TP+TN+FP+FN} = \frac{CorrectLabeledSamples}{TotalNumberSamples}$


`SPECIFICITY (True Negative Rate)`

Specificity measures the ability of a model to correctly identify negative examples.

$Specificity = \frac{TN}{TN+FP} = \frac{True Negatives}{Total Actual Negatives}$


`FALSE POSITIVE RATE (FPR)`

FPR measures the proportion of actual negatives that are incorrectly classified as positives.

$FPR = \frac{FP}{TN+FP} = \frac{False Positives}{Total Actual Negatives}$


`AUC-ROC (Area Under the Receiver Operating Characteristic curve)`

AUC-ROC provides an aggregate measure of a model's performance across various classification thresholds.


`AUC-PR (Area Under the Precision-Recall curve)`

Similar to AUC-ROC, AUC-PR summarizes the precision-recall trade-off across different threshold values.


`MATTHEWS CORRELATION COEFFICIENT (MCC)`
MCC takes into account true and false positives and negatives, providing a balanced measure even for imbalanced datasets.

$MCC = \frac{TP \times TN - FP \times FN}{\sqrt{(TP+FP)(TP+FN)(TN+FP)(TN+FN)}}$

### <span style="color:cyan;">Evaluation of regression models</span>

`MEAN ABSOLUTE ERROR (MAE)`

MAE measures the average absolute difference between predicted and actual values.

$MAE = \frac{1}{n}\sum_{i=1}^{n}|y_i - \hat{y}_i|$


`MEAN SQUARED ERROR (MSE)`

MSE measures the average squared difference between predicted and actual values.

$MSE = \frac{1}{n}\sum_{i=1}^{n}(y_i - \hat{y}_i)^2$

`ROOT MEAN SQUARED ERROR (RMSE)`

RMSE is the square root of MSE and provides the standard deviation of the residuals.

$RMSE = \sqrt{MSE}$

`R-SQUARED (R2)`

R-squared measures the proportion of the variance in the dependent variable that is predictable from the independent variables.

$R^2 = 1 - \frac{SS_{res}}{SS_{tot}}$

where $SS_{res}$ is the sum of squared residuals, and $SS_{tot}$ is the total sum of squares.

`MEAN PERCENTAGE ERROR (MPE)`

MPE measures the percentage difference between predicted and actual values.

$MPE = \frac{1}{n}\sum_{i=1}^{n}\frac{y_i - \hat{y}_i}{y_i} \times 100$

`MEDIAN ABSOLUTE ERROR (MedAE)`

MedAE measures the median absolute difference between predicted and actual values.

$MedAE = \text{median}(|y_i - \hat{y}_i|)$

`HUBER LOSS`

Huber loss is less sensitive to outliers than MSE and combines characteristics of both MAE and MSE.

$H_{\delta}(r) = \begin{cases} \frac{1}{2}r^2 & \text{for } |r| \leq \delta \ \delta(|r| - \frac{1}{2}\delta) & \text{otherwise} \end{cases}$

`EXPLAINED VARIANCE SCORE`

Explained Variance Score measures the proportion of variance in the dependent variable explained by the model.

$Explained Variance = 1 - \frac{Var(y - \hat{y})}{Var(y)}$