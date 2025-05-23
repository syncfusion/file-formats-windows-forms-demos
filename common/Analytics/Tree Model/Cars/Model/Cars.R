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
# install.packages("rpart")
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("caret")

# Load below packages
library(rpart)
library(pmml)
library(gmodels)
library(caret) # This package is specifically loaded for cars dataset shipped within it.

# Here we directly load the cars dataset installed with the "caret" package.
data(cars)

# rename column names in cars dataset from caret package
carsOriginal <- setNames(cars, c("Price", "Mileage", "Cylinder", "Doors", "Cruise", "Sound", "Leather", "Buick", "Cadillac", "Chevy", "Pontiac", "Saab", "Saturn", 
"Convertible", "Coupe", "Hatchback", "Sedan", "Wagon"))

# Omit rows with missing values
carsOriginal <- na.omit(carsOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# cars<- read.csv("Cars.csv")

# Randomizing data
cars<-carsOriginal[sample(nrow(carsOriginal)),]

# Divide dataset for training and test
carsTrain <- cars[1:643, ]
carsTest <- cars[644:804, ]

# Applying TreeModel
carsModel <- rpart( Price ~ ., data = carsTrain)
carsModel 

# Display the predicted results
# Predict "Price" column for test data set
carsTestPrediction<- predict(carsModel ,carsTest)
# Display predicted values
carsTestPrediction

# PMML generation
carsPmml<- pmml(carsModel, data = carsTrain)
write (toString (carsPmml), file="Cars.pmml")
saveXML (carsPmml, file="Cars.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original cars data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Apply model to entire dataset and write the results in a csv file
carsEntirePrediction<- predict(carsModel ,carsOriginal)
carsEntirePrediction

# Save predicted value in a data frame
result = data.frame(carsEntirePrediction)
names(result) = c("Predicted_RetailPrice")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)



