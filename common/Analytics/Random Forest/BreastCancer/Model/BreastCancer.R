# Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
# Use of this code is subject to the terms of our license.
# A copy of the current license can be obtained at any time by e-mailing
# licensing@syncfusion.com. Any infringement will be prosecuted under
# applicable laws. 


# If you are not familiar with R you can obtain a quick introduction by downloading
# R Succinctly for free from Syncfusion - http://www.syncfusion.com/resources/techportal/ebooks/rsuccinctly
# R Succinctly is also included with this installation and is available here
# Installed Drive :\Program Files (x86)\Syncfusion\Essential Studio\XX.X.X.XX\Infrastructure\EBooks\R_Succintly.pdf OF R Succinctly
# Uncomment below lines to install necessary packages if not installed already
# install.packages("randomForest")
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("TH.data")
# install.packages("ROCR")
# install.packages("caret")
# install.packages("e1071")

# Load below packages
library(randomForest)
library(pmml)
library(gmodels)
library(TH.data)# This package is specifically loaded for BreastCancer dataset shipped within it.
library(ROCR)
library(caret)
library(e1071)

# Here we directly load the breastcancer dataset installed with the "TH.data" package.
data(GBSG2)

# rename column names in GBSG2 dataset from TH.data package
breastCancerOriginal <- setNames(GBSG2, c("Hormonal_Therapy", "Age", "Menopausal_Status", "Tumor_Size", "Tumor_Grade", "Positive_Nodes", "Progesterone", 
"Estrogen_Receptor", "Survival_Time", "Indicator"))

# Omit rows with missing values
breastCancerOriginal <- na.omit(breastCancerOriginal) 

# Code below demonstrates loading the same dataset from a CSV file  shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# breastCancer<- read.csv("BreastCancer.csv")

# Considering the integer variable as factor
breastCancerOriginal[, "Indicator"]=as.factor(breastCancerOriginal[, "Indicator"])
breastCancerOriginal$Tumor_Grade<-factor(breastCancerOriginal$Tumor_Grade, ordered = FALSE)

# Randomizing data
breastCancer<-breastCancerOriginal[sample(nrow(breastCancerOriginal)),]

# Divide dataset for training and test
trainData<-breastCancer[1:549,]
testData<-breastCancer[550:686,]

# Applying random forest function
breastcancer_RF<-randomForest(Indicator~.,data=trainData,ntree=50)
breastcancer_RF

# Display the predicted results and cross table for accuracy
# Predict "cens" column for test data set
breastCancerTestPrediction<-predict(breastcancer_RF,testData)
# Display predicted values
breastCancerTestPrediction

# Create cross table to check on accuracy
CrossTable(breastCancerTestPrediction,testData$Indicator,
           prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,
           dnn = c('actual', 'predicted'))

# Predict the Probabilities for test dataset
breastCancerTestProbabilities<-predict(breastcancer_RF,testData,type="prob")

# Generate ROC curve and calculate AUC value to predict the accuracy for BreastCancer test dataset
# To create visualizations - ROC curve with "ROCR" package two vectors of data are needed, 
# The first vector must contain the class values - cens column and
# The second vector must contain the estimated probability of the positive class(NonCensoredProbability)
pred <- prediction(labels = testData$Indicator, predictions = breastCancerTestProbabilities[,2])

# Using the perf performance object, we can visualize the ROC curve with R's plot() function
perf <- performance(pred, measure = "tpr", x.measure = "fpr")

# Plot the ROC curve for the visualization 
plot(perf, main = "ROC curve for BreastCancer Test Dataset", col = "blue", lwd = 3)

# To indicate reference line in the ROC plot
abline(a = 0, b = 1, lwd = 2, lty = 2)

# We can use the ROCR package to calculate the AUC(Area under the ROC Curve)
# To do so, we first need to create another performance object and specify measure = "auc", as shown in the following code:
perf.auc <- performance(pred, measure = "auc")

# perf.auc is an object (specifically known as an S4 object) we need to use a special type of notation to access the values stored within.
# S4 objects hold information in positions known as slots
# The str() function can be used to see all slots for an object
str(perf.auc)

# To access the AUC value, which is stored as a list in the y.values slot, we can use the @ notation along with the unlist() function, which simplifies lists to a vector of numeric values
# Below AUC value is under the "acceptable/fair" category 
unlist(perf.auc@y.values)

# View Specificity, Sensitivity and Accuracy information using confusionMatrix function from "caret" package
confusionMatrix(breastCancerTestPrediction,testData$Indicator, positive = "1")


# PMML Generation
pmmlFile<-pmml(breastcancer_RF,data=trainData)
write(toString(pmmlFile),file="BreastCancer.pmml")
saveXML(pmmlFile,file="BreastCancer.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original breastCancer data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Random Forest model to entire dataset and save the results in a CSV file
breastCancerEntirePrediction<-predict(breastcancer_RF,breastCancerOriginal)

# Predict probability value for entire dataset
Predicted_probabilities<-predict(breastcancer_RF,breastCancerOriginal,type="prob")

# Save predicted value and probabilities in a data frame
result = data.frame(breastCancerEntirePrediction,Predicted_probabilities)
names(result) = c("Predicted_censored","CensoredProbability","NonCensoredProbability")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)
